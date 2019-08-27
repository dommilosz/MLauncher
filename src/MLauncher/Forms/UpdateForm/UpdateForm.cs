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
        GitHubRelease rls = null;

        public UpdateForm(GitHubRelease release, Configuration configuration)
        {
            rls = release;
            _configuration = configuration;
            InitializeComponent();
            LoadLocalization();
            autocheckCheckBox.Checked = _configuration.ApplicationConfiguration.CheckLauncherUpdates;
            Text = $"Found update: {release.Name}";
            changelogBox.Text = $"{release.Description}";
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
            InitializeComponent();
            string newpatch = Application.ExecutablePath + ".UpdateTmp-1.exe";
            WebClient w = new WebClient();
            w.DownloadFile(@"https://github.com/dommilosz/MLauncher/releases/download/" + rls.Tag + "/MLauncher.exe", newpatch);
            w.Dispose();
            Process.Start(newpatch);
            Application.Exit();
        }
    }
}
