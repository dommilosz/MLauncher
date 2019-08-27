﻿using dotMCLauncher.Networking;
using dotMCLauncher.Profiling;
using dotMCLauncher.Resourcing;
using dotMCLauncher.Versioning;
using Ionic.Zip;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;
using OS = dotMCLauncher.OperatingSystem;

namespace MLauncher.Forms
{
    public partial class LauncherForm : RadForm
    {
        #region Variables

        private readonly Configuration _configuration;
        private ProfileManager _profileManager;
        private RawVersionListManifest _versionList;
        private Profile _selectedProfile;
        private UserManager _userManager;
        private User _selectedUser;
        private readonly Dictionary<string, Tuple<string, DateTime>> _nicknameDictionary;
        private readonly ApplicationConfiguration _cfg;
        private string _versionToLaunch;
        private bool _restoreVersion;

        private static int LinuxTimeStamp => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

        private int StatusBarValue
        {
            get
            {
                return StatusBar.Value1;
            }
            set
            {
                SetStatusBarValue(value);
            }
        }

        private void SetControlBlockState(bool block)
        {
            LaunchButton.Enabled = !block;
            profilesDropDownBox.Enabled = !block;
            DeleteProfileButton.Enabled = !block && (_profileManager.Profiles.Count > 1);
            EditProfileButton.Enabled = !block;
            AddProfile.Enabled = !block;
            NicknameDropDownList.Enabled = !block;
        }

        private void SetStatusBarValue(int value)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action<int>(SetStatusBarValue), value);
            }
            else
            {
                try { StatusBar.Value1 = value; } catch { }
            }
        }

        private void SetStatusBarMaxValue(int value)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action<int>(SetStatusBarMaxValue), value);
            }
            else
            {
                StatusBar.Maximum = value;
            }
        }

        private void SetStatusBarVisibility(bool visible)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action<bool>(SetStatusBarVisibility), visible);
            }
            else
            {
                StatusBar.Visible = visible;
            }
        }

        #endregion

        public LauncherForm(Configuration configuration)
        {
            
            if (Application.ExecutablePath.Contains("UpdateTmp-1"))
            {
                string newpatch = Application.ExecutablePath;
                newpatch = newpatch.Replace(".UpdateTmp-1.exe", "");
                try
                {
                    File.Delete(newpatch);
                }
                catch { }
                File.Copy(Application.ExecutablePath, newpatch);
                Process.Start(newpatch);
                Application.Exit();
                return;
            }
            if (DesignMode) return;
            try
            {
                File.Delete(Application.ExecutablePath + ".UpdateTmp-1.exe");
            }
            catch { }

            _configuration = configuration;
            _nicknameDictionary = new Dictionary<string, Tuple<string, DateTime>>();
            InitializeComponent();

            _cfg = _configuration.ApplicationConfiguration;
            CheckUpdatesCheckBox.Checked = _cfg.CheckLauncherUpdates;
            DownloadAssetsBox.Checked = _cfg.SkipAssetsDownload;
            EnableMinecraftLogging.Checked = _cfg.EnableGameLogging;
            CloseGameOutput.Checked = _cfg.CloseTabAfterSuccessfulExitCode;
            LoadLocalization();
            Text = $"{ProductName} {ProductVersion}";
            AboutVersion.Text = ProductVersion;
            AppendLog($"Application: {ProductName}");
            AppendLog($"EXE patch: {Application.ExecutablePath}");
            AppendLog($"Version: {ProductVersion}");
            AppendLog($"Loaded language: {_configuration.Localization.Name}({_configuration.Localization.LanguageTag})");
            AppendLog(new string('=', 12));
            AppendLog("System info:");
            AppendLog($"{new string(' ', 2)}Operating system:");
            AppendLog($"{new string(' ', 4)}OSFullName: {new ComputerInfo().OSFullName}");
            AppendLog($"{new string(' ', 4)}Build: {Environment.OSVersion.Version.Build}");
            AppendLog($"{new string(' ', 4)}Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}");
            AppendLog($"{new string(' ', 2)}Java path: '{Java.JavaInstallationPath}' ({Java.JavaBitInstallation}-bit)");
            AppendLog(new string('=', 12));
            LangDropDownList.Items.Clear();
            if (_configuration.LocalizationsList.Count != 0)
            {
                foreach (KeyValuePair<string, ApplicationLocalization> keyvalue in _configuration.LocalizationsList)
                {
                    LangDropDownList.Items.Add(new RadListDataItem
                    {
                        Text = $"{keyvalue.Value.Name} ({keyvalue.Key})",
                        Tag = keyvalue.Key
                    });
                }
                foreach (RadListDataItem item in LangDropDownList.Items.Where(a => a.Tag.ToString() == _cfg.SelectedLanguage))
                {
                    LangDropDownList.SelectedItem = item;
                }
            }
            else
            {
                LangDropDownList.Enabled = false;
            }

            if (!_configuration.Arguments.OfflineMode)
            {
                _configuration.Arguments.OfflineMode = !CheckForInternetConnection();
            }

            if (!Directory.Exists(_configuration.McDirectory))
            {
                Directory.CreateDirectory(_configuration.McDirectory);
            }
            if (!Directory.Exists(_configuration.McLauncher))
            {
                Directory.CreateDirectory(_configuration.McLauncher);
            }

            if (_configuration.Arguments.OfflineMode)
            {
                newsBrowser.DocumentText = $@"<html><body>
<h1>OFFLINE-MODE ENABLED</h1>
<hr />
Failed to check for Internet connection or offline-mode was forced to be enabled.
<br />
Please, check for your Internet configuration and restart the launcher.
<hr />
<i>{ProductName} {ProductVersion}</i>
</body></html>";
                Text += " [OFFLINE]";
            }
            else
            {
                newsBrowser.Navigate("http://dedepete.github.io/FreeLauncher");
                CheckLauncherUpdates();
            }

            UpdateVersions();

            UpdateProfileList();
            UpdateVersionListView();
            UpdateUserList();
            Focus();
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cfg.CheckLauncherUpdates = CheckUpdatesCheckBox.Checked;
            _cfg.SkipAssetsDownload = DownloadAssetsBox.Checked;
            _cfg.EnableGameLogging = EnableMinecraftLogging.Checked;
            _cfg.CloseTabAfterSuccessfulExitCode = CloseGameOutput.Checked;
        }

        private void profilesDropDownBox_SelectedIndexChanged(object sender,
            PositionChangedEventArgs e)
        {
            if (profilesDropDownBox.SelectedItem == null)
            {
                return;
            }
            _profileManager.LastUsedProfile = profilesDropDownBox.SelectedItem.Text;
            _selectedProfile = _profileManager.GetProfile(profilesDropDownBox.SelectedItem.Text);
            UpdateVersionListView();
            SaveProfiles();
        }

        private void NicknameDropDownList_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
        {
            if (NicknameDropDownList.SelectedItem == null)
            {
                return;
            }
            _userManager.SelectedUsername = NicknameDropDownList.SelectedItem.Text;
            _selectedUser = _userManager.Accounts[NicknameDropDownList.SelectedItem.Text];
            SaveUsers();
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            ProfileForm pf = new ProfileForm(_selectedProfile, _configuration)
            {
                Text = _configuration.Localization.EditingProfileTitle
            };
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK)
            {
                _profileManager.RemoveProfile(_profileManager.LastUsedProfile);
                if (_profileManager.Profiles.Any(pair => pair.Key == pf.Profile.ProfileName))
                {
                    RadMessageBox.Show(_configuration.Localization.ProfileAlreadyExistsErrorText,
                        _configuration.Localization.Error,
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                    UpdateProfileList();
                    return;
                }
                _profileManager.AddProfile(pf.Profile);
                _profileManager.LastUsedProfile = pf.Profile.ProfileName;
            }
            SaveProfiles();
            UpdateProfileList();
        }

        private void AddProfile_Click(object sender, EventArgs e)
        {
            Profile editedProfile = Profile.ParseProfile(_selectedProfile.ToString());
            editedProfile.ProfileName = $"Copy of '{_selectedProfile.ProfileName}'({LinuxTimeStamp})";
            ProfileForm pf = new ProfileForm(editedProfile, _configuration)
            {
                Text = _configuration.Localization.AddingProfileTitle
            };
            pf.ShowDialog();
            if (pf.DialogResult == DialogResult.OK)
            {
                if (_profileManager.Profiles.Any(pair => pair.Key == editedProfile.ProfileName))
                {
                    RadMessageBox.Show(_configuration.Localization.ProfileAlreadyExistsErrorText,
                        _configuration.Localization.Error,
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
                _profileManager.AddProfile(editedProfile);
                _profileManager.LastUsedProfile = pf.Profile.ProfileName;
            }
            SaveProfiles();
            UpdateProfileList();
        }

        private void DeleteProfileButton_Click(object sender, EventArgs e)
        {
            DialogResult dr =
                RadMessageBox.Show(
                    string.Format(_configuration.Localization.ProfileDeleteConfirmationText,
                        _profileManager.LastUsedProfile), _configuration.Localization.DeleteConfirmationTitle,
                    MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            _profileManager.RemoveProfile(_profileManager.LastUsedProfile);
            _profileManager.LastUsedProfile = _profileManager.Profiles.FirstOrDefault().Key;
            SaveProfiles();
            UpdateProfileList();
        }

        private void ManageUsersButton_Click(object sender, EventArgs e)
        {
            new UsersForm(_configuration).ShowDialog();
            UpdateUserList();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            SetControlBlockState(true);
            if (string.IsNullOrWhiteSpace(NicknameDropDownList.Text))
            {
                NicknameDropDownList.Text = $"Player{LinuxTimeStamp}";
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += delegate
            {
                DownloadVersion(_versionToLaunch ?? (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)));
                UpdateVersionListView();
            };
            bgw.RunWorkerCompleted += delegate
            {
                string libraries = string.Empty;
                BackgroundWorker bgw1 = new BackgroundWorker();
                bgw1.DoWork += delegate
                {
                    libraries = DownloadLibraries();
                };
                bgw1.RunWorkerCompleted += delegate
                {
                    BackgroundWorker bgw2 = new BackgroundWorker();
                    bgw2.DoWork += delegate
                    {
                        if (!DownloadAssetsBox.Checked)
                        {
                            DownloadAssets();
                        }
                        else
                        {
                            AppendLog("Assets download skipped.");
                        }
                        SetStatusBarVisibility(false);
                    };
                    bgw2.RunWorkerCompleted += delegate
                    {
                        if (_restoreVersion)
                        {
                            AppendLog($@"Successfully restored ""{_versionToLaunch}"" version.");
                            _restoreVersion = false;
                            SetControlBlockState(false);
                            UpdateVersionListView();
                            _versionToLaunch = null;
                            return;
                        }
                        if (!_userManager.Accounts.ContainsKey(NicknameDropDownList.Text))
                        {
                            User user = new User
                            {
                                Username = NicknameDropDownList.Text,
                                Type = "offline"
                            };
                            _userManager.Accounts.Add(user.Username, user);
                            _selectedUser = user;
                        }
                        else
                        {
                            _selectedUser = _userManager.Accounts[NicknameDropDownList.Text];
                            if (_selectedUser.Type != "offline")
                            {
                                AuthManager am = new AuthManager
                                {
                                    ClientToken = _selectedUser.ClientToken,
                                    AccessToken = _selectedUser.AccessToken,
                                    Uuid = _selectedUser.Uuid
                                };
                                bool check = am.Validate();
                                if (!check)
                                {
                                    RadMessageBox.Show(
                                        _configuration.Localization.InvalidSessionMessage,
                                        _configuration.Localization.Error, MessageBoxButtons.OK,
                                        RadMessageIcon.Exclamation);
                                    User user = new User
                                    {
                                        Username = NicknameDropDownList.Text,
                                        Type = "offline"
                                    };
                                    _selectedUser = user;
                                }
                                else
                                {
                                    Refresh refresh = new Refresh(_selectedUser.AccessToken, _selectedUser.ClientToken);
                                    refresh = (Refresh)refresh.DoPost();
                                    _selectedUser.UserProperties = (JArray)refresh.User?["properties"];
                                    _selectedUser.AccessToken = refresh.AccessToken;
                                    _userManager.Accounts[NicknameDropDownList.Text] = _selectedUser;
                                }
                            }
                        }
                        _userManager.SelectedUsername = _selectedUser.Username;
                        SaveUsers();
                        UpdateUserList();
                        VersionManifest selectedVersionManifest = VersionManifest.ParseVersion(
                            new DirectoryInfo(PatchCombineFix.PatchCombine(_configuration.McVersions, _versionToLaunch ?? (
                                _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))));
                        JObject properties = new JObject {
                            new JProperty("MLauncher", new JArray("cheeki_breeki_iv_damke"))
                        };
                        if (_selectedProfile.ConnectionSettigs != null)
                        {
                            selectedVersionManifest.ArgCollection.Add("server",
                                _selectedProfile.ConnectionSettigs.ServerIp);
                            selectedVersionManifest.ArgCollection.Add("port",
                                _selectedProfile.ConnectionSettigs.ServerPort.ToString());
                        }
                        string javaArguments = _selectedProfile.JavaArguments == null
                            ? string.Empty
                            : _selectedProfile.JavaArguments + " ";
                        if (_selectedProfile.WorkingDirectory != null &&
                            !Directory.Exists(_selectedProfile.WorkingDirectory))
                        {
                            Directory.CreateDirectory(_selectedProfile.WorkingDirectory);
                        }
                        string username;
                        if (_selectedUser.Type != "offline")
                        {
                            while (true)
                            {
                                try
                                {
                                    if (_nicknameDictionary.ContainsKey(_selectedUser.Uuid) && _nicknameDictionary[_selectedUser.Uuid].Item2 > DateTime.Now)
                                    {
                                        username = _nicknameDictionary[_selectedUser.Uuid].Item1;
                                        break;
                                    }
                                    if (_nicknameDictionary.ContainsKey(_selectedUser.Uuid) && _nicknameDictionary[_selectedUser.Uuid].Item2 <= DateTime.Now)
                                    {
                                        _nicknameDictionary.Remove(_selectedUser.Uuid);
                                    }
                                    _nicknameDictionary.Add(_selectedUser.Uuid, new Tuple<string, DateTime>(
                                        new Username
                                        {
                                            Uuid = _selectedUser.Uuid
                                        }.GetUsernameByUuid(),
                                        DateTime.Now.AddMinutes(30)));
                                    username = _nicknameDictionary[_selectedUser.Uuid].Item1;
                                    break;
                                }
                                catch (WebException ex)
                                {
                                    if ((int)((HttpWebResponse)ex.Response).StatusCode != 429)
                                    {
                                        AppendException($"An unhandled exception has occured while getting username by UUID:{Environment.NewLine}{ex}");
                                        username = NicknameDropDownList.Text;
                                        break;
                                    }
                                    Thread.Sleep(10000);
                                }
                            }
                        }
                        else
                        {
                            username = NicknameDropDownList.Text;
                        }
                        Dictionary<string, string> gameArgumentDictionary = new Dictionary<string, string> {
                            {
                                "auth_player_name", username
                            }, {
                                "version_name", _selectedProfile.ProfileName
                            }, {
                                "game_directory",
                                _selectedProfile.WorkingDirectory ?? _configuration.McDirectory
                            }, {
                                "assets_root", PatchCombineFix.PatchCombine(_configuration.McDirectory, "assets")
                            }, {
                                "game_assets", PatchCombineFix.PatchCombine(_configuration.McDirectory, "assets", "virtual", "legacy")
                            }, {
                                "assets_index_name", selectedVersionManifest.GetAssetsIndex()
                            }, {
                                "version_type", selectedVersionManifest.ReleaseType
                            }, {
                                "auth_session", $"token:{_selectedUser.ClientToken}:{_selectedUser.Uuid}" ?? "token:sample_token:sample_token"
                            }, {
                                "auth_access_token", _selectedUser.AccessToken ?? "sample_token"
                            }, {
                                "auth_uuid", _selectedUser.Uuid ?? "sample_token"
                            }, {
                                "user_properties",
                                _selectedUser.UserProperties?.ToString(Formatting.None) ??
                                properties.ToString(Formatting.None)
                            }, {
                                "user_type", _selectedUser.Type
                            }
                        };
                        Dictionary<string, string> jvmArgumentDictionary = new Dictionary<string, string> {
                            {
                                "natives_directory", PatchCombineFix.PatchCombine(_configuration.McDirectory, "natives")
                            }, {
                                "launcher_name", Application.ProductName
                            }, {
                                "launcher_version", Application.ProductVersion
                            }, {
                                "classpath", libraries.Contains(' ') ? $"\"{libraries}\"" : libraries
                            }
                        };
                        string gameArguments, jvmArguments;
                        if (selectedVersionManifest.Type == VersionManifestType.V2)
                        {
                            List<Rule> requiredRules = new List<Rule> {
                                new Rule {
                                    Action = "allow",
                                    Os = new Os {
                                        Name = "windows"
                                    }
                                }
                            };
                            if (new ComputerInfo().OSFullName.ToUpperInvariant().Contains("WINDOWS 10"))
                            {
                                requiredRules.Add(new Rule
                                {
                                    Action = "allow",
                                    Os = new Os
                                    {
                                        Name = "windows",
                                        Version = "^10\\."
                                    }
                                });
                            }
                            if (_selectedProfile.WindowInfo != null && (_selectedProfile.WindowInfo.Width != 854 || _selectedProfile.WindowInfo.Height != 480))
                            {
                                requiredRules.Add(new Rule
                                {
                                    Action = "allow",
                                    Features = new Features
                                    {
                                        IsForCustomResolution = true
                                    }
                                });
                                gameArgumentDictionary.Add("resolution_width",
                                    _selectedProfile.WindowInfo?.Width.ToString());
                                gameArgumentDictionary.Add("resolution_height",
                                    _selectedProfile.WindowInfo?.Height.ToString());
                            }
                            gameArguments =
                                selectedVersionManifest.BuildArgumentsByGroup(ArgumentsGroupType.GAME, gameArgumentDictionary, requiredRules.ToArray());
                            jvmArguments = selectedVersionManifest.BuildArgumentsByGroup(ArgumentsGroupType.JVM, jvmArgumentDictionary, requiredRules.ToArray());
                        }
                        else
                        {
                            string nativesPath = PatchCombineFix.PatchCombine(_configuration.McDirectory, "natives");
                            nativesPath = nativesPath.Contains(' ') ? $@"""{nativesPath}""" : nativesPath;
                            gameArguments = selectedVersionManifest.ArgCollection.ToString(gameArgumentDictionary);
                            jvmArguments = javaArguments +
                                $"-Djava.library.path={nativesPath} -cp {(libraries.Contains(' ') ? $@"""{libraries}""" : libraries)}";
                        }
                        ProcessStartInfo proc = new ProcessStartInfo
                        {
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            FileName = _selectedProfile.JavaExecutable ?? Java.JavaExecutable,
                            StandardErrorEncoding = Encoding.UTF8,
                            WorkingDirectory = _selectedProfile.WorkingDirectory ?? _configuration.McDirectory,
                            Arguments =
                                $"{jvmArguments} {selectedVersionManifest.MainClass} {gameArguments}"
                        };
                        AppendLog($"Command line executed: \"{proc.FileName}\" {proc.Arguments}");
                        new MinecraftProcess(new Process
                        {
                            StartInfo = proc,
                            EnableRaisingEvents = true
                        }, this,
                            _selectedProfile).Launch();
                        AppendLog($"Version {selectedVersionManifest.VersionId} successfuly executed.");
                        SetControlBlockState(false);
                        UpdateVersionListView();
                        _versionToLaunch = null;
                    };
                    bgw2.RunWorkerAsync();
                };
                bgw1.RunWorkerAsync();
            };
            bgw.RunWorkerAsync();
        }

        private void logBox_TextChanged(object sender, EventArgs e)
        {
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        #region newsBrowser

        private void newsBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            ProcessUrl();
        }

        private void newsBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            ProcessUrl();
        }

        private void ProcessUrl()
        {
            if (_configuration.Arguments.OfflineMode)
            {
                return;
            }
            if (newsBrowser.Url != new Uri("http://dedepete.github.io/MLauncher/"))
            {
                BackWebButton.Enabled = newsBrowser.CanGoBack;
                ForwardWebButton.Enabled = newsBrowser.CanGoForward;
                navBar.Text = newsBrowser.Url?.ToString();
                navBar.Visible = true;
            }
            else
            {
                navBar.Visible = false;
            }
        }

        private void backWebButton_Click(object sender, EventArgs e)
        {
            newsBrowser.GoBack();
        }

        private void forwardWebButton_Click(object sender, EventArgs e)
        {
            newsBrowser.GoForward();
        }

        #endregion

        private void versionsListView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            versionsListView.SelectedItem = e.Item;
            VersionManifest ver =
                VersionManifest.ParseVersion(
                    new DirectoryInfo(PatchCombineFix.PatchCombine(_configuration.McVersions,
                        versionsListView.SelectedItem[0].ToString())), false);
            RadMenuItem launchVerButton = new RadMenuItem
            {
                Text = _configuration.Localization.Launch
            };
            launchVerButton.Click += delegate
            {
                if (versionsListView.SelectedItem == null)
                {
                    return;
                }
                _versionToLaunch = versionsListView.SelectedItem[0].ToString();
                LaunchButton.PerformClick();
            };
            bool enableRestoreButton = !_configuration.Arguments.OfflineMode &&
                (ver.ReleaseType == "release" || ver.ReleaseType == "snapshot" ||
                    ver.ReleaseType == "old_beta" || ver.ReleaseType == "old_alpha");
            RadMenuItem restoreVerButton = new RadMenuItem
            {
                Text = _configuration.Localization.Restore,
                Enabled = enableRestoreButton
            };
            restoreVerButton.Click += delegate
            {
                _restoreVersion = true;
                _versionToLaunch = versionsListView.SelectedItem[0].ToString();
                LaunchButton.PerformClick();
            };
            RadMenuItem openVerButton = new RadMenuItem
            {
                Text = _configuration.Localization.OpenLocation
            };
            openVerButton.Click += delegate
            {
                if (versionsListView.SelectedItem == null)
                {
                    return;
                }
                Process.Start(PatchCombineFix.PatchCombine(_configuration.McVersions, versionsListView.SelectedItem[0] + @"\"));
            };
            RadMenuItem delVerButton = new RadMenuItem
            {
                Text = _configuration.Localization.DeleteVersion
            };
            delVerButton.Click += delegate
            {
                if (versionsListView.SelectedItem == null)
                {
                    return;
                }
                DialogResult dr =
                    RadMessageBox.Show(
                        string.Format(_configuration.Localization.DeleteConfirmationText,
                            versionsListView.SelectedItem[0]),
                        _configuration.Localization.DeleteConfirmationTitle,
                        MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
                try
                {
                    Directory.Delete(
                        PatchCombineFix.PatchCombine(_configuration.McVersions, versionsListView.SelectedItem[0].ToString()), true);
                    AppendLog($"Version '{versionsListView.SelectedItem[0]}' has been deleted successfuly.");
                    UpdateVersionListView();
                }
                catch (Exception ex)
                {
                    AppendException($"An error has occurred during version deletion: {ex}");
                }
            };
            RadContextMenu verListMenuStrip = new RadContextMenu();
            verListMenuStrip.Items.Add(launchVerButton);
            verListMenuStrip.Items.Add(new RadMenuSeparatorItem());
            verListMenuStrip.Items.Add(restoreVerButton);
            verListMenuStrip.Items.Add(new RadMenuSeparatorItem());
            verListMenuStrip.Items.Add(openVerButton);
            verListMenuStrip.Items.Add(delVerButton);
            new RadContextMenuManager().SetRadContextMenu(versionsListView, verListMenuStrip);
        }

        private void SetToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(logBox.Text);
        }

        private void urlLabel_Click(object sender, EventArgs e)
        {
            Process.Start((sender as Label).Text);
        }

        private void langWikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/dedepete/MLauncher/wiki/");
        }

        private void LangDropDownList_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
        {
            if (LangDropDownList.SelectedItem.Tag.ToString() == _cfg.SelectedLanguage)
            {
                return;
            }

            var selectedLocalization = LangDropDownList.SelectedItem.Tag;
            _configuration.SetLocalization(selectedLocalization.ToString());

            _cfg.SelectedLanguage = selectedLocalization.ToString();
            AppendLog($"Application language switched to {selectedLocalization}");
            LoadLocalization();
        }

        private void UpdateVersions()
        {

            string versionsManifestPath = PatchCombineFix.PatchCombine(_configuration.McVersions, @"\versions.json");
            if (_configuration.Arguments.OfflineMode)
            {
                AppendLog("Unable to get new version list: offline-mode enabled.");
                if (File.Exists(versionsManifestPath))
                {
                    _versionList = RawVersionListManifest.ParseList(File.ReadAllText(versionsManifestPath));
                    return;
                }
                MessageBox.Show(_configuration.Localization.SomeFilesMissingMessage);
                Environment.Exit(0);
            }
            AppendLog("Checking version.json...");
            RawVersionListManifest remoteManifest = RawVersionListManifest.ParseList(new WebClient().DownloadString(
                new Uri("https://launchermeta.mojang.com/mc/game/version_manifest.json")));
            if (!Directory.Exists(_configuration.McVersions))
            {
                Directory.CreateDirectory(_configuration.McVersions);
            }
            if (!File.Exists(versionsManifestPath))
            {
                File.WriteAllText(versionsManifestPath, remoteManifest.ToString());
                _versionList = remoteManifest;
                return;
            }
            AppendLog("Latest snapshot: " + remoteManifest.LatestVersions.Snapshot);
            AppendLog("Latest release: " + remoteManifest.LatestVersions.Release);
            RawVersionListManifest localManifest =
                RawVersionListManifest.ParseList(File.ReadAllText(versionsManifestPath));
            AppendLog($"Local versions: {localManifest.Versions.Count}. "
                + $"Remote versions: {remoteManifest.Versions.Count}");
            if (remoteManifest.Versions.Count == localManifest.Versions.Count &&
                remoteManifest.LatestVersions.Release == localManifest.LatestVersions.Release &&
                remoteManifest.LatestVersions.Snapshot == localManifest.LatestVersions.Snapshot)
            {
                _versionList = localManifest;
                AppendLog("No update found.");
                return;
            }
            AppendLog("Writting new list...");
            File.WriteAllText(versionsManifestPath, remoteManifest.ToString());
            _versionList = remoteManifest;
        }

        private void UpdateProfileList()
        {
            profilesDropDownBox.Items.Clear();
            profilesListView.Items.Clear();
            string profilesPath = PatchCombineFix.PatchCombine(_configuration.McDirectory, @"\launcher_profiles.json");
            try
            {
                _profileManager =
                    ProfileManager.ParseProfile(profilesPath);
                if (!_profileManager.Profiles.Any())
                {
                    throw new FileLoadException("File is corrupted or contains no profiles.");
                }
            }
            catch (Exception ex)
            {
                AppendException($"An exception has occurred while processing profiles:\n{ex.Message}\nA new profile list will be created.");
                if (File.Exists(profilesPath))
                {
                    string fileName = $"launcher_profiles-{LinuxTimeStamp}.bak.json";
                    AppendLog("A copy of old profile list has been created: " + fileName);
                    File.Move(profilesPath,
                        PatchCombineFix.PatchCombine(_configuration.McDirectory, fileName));
                }
                File.WriteAllText(profilesPath, new JObject {
                    {
                        "profiles", new JObject {
                            {
                                ProductName, new JObject {
                                    {
                                        "name", ProductName
                                    }, {
                                        "allowedReleaseTypes", new JArray {
                                            "other"
                                        }
                                    }, {
                                        "launcherVisibilityOnGameClose", "keep the launcher open"
                                    }
                                }
                            }, {
                                "Latest Release", new JObject {
                                    {
                                        "name", "Latest Release"
                                    }, {
                                        "launcherVisibilityOnGameClose", "keep the launcher open"
                                    }
                                }
                            }, {
                                "Latest Snapshot", new JObject {
                                    {
                                        "name", "Latest Snapshot"
                                    }, {
                                        "allowedReleaseTypes", new JArray {
                                            "snapshot"
                                        }
                                    }, {
                                        "launcherVisibilityOnGameClose", "keep the launcher open"
                                    }
                                }
                            }
                        }
                    }, {
                        "selectedProfile", ProductName
                    }
                }.ToString());
                _profileManager = ProfileManager.ParseProfile(profilesPath);
                SaveProfiles();
            }
            DeleteProfileButton.Enabled = _profileManager.Profiles.Count > 1;
            profilesDropDownBox.Items.AddRange(_profileManager.Profiles.Select(pair => pair.Key));
            profilesDropDownBox.SelectedItem = profilesDropDownBox.FindItemExact(_profileManager.LastUsedProfile, true);
            foreach (KeyValuePair<string, Profile> keyValuePair in _profileManager.Profiles)
            {
                Profile profile = keyValuePair.Value;
                string allowedReleaseTypes = "release";
                if (profile.AllowedReleaseTypes != null)
                {
                    allowedReleaseTypes = profile.AllowedReleaseTypes.Aggregate(allowedReleaseTypes, (current, type) => current + $", {type}");
                }
                profilesListView.Items.Add(keyValuePair.Key, profile.ProfileName, profile.SelectedVersion ?? "latest", allowedReleaseTypes, profile.LauncherVisibilityOnGameClose);
            }
            radListView1.Items.Clear();
            for (int i = 0; i < profilesDropDownBox.Items.Count; i++)
            {
                radListView1.Items.Add(profilesDropDownBox.Items[i]);
                radListView1.Items[i].BorderColor = Color.CornflowerBlue;
            }

        }

        private void UpdateUserList()
        {
            NicknameDropDownList.Items.Clear();
            try
            {
                _userManager = File.Exists(_configuration.McLauncher + @"\users.json")
                    ? JsonConvert.DeserializeObject<UserManager>(
                        File.ReadAllText(_configuration.McLauncher + @"\users.json"))
                    : new UserManager();
            }
            catch (Exception ex)
            {
                AppendException("Reading user list: an exception has occurred\n" + ex.Message);
                _userManager = new UserManager();
                SaveUsers();
            }
            NicknameDropDownList.Items.AddRange(_userManager.Accounts.Keys);
            NicknameDropDownList.SelectedItem = NicknameDropDownList.FindItemExact(_userManager.SelectedUsername, true);
        }

        private void SaveProfiles()
        {
            File.WriteAllText(_configuration.McDirectory + @"\launcher_profiles.json", _profileManager.ToJson());
        }

        private void SaveUsers()
        {
            File.WriteAllText(_configuration.McLauncher + @"\users.json",
                JsonConvert.SerializeObject(_userManager, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }));
        }

        private void DownloadVersion(string version)
        {
            string filename;
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += (_, e) =>
            {
                StatusBarValue = e.ProgressPercentage;
            };
            SetStatusBarVisibility(true);
            SetStatusBarMaxValue(100);
            StatusBarValue = 0;
            UpdateStatusBarText(string.Format(_configuration.Localization.CheckingVersionAvailability, version));
            AppendLog($"Checking '{version}' version availability...");
            string path = PatchCombineFix.PatchCombine(_configuration.McVersions, version + @"\");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists($@"{path}\{version}.json") || _restoreVersion)
            {
                if (!_configuration.Arguments.OfflineMode)
                {
                    filename = version + ".json";
                    UpdateStatusBarAndLog($"Downloading {filename}...", new StackFrame().GetMethod().Name);
                    downloader.DownloadFileTaskAsync(
                        new Uri(_versionList.GetVersion(version)?.ManifestUrl ?? string.Format(
                            "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.json", version)),
                        string.Format(@"{0}\{1}\{1}.json", _configuration.McVersions, version)).Wait();
                }
                else
                {
                    AppendException($"Unable to download version {version}: offline-mode enabled.");
                    return;
                }
            }
            StatusBarValue = 0;
            VersionManifest selectedVersionManifest = VersionManifest.ParseVersion(
                new DirectoryInfo(_configuration.McVersions + @"\" + version), false);
            if ((!File.Exists($"{path}/{version}.jar") || _restoreVersion) &&
                selectedVersionManifest.InheritsFrom == null)
            {
                if (!_configuration.Arguments.OfflineMode)
                {
                    filename = version + ".jar";
                    UpdateStatusBarAndLog($"Downloading {filename}...", new StackFrame().GetMethod().Name);
                    downloader.DownloadFileTaskAsync(new Uri(selectedVersionManifest.DownloadInfo?.Client.Url
                            ??
                            string.Format(
                                "https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{0}.jar",
                                version)),
                        string.Format("{0}/{1}/{1}.jar", _configuration.McVersions, version)).Wait();
                }
                else
                {
                    AppendException($"Unable to download version {version}: offline-mode enabled.");
                    return;
                }
            }
            if (selectedVersionManifest.InheritsFrom != null)
            {
                DownloadVersion(selectedVersionManifest.InheritsFrom);
            }
            AppendLog($@"Finished checking {version} version avalability.");
        }

        private string DownloadLibraries()
        {
            StringBuilder libraries = new StringBuilder();
            VersionManifest selectedVersionManifest = VersionManifest.ParseVersion(
                new DirectoryInfo(_configuration.McVersions + @"\" +
                    (_versionToLaunch ??
                        (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))));
            SetStatusBarVisibility(true);
            StatusBarValue = 0;
            UpdateStatusBarText(_configuration.Localization.CheckingLibraries);
            AppendLog("Preparing required libraries...");
            Dictionary<DownloadEntry, bool> libsToDownload = new Dictionary<DownloadEntry, bool>();
            foreach (Lib a in selectedVersionManifest.Libs)
            {
                if (!a.IsForWindows())
                {
                    continue;
                }
                if (a.DownloadInfo == null)
                {
                    libsToDownload.Add(new DownloadEntry
                    {
                        Path = a.GetPath(),
                        Url = a.GetUrl()
                    }, false);
                    continue;
                }
                foreach (DownloadEntry entry in a.DownloadInfo?.GetDownloadsEntries(OS.WINDOWS))
                {
                    if (entry == null)
                    {
                        continue;
                    }
                    if (a.DownloadInfo.Classifiers?.ContainsKey("natives-windows") ?? false)
                    {
                        entry.Path = a.DownloadInfo.Classifiers["natives-windows"].Path ?? a.GetPath();
                        entry.Url = a.DownloadInfo.Classifiers["natives-windows"].Url ?? a.GetUrl();
                    }
                    else
                    {
                        entry.Path = entry.Path ?? a.GetPath();
                        entry.Url = entry.Url ?? a.Url;
                    }
                    entry.Path = entry.Path ?? a.GetPath();
                    entry.Url = entry.Url ?? a.Url;
                    libsToDownload.Add(entry, entry.IsNative);
                }
            }
            SetStatusBarMaxValue(libsToDownload.Count + 1);
            foreach (DownloadEntry entry in libsToDownload.Keys)
            {
                StatusBarValue++;
                if (!File.Exists(_configuration.McLibs + @"\" + entry.Path) ||
                    _restoreVersion)
                {
                    if (!_configuration.Arguments.OfflineMode)
                    {
                        UpdateStatusBarAndLog($"Downloading {entry.Path.Replace('/', '\\')}...");
                        string directory = Path.GetDirectoryName(_configuration.McLibs + @"\" + entry.Path);
                        AppendDebug("Url: " + (entry.Url ?? @"https://libraries.minecraft.net/" + entry.Path));
                        AppendDebug("DownloadDir: " + directory);
                        AppendDebug("LibPath: " + entry.Path.Replace('/', '\\'));
                        if (!File.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }
                        try
                        {
                            new WebClient().DownloadFile(entry.Url ?? @"https://libraries.minecraft.net/" + entry.Path,
                                _configuration.McLibs + @"\" + entry.Path);
                        }
                        catch (WebException ex)
                        {
                            AppendException("Downloading failed: " + ex.Message);
                            File.Delete(_configuration.McLibs + @"\" + entry.Path);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            AppendException("Downloading failed: " + ex.Message);
                            continue;
                        }
                    }
                    else
                    {
                        AppendException($"Unable to download {entry.Path}: offline-mode enabled.");
                    }
                }
                if (entry.IsNative)
                {
                    UpdateStatusBarAndLog($"Unpacking {entry.Path.Replace('/', '\\')}...");
                    using (ZipFile zip = ZipFile.Read(_configuration.McLibs + @"\" + entry.Path))
                    {
                        foreach (ZipEntry zipEntry in zip.Where(zipEntry => zipEntry.FileName.EndsWith(".dll")))
                        {
                            AppendDebug($"Unzipping {zipEntry.FileName}");
                            try
                            {
                                zipEntry.Extract(_configuration.McDirectory + @"\natives\",
                                    ExtractExistingFileAction.OverwriteSilently);
                            }
                            catch (Exception ex)
                            {
                                AppendException(ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    libraries.Append(_configuration.McLibs + @"\" + entry.Path.Replace('/', '\\') + ";");
                }
                UpdateStatusBarText(_configuration.Localization.CheckingLibraries);
            }
            libraries.Append(string.Format(@"{0}\{1}\{1}.jar", _configuration.McVersions,
                selectedVersionManifest.GetBaseJar()));
            AppendLog("Finished checking libraries.");
            return libraries.ToString();
        }

        private void DownloadAssets()
        {
            UpdateStatusBarAndLog("Checking game assets...");
            VersionManifest selectedVersionManifest = VersionManifest.ParseVersion(
                new DirectoryInfo(_configuration.McVersions + @"\" +
                    (_versionToLaunch ??
                        (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)))));
            if (selectedVersionManifest.InheritsFrom != null)
            {
                selectedVersionManifest = selectedVersionManifest.InheritableVersionManifest;
            }
            string file = string.Format(@"{0}\assets\indexes\{1}.json", _configuration.McDirectory,
                selectedVersionManifest.AssetsIndex ?? "legacy");
            if (!File.Exists(file))
            {
                if (!Directory.Exists(Path.GetDirectoryName(file)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(file));
                }
                new WebClient().DownloadFile(selectedVersionManifest.GetAssetIndexDownloadUrl(), file);
            }
            AssetsManifest manifest = AssetsManifest.Parse(file);
            StatusBarValue = 0;
            SetStatusBarMaxValue(manifest.Objects.Select(pair => pair.Value.Hash.GetFullPath()).Count(filename => !File.Exists(_configuration.McDirectory + @"\assets\objects\" +
                filename) || _restoreVersion) + 1);
            foreach (Asset asset in manifest.Objects.Select(pair => pair.Value).Where(asset => !File.Exists(_configuration.McDirectory + @"\assets\objects\" +
                asset.Hash.GetFullPath()) || _restoreVersion))
            {
                string directory = _configuration.McDirectory + @"\assets\objects\" + asset.Hash.GetDirectoryName();
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                try
                {
                    AppendDebug($"Downloading {asset.Hash}...");
                    new WebClient().DownloadFile(@"http://resources.download.minecraft.net/" + asset.Hash.GetFullPath(),
                        _configuration.McDirectory + @"\assets\objects\" + asset.Hash.GetFullPath());
                }
                catch (Exception ex)
                {
                    AppendException(ex.ToString());
                }
                StatusBarValue++;
            }
            AppendLog("Finished checking game assets.");
            if (selectedVersionManifest.AssetsIndex == null || selectedVersionManifest.AssetsIndex == "legacy")
            {
                StatusBarValue = 0;
                SetStatusBarMaxValue(manifest.Objects.Select(pair => pair.Value.AssociatedName)
                    .Count(
                        filename =>
                            !File.Exists(_configuration.McDirectory + @"\assets\virtual\legacy\" +
                                filename) || _restoreVersion) + 1);
                UpdateStatusBarAndLog("Converting assets...");
                foreach (Asset asset in manifest.Objects.Select(pair => pair.Value)
                    .Where(asset =>
                        !File.Exists(_configuration.McDirectory + @"\assets\virtual\legacy\" +
                            asset.AssociatedName) || _restoreVersion))
                {
                    string filename = _configuration.McDirectory + @"\assets\virtual\legacy\" + asset.AssociatedName;
                    try
                    {
                        if (!Directory.Exists(new FileInfo(filename).DirectoryName))
                        {
                            Directory.CreateDirectory(new FileInfo(filename).DirectoryName);
                        }
                        AppendDebug(
                            $"Converting '{asset.Hash.GetFullPath()}' to '{asset.AssociatedName}'");
                        File.Copy(_configuration.McDirectory + @"\assets\objects\" + asset.Hash.GetFullPath(),
                            filename);
                    }
                    catch (Exception ex)
                    {
                        AppendLog(ex.ToString());
                    }
                    StatusBarValue++;
                }
                AppendLog("Finished converting assets.");
            }
            SetStatusBarVisibility(false);
        }

        private string GetLatestVersion(Profile profile)
        {
            return profile.AllowedReleaseTypes != null
                ? profile.AllowedReleaseTypes.Contains("snapshot")
                    ? _versionList.LatestVersions.Snapshot
                    : _versionList.LatestVersions.Release
                : _versionList.LatestVersions.Release;
        }

        public LauncherFormOutput AddOutputPage()
        {
            RadPageViewPage outputPage = new RadPageViewPage
            {
                Text =
                    string.Format("{0} ({1})", _configuration.Localization.GameOutput.ToUpper(),
                        _versionToLaunch ?? _selectedProfile.ProfileName)
            };
            RadButton killProcessButton = new RadButton
            {
                Text = _configuration.Localization.KillProcess,
                Anchor = (AnchorStyles.Right | AnchorStyles.Top)
            };
            RadPanel panel = new RadPanel
            {
                Dock = DockStyle.Top
            };
            panel.Size = new Size(panel.Size.Width, 60);
            RadButton closeButton = new RadButton
            {
                Text = _configuration.Localization.Close,
                Anchor = (AnchorStyles.Right | AnchorStyles.Top)
            };
            RichTextBox reportBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Font = logBox.Font
            };
            closeButton.Location = new Point(panel.Size.Width - (closeButton.Size.Width + 5), 5);
            closeButton.Click += delegate
            {
                if (!mainPageView.Pages.Contains(outputPage))
                {
                    return;
                }
                mainPageView.Pages.Remove(outputPage);
            };
            killProcessButton.Location = new Point(panel.Size.Width - (killProcessButton.Size.Width + 5),
                closeButton.Location.Y + closeButton.Size.Height + 5);
            panel.Controls.Add(closeButton);
            panel.Controls.Add(killProcessButton);
            outputPage.Controls.Add(reportBox);
            outputPage.Controls.Add(panel);
            mainPageView.Pages.Add(outputPage);
            mainPageView.SelectedPage = outputPage;
            reportBox.LinkClicked += (_, e) => Process.Start(e.LinkText);
            return new LauncherFormOutput
            {
                OutputBox = reportBox,
                CloseButton = closeButton,
                KillButton = killProcessButton,
                McVersion = _versionToLaunch ?? (
                    _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)),
                McType = VersionManifest.ParseVersion(
                    new DirectoryInfo(PatchCombineFix.PatchCombine(_configuration.McVersions, _versionToLaunch ?? (_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile))))).ReleaseType,
                Panel = panel
            };
        }

        private void LoadLocalization()
        {
            ApplicationLocalization localization = _configuration.Localization;

            News.Text = localization.NewsTabText;
            ConsolePage.Text = localization.ConsoleTabText;
            EditVersions.Text = localization.ManageVersionsTabText;
            EditProfiles.Text = localization.ManageProfilesTabText;
            AboutPage.Text = localization.AboutTabText;
            AboutPageViewPage.Text = localization.AboutTabText;
            LicensesPage.Text = localization.LicensesTabText;

            LaunchButton.Text = localization.LaunchButtonText;
            AddProfile.Text = localization.AddProfileButtonText;
            EditProfileButton.Text = localization.EditProfileButtonText;
            SetToClipboardButton.Text = localization.SetToClipboardButtonText;

            versionsListView.Columns[0].HeaderText = localization.VersionHeader;
            versionsListView.Columns[1].HeaderText = localization.TypeHeader;
            versionsListView.Columns[2].HeaderText = localization.ReleaseDateHeader;
            versionsListView.Columns[3].HeaderText = localization.LastUpdatedHeader;
            versionsListView.Columns[4].HeaderText = localization.AssetsIndexHeader;
            versionsListView.Columns[5].HeaderText = localization.DependencyHeader;

            DevInfoLabel.Text = localization.DevInfo;
            GratitudesLabel.Text = localization.GratitudesText;
            GratitudesDescLabel.Text = localization.GratitudesDescription;
            PartnersLabel.Text = localization.PartnersText;
            CopyrightInfoLabel.Text = localization.CopyrightInfo;

            MainGroupBox.Text = localization.MainSettingsTitle;
            CheckUpdatesCheckBox.Text = localization.CheckUpdatesCheckBox;
            DownloadAssetsBox.Text = localization.SkipAssetsDownload;
            LoggerGroupBox.Text = localization.LoggerSettingsTitle;
            EnableMinecraftLogging.Text = localization.EnableMinecraftLoggingText;
            CloseGameOutput.Text = localization.CloseGameOutputText;
        }

        private void UpdateVersionListView()
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action(UpdateVersionListView));
            }
            else
            {
                versionsListView.Items.Clear();
                foreach (
                    VersionManifest version in
                    Directory.GetDirectories(_configuration.McVersions)
                        .Select(versionDir => new DirectoryInfo(versionDir))
                        .Where(VersionManifest.IsValid)
                        .Select(info => VersionManifest.ParseVersion(info, false)))
                {
                    versionsListView.Items.Add(version.VersionId, version.ReleaseType, version.ReleaseTime, version.LastUpdateTime,
                        version.AssetsIndex ?? "null", version.InheritsFrom ?? _configuration.Localization.Independent);
                }
                try
                {
                    string path = PatchCombineFix.PatchCombine(_configuration.McVersions,
                        _selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile));
                    string state = _configuration.Localization.ReadyToLaunch;
                    LaunchButton.Enabled = true;
                    if (!File.Exists(PatchCombineFix.PatchCombine(path, $"{_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)}.json")))
                    {
                        state = _configuration.Localization.ReadyToDownload;
                        if (_configuration.Arguments.OfflineMode)
                        {
                            LaunchButton.Enabled = false;
                        }
                        SelectedVersion.Text = string.Format(state, _selectedProfile.SelectedVersion ??
                            GetLatestVersion(_selectedProfile));
                        return;
                    }
                    if (!File.Exists(PatchCombineFix.PatchCombine(path, $"{_selectedProfile.SelectedVersion ?? GetLatestVersion(_selectedProfile)}.jar")) && VersionManifest.ParseVersion(new DirectoryInfo(path)).InheritsFrom == null)
                    {
                        state = _configuration.Localization.ReadyToDownload;
                        if (_configuration.Arguments.OfflineMode)
                        {
                            LaunchButton.Enabled = false;
                        }
                    }
                    SelectedVersion.Text = string.Format(state, _selectedProfile.SelectedVersion ??
                        GetLatestVersion(_selectedProfile));
                }
                catch { }
            }
        }

        private static bool CheckForInternetConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://captive.apple.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void UpdateStatusBarText(string text)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action<string>(UpdateStatusBarText), text);
            }
            else
            {
                StatusBar.Text = text;
            }
        }

        private void UpdateStatusBarAndLog(string text, string methodName = null)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action<string, string>(UpdateStatusBarAndLog), text,
                    new StackFrame(1).GetMethod().Name);
            }
            else
            {
                StatusBar.Text = text;
                AppendLog(text, methodName);
            }
        }

        private void AppendText(string text, string logLevel, string methodName)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action<string, string, string>(AppendText), text, logLevel,
                    methodName);
            }
            else
            {
                logBox.AppendText(string.Format(
                    (string.IsNullOrEmpty(logBox.Text) ? string.Empty : Environment.NewLine) +
                    "[{0}][{2}:{1}] {3}",
                    DateTime.Now.ToString("dd-MM-yy HH:mm:ss"), logLevel,
                    methodName, text));
                Application.DoEvents();
            }
        }

        private void AppendLog(string text, string methodName = null)
        {
            AppendText(text, "INFO", methodName ?? new StackFrame(1).GetMethod().Name);
        }

        private void AppendException(string text, string methodName = null)
        {
            AppendText(text, "ERROR", methodName ?? new StackFrame(1).GetMethod().Name);
        }

        private void AppendDebug(string text, string methodName = null)
        {
            if (!DebugModeButton.IsChecked)
            {
                return;
            }
            AppendText(text, "DEBUG", methodName ?? new StackFrame(1).GetMethod().Name);
        }

        private void profilesListView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            profilesListView.SelectedItem = e.Item;
            profilesDropDownBox.SelectedItem = profilesDropDownBox.FindItemExact(profilesListView.SelectedItem[0].ToString(), true);
            RadContextMenu contextMenu = new RadContextMenu();
            RadMenuItem launchButton = new RadMenuItem
            {
                Text = _configuration.Localization.Launch
            };
            launchButton.Click += delegate
            {
                LaunchButton.PerformClick();
            };
            RadMenuItem moveUpButton = new RadMenuItem
            {
                Text = _configuration.Localization.MoveUp,
                Enabled = profilesListView.SelectedIndex != 0
            };
            moveUpButton.Click += delegate
            {
                _profileManager.MoveDownProfile(_profileManager.GetProfile(profilesDropDownBox.SelectedItem.Text));
                SaveProfiles();
                UpdateProfileList();
            };
            RadMenuItem moveDownButton = new RadMenuItem
            {
                Text = _configuration.Localization.MoveDown,
                Enabled = profilesListView.SelectedIndex != profilesListView.Items.Count - 1
            };
            moveDownButton.Click += delegate
            {
                _profileManager.MoveUpProfile(_profileManager.GetProfile(profilesDropDownBox.SelectedItem.Text));
                SaveProfiles();
                UpdateProfileList();
            };
            RadMenuItem deleteButton = new RadMenuItem
            {
                Text = _configuration.Localization.Delete,
                Enabled = profilesListView.Items.Count > 1
            };
            deleteButton.Click += delegate
            {
                DeleteProfileButton.PerformClick();
            };
            RadMenuItem editButton = new RadMenuItem
            {
                Text = _configuration.Localization.EditProfileButtonText
            };
            editButton.Click += delegate
            {
                EditProfileButton.PerformClick();
            };
            contextMenu.Items.Add(launchButton);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(moveUpButton);
            contextMenu.Items.Add(moveDownButton);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(deleteButton);
            contextMenu.Items.Add(editButton);
            new RadContextMenuManager().SetRadContextMenu(profilesListView, contextMenu);
        }

        private void CheckLauncherUpdates()
        {
            if (!_cfg.CheckLauncherUpdates)
            {
                return;
            }
            AppendLog("Checking for launcher updates...");
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                WebClient wc = new WebClient();
                wc.Headers.Add("User-Agent", "request");
                GitHubRelease latest = JsonConvert.DeserializeObject<GitHubRelease>(wc.DownloadString(new Uri("https://api.github.com/repos/dommilosz/MLauncher/releases/latest")));
                string latestVersion = latest.Tag.Substring(1, latest.Tag.Length - 1),
                       currentVersion = Assembly.GetEntryAssembly().GetName().Version.ToString().Substring(0, Assembly.GetEntryAssembly().GetName().Version.ToString().LastIndexOf(".", StringComparison.Ordinal));
                AppendLog($"Current version: {currentVersion}");
                AppendLog($"Latest version: {latestVersion}");
                if (System.Version.Parse(currentVersion) >= System.Version.Parse(latestVersion))
                {
                    AppendLog("No update found.");
                    return;
                }
                AppendLog("Found update.");
                UpdateForm updateForm = new UpdateForm(latest, _configuration);
                updateForm.ShowDialog();
                CheckUpdatesCheckBox.Checked = updateForm.autocheckCheckBox.Checked;
            }
            catch (Exception ex)
            {
                AppendException($"Unable to check for launcher updates. Exception:{Environment.NewLine}{ex}");
            }
        }

        private void RadListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LaunchButton_Click(sender, new EventArgs());
        }

        private void RadListView1_MouseClick(object sender, MouseEventArgs e)
        {
            profilesDropDownBox.SelectedIndex = radListView1.SelectedIndex;
        }

        private void RadListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            profilesDropDownBox.SelectedIndex = radListView1.SelectedIndex;
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {

            string searchQuery = radTextBox1.Text;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                HtmlAgilityPack.HtmlWeb htmlWeb = new HtmlAgilityPack.HtmlWeb();
                // unpopulate listview
                imageList1.Images.Clear();
                radListView2.Items.Clear();
                // get data from web
                var page = htmlWeb.Load("https://www.curseforge.com/minecraft/mc-mods/search?search=" + Uri.EscapeDataString(searchQuery));
                var imageNodes = page.DocumentNode.SelectNodes("/html/body/div[1]/main/div[1]/div[3]/ul/div/div/div/div[1]/div[1]/div/a/img");
                var linkNodes = page.DocumentNode.SelectNodes("/html/body/div[1]/main/div[1]/div[3]/ul/div/div/div/div[2]/div[1]/a[1]");

                // check if there are any search results
                if (imageNodes != null)
                {

                    // populate listview
                    for (int i = 0; i < imageNodes.Count; i++)
                    {
                        var imageNode = imageNodes[i];
                        var url = imageNode.Attributes["src"].Value;
                        // download associated image
                        using (var wc = new WebClient())
                        {
                            using (var ms = new MemoryStream(wc.DownloadData(url)))
                            {
                                using (var img = Image.FromStream(ms))
                                {
                                    // add items
                                    imageList1.Images.Add(i.ToString(), img);
                                    var linkNode = linkNodes[i];
                                    var listViewItem = new ListViewItem(WebUtility.HtmlDecode(linkNode.InnerText), i);
                                    var listViewItem2 = new RadListDataItem(WebUtility.HtmlDecode(linkNode.InnerText), i.ToString());
                                    listViewItem.ToolTipText = linkNode.Attributes["href"].Value;
                                    radListView2.Items.Add(listViewItem2);
                                    radListView2.Items[i].ImageIndex = i;
                                }
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("No search results for query: \"" + searchQuery + "\"", "Curseforge Scraper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            radListView2.SelectedIndex = 0;
        }
    }

    internal class MinecraftProcess
    {
        private readonly LauncherForm _launcherForm;
        private readonly Profile _profile;
        private readonly Process _minecraftProcess;
        private LauncherFormOutput _output;
        private readonly StringBuilder _outputInfoBuilder;
        private readonly StringBuilder _outputErrorBuilder;

        public MinecraftProcess(Process minecraftProcess, LauncherForm launcherForm, Profile profile)
        {
            _launcherForm = launcherForm;
            _profile = profile;
            _minecraftProcess = minecraftProcess;
            _outputInfoBuilder = new StringBuilder();
            _outputErrorBuilder = new StringBuilder();
        }

        public void Launch()
        {
            if (_profile.LauncherVisibilityOnGameClose != Profile.LauncherVisibility.CLOSED)
            {
                _output = _launcherForm.AddOutputPage();
                _output.KillButton.Click += KillProcessButton_Click;
                _minecraftProcess.Exited += MinecraftProcess_Exited;
                if (_launcherForm.EnableMinecraftLogging.Checked)
                {
                    _minecraftProcess.OutputDataReceived +=
                        (sender, args) =>
                        {
                            lock (this)
                            {
                                _outputInfoBuilder.Append(
                                    $"{(_outputInfoBuilder.Length == 0 ? string.Empty : Environment.NewLine)}[O] {args.Data}");
                            }
                        };
                }
                else
                {
                    AppendLog($"NOTICE:{Environment.NewLine}Logging from [O]UTPUT thread has been disabled. It can be enabled in the Settings.{Environment.NewLine}{Environment.NewLine}");
                }
                _minecraftProcess.ErrorDataReceived +=
                    (sender, args) =>
                    {
                        lock (this)
                        {
                            _outputErrorBuilder.Append(
                                $"{(_outputErrorBuilder.Length == 0 ? string.Empty : Environment.NewLine)}[E] {args.Data}");
                        }
                    };
            }
            _minecraftProcess.Start();
            if (_profile.LauncherVisibilityOnGameClose == Profile.LauncherVisibility.CLOSED)
            {
                _launcherForm.Close();
                return;
            }
            _minecraftProcess.BeginOutputReadLine();
            _minecraftProcess.BeginErrorReadLine();
            new Thread(() =>
            {
                while (!_minecraftProcess.HasExited || _outputInfoBuilder.Length != 0 || _outputErrorBuilder.Length != 0)
                {
                    if (_output.Panel.Disposing || _output.Panel.IsDisposed)
                    {
                        break;
                    }
                    _output.Panel?.Invoke((MethodInvoker)delegate
                    {
                        _output.Panel.Text = $"Minecraft version: {_output.McVersion}/{_output.McType}" +
                            "\nStatus: " +
                            (!_minecraftProcess.HasExited ? "Running" : "Stopped, printing output");
                        Application.DoEvents();
                        if (_outputInfoBuilder.Length > 0)
                        {
                            AppendLog(_outputInfoBuilder.ToString());
                            _outputInfoBuilder.Clear();
                        }
                        if (_outputErrorBuilder.Length > 0)
                        {
                            AppendLog(_outputErrorBuilder.ToString(), true);
                            _outputErrorBuilder.Clear();
                        }
                    });
                    Thread.Sleep(1);
                }
                if (_minecraftProcess.HasExited)
                {
                    PrintExitInfo();
                }
            })
            {
                IsBackground = true
            }.Start();
            if (_profile.LauncherVisibilityOnGameClose == Profile.LauncherVisibility.HIDDEN)
            {
                _launcherForm.Hide();
            }
        }

        private void KillProcessButton_Click(object sender, EventArgs e)
        {
            _minecraftProcess.Kill();
        }

        private void MinecraftProcess_Exited(object sender, EventArgs e)
        {
            if (_profile.LauncherVisibilityOnGameClose == Profile.LauncherVisibility.HIDDEN)
            {
                _launcherForm.Invoke((MethodInvoker)(() => _launcherForm.Show()));
            }
            _launcherForm.Invoke((MethodInvoker)delegate
            {
                _output.KillButton.Enabled = false;
                if (_launcherForm.CloseGameOutput.Checked &&
                    new[] {
                        0, -1
                    }.Contains(_minecraftProcess.ExitCode))
                {
                    _output.CloseButton.PerformClick();
                }
            });
        }

        private void PrintExitInfo()
        {
            if (_output.OutputBox.InvokeRequired)
            {
                _output.OutputBox.Invoke(new Action(PrintExitInfo));
            }
            else
            {
                string reason = _minecraftProcess.ExitCode == 0
                    ? "Stable closure"
                    : _minecraftProcess.ExitCode == -1
                        ? "Process killed"
                        : "Crashed";
                _output.Panel.Text = $"Minecraft version: {_output.McVersion}/{_output.McType}" +
                    "\nStatus: Stopped" +
                    $"\nExit code: {_minecraftProcess.ExitCode} (Reason: {reason})" +
                    $"\nSession duration: {_minecraftProcess.TotalProcessorTime:g}";
                _output.CloseButton.Enabled = true;
                if (new[] {
                    0, -1
                }.Contains(_minecraftProcess.ExitCode))
                {
                    return;
                }
                AppendLog(string.Empty);
                AppendLog(new string('=', 12));
                AppendLog("//Oops, seems like the game has been exited with unusual error code!");
                AppendLog("//Printing debug information right now!");
                AppendLog(string.Empty);
                AppendLog($"{Application.ProductName} {Application.ProductVersion}");
                AppendLog(string.Empty);
                AppendLog("System info:");
                AppendLog($"{new string(' ', 2)}Operating system:");
                AppendLog($"{new string(' ', 4)}OSFullName: {new ComputerInfo().OSFullName}");
                AppendLog($"{new string(' ', 4)}Build: {Environment.OSVersion.Version.Build}");
                AppendLog($"{new string(' ', 4)}Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}");
                AppendLog(
                    $"{new string(' ', 2)}Java path: '{Java.JavaInstallationPath}' ({Java.JavaBitInstallation}-bit)");
                AppendLog(string.Empty);
                AppendLog("Process info:");
                AppendLog($"{new string(' ', 2)}Minecraft version/type: {_output.McVersion}/{_output.McType}");
                AppendLog($"{new string(' ', 2)}Executable file: '{_minecraftProcess.StartInfo.FileName}'");
                AppendLog($"{new string(' ', 2)}Arguments: '{_minecraftProcess.StartInfo.Arguments}'");
                AppendLog($"{new string(' ', 2)}Exit code: {_minecraftProcess.ExitCode}");
                AppendLog(string.Empty);
                AppendLog("//Finished printing debug information");
                AppendLog(new string('=', 12));
            }
        }

        private void AppendLog(string text, bool isError = false)
        {
            if (_output.OutputBox.IsDisposed)
            {
                return;
            }
            if (_output.OutputBox.InvokeRequired)
            {
                _output.OutputBox.Invoke(new Action<string, bool>(AppendLog), text, isError);
            }
            else
            {
                Color color = isError ? Color.Red : Color.DarkSlateGray;
                string line = text + "\n";
                int start = _output.OutputBox.TextLength;
                _output.OutputBox.AppendText(line);
                int end = _output.OutputBox.TextLength;
                _output.OutputBox.Select(start, end - start);
                _output.OutputBox.SelectionColor = color;
                _output.OutputBox.SelectionLength = 0;
                _output.OutputBox.ScrollToCaret();
                Application.DoEvents();
            }
        }
    }

    public class LauncherFormOutput
    {
        public RichTextBox OutputBox { get; set; }
        public RadButton CloseButton { get; set; }
        public RadButton KillButton { get; set; }
        public RadPanel Panel { get; set; }
        public string McVersion { get; set; }
        public string McType { get; set; }
    }
}
