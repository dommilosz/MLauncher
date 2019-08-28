using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MLauncher.Forms
{
    public partial class UpdateForm : Telerik.WinControls.UI.RadForm
    {
        private Configuration _configuration { get; }
        GitHubRelease rls;
        LauncherForm form;

        public UpdateForm(GitHubRelease release, Configuration configuration,LauncherForm f)
        {
            rls = release;
            _configuration = configuration;
            InitializeComponent();
            LoadLocalization();
            autocheckCheckBox.Checked = _configuration.ApplicationConfiguration.CheckLauncherUpdates;
            Text = $"Found update: {release.Name}";
            changelogBox.Text = $"{release.Description}";
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
            string newpatch = Application.ExecutablePath.Replace(".exe","_"+rls.Tag+".exe");
            WebClient w = new WebClient();
            string exec = Application.ExecutablePath.Replace(Application.StartupPath, "");
            string execnew = newpatch.Replace(Application.StartupPath, "");
            exec = exec.TrimStart(@"\".ToCharArray()[0]);
            execnew = execnew.TrimStart(@"\".ToCharArray()[0]);
            w.DownloadFile(@"https://github.com/dommilosz/MLauncher/releases/download/" + rls.Tag + "/MLauncher.exe", newpatch);
            w.DownloadFile(@"https://github.com/dommilosz/MLauncher/releases/download/v0.2.0/Update.bat", Application.StartupPath+"Update.bat");
            Process.Start(Application.StartupPath + "Update.bat", "\""+execnew+"\" \""+exec+"\"" );
            Application.Exit();
        }
    }
}
