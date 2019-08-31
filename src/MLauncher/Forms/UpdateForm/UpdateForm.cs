using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace MLauncher.Forms
{
    public partial class UpdateForm : Telerik.WinControls.UI.RadForm
    {
        private Configuration _configuration { get; }
        GitHubRelease rls;
        LauncherForm form;
        Uri update_url;
        string newpatch;
        Uri batchURL;
        bytesconvert update_size;
        int _speed_last_perc = 0;
        bytesconvert speed;
        int _speed_ticks = 0;

        public UpdateForm(GitHubRelease release, Configuration configuration, LauncherForm f)
        {

            rls = release;
            _configuration = configuration;
            InitializeComponent();
            LoadLocalization();
            update_url = new Uri(@"https://github.com/dommilosz/MLauncher/releases/download/" + rls.Tag + "/MLauncher.exe");
            newpatch = Application.ExecutablePath.Replace(".exe", "_" + rls.Tag + ".exe");
            update_size = GetUpdateSize();
            batchURL = new Uri(@"https://github.com/dommilosz/MLauncher/releases/download/v0.2.0/Update.bat");
            autocheckCheckBox.Checked = _configuration.ApplicationConfiguration.CheckLauncherUpdates;
            Text = $"Found update: {release.Name}";

            changelogBox.Text = $"Installed Version : {Application.ProductVersion}" + Environment.NewLine;
            changelogBox.Text += $"Latest Version : {rls.Tag}" + Environment.NewLine;
            changelogBox.Text += $"Update Size : {update_size.MB}MB  ({update_size.B} bytes)" + Environment.NewLine;
            changelogBox.Text += $"{release.Description}";
            form = f;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/dedepete/MLauncher/releases/latest");
        }

        private void LoadLocalization()
        {
            ApplicationLocalization localization = _configuration.Localization;

            cancelButton.Text = localization.Cancel;
            autocheckCheckBox.Text = localization.CheckUpdatesCheckBox;
            goButton.Text = localization.GoToGitHub;
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            cancelButton.Enabled = false;
            radButton1.Enabled = false;
            autocheckCheckBox.Enabled = false;
            StatusBar.Visible = true;
            Thread t = new Thread(DownloadUpdates);
            t.Start();
        }

        public bytesconvert GetUpdateSize()
        {
            WebClient client = new WebClient();
            client.OpenRead(update_url);
            long b = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);

            return new bytesconvert(b);
        }

        public void DownloadUpdates()
        {
            void AppendLOG(string str)
            {
                if (changelogBox.InvokeRequired)
                    changelogBox.Invoke(new Action<string>(AppendLOG), str);
                else
                    changelogBox.AppendText(str);
            }
            void SetProgress(int value)
            {
                if (StatusBar.InvokeRequired)
                    StatusBar.Invoke(new Action<int>(SetProgress), value);
                else
                    StatusBar.Value1 = value;
            }
            void SetStatusText(string str)
            {
                if (StatusBar.InvokeRequired)
                    StatusBar.Invoke(new Action<string>(SetStatusText), str);
                else
                    StatusBar.Text = str;
            }
            void AppStatusText(string str)
            {
                str = StatusBar.Text + str;
                SetStatusText(str);
            }

            string exec = Application.ExecutablePath.Replace(Application.StartupPath, "");
            string execnew = newpatch.Replace(Application.StartupPath, "");
            exec = exec.TrimStart(@"\".ToCharArray()[0]);
            execnew = execnew.TrimStart(@"\".ToCharArray()[0]);
            WebClient w = new WebClient();
            w.DownloadProgressChanged += (s, e) =>
            {
                string form_speed = "";
                if (speed.Kb >= 1024) form_speed = ($"{speed.Mb} Mb/s"); else form_speed = ($"{speed.Kb} Kb/s");
                SetProgress(e.ProgressPercentage);
                SetStatusText($"Downloading    {Math.Round((Convert.ToDouble(e.ProgressPercentage) / 100) * update_size.MB, 2)}/{update_size.MB} MB       {form_speed}");
            };
            w.DownloadFileCompleted += (s, e) =>
            {
                int download_time = (_speed_ticks * 4);
                bytesconvert speed = new bytesconvert((update_size.b) / download_time);
                string speed_form = "";
                if (speed.Kb >= 1024) speed_form = $"{speed.Mb} Mb/s"; else speed_form = $"{speed.Kb} Kb/s";
                AppendLOG(Environment.NewLine + $"Average Download Speed : {speed_form}");
                string args = "\"" + execnew + "\" \"" + exec + "\"";
                AppendLOG(Environment.NewLine + $"Downloading Update Installer From : {batchURL}");
                w.DownloadFile(batchURL, Application.StartupPath + "Update.bat");
                AppendLOG(Environment.NewLine + $"Starting Installer : Update.bat WITH ARGS : {args}");
                Thread.Sleep(2000);
                Process.Start(Application.StartupPath + "Update.bat", args);
                Application.Exit();
            };
            AppendLOG(Environment.NewLine + $"Downloading Update From : {update_url}");
            w.DownloadFileAsync(update_url, newpatch);
        }

        public class bytesconvert
        {
            public long b { get; private set; }
            public long B { get; private set; }
            public float KB { get; private set; }
            public float MB { get; private set; }
            public float Kb { get; private set; }
            public float Mb { get; private set; }

            public bytesconvert(long B)
            {
                this.B = B;
                KB = (float)(Math.Round(Convert.ToDouble(B) / 1024, 2));
                MB = (float)(Math.Round(Convert.ToDouble(KB) / 1024, 2));

                b = B * 8;
                Kb = KB * 8;
                Mb = MB * 8;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            _speed_ticks++;
            int speed_prc = StatusBar.Value1 - _speed_last_perc;
            _speed_last_perc = StatusBar.Value1;
            long bytespertick = Convert.ToInt64(Math.Round((Convert.ToDouble(speed_prc) / 100) * update_size.B, 0));
            speed = new bytesconvert(bytespertick * 4);
        }
    }
}