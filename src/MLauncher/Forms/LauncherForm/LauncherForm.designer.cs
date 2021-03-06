﻿using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace MLauncher.Forms
{
    partial class LauncherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem5 = new Telerik.WinControls.UI.ListViewDataItem("<html><size=12>ProfileName<br><size=9><color= #646464>MCVersion");
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem6 = new Telerik.WinControls.UI.ListViewDataItem("<html><size=12>ProfileName<br><size=9><color= #646464>MCVersion");
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem7 = new Telerik.WinControls.UI.ListViewDataItem("<html><size=12>ProfileName<br><size=9><color= #646464>MCVersion");
            Telerik.WinControls.UI.ListViewDataItem listViewDataItem8 = new Telerik.WinControls.UI.ListViewDataItem("<html><size=12>ProfileName<br><size=9><color= #646464>MCVersion");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn12 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Version");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn13 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Type");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn14 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Relase Date");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn15 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Last Update");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn16 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 5", "Assets Index");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn17 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Inherits From");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "ID");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Name");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Version");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn4 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Relase Configuration");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn5 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Launcher Visibility");
            Telerik.WinControls.UI.RadListDataItem radListDataItem7 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem9 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem10 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem8 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.mainPageView = new Telerik.WinControls.UI.RadPageView();
            this.Hotbar = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.News = new Telerik.WinControls.UI.RadPageViewPage();
            this.newsBrowser = new System.Windows.Forms.WebBrowser();
            this.navBar = new Telerik.WinControls.UI.RadPanel();
            this.BackWebButton = new Telerik.WinControls.UI.RadButton();
            this.ForwardWebButton = new Telerik.WinControls.UI.RadButton();
            this.ConsolePage = new Telerik.WinControls.UI.RadPageViewPage();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.ConsoleOptionsPanel = new Telerik.WinControls.UI.RadPanel();
            this.SetToClipboardButton = new Telerik.WinControls.UI.RadButton();
            this.DebugModeButton = new Telerik.WinControls.UI.RadToggleButton();
            this.EditVersions = new Telerik.WinControls.UI.RadPageViewPage();
            this.versionsListView = new Telerik.WinControls.UI.RadListView();
            this.EditProfiles = new Telerik.WinControls.UI.RadPageViewPage();
            this.profilesListView = new Telerik.WinControls.UI.RadListView();
            this.Mods = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.GetMods = new Telerik.WinControls.UI.RadPageViewPage();
            this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
            this.radListView2 = new Telerik.WinControls.UI.RadListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radListControl2 = new Telerik.WinControls.UI.RadListControl();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radListControl1 = new Telerik.WinControls.UI.RadListControl();
            this.AboutPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.AboutPageView = new Telerik.WinControls.UI.RadPageView();
            this.AboutPageViewPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.AboutPanel = new Telerik.WinControls.UI.RadScrollablePanel();
            this.GitHubLink = new System.Windows.Forms.LinkLabel();
            this.AboutVersion = new Telerik.WinControls.UI.RadLabel();
            this.MLauncher_lbl = new System.Windows.Forms.Label();
            this.CopyrightInfoLabel = new System.Windows.Forms.Label();
            this.LoggerGroupBox = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.CloseGameOutput = new Telerik.WinControls.UI.RadCheckBox();
            this.EnableMinecraftLogging = new Telerik.WinControls.UI.RadCheckBox();
            this.MainGroupBox = new Telerik.WinControls.UI.RadGroupBox();
            this.CheckUpdatesCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.DownloadAssetsBox = new Telerik.WinControls.UI.RadCheckBox();
            this.ThemeDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.LangDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.PartnersLabel = new Telerik.WinControls.UI.RadLabel();
            this.gitURL = new System.Windows.Forms.Label();
            this.DevInfoLabel = new System.Windows.Forms.Label();
            this.ruMcURL = new System.Windows.Forms.Label();
            this.GratitudesDescLabel = new System.Windows.Forms.Label();
            this.GratitudesLabel = new Telerik.WinControls.UI.RadLabel();
            this.LicensesPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.licensePageView = new Telerik.WinControls.UI.RadPageView();
            this.MLauncherLicense = new Telerik.WinControls.UI.RadPageViewPage();
            this.MLauncherLicenseText = new Telerik.WinControls.UI.RadLabel();
            this.dotMCLauncherLicense = new Telerik.WinControls.UI.RadPageViewPage();
            this.dotMCLauncherLicenseText = new Telerik.WinControls.UI.RadLabel();
            this.StatusBar = new Telerik.WinControls.UI.RadProgressBar();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.aquaTheme1 = new Telerik.WinControls.Themes.AquaTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.crystalTheme1 = new Telerik.WinControls.Themes.CrystalTheme();
            this.crystalDarkTheme1 = new Telerik.WinControls.Themes.CrystalDarkTheme();
            this.desertTheme1 = new Telerik.WinControls.Themes.DesertTheme();
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            this.fluentDarkTheme1 = new Telerik.WinControls.Themes.FluentDarkTheme();
            this.highContrastBlackTheme1 = new Telerik.WinControls.Themes.HighContrastBlackTheme();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.materialPinkTheme1 = new Telerik.WinControls.Themes.MaterialPinkTheme();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.office2007BlackTheme1 = new Telerik.WinControls.Themes.Office2007BlackTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.office2010BlackTheme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.object_d04bbd82_0879_4d0c_8dbd_d5b9ad368291 = new Telerik.WinControls.RootRadElement();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.DeleteProfileButton = new Telerik.WinControls.UI.RadButton();
            this.ManageUsersButton = new Telerik.WinControls.UI.RadButton();
            this.NicknameDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.SelectedVersion = new System.Windows.Forms.Label();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.LaunchButton = new Telerik.WinControls.UI.RadButton();
            this.profilesDropDownBox = new Telerik.WinControls.UI.RadDropDownList();
            this.EditProfileButton = new Telerik.WinControls.UI.RadButton();
            this.AddProfile = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).BeginInit();
            this.mainPageView.SuspendLayout();
            this.Hotbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            this.News.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.navBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackWebButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardWebButton)).BeginInit();
            this.ConsolePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleOptionsPanel)).BeginInit();
            this.ConsoleOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetToClipboardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugModeButton)).BeginInit();
            this.EditVersions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.versionsListView)).BeginInit();
            this.EditProfiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilesListView)).BeginInit();
            this.Mods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.GetMods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl2)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).BeginInit();
            this.AboutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutPageView)).BeginInit();
            this.AboutPageView.SuspendLayout();
            this.AboutPageViewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutPanel)).BeginInit();
            this.AboutPanel.PanelContainer.SuspendLayout();
            this.AboutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggerGroupBox)).BeginInit();
            this.LoggerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseGameOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableMinecraftLogging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroupBox)).BeginInit();
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckUpdatesCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadAssetsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThemeDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LangDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnersLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GratitudesLabel)).BeginInit();
            this.LicensesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.licensePageView)).BeginInit();
            this.licensePageView.SuspendLayout();
            this.MLauncherLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MLauncherLicenseText)).BeginInit();
            this.dotMCLauncherLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotMCLauncherLicenseText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteProfileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageUsersButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NicknameDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaunchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesDropDownBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditProfileButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPageView
            // 
            this.mainPageView.Controls.Add(this.Hotbar);
            this.mainPageView.Controls.Add(this.News);
            this.mainPageView.Controls.Add(this.ConsolePage);
            this.mainPageView.Controls.Add(this.EditVersions);
            this.mainPageView.Controls.Add(this.EditProfiles);
            this.mainPageView.Controls.Add(this.Mods);
            this.mainPageView.Controls.Add(this.AboutPage);
            this.mainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPageView.Location = new System.Drawing.Point(0, 0);
            this.mainPageView.Name = "mainPageView";
            this.mainPageView.SelectedPage = this.AboutPage;
            this.mainPageView.Size = new System.Drawing.Size(858, 363);
            this.mainPageView.TabIndex = 2;
            this.mainPageView.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.mainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // Hotbar
            // 
            this.Hotbar.Controls.Add(this.radLabel2);
            this.Hotbar.Controls.Add(this.radListView1);
            this.Hotbar.Controls.Add(this.pictureBox1);
            this.Hotbar.ItemSize = new System.Drawing.SizeF(43F, 24F);
            this.Hotbar.Location = new System.Drawing.Point(5, 30);
            this.Hotbar.Name = "Hotbar";
            this.Hotbar.Size = new System.Drawing.Size(848, 328);
            this.Hotbar.Text = "Home";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radLabel2.ForeColor = System.Drawing.Color.Gray;
            this.radLabel2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLabel2.Location = new System.Drawing.Point(664, 9);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(180, 29);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLabel2.ThemeName = "VisualStudio2012Dark";
            // 
            // radListView1
            // 
            this.radListView1.AllowColumnReorder = false;
            this.radListView1.AllowColumnResize = false;
            this.radListView1.AllowEdit = false;
            this.radListView1.AllowRemove = false;
            this.radListView1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radListView1.FullRowSelect = false;
            listViewDataItem5.BorderColor = System.Drawing.Color.CornflowerBlue;
            listViewDataItem5.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            listViewDataItem5.Text = "<html><size=12>ProfileName<br><size=9><color= #646464>MCVersion";
            listViewDataItem5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            listViewDataItem6.BorderColor = System.Drawing.Color.CornflowerBlue;
            listViewDataItem6.Text = "<html><size=12>ProfileName<br><size=9><color= #646464>MCVersion";
            listViewDataItem6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            listViewDataItem7.BorderColor = System.Drawing.Color.CornflowerBlue;
            listViewDataItem7.Text = "<html><size=12>ProfileName<br><size=9><color= #646464>MCVersion";
            listViewDataItem7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            listViewDataItem8.BorderColor = System.Drawing.Color.CornflowerBlue;
            listViewDataItem8.Text = "<html><size=12>ProfileName<br><size=9><color= #646464>MCVersion";
            listViewDataItem8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radListView1.Items.AddRange(new Telerik.WinControls.UI.ListViewDataItem[] {
            listViewDataItem5,
            listViewDataItem6,
            listViewDataItem7,
            listViewDataItem8});
            this.radListView1.ItemSize = new System.Drawing.Size(200, 64);
            this.radListView1.ItemSpacing = 10;
            this.radListView1.Location = new System.Drawing.Point(10, 9);
            this.radListView1.Name = "radListView1";
            this.radListView1.Size = new System.Drawing.Size(626, 322);
            this.radListView1.TabIndex = 0;
            this.radListView1.ThemeName = "VisualStudio2012Dark";
            this.radListView1.ViewType = Telerik.WinControls.UI.ListViewType.IconsView;
            this.radListView1.SelectedIndexChanged += new System.EventHandler(this.RadListView1_SelectedIndexChanged);
            this.radListView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RadListView1_MouseClick);
            this.radListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RadListView1_MouseDoubleClick);
            // 
            // News
            // 
            this.News.Controls.Add(this.newsBrowser);
            this.News.Controls.Add(this.navBar);
            this.News.ItemSize = new System.Drawing.SizeF(43F, 24F);
            this.News.Location = new System.Drawing.Point(5, 30);
            this.News.Name = "News";
            this.News.Size = new System.Drawing.Size(848, 328);
            this.News.Text = "NEWS";
            // 
            // newsBrowser
            // 
            this.newsBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsBrowser.Location = new System.Drawing.Point(0, 0);
            this.newsBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.newsBrowser.Name = "newsBrowser";
            this.newsBrowser.ScriptErrorsSuppressed = true;
            this.newsBrowser.Size = new System.Drawing.Size(848, 299);
            this.newsBrowser.TabIndex = 0;
            this.newsBrowser.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.newsBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.newsBrowser_Navigated);
            this.newsBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.newsBrowser_Navigating);
            // 
            // navBar
            // 
            this.navBar.Controls.Add(this.BackWebButton);
            this.navBar.Controls.Add(this.ForwardWebButton);
            this.navBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navBar.Location = new System.Drawing.Point(0, 299);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(848, 29);
            this.navBar.TabIndex = 1;
            this.navBar.ThemeName = "VisualStudio2012Dark";
            this.navBar.Visible = false;
            // 
            // BackWebButton
            // 
            this.BackWebButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackWebButton.Location = new System.Drawing.Point(715, 3);
            this.BackWebButton.Name = "BackWebButton";
            this.BackWebButton.Size = new System.Drawing.Size(64, 23);
            this.BackWebButton.TabIndex = 1;
            this.BackWebButton.Text = "<";
            this.BackWebButton.ThemeName = "VisualStudio2012Dark";
            this.BackWebButton.Click += new System.EventHandler(this.backWebButton_Click);
            // 
            // ForwardWebButton
            // 
            this.ForwardWebButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ForwardWebButton.Location = new System.Drawing.Point(779, 3);
            this.ForwardWebButton.Name = "ForwardWebButton";
            this.ForwardWebButton.Size = new System.Drawing.Size(64, 23);
            this.ForwardWebButton.TabIndex = 0;
            this.ForwardWebButton.Text = ">";
            this.ForwardWebButton.ThemeName = "VisualStudio2012Dark";
            this.ForwardWebButton.Click += new System.EventHandler(this.forwardWebButton_Click);
            // 
            // ConsolePage
            // 
            this.ConsolePage.Controls.Add(this.logBox);
            this.ConsolePage.Controls.Add(this.ConsoleOptionsPanel);
            this.ConsolePage.ItemSize = new System.Drawing.SizeF(62F, 24F);
            this.ConsolePage.Location = new System.Drawing.Point(5, 30);
            this.ConsolePage.Name = "ConsolePage";
            this.ConsolePage.Size = new System.Drawing.Size(848, 328);
            this.ConsolePage.Text = "CONSOLE";
            // 
            // logBox
            // 
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(848, 299);
            this.logBox.TabIndex = 1;
            this.logBox.Text = "";
            this.logBox.TextChanged += new System.EventHandler(this.logBox_TextChanged);
            // 
            // ConsoleOptionsPanel
            // 
            this.ConsoleOptionsPanel.Controls.Add(this.SetToClipboardButton);
            this.ConsoleOptionsPanel.Controls.Add(this.DebugModeButton);
            this.ConsoleOptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConsoleOptionsPanel.Location = new System.Drawing.Point(0, 299);
            this.ConsoleOptionsPanel.Name = "ConsoleOptionsPanel";
            this.ConsoleOptionsPanel.Size = new System.Drawing.Size(848, 29);
            this.ConsoleOptionsPanel.TabIndex = 2;
            this.ConsoleOptionsPanel.ThemeName = "VisualStudio2012Dark";
            // 
            // SetToClipboardButton
            // 
            this.SetToClipboardButton.Location = new System.Drawing.Point(7, 3);
            this.SetToClipboardButton.Name = "SetToClipboardButton";
            this.SetToClipboardButton.Size = new System.Drawing.Size(131, 23);
            this.SetToClipboardButton.TabIndex = 1;
            this.SetToClipboardButton.Text = "Copy To Clipboard";
            this.SetToClipboardButton.ThemeName = "VisualStudio2012Dark";
            this.SetToClipboardButton.Click += new System.EventHandler(this.SetToClipboardButton_Click);
            // 
            // DebugModeButton
            // 
            this.DebugModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugModeButton.Location = new System.Drawing.Point(710, 3);
            this.DebugModeButton.Name = "DebugModeButton";
            this.DebugModeButton.Size = new System.Drawing.Size(131, 23);
            this.DebugModeButton.TabIndex = 0;
            this.DebugModeButton.Text = "Debug Mode";
            this.DebugModeButton.ThemeName = "VisualStudio2012Dark";
            // 
            // EditVersions
            // 
            this.EditVersions.Controls.Add(this.versionsListView);
            this.EditVersions.ItemSize = new System.Drawing.SizeF(123F, 24F);
            this.EditVersions.Location = new System.Drawing.Point(5, 30);
            this.EditVersions.Name = "EditVersions";
            this.EditVersions.Size = new System.Drawing.Size(848, 328);
            this.EditVersions.Text = "BUILDS MANAGMENT";
            // 
            // versionsListView
            // 
            this.versionsListView.AllowColumnReorder = false;
            this.versionsListView.AllowColumnResize = false;
            this.versionsListView.AllowEdit = false;
            this.versionsListView.AllowRemove = false;
            this.versionsListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.versionsListView.CheckOnClickMode = Telerik.WinControls.UI.CheckOnClickMode.FirstClick;
            listViewDetailColumn12.HeaderText = "Version";
            listViewDetailColumn12.Width = 150F;
            listViewDetailColumn13.HeaderText = "Type";
            listViewDetailColumn13.Width = 100F;
            listViewDetailColumn14.HeaderText = "Relase Date";
            listViewDetailColumn14.Width = 150F;
            listViewDetailColumn15.HeaderText = "Last Update";
            listViewDetailColumn15.Width = 150F;
            listViewDetailColumn16.HeaderText = "Assets Index";
            listViewDetailColumn16.Width = 120F;
            listViewDetailColumn17.HeaderText = "Inherits From";
            listViewDetailColumn17.Width = 100F;
            this.versionsListView.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn12,
            listViewDetailColumn13,
            listViewDetailColumn14,
            listViewDetailColumn15,
            listViewDetailColumn16,
            listViewDetailColumn17});
            this.versionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionsListView.EnableColumnSort = true;
            this.versionsListView.EnableFiltering = true;
            this.versionsListView.EnableSorting = true;
            this.versionsListView.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
            this.versionsListView.ItemSpacing = -1;
            this.versionsListView.Location = new System.Drawing.Point(0, 0);
            this.versionsListView.Name = "versionsListView";
            this.versionsListView.SelectLastAddedItem = false;
            this.versionsListView.ShowItemToolTips = false;
            this.versionsListView.Size = new System.Drawing.Size(848, 328);
            this.versionsListView.TabIndex = 0;
            this.versionsListView.ThemeName = "VisualStudio2012Dark";
            this.versionsListView.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.versionsListView.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.versionsListView.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.versionsListView_ItemMouseClick);
            // 
            // EditProfiles
            // 
            this.EditProfiles.Controls.Add(this.profilesListView);
            this.EditProfiles.ItemSize = new System.Drawing.SizeF(134F, 24F);
            this.EditProfiles.Location = new System.Drawing.Point(5, 30);
            this.EditProfiles.Name = "EditProfiles";
            this.EditProfiles.Size = new System.Drawing.Size(848, 328);
            this.EditProfiles.Text = "PROFILES MANAGMENT";
            // 
            // profilesListView
            // 
            this.profilesListView.AllowColumnReorder = false;
            this.profilesListView.AllowColumnResize = false;
            this.profilesListView.AllowEdit = false;
            this.profilesListView.AllowRemove = false;
            this.profilesListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.profilesListView.CheckOnClickMode = Telerik.WinControls.UI.CheckOnClickMode.FirstClick;
            listViewDetailColumn1.HeaderText = "ID";
            listViewDetailColumn2.HeaderText = "Name";
            listViewDetailColumn3.HeaderText = "Version";
            listViewDetailColumn4.HeaderText = "Relase Configuration";
            listViewDetailColumn5.HeaderText = "Launcher Visibility";
            this.profilesListView.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3,
            listViewDetailColumn4,
            listViewDetailColumn5});
            this.profilesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilesListView.EnableColumnSort = true;
            this.profilesListView.EnableFiltering = true;
            this.profilesListView.EnableSorting = true;
            this.profilesListView.ItemSpacing = -1;
            this.profilesListView.Location = new System.Drawing.Point(0, 0);
            this.profilesListView.Name = "profilesListView";
            this.profilesListView.SelectLastAddedItem = false;
            this.profilesListView.ShowItemToolTips = false;
            this.profilesListView.Size = new System.Drawing.Size(848, 328);
            this.profilesListView.TabIndex = 1;
            this.profilesListView.ThemeName = "VisualStudio2012Dark";
            this.profilesListView.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.profilesListView.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.profilesListView.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.profilesListView_ItemMouseClick);
            // 
            // Mods
            // 
            this.Mods.Controls.Add(this.radPageView1);
            this.Mods.ItemSize = new System.Drawing.SizeF(75F, 24F);
            this.Mods.Location = new System.Drawing.Point(5, 30);
            this.Mods.Name = "Mods";
            this.Mods.Size = new System.Drawing.Size(848, 328);
            this.Mods.Text = "MODS [WIP]";
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.GetMods);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.GetMods;
            this.radPageView1.Size = new System.Drawing.Size(848, 328);
            this.radPageView1.TabIndex = 3;
            this.radPageView1.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // GetMods
            // 
            this.GetMods.Controls.Add(this.radDropDownList1);
            this.GetMods.Controls.Add(this.radListView2);
            this.GetMods.Controls.Add(this.radButton1);
            this.GetMods.Controls.Add(this.radTextBox1);
            this.GetMods.Controls.Add(this.radGroupBox1);
            this.GetMods.ItemSize = new System.Drawing.SizeF(40F, 24F);
            this.GetMods.Location = new System.Drawing.Point(5, 30);
            this.GetMods.Name = "GetMods";
            this.GetMods.Size = new System.Drawing.Size(838, 293);
            this.GetMods.Text = "Mods";
            // 
            // radDropDownList1
            // 
            this.radDropDownList1.Location = new System.Drawing.Point(189, 2);
            this.radDropDownList1.Name = "radDropDownList1";
            this.radDropDownList1.NullText = "Select Modpack";
            this.radDropDownList1.Size = new System.Drawing.Size(125, 24);
            this.radDropDownList1.TabIndex = 0;
            this.radDropDownList1.ThemeName = "VisualStudio2012Dark";
            // 
            // radListView2
            // 
            this.radListView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radListView2.ImageList = this.imageList1;
            this.radListView2.ItemSize = new System.Drawing.Size(200, 75);
            this.radListView2.Location = new System.Drawing.Point(183, 33);
            this.radListView2.Name = "radListView2";
            this.radListView2.Size = new System.Drawing.Size(655, 260);
            this.radListView2.TabIndex = 13;
            this.radListView2.ThemeName = "VisualStudio2012Dark";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(506, 1);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(70, 24);
            this.radButton1.TabIndex = 12;
            this.radButton1.Text = "Search";
            this.radButton1.ThemeName = "VisualStudio2012Dark";
            this.radButton1.Click += new System.EventHandler(this.RadButton1_Click);
            // 
            // radTextBox1
            // 
            this.radTextBox1.Location = new System.Drawing.Point(320, 1);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.NullText = "Search";
            this.radTextBox1.Size = new System.Drawing.Size(180, 24);
            this.radTextBox1.TabIndex = 10;
            this.radTextBox1.ThemeName = "VisualStudio2012Dark";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radListControl2);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radGroupBox1.HeaderText = "Installed Mods";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(183, 293);
            this.radGroupBox1.TabIndex = 11;
            this.radGroupBox1.Text = "Installed Mods";
            this.radGroupBox1.ThemeName = "VisualStudio2012Dark";
            // 
            // radListControl2
            // 
            this.radListControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            radListDataItem7.Text = "Optifine xD";
            radListDataItem9.Text = "No Minecraft Mod";
            radListDataItem10.Text = "Do you really read this?";
            this.radListControl2.Items.Add(radListDataItem7);
            this.radListControl2.Items.Add(radListDataItem9);
            this.radListControl2.Items.Add(radListDataItem10);
            this.radListControl2.Location = new System.Drawing.Point(2, 18);
            this.radListControl2.Name = "radListControl2";
            this.radListControl2.Size = new System.Drawing.Size(179, 273);
            this.radListControl2.TabIndex = 2;
            this.radListControl2.ThemeName = "VisualStudio2012Dark";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.radButton2);
            this.radPageViewPage2.Controls.Add(this.radGroupBox2);
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(64F, 24F);
            this.radPageViewPage2.Location = new System.Drawing.Point(5, 30);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(838, 293);
            this.radPageViewPage2.Text = "Modpacks";
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(206, 0);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 13;
            this.radButton2.Text = "Create New";
            this.radButton2.ThemeName = "VisualStudio2012Dark";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radListControl1);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radGroupBox2.HeaderText = "Installed Modpacks";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(200, 293);
            this.radGroupBox2.TabIndex = 12;
            this.radGroupBox2.Text = "Installed Modpacks";
            this.radGroupBox2.ThemeName = "VisualStudio2012Dark";
            // 
            // radListControl1
            // 
            this.radListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            radListDataItem1.Text = "Optifine xD";
            radListDataItem2.Text = "No Minecraft Mod";
            radListDataItem3.Text = "Do you really read this?";
            this.radListControl1.Items.Add(radListDataItem1);
            this.radListControl1.Items.Add(radListDataItem2);
            this.radListControl1.Items.Add(radListDataItem3);
            this.radListControl1.Location = new System.Drawing.Point(2, 18);
            this.radListControl1.Name = "radListControl1";
            this.radListControl1.Size = new System.Drawing.Size(196, 273);
            this.radListControl1.TabIndex = 2;
            this.radListControl1.ThemeName = "VisualStudio2012Dark";
            // 
            // AboutPage
            // 
            this.AboutPage.Controls.Add(this.AboutPageView);
            this.AboutPage.ItemSize = new System.Drawing.SizeF(48F, 24F);
            this.AboutPage.Location = new System.Drawing.Point(5, 30);
            this.AboutPage.Name = "AboutPage";
            this.AboutPage.Size = new System.Drawing.Size(848, 328);
            this.AboutPage.Text = "ABOUT";
            // 
            // AboutPageView
            // 
            this.AboutPageView.Controls.Add(this.AboutPageViewPage);
            this.AboutPageView.Controls.Add(this.LicensesPage);
            this.AboutPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutPageView.Location = new System.Drawing.Point(0, 0);
            this.AboutPageView.Name = "AboutPageView";
            this.AboutPageView.SelectedPage = this.AboutPageViewPage;
            this.AboutPageView.Size = new System.Drawing.Size(848, 328);
            this.AboutPageView.TabIndex = 9;
            this.AboutPageView.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.AboutPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.AboutPageView.GetChildAt(0))).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Center;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.AboutPageView.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.AboutPageView.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
            // 
            // AboutPageViewPage
            // 
            this.AboutPageViewPage.Controls.Add(this.AboutPanel);
            this.AboutPageViewPage.ItemSize = new System.Drawing.SizeF(418F, 24F);
            this.AboutPageViewPage.Location = new System.Drawing.Point(5, 5);
            this.AboutPageViewPage.Name = "AboutPageViewPage";
            this.AboutPageViewPage.Size = new System.Drawing.Size(838, 293);
            this.AboutPageViewPage.Text = "ABOUT";
            // 
            // AboutPanel
            // 
            this.AboutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutPanel.Location = new System.Drawing.Point(0, 0);
            this.AboutPanel.Name = "AboutPanel";
            // 
            // AboutPanel.PanelContainer
            // 
            this.AboutPanel.PanelContainer.Controls.Add(this.GitHubLink);
            this.AboutPanel.PanelContainer.Controls.Add(this.AboutVersion);
            this.AboutPanel.PanelContainer.Controls.Add(this.MLauncher_lbl);
            this.AboutPanel.PanelContainer.Controls.Add(this.CopyrightInfoLabel);
            this.AboutPanel.PanelContainer.Controls.Add(this.LoggerGroupBox);
            this.AboutPanel.PanelContainer.Controls.Add(this.MainGroupBox);
            this.AboutPanel.PanelContainer.Controls.Add(this.PartnersLabel);
            this.AboutPanel.PanelContainer.Controls.Add(this.gitURL);
            this.AboutPanel.PanelContainer.Controls.Add(this.DevInfoLabel);
            this.AboutPanel.PanelContainer.Controls.Add(this.ruMcURL);
            this.AboutPanel.PanelContainer.Controls.Add(this.GratitudesDescLabel);
            this.AboutPanel.PanelContainer.Controls.Add(this.GratitudesLabel);
            this.AboutPanel.PanelContainer.Size = new System.Drawing.Size(836, 291);
            this.AboutPanel.Size = new System.Drawing.Size(838, 293);
            this.AboutPanel.TabIndex = 9;
            this.AboutPanel.ThemeName = "VisualStudio2012Dark";
            // 
            // GitHubLink
            // 
            this.GitHubLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(105)))), ((int)(((byte)(175)))));
            this.GitHubLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GitHubLink.AutoSize = true;
            this.GitHubLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.GitHubLink.LinkColor = System.Drawing.Color.Gray;
            this.GitHubLink.Location = new System.Drawing.Point(713, 3);
            this.GitHubLink.Name = "GitHubLink";
            this.GitHubLink.Size = new System.Drawing.Size(76, 13);
            this.GitHubLink.TabIndex = 5;
            this.GitHubLink.TabStop = true;
            this.GitHubLink.Text = "Go To Github";
            this.GitHubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.langWikiLink_LinkClicked);
            // 
            // AboutVersion
            // 
            this.AboutVersion.BackColor = System.Drawing.Color.Transparent;
            this.AboutVersion.ForeColor = System.Drawing.Color.DimGray;
            this.AboutVersion.Location = new System.Drawing.Point(122, 34);
            this.AboutVersion.MinimumSize = new System.Drawing.Size(58, 18);
            this.AboutVersion.Name = "AboutVersion";
            // 
            // 
            // 
            this.AboutVersion.RootElement.MinSize = new System.Drawing.Size(58, 18);
            this.AboutVersion.Size = new System.Drawing.Size(58, 18);
            this.AboutVersion.TabIndex = 1;
            this.AboutVersion.Text = "0.0.0.000";
            this.AboutVersion.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.AboutVersion.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.AboutVersion.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            ((Telerik.WinControls.UI.RadLabelElement)(this.AboutVersion.GetChildAt(0))).Text = "0.0.0.000";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.AboutVersion.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // MLauncher_lbl
            // 
            this.MLauncher_lbl.AutoSize = true;
            this.MLauncher_lbl.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.MLauncher_lbl.Location = new System.Drawing.Point(3, 3);
            this.MLauncher_lbl.Name = "MLauncher_lbl";
            this.MLauncher_lbl.Size = new System.Drawing.Size(148, 37);
            this.MLauncher_lbl.TabIndex = 15;
            this.MLauncher_lbl.Text = "MLauncher";
            // 
            // CopyrightInfoLabel
            // 
            this.CopyrightInfoLabel.AutoSize = true;
            this.CopyrightInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.CopyrightInfoLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyrightInfoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CopyrightInfoLabel.Location = new System.Drawing.Point(2, 254);
            this.CopyrightInfoLabel.Name = "CopyrightInfoLabel";
            this.CopyrightInfoLabel.Size = new System.Drawing.Size(438, 34);
            this.CopyrightInfoLabel.TabIndex = 14;
            this.CopyrightInfoLabel.Text = "\"Minecraft\" is a trademark of Mojang Synergies AB. All rights reserved.\r\nMojang S" +
    "ynergies AB is a subsidiary of Microsoft Studios.";
            this.CopyrightInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoggerGroupBox
            // 
            this.LoggerGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.LoggerGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.LoggerGroupBox.Controls.Add(this.radButton4);
            this.LoggerGroupBox.Controls.Add(this.radButton3);
            this.LoggerGroupBox.Controls.Add(this.CloseGameOutput);
            this.LoggerGroupBox.Controls.Add(this.EnableMinecraftLogging);
            this.LoggerGroupBox.HeaderText = "Debug";
            this.LoggerGroupBox.Location = new System.Drawing.Point(469, 147);
            this.LoggerGroupBox.Name = "LoggerGroupBox";
            this.LoggerGroupBox.Size = new System.Drawing.Size(357, 141);
            this.LoggerGroupBox.TabIndex = 13;
            this.LoggerGroupBox.Text = "Debug";
            this.LoggerGroupBox.ThemeName = "VisualStudio2012Dark";
            // 
            // radButton4
            // 
            this.radButton4.ForeColor = System.Drawing.Color.Red;
            this.radButton4.Location = new System.Drawing.Point(5, 83);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(110, 24);
            this.radButton4.TabIndex = 4;
            this.radButton4.Text = "Reset Launcher";
            this.radButton4.ThemeName = "VisualStudio2012Dark";
            this.radButton4.Click += new System.EventHandler(this.RadButton4_Click);
            // 
            // radButton3
            // 
            this.radButton3.ForeColor = System.Drawing.Color.Red;
            this.radButton3.Location = new System.Drawing.Point(121, 83);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(142, 24);
            this.radButton3.TabIndex = 3;
            this.radButton3.Text = "Delete Working Dir";
            this.radButton3.ThemeName = "VisualStudio2012Dark";
            this.radButton3.Click += new System.EventHandler(this.RadButton3_Click);
            // 
            // CloseGameOutput
            // 
            this.CloseGameOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CloseGameOutput.Location = new System.Drawing.Point(5, 45);
            this.CloseGameOutput.Name = "CloseGameOutput";
            this.CloseGameOutput.Size = new System.Drawing.Size(245, 18);
            this.CloseGameOutput.TabIndex = 2;
            this.CloseGameOutput.Text = "Close tabs automaticly if there was no errors";
            this.CloseGameOutput.ThemeName = "VisualStudio2012Dark";
            this.CloseGameOutput.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // EnableMinecraftLogging
            // 
            this.EnableMinecraftLogging.Location = new System.Drawing.Point(5, 21);
            this.EnableMinecraftLogging.Name = "EnableMinecraftLogging";
            this.EnableMinecraftLogging.Size = new System.Drawing.Size(191, 18);
            this.EnableMinecraftLogging.TabIndex = 0;
            this.EnableMinecraftLogging.Text = "Display logs from OUTPUT thread";
            this.EnableMinecraftLogging.ThemeName = "VisualStudio2012Dark";
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.MainGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.MainGroupBox.Controls.Add(this.CheckUpdatesCheckBox);
            this.MainGroupBox.Controls.Add(this.radLabel3);
            this.MainGroupBox.Controls.Add(this.radLabel4);
            this.MainGroupBox.Controls.Add(this.DownloadAssetsBox);
            this.MainGroupBox.Controls.Add(this.ThemeDropDownList);
            this.MainGroupBox.Controls.Add(this.LangDropDownList);
            this.MainGroupBox.HeaderText = "Main";
            this.MainGroupBox.Location = new System.Drawing.Point(469, 14);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(357, 134);
            this.MainGroupBox.TabIndex = 12;
            this.MainGroupBox.Text = "Main";
            this.MainGroupBox.ThemeName = "VisualStudio2012Dark";
            // 
            // CheckUpdatesCheckBox
            // 
            this.CheckUpdatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckUpdatesCheckBox.Location = new System.Drawing.Point(5, 79);
            this.CheckUpdatesCheckBox.Name = "CheckUpdatesCheckBox";
            this.CheckUpdatesCheckBox.Size = new System.Drawing.Size(160, 18);
            this.CheckUpdatesCheckBox.TabIndex = 6;
            this.CheckUpdatesCheckBox.Text = "Check for launcher updates";
            this.CheckUpdatesCheckBox.ThemeName = "VisualStudio2012Dark";
            this.CheckUpdatesCheckBox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(5, 49);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(43, 18);
            this.radLabel3.TabIndex = 7;
            this.radLabel3.Text = "Theme:";
            this.radLabel3.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel3.GetChildAt(0))).Text = "Theme:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel3.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(5, 21);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(58, 18);
            this.radLabel4.TabIndex = 5;
            this.radLabel4.Text = "Language:";
            this.radLabel4.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.radLabel4.GetChildAt(0))).Text = "Language:";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radLabel4.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // DownloadAssetsBox
            // 
            this.DownloadAssetsBox.Location = new System.Drawing.Point(5, 103);
            this.DownloadAssetsBox.Name = "DownloadAssetsBox";
            this.DownloadAssetsBox.Size = new System.Drawing.Size(130, 18);
            this.DownloadAssetsBox.TabIndex = 0;
            this.DownloadAssetsBox.Text = "Skip assets download";
            this.DownloadAssetsBox.ThemeName = "VisualStudio2012Dark";
            // 
            // ThemeDropDownList
            // 
            this.ThemeDropDownList.AutoCompleteDisplayMember = null;
            this.ThemeDropDownList.AutoCompleteValueMember = null;
            this.ThemeDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ThemeDropDownList.Location = new System.Drawing.Point(150, 49);
            this.ThemeDropDownList.Name = "ThemeDropDownList";
            this.ThemeDropDownList.Size = new System.Drawing.Size(202, 24);
            this.ThemeDropDownList.TabIndex = 6;
            this.ThemeDropDownList.ThemeName = "VisualStudio2012Dark";
            this.ThemeDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.RadDropDownList2_SelectedIndexChanged_1);
            // 
            // LangDropDownList
            // 
            this.LangDropDownList.AutoCompleteDisplayMember = null;
            this.LangDropDownList.AutoCompleteValueMember = null;
            this.LangDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem8.Tag = "en_UK";
            radListDataItem8.Text = "english";
            this.LangDropDownList.Items.Add(radListDataItem8);
            this.LangDropDownList.Location = new System.Drawing.Point(150, 21);
            this.LangDropDownList.Name = "LangDropDownList";
            this.LangDropDownList.Size = new System.Drawing.Size(202, 24);
            this.LangDropDownList.TabIndex = 3;
            this.LangDropDownList.ThemeName = "VisualStudio2012Dark";
            this.LangDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.LangDropDownList_SelectedIndexChanged);
            // 
            // PartnersLabel
            // 
            this.PartnersLabel.BackColor = System.Drawing.Color.Transparent;
            this.PartnersLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.PartnersLabel.ForeColor = System.Drawing.Color.Transparent;
            this.PartnersLabel.Location = new System.Drawing.Point(3, 147);
            this.PartnersLabel.Name = "PartnersLabel";
            this.PartnersLabel.Size = new System.Drawing.Size(140, 41);
            this.PartnersLabel.TabIndex = 10;
            this.PartnersLabel.Text = "Партнёры";
            this.PartnersLabel.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.PartnersLabel.GetChildAt(0))).Text = "Партнёры";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.PartnersLabel.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // gitURL
            // 
            this.gitURL.AutoSize = true;
            this.gitURL.BackColor = System.Drawing.Color.Transparent;
            this.gitURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gitURL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gitURL.ForeColor = System.Drawing.Color.Gray;
            this.gitURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gitURL.Location = new System.Drawing.Point(14, 72);
            this.gitURL.Name = "gitURL";
            this.gitURL.Size = new System.Drawing.Size(173, 15);
            this.gitURL.TabIndex = 5;
            this.gitURL.Text = "https://github.com/dommilosz";
            this.gitURL.Click += new System.EventHandler(this.urlLabel_Click);
            // 
            // DevInfoLabel
            // 
            this.DevInfoLabel.AutoSize = true;
            this.DevInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.DevInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.DevInfoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DevInfoLabel.Location = new System.Drawing.Point(14, 55);
            this.DevInfoLabel.Name = "DevInfoLabel";
            this.DevInfoLabel.Size = new System.Drawing.Size(157, 17);
            this.DevInfoLabel.TabIndex = 3;
            this.DevInfoLabel.Text = "Developed by dommilosz";
            // 
            // ruMcURL
            // 
            this.ruMcURL.AutoSize = true;
            this.ruMcURL.BackColor = System.Drawing.Color.Transparent;
            this.ruMcURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ruMcURL.ForeColor = System.Drawing.Color.Gray;
            this.ruMcURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ruMcURL.Location = new System.Drawing.Point(14, 135);
            this.ruMcURL.Name = "ruMcURL";
            this.ruMcURL.Size = new System.Drawing.Size(157, 13);
            this.ruMcURL.TabIndex = 8;
            this.ruMcURL.Text = "https://github.com/dedepete";
            this.ruMcURL.Click += new System.EventHandler(this.urlLabel_Click);
            // 
            // GratitudesDescLabel
            // 
            this.GratitudesDescLabel.AutoSize = true;
            this.GratitudesDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.GratitudesDescLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.GratitudesDescLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GratitudesDescLabel.Location = new System.Drawing.Point(14, 118);
            this.GratitudesDescLabel.Name = "GratitudesDescLabel";
            this.GratitudesDescLabel.Size = new System.Drawing.Size(219, 17);
            this.GratitudesDescLabel.TabIndex = 6;
            this.GratitudesDescLabel.Text = "Dedepete - Creator of FreeLauncher";
            // 
            // GratitudesLabel
            // 
            this.GratitudesLabel.BackColor = System.Drawing.Color.Transparent;
            this.GratitudesLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.GratitudesLabel.ForeColor = System.Drawing.Color.Transparent;
            this.GratitudesLabel.Location = new System.Drawing.Point(3, 81);
            this.GratitudesLabel.Name = "GratitudesLabel";
            this.GratitudesLabel.Size = new System.Drawing.Size(136, 41);
            this.GratitudesLabel.TabIndex = 7;
            this.GratitudesLabel.Text = "Thanks";
            this.GratitudesLabel.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.GratitudesLabel.GetChildAt(0))).Text = "gratitudes";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.GratitudesLabel.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // LicensesPage
            // 
            this.LicensesPage.Controls.Add(this.licensePageView);
            this.LicensesPage.ItemSize = new System.Drawing.SizeF(430F, 24F);
            this.LicensesPage.Location = new System.Drawing.Point(5, 5);
            this.LicensesPage.Name = "LicensesPage";
            this.LicensesPage.Size = new System.Drawing.Size(838, 293);
            this.LicensesPage.Text = "LICENSES";
            // 
            // licensePageView
            // 
            this.licensePageView.Controls.Add(this.MLauncherLicense);
            this.licensePageView.Controls.Add(this.dotMCLauncherLicense);
            this.licensePageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licensePageView.Location = new System.Drawing.Point(0, 0);
            this.licensePageView.Name = "licensePageView";
            this.licensePageView.SelectedPage = this.MLauncherLicense;
            this.licensePageView.Size = new System.Drawing.Size(838, 293);
            this.licensePageView.TabIndex = 0;
            this.licensePageView.ThemeName = "VisualStudio2012Dark";
            this.licensePageView.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            ((Telerik.WinControls.UI.StripViewItemContainer)(this.licensePageView.GetChildAt(0).GetChildAt(0))).MinSize = new System.Drawing.Size(150, 0);
            // 
            // MLauncherLicense
            // 
            this.MLauncherLicense.Controls.Add(this.MLauncherLicenseText);
            this.MLauncherLicense.ItemSize = new System.Drawing.SizeF(94F, 26F);
            this.MLauncherLicense.Location = new System.Drawing.Point(155, 4);
            this.MLauncherLicense.Name = "MLauncherLicense";
            this.MLauncherLicense.Size = new System.Drawing.Size(679, 285);
            this.MLauncherLicense.Text = "FreeLauncher";
            // 
            // MLauncherLicenseText
            // 
            this.MLauncherLicenseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MLauncherLicenseText.Location = new System.Drawing.Point(0, 0);
            this.MLauncherLicenseText.Name = "MLauncherLicenseText";
            this.MLauncherLicenseText.Size = new System.Drawing.Size(679, 285);
            this.MLauncherLicenseText.TabIndex = 2;
            this.MLauncherLicenseText.Text = resources.GetString("MLauncherLicenseText.Text");
            this.MLauncherLicenseText.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.MLauncherLicenseText.GetChildAt(0))).Text = resources.GetString("resource.Text");
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.MLauncherLicenseText.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // dotMCLauncherLicense
            // 
            this.dotMCLauncherLicense.AutoScroll = true;
            this.dotMCLauncherLicense.Controls.Add(this.dotMCLauncherLicenseText);
            this.dotMCLauncherLicense.ItemSize = new System.Drawing.SizeF(94F, 26F);
            this.dotMCLauncherLicense.Location = new System.Drawing.Point(155, 4);
            this.dotMCLauncherLicense.Name = "dotMCLauncherLicense";
            this.dotMCLauncherLicense.Size = new System.Drawing.Size(679, 285);
            this.dotMCLauncherLicense.Text = "dotMCLauncher";
            // 
            // dotMCLauncherLicenseText
            // 
            this.dotMCLauncherLicenseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dotMCLauncherLicenseText.Location = new System.Drawing.Point(0, 0);
            this.dotMCLauncherLicenseText.Name = "dotMCLauncherLicenseText";
            this.dotMCLauncherLicenseText.Size = new System.Drawing.Size(679, 285);
            this.dotMCLauncherLicenseText.TabIndex = 1;
            this.dotMCLauncherLicenseText.Text = resources.GetString("dotMCLauncherLicenseText.Text");
            this.dotMCLauncherLicenseText.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadLabelElement)(this.dotMCLauncherLicenseText.GetChildAt(0))).Text = resources.GetString("resource.Text1");
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.dotMCLauncherLicenseText.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Transparent;
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.Location = new System.Drawing.Point(0, 363);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(858, 24);
            this.StatusBar.TabIndex = 4;
            this.StatusBar.Text = "StatusBar";
            this.StatusBar.ThemeName = "VisualStudio2012Dark";
            this.StatusBar.Visible = false;
            // 
            // object_d04bbd82_0879_4d0c_8dbd_d5b9ad368291
            // 
            this.object_d04bbd82_0879_4d0c_8dbd_d5b9ad368291.Name = "object_d04bbd82_0879_4d0c_8dbd_d5b9ad368291";
            this.object_d04bbd82_0879_4d0c_8dbd_d5b9ad368291.StretchHorizontally = true;
            this.object_d04bbd82_0879_4d0c_8dbd_d5b9ad368291.StretchVertically = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(664, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 283);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // radPanel1
            // 
            this.radPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radPanel1.BackgroundImage")));
            this.radPanel1.Controls.Add(this.DeleteProfileButton);
            this.radPanel1.Controls.Add(this.ManageUsersButton);
            this.radPanel1.Controls.Add(this.NicknameDropDownList);
            this.radPanel1.Controls.Add(this.SelectedVersion);
            this.radPanel1.Controls.Add(this.LogoBox);
            this.radPanel1.Controls.Add(this.LaunchButton);
            this.radPanel1.Controls.Add(this.profilesDropDownBox);
            this.radPanel1.Controls.Add(this.EditProfileButton);
            this.radPanel1.Controls.Add(this.AddProfile);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 387);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(858, 59);
            this.radPanel1.TabIndex = 3;
            this.radPanel1.ThemeName = "VisualStudio2012Dark";
            // 
            // DeleteProfileButton
            // 
            this.DeleteProfileButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteProfileButton.Image")));
            this.DeleteProfileButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeleteProfileButton.Location = new System.Drawing.Point(6, 6);
            this.DeleteProfileButton.Name = "DeleteProfileButton";
            this.DeleteProfileButton.Size = new System.Drawing.Size(32, 24);
            this.DeleteProfileButton.TabIndex = 8;
            this.DeleteProfileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteProfileButton.ThemeName = "VisualStudio2012Dark";
            this.DeleteProfileButton.Click += new System.EventHandler(this.DeleteProfileButton_Click);
            // 
            // ManageUsersButton
            // 
            this.ManageUsersButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ManageUsersButton.Image = global::MLauncher.Properties.Resources.edit;
            this.ManageUsersButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ManageUsersButton.Location = new System.Drawing.Point(513, 6);
            this.ManageUsersButton.Name = "ManageUsersButton";
            this.ManageUsersButton.Size = new System.Drawing.Size(32, 24);
            this.ManageUsersButton.TabIndex = 7;
            this.ManageUsersButton.ThemeName = "VisualStudio2012Dark";
            this.ManageUsersButton.Click += new System.EventHandler(this.ManageUsersButton_Click);
            // 
            // NicknameDropDownList
            // 
            this.NicknameDropDownList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NicknameDropDownList.AutoCompleteDisplayMember = null;
            this.NicknameDropDownList.AutoCompleteValueMember = null;
            this.NicknameDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.NicknameDropDownList.Location = new System.Drawing.Point(314, 6);
            this.NicknameDropDownList.Name = "NicknameDropDownList";
            this.NicknameDropDownList.NullText = "Nick";
            this.NicknameDropDownList.Size = new System.Drawing.Size(196, 24);
            this.NicknameDropDownList.TabIndex = 3;
            this.NicknameDropDownList.ThemeName = "VisualStudio2012Dark";
            this.NicknameDropDownList.TextChanged += new System.EventHandler(this.NicknameDropDownList_TextChanged);
            this.NicknameDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.NicknameDropDownList_SelectedIndexChanged);
            // 
            // SelectedVersion
            // 
            this.SelectedVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedVersion.AutoSize = true;
            this.SelectedVersion.BackColor = System.Drawing.Color.Transparent;
            this.SelectedVersion.ForeColor = System.Drawing.Color.White;
            this.SelectedVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SelectedVersion.Location = new System.Drawing.Point(631, 42);
            this.SelectedVersion.MinimumSize = new System.Drawing.Size(220, 13);
            this.SelectedVersion.Name = "SelectedVersion";
            this.SelectedVersion.Size = new System.Drawing.Size(220, 13);
            this.SelectedVersion.TabIndex = 6;
            this.SelectedVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogoBox
            // 
            this.LogoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoBox.BackColor = System.Drawing.Color.Transparent;
            this.LogoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogoBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoBox.Image")));
            this.LogoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LogoBox.Location = new System.Drawing.Point(651, -11);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(181, 84);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 5;
            this.LogoBox.TabStop = false;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LaunchButton.Location = new System.Drawing.Point(314, 33);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(231, 22);
            this.LaunchButton.TabIndex = 4;
            this.LaunchButton.Text = "Launch The Game";
            this.LaunchButton.ThemeName = "VisualStudio2012Dark";
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // profilesDropDownBox
            // 
            this.profilesDropDownBox.AutoCompleteDisplayMember = null;
            this.profilesDropDownBox.AutoCompleteValueMember = null;
            this.profilesDropDownBox.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.profilesDropDownBox.Location = new System.Drawing.Point(41, 6);
            this.profilesDropDownBox.Name = "profilesDropDownBox";
            this.profilesDropDownBox.Size = new System.Drawing.Size(191, 24);
            this.profilesDropDownBox.TabIndex = 2;
            this.profilesDropDownBox.ThemeName = "VisualStudio2012Dark";
            this.profilesDropDownBox.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.profilesDropDownBox_SelectedIndexChanged);
            // 
            // EditProfileButton
            // 
            this.EditProfileButton.Location = new System.Drawing.Point(122, 33);
            this.EditProfileButton.Name = "EditProfileButton";
            this.EditProfileButton.Size = new System.Drawing.Size(110, 22);
            this.EditProfileButton.TabIndex = 1;
            this.EditProfileButton.Text = "Edit Profile";
            this.EditProfileButton.TextWrap = true;
            this.EditProfileButton.ThemeName = "VisualStudio2012Dark";
            this.EditProfileButton.Click += new System.EventHandler(this.EditProfile_Click);
            // 
            // AddProfile
            // 
            this.AddProfile.Location = new System.Drawing.Point(6, 33);
            this.AddProfile.Name = "AddProfile";
            this.AddProfile.Size = new System.Drawing.Size(110, 22);
            this.AddProfile.TabIndex = 0;
            this.AddProfile.Text = "Add Profile";
            this.AddProfile.TextWrap = true;
            this.AddProfile.ThemeName = "VisualStudio2012Dark";
            this.AddProfile.Click += new System.EventHandler(this.AddProfile_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 446);
            this.Controls.Add(this.mainPageView);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.radPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(712, 446);
            this.Name = "LauncherForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "MLauncher";
            this.ThemeName = "VisualStudio2012Dark";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LauncherForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).EndInit();
            this.mainPageView.ResumeLayout(false);
            this.Hotbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            this.News.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.navBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackWebButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardWebButton)).EndInit();
            this.ConsolePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConsoleOptionsPanel)).EndInit();
            this.ConsoleOptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SetToClipboardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugModeButton)).EndInit();
            this.EditVersions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.versionsListView)).EndInit();
            this.EditProfiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilesListView)).EndInit();
            this.Mods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.GetMods.ResumeLayout(false);
            this.GetMods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radListControl2)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).EndInit();
            this.AboutPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AboutPageView)).EndInit();
            this.AboutPageView.ResumeLayout(false);
            this.AboutPageViewPage.ResumeLayout(false);
            this.AboutPanel.PanelContainer.ResumeLayout(false);
            this.AboutPanel.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutPanel)).EndInit();
            this.AboutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AboutVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggerGroupBox)).EndInit();
            this.LoggerGroupBox.ResumeLayout(false);
            this.LoggerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseGameOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnableMinecraftLogging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroupBox)).EndInit();
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckUpdatesCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadAssetsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThemeDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LangDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartnersLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GratitudesLabel)).EndInit();
            this.LicensesPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.licensePageView)).EndInit();
            this.licensePageView.ResumeLayout(false);
            this.MLauncherLicense.ResumeLayout(false);
            this.MLauncherLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MLauncherLicenseText)).EndInit();
            this.dotMCLauncherLicense.ResumeLayout(false);
            this.dotMCLauncherLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotMCLauncherLicenseText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteProfileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManageUsersButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NicknameDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaunchButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesDropDownBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditProfileButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private RadPageView mainPageView;
        private RadPageViewPage News;
        private WebBrowser newsBrowser;
        private RadPanel navBar;
        private RadButton BackWebButton;
        private RadButton ForwardWebButton;
        private RadPageViewPage ConsolePage;
        public RichTextBox logBox;
        private RadPageViewPage EditVersions;
        private RadListView versionsListView;
        private RadPageViewPage AboutPage;
        private RadPageView AboutPageView;
        private RadPageViewPage AboutPageViewPage;
        private RadScrollablePanel AboutPanel;
        private RadLabel PartnersLabel;
        private RadLabel AboutVersion;
        private Label gitURL;
        private Label DevInfoLabel;
        private Label ruMcURL;
        private Label GratitudesDescLabel;
        private RadLabel GratitudesLabel;
        private RadPageViewPage LicensesPage;
        private RadPageView licensePageView;
        private RadPageViewPage dotMCLauncherLicense;
        private RadPageViewPage MLauncherLicense;
        private RadLabel dotMCLauncherLicenseText;
        private RadProgressBar StatusBar;
        private RadPanel ConsoleOptionsPanel;
        private RadToggleButton DebugModeButton;
        private RadButton SetToClipboardButton;
        private RadGroupBox LoggerGroupBox;
        public RadCheckBox CloseGameOutput;
        public RadCheckBox EnableMinecraftLogging;
        private RadGroupBox MainGroupBox;
        public RadLabel radLabel4;
        private RadDropDownList LangDropDownList;
        public RadCheckBox DownloadAssetsBox;
        private Label CopyrightInfoLabel;
        private RadLabel MLauncherLicenseText;
        private RadPageViewPage EditProfiles;
        private RadListView profilesListView;
        public RadCheckBox CheckUpdatesCheckBox;
        private RadButton AddProfile;
        private RadButton EditProfileButton;
        public RadDropDownList profilesDropDownBox;
        private RadButton LaunchButton;
        private PictureBox LogoBox;
        private Label SelectedVersion;
        public RadDropDownList NicknameDropDownList;
        private RadButton ManageUsersButton;
        private RadButton DeleteProfileButton;
        private RadPanel radPanel1;
        private RadPageViewPage Hotbar;
        private RadListView radListView1;
        private RadPageViewPage Mods;
        private ImageList imageList1;
        private RadPageView radPageView1;
        private RadPageViewPage GetMods;
        private RadListView radListView2;
        private RadButton radButton1;
        private RadTextBox radTextBox1;
        private RadGroupBox radGroupBox1;
        private RadListControl radListControl2;
        private RadPageViewPage radPageViewPage2;
        private RadButton radButton2;
        private RadGroupBox radGroupBox2;
        private RadListControl radListControl1;
        private RadDropDownList radDropDownList1;
        private RadLabel radLabel2;
        private PictureBox pictureBox1;
        public RadLabel radLabel3;
        private RadDropDownList ThemeDropDownList;
        private VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Label MLauncher_lbl;
        private LinkLabel GitHubLink;
        private AquaTheme aquaTheme1;
        private BreezeTheme breezeTheme1;
        private CrystalTheme crystalTheme1;
        private CrystalDarkTheme crystalDarkTheme1;
        private DesertTheme desertTheme1;
        private FluentTheme fluentTheme1;
        private FluentDarkTheme fluentDarkTheme1;
        private HighContrastBlackTheme highContrastBlackTheme1;
        private MaterialTheme materialTheme1;
        private MaterialBlueGreyTheme materialBlueGreyTheme1;
        private MaterialPinkTheme materialPinkTheme1;
        private MaterialTealTheme materialTealTheme1;
        private Office2007BlackTheme office2007BlackTheme1;
        private Office2007SilverTheme office2007SilverTheme1;
        private Office2010BlackTheme office2010BlackTheme1;
        private Office2010BlueTheme office2010BlueTheme1;
        private Office2010SilverTheme office2010SilverTheme1;
        private Office2013DarkTheme office2013DarkTheme1;
        private Office2013LightTheme office2013LightTheme1;
        private TelerikMetroTheme telerikMetroTheme1;
        private TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Windows7Theme windows7Theme1;
        private Windows8Theme windows8Theme1;
        private RadButton radButton4;
        private RadButton radButton3;
        private Telerik.WinControls.RootRadElement object_d04bbd82_0879_4d0c_8dbd_d5b9ad368291;
    }
}
