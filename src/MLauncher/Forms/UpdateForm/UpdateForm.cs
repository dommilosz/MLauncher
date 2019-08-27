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
            string newpatch = Application.ExecutablePath + rls.Tag;
            WebClient w = new WebClient();
            w.DownloadFile(@"https://github.com/dommilosz/MLauncher/releases/download/" + rls.Tag + "/MLauncher.exe", newpatch);
            Process.Start(newpatch);
            MessageBox.Show("Updated");
            Application.Exit();
        }
    }
}
