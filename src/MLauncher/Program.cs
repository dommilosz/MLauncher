﻿using MLauncher.Forms;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MLauncher
{
    internal static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Configuration configuration = new Configuration(args);
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LauncherForm(configuration));
            configuration.SaveConfiguration();
        }
    }
}
