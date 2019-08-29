namespace MLauncher
{
    public class ApplicationLocalization
    {
        public string Name { get; set; } = "English";
        public string LanguageTag { get; set; } = "en_UK";
        public string Authors { get; set; } = "Dommilosz";

        #region LauncherForm

        #region Tabs

        public string NewsTabText { get; set; } = "NEWS";
        public string ConsoleTabText { get; set; } = "CONSOLE";
        public string ManageVersionsTabText { get; set; } = "BUILDS MANAGMENT";
        public string ManageProfilesTabText { get; set; } = "PROFILES MANAGMENT";
        public string AboutTabText { get; set; } = "ABOUT";
        public string LicensesTabText { get; set; } = "LICENSES";
        public string SettingsTabText { get; set; } = "SETTINGS";

        #endregion

        #region Main Controls

        public string LaunchButtonText { get; set; } = "Launch the game";
        public string AddProfileButtonText { get; set; } = "Add profile";
        public string EditProfileButtonText { get; set; } = "Edit profile";
        public string SetToClipboardButtonText { get; set; } = "Copy to Clipboard";

        #endregion

        #region Build Managment Tab

        public string VersionHeader { get; set; } = "Version";
        public string TypeHeader { get; set; } = "Type";
        public string ReleaseDateHeader { get; set; } = "Release Date";
        public string LastUpdatedHeader { get; set; } = "Last Update";
        public string AssetsIndexHeader { get; set; } = "Assets Index";
        public string DependencyHeader { get; set; } = "Inherits from";

        public string Restore { get; set; } = "Restore";
        public string OpenLocation { get; set; } = "Open location";
        public string DeleteVersion { get; set; } = "Delete";
        public string DeleteConfirmationTitle { get; set; } = "Delete confirmation";
        public string DeleteConfirmationText { get; set; } = "Are you sure want to delete build '{0}'?";

        #endregion

        #region Profile Managment Tab

        public string MoveUp { get; set; } = "Move up";
        public string MoveDown { get; set; } = "Move down";
        #endregion

        #region About Tab

        public string DevInfo { get; set; } = "Developed by Dommilosz";
        public string GratitudesText { get; set; } = "Gratitudes";
        public string GratitudesDescription { get; set; } = "Dedepete - Creator of FreeLauncher";
        public string PartnersText { get; set; } = "";
        public string MCofflineDescription { get; set; } = "";

        public string CopyrightInfo { get; set; } =
            "\"Minecraft\" is a trademark of Mojang Synergies AB. All rights reserved.\nMojang Synergies AB is a subsidiary of Microsoft Studios.";

        #endregion

        #region Settings Tab

        public string MainSettingsTitle { get; set; } = "Main";
        public string CheckUpdatesCheckBox { get; set; } = "Check for launcher updates";
        public string SkipAssetsDownload { get; set; } = "Skip assets download";
        public string EnableMinecraftLoggingText { get; set; } = "Display logs from OUTPUT thread";
        public string LoggerSettingsTitle { get; set; } = "Logging";

        public string CloseGameOutputText { get; set; } =
            "Close tabs automaticly if there was no errors";

        #endregion

        public string Launch { get; set; } = "Launch";
        public string Delete { get; set; } = "Delete";
        public string ReadyToLaunch { get; set; } = "Ready to launch build {0}";
        public string ReadyToDownload { get; set; } = "Ready to download build {0}";
        public string EditingProfileTitle { get; set; } = "Editing profile";
        public string ProfileAlreadyExistsErrorText { get; set; } = "Profile with provided name already exists!";
        public string ProfileDeleteConfirmationText { get; set; } = "Are you sure want to delete profile '{0}'?";
        public string AddingProfileTitle { get; set; } = "Adding profile";
        public string CheckingVersionAvailability { get; set; } = "Checking availability of build '{0}'";
        public string CheckingLibraries { get; set; } = "Checking libraries";
        public string GameOutput { get; set; } = "Game output";
        public string KillProcess { get; set; } = "Terminate";
        public string Independent { get; set; } = "Nothing";
        public string InvalidSessionMessage { get; set; } = "Session token is not valid. Please, re-add your account.";
        public string SomeFilesMissingMessage { get; set; } = "Looks like this is your first time using this launcher.\nUnfortunately, some required files are missing and we are unable to download them without the Internet connection.\nPlease, check for your Internet configuration and restart the launcher.";

        #endregion

        #region ProfileForm

        #region GroupBoxes

        public string MainProfileSettingsGroup { get; set; } = "Main Profile Configuration";
        public string VersionSettingsGroup { get; set; } = "Version Selection";
        public string JavaSettingsGroup { get; set; } = "Java Configuration";

        #endregion

        #region Main Settings

        public string ProfileName { get; set; } = "Profile name:";
        public string WorkingDirectory { get; set; } = "Working directory:";
        public string WindowResolution { get; set; } = "Working directory:";
        public string ActionAfterLaunch { get; set; } = "Action after launch:";
        public string KeepLauncherOpen { get; set; } = "Keep the Launcher Open";
        public string HideLauncher { get; set; } = "Hide Launcher";
        public string CloseLauncher { get; set; } = "Close Launcher";
        public string Autoconnect { get; set; } = "Autoconnect to:";

        #endregion

        #region Version Selection

        public string Snapshots { get; set; } = "Display experemental builds (\"snapshots\")";
        public string Beta { get; set; } = "Display \"Beta\" builds (2011-2012)";
        public string Alpha { get; set; } = "Display \"Alpha\" builds (until 2011)";
        public string Other { get; set; } = "Display third-party builds (Forge, LiteLoader, etc.)";
        public string UseLatestVersion { get; set; } = "Use Latest Build '{0}'";

        #endregion

        #region Java Options

        public string JavaExecutable { get; set; } = "JMV Executable:";
        public string JavaFlags { get; set; } = "JVM Flags:";

        #endregion

        public string OpenDirectory { get; set; } = "Open working dir";

        public string JavaDetectionFailed { get; set; } = "No Java installation was detected! Please, provide a path to Java executable manually.";

        #endregion

        #region UsersForm

        public string AddNewUserBox { get; set; } = "Add new user";
        public string Nickname { get; set; } = "Username:";
        public string LicenseQuestion { get; set; } = "License account?";
        public string Password { get; set; } = "Password:";
        public string AddNewUserButton { get; set; } = "Add new user";
        public string RemoveSelectedUser { get; set; } = "Remove selected user";
        public string IncorrectLoginOrPassword { get; set; } = "Login and/or password is incorrect!";
        public string PleaseWait { get; set; } = "Please, wait";

        #endregion

        #region UpdateForm

        public string GoToGitHub { get; set; } = "Go to GitHub";
        public string SupportDeveloper { get; set; } = "Support the developer";

        #endregion

        public string Error { get; set; } = "Error";
        public string Cancel { get; set; } = "Cancel";
        public string Close { get; set; } = "Close";
        public string Save { get; set; } = "Save";
    }
}
