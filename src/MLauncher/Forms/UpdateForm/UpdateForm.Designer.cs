namespace MLauncher.Forms
{
    partial class UpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.changelogBox = new System.Windows.Forms.RichTextBox();
            this.goButton = new Telerik.WinControls.UI.RadButton();
            this.cancelButton = new Telerik.WinControls.UI.RadButton();
            this.autocheckCheckBox = new Telerik.WinControls.UI.RadCheckBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.StatusBar = new Telerik.WinControls.UI.RadProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.goButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autocheckCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // changelogBox
            // 
            this.changelogBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.changelogBox.Location = new System.Drawing.Point(0, 0);
            this.changelogBox.Name = "changelogBox";
            this.changelogBox.ReadOnly = true;
            this.changelogBox.Size = new System.Drawing.Size(636, 203);
            this.changelogBox.TabIndex = 0;
            this.changelogBox.Text = "";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(472, 232);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(152, 24);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go to GitHub";
            this.goButton.ThemeName = "VisualStudio2012Dark";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 232);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 24);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.ThemeName = "VisualStudio2012Dark";
            // 
            // autocheckCheckBox
            // 
            this.autocheckCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autocheckCheckBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.autocheckCheckBox.Location = new System.Drawing.Point(138, 235);
            this.autocheckCheckBox.Name = "autocheckCheckBox";
            this.autocheckCheckBox.Size = new System.Drawing.Size(178, 18);
            this.autocheckCheckBox.TabIndex = 7;
            this.autocheckCheckBox.Text = "Automatically check for updates";
            this.autocheckCheckBox.ThemeName = "VisualStudio2012Dark";
            this.autocheckCheckBox.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(369, 232);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(97, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Update";
            this.radButton1.ThemeName = "VisualStudio2012Dark";
            this.radButton1.Click += new System.EventHandler(this.RadButton1_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBar.Location = new System.Drawing.Point(0, 203);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(636, 24);
            this.StatusBar.TabIndex = 8;
            this.StatusBar.Text = "Downloading";
            this.StatusBar.ThemeName = "VisualStudio2012Dark";
            this.StatusBar.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 258);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.autocheckCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.changelogBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update checker";
            this.ThemeName = "VisualStudio2012Dark";
            ((System.ComponentModel.ISupportInitialize)(this.goButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autocheckCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox changelogBox;
        private Telerik.WinControls.UI.RadButton goButton;
        private Telerik.WinControls.UI.RadButton cancelButton;
        public Telerik.WinControls.UI.RadCheckBox autocheckCheckBox;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadProgressBar StatusBar;
        private System.Windows.Forms.Timer timer1;
    }
}
