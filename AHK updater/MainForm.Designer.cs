namespace AHK_updater
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
			this.lstBHotstrings = new System.Windows.Forms.ListBox();
			this.txtHSText = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnSaveHotstringText = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnSaveFunctions = new System.Windows.Forms.Button();
			this.txtFunctions = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnSaveChangelog = new System.Windows.Forms.Button();
			this.txtChangelog = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.nyHotstringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sparaTillFilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stängToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstBHotstrings
			// 
			this.lstBHotstrings.FormattingEnabled = true;
			this.lstBHotstrings.Location = new System.Drawing.Point(6, 6);
			this.lstBHotstrings.Name = "lstBHotstrings";
			this.lstBHotstrings.Size = new System.Drawing.Size(156, 355);
			this.lstBHotstrings.TabIndex = 0;
			this.lstBHotstrings.SelectedValueChanged += new System.EventHandler(this.lstHotstrings_ValueChange);
			// 
			// txtHSText
			// 
			this.txtHSText.AcceptsTab = true;
			this.txtHSText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHSText.Location = new System.Drawing.Point(165, 6);
			this.txtHSText.Multiline = true;
			this.txtHSText.Name = "txtHSText";
			this.txtHSText.Size = new System.Drawing.Size(508, 355);
			this.txtHSText.TabIndex = 0;
			this.txtHSText.TabStop = false;
			this.txtHSText.TextChanged += new System.EventHandler(this.TxtHSText_TextChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(12, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(690, 393);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnSaveHotstringText);
			this.tabPage1.Controls.Add(this.lstBHotstrings);
			this.tabPage1.Controls.Add(this.txtHSText);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(682, 367);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Hotstrings";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnSaveHotstringText
			// 
			this.btnSaveHotstringText.Enabled = false;
			this.btnSaveHotstringText.Location = new System.Drawing.Point(632, 3);
			this.btnSaveHotstringText.Name = "btnSaveHotstringText";
			this.btnSaveHotstringText.Size = new System.Drawing.Size(41, 23);
			this.btnSaveHotstringText.TabIndex = 1;
			this.btnSaveHotstringText.Text = "Save";
			this.btnSaveHotstringText.UseVisualStyleBackColor = true;
			this.btnSaveHotstringText.Visible = false;
			this.btnSaveHotstringText.Click += new System.EventHandler(this.BtnSaveHotstringText_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnSaveFunctions);
			this.tabPage2.Controls.Add(this.txtFunctions);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(682, 367);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Functions";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnSaveFunctions
			// 
			this.btnSaveFunctions.AutoSize = true;
			this.btnSaveFunctions.Enabled = false;
			this.btnSaveFunctions.Location = new System.Drawing.Point(634, 6);
			this.btnSaveFunctions.Name = "btnSaveFunctions";
			this.btnSaveFunctions.Size = new System.Drawing.Size(42, 23);
			this.btnSaveFunctions.TabIndex = 1;
			this.btnSaveFunctions.Text = "Save";
			this.btnSaveFunctions.UseVisualStyleBackColor = true;
			this.btnSaveFunctions.Visible = false;
			this.btnSaveFunctions.Click += new System.EventHandler(this.BtnSaveFunctions_Click);
			// 
			// txtFunctions
			// 
			this.txtFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctions.Location = new System.Drawing.Point(6, 6);
			this.txtFunctions.Multiline = true;
			this.txtFunctions.Name = "txtFunctions";
			this.txtFunctions.Size = new System.Drawing.Size(670, 355);
			this.txtFunctions.TabIndex = 0;
			this.txtFunctions.TextChanged += new System.EventHandler(this.TxtFunctions_TextChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.btnSaveChangelog);
			this.tabPage3.Controls.Add(this.txtChangelog);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(682, 367);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Changelog";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// btnSaveChangelog
			// 
			this.btnSaveChangelog.AutoSize = true;
			this.btnSaveChangelog.Enabled = false;
			this.btnSaveChangelog.Location = new System.Drawing.Point(634, 6);
			this.btnSaveChangelog.Name = "btnSaveChangelog";
			this.btnSaveChangelog.Size = new System.Drawing.Size(42, 23);
			this.btnSaveChangelog.TabIndex = 2;
			this.btnSaveChangelog.Text = "Save";
			this.btnSaveChangelog.UseVisualStyleBackColor = true;
			this.btnSaveChangelog.Visible = false;
			this.btnSaveChangelog.Click += new System.EventHandler(this.BtnSaveChangelogClick);
			// 
			// txtChangelog
			// 
			this.txtChangelog.AcceptsTab = true;
			this.txtChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtChangelog.Location = new System.Drawing.Point(6, 6);
			this.txtChangelog.Multiline = true;
			this.txtChangelog.Name = "txtChangelog";
			this.txtChangelog.Size = new System.Drawing.Size(670, 355);
			this.txtChangelog.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.nyHotstringToolStripMenuItem,
									this.sparaTillFilToolStripMenuItem,
									this.stängToolStripMenuItem,
									this.testToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(714, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// nyHotstringToolStripMenuItem
			// 
			this.nyHotstringToolStripMenuItem.Name = "nyHotstringToolStripMenuItem";
			this.nyHotstringToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
			this.nyHotstringToolStripMenuItem.Text = "Ny hotstring";
			this.nyHotstringToolStripMenuItem.Click += new System.EventHandler(this.NewHotstring_Click);
			// 
			// sparaTillFilToolStripMenuItem
			// 
			this.sparaTillFilToolStripMenuItem.Name = "sparaTillFilToolStripMenuItem";
			this.sparaTillFilToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.sparaTillFilToolStripMenuItem.Text = "Spara till fil";
			this.sparaTillFilToolStripMenuItem.Click += new System.EventHandler(this.SaveToFile_Click);
			// 
			// stängToolStripMenuItem
			// 
			this.stängToolStripMenuItem.Name = "stängToolStripMenuItem";
			this.stängToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.stängToolStripMenuItem.Text = "Stäng";
			this.stängToolStripMenuItem.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.testToolStripMenuItem.Text = "Test";
			this.testToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 451);
			this.ControlBox = false;
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(720, 457);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AHK updater";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.Button btnSaveChangelog;
		private System.Windows.Forms.TextBox txtChangelog;
		private System.Windows.Forms.Button btnSaveFunctions;
		private System.Windows.Forms.Button btnSaveHotstringText;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ToolStripMenuItem stängToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sparaTillFilToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nyHotstringToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.TextBox txtFunctions;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TextBox txtHSText;
		public System.Windows.Forms.ListBox lstBHotstrings;
	}
}
