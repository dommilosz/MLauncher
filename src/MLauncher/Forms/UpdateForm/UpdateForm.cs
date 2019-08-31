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
        bytesconvert update_size;
        int _speed_last_perc = 0;
        bytesconvert speed;

        public UpdateForm(GitHubRelease release, Configuration configuration, LauncherForm f)
        {

            rls = release;
            _configuration = configuration;
            InitializeComponent();
            LoadLocalization();

            update_url = new Uri(@"https://github.com/dommilosz/MLauncher/releases/download/" + rls.Tag + "/MLauncher.exe");
            newpatch = Application.ExecutablePath.Replace(".exe", "_" + rls.Tag + ".exe");
            update_size = GetUpdateSize();
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
            string exec = Application.ExecutablePath.Replace(Application.StartupPath, "");
            string execnew = newpatch.Replace(Application.StartupPath, "");
            exec = exec.TrimStart(@"\".ToCharArray()[0]);
            execnew = execnew.TrimStart(@"\".ToCharArray()[0]);
            WebClient w = new WebClient();
            w.DownloadProgressChanged += (s, e) =>
            {
                try
                {
                    StatusBar.Value1 = e.ProgressPercentage;
                }
                catch { }
                StatusBar.Text = $"Downloading    {Math.Round((Convert.ToDouble(e.ProgressPercentage) / 100) * update_size.MB, 2)}/{update_size.MB} MB       ";
                if (speed.Kb <= 1000) StatusBar.Text += $"{speed.Kb} Kb/s";
                if (speed.Kb > 1000) StatusBar.Text += $"{speed.Mb} Mb/s";
            };
            w.DownloadFileCompleted += (s, e) =>
            {
                w.DownloadFile(@"https://github.com/dommilosz/MLauncher/releases/download/v0.2.0/Update.bat", Application.StartupPath + "Update.bat");
                Process.Start(Application.StartupPath + "Update.bat", "\"" + execnew + "\" \"" + exec + "\"");
                Application.Exit();
            };
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
            int speed_prc = StatusBar.Value1 - _speed_last_perc;
            _speed_last_perc = StatusBar.Value1;
            long bytespertick = Convert.ToInt64(Math.Round((Convert.ToDouble(speed_prc) / 100) * update_size.B, 0));
            speed = new bytesconvert(bytespertick * 4);
        }
    }
}