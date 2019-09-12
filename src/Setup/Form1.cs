using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace Setup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Download);
            t.Start();
        }
        public void Download()
        {
            try
            {
                string newzippatch = Environment.SpecialFolder.ProgramFilesX86 + @"\MLauncher\Download.zip";
                string newpatch = Environment.SpecialFolder.ProgramFilesX86 + @"\MLauncher";
                void SetProgress(int value)
                {
                    if (progressBar1.InvokeRequired)
                        progressBar1.Invoke(new Action<int>(SetProgress), value);
                    else
                        progressBar1.Value = value;
                }
                WebClient w = new WebClient();
                w.DownloadProgressChanged += (s, e) =>
                {
                    SetProgress(e.ProgressPercentage);
                };
                w.DownloadFileCompleted += (s, e) =>
                {
                    ZipFile.ExtractToDirectory(newzippatch, newpatch);
                    File.Delete(newzippatch);
                    MessageBox.Show($"MLauncher installed to {newpatch}", "Install Succes");
                };
                w.DownloadFileAsync(new Uri(@"https://github.com/dommilosz/MLauncher/releases/latest/download/Debug.zip"), newzippatch);
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Install Error"); }
        }
    }
}
