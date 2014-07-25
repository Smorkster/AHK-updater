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
			this.lstHotstrings = new System.Windows.Forms.ListBox();
			this.txtHSText = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnSaveText = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtFunctions = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.txtChangelog = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.nyHotstringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sparaTillFilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sparaTillXMLfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stängToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstHotstrings
			// 
			this.lstHotstrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.lstHotstrings.FormattingEnabled = true;
			this.lstHotstrings.Location = new System.Drawing.Point(6, 8);
			this.lstHotstrings.Name = "lstHotstrings";
			this.lstHotstrings.Size = new System.Drawing.Size(156, 355);
			this.lstHotstrings.TabIndex = 0;
			this.lstHotstrings.SelectedValueChanged += new System.EventHandler(this.lstHotstrings_ValueChange);
			// 
			// txtHSText
			// 
			this.txtHSText.AcceptsTab = true;
			this.txtHSText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHSText.Location = new System.Drawing.Point(168, 8);
			this.txtHSText.Multiline = true;
			this.txtHSText.Name = "txtHSText";
			this.txtHSText.Size = new System.Drawing.Size(508, 354);
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
			this.tabControl1.Size = new System.Drawing.Size(690, 394);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnSaveText);
			this.tabPage1.Controls.Add(this.lstHotstrings);
			this.tabPage1.Controls.Add(this.txtHSText);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(682, 368);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Hotstrings";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnSaveText
			// 
			this.btnSaveText.Enabled = false;
			this.btnSaveText.Location = new System.Drawing.Point(635, 8);
			this.btnSaveText.Name = "btnSaveText";
			this.btnSaveText.Size = new System.Drawing.Size(41, 23);
			this.btnSaveText.TabIndex = 1;
			this.btnSaveText.Text = "Save";
			this.btnSaveText.UseVisualStyleBackColor = true;
			this.btnSaveText.Visible = false;
			this.btnSaveText.Click += new System.EventHandler(this.BtnSaveTextClick);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtFunctions);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(682, 368);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Functions";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtFunctions
			// 
			this.txtFunctions.Location = new System.Drawing.Point(6, 6);
			this.txtFunctions.Multiline = true;
			this.txtFunctions.Name = "txtFunctions";
			this.txtFunctions.Size = new System.Drawing.Size(670, 357);
			this.txtFunctions.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.txtChangelog);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(682, 368);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Changelog";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// txtChangelog
			// 
			this.txtChangelog.Location = new System.Drawing.Point(3, 3);
			this.txtChangelog.Multiline = true;
			this.txtChangelog.Name = "txtChangelog";
			this.txtChangelog.Size = new System.Drawing.Size(676, 362);
			this.txtChangelog.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.nyHotstringToolStripMenuItem,
									this.sparaTillFilToolStripMenuItem,
									this.sparaTillXMLfilToolStripMenuItem,
									this.stängToolStripMenuItem});
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
			this.nyHotstringToolStripMenuItem.Click += new System.EventHandler(this.newHotstring);
			// 
			// sparaTillFilToolStripMenuItem
			// 
			this.sparaTillFilToolStripMenuItem.Name = "sparaTillFilToolStripMenuItem";
			this.sparaTillFilToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
			this.sparaTillFilToolStripMenuItem.Text = "Spara till skriptfil";
			this.sparaTillFilToolStripMenuItem.Click += new System.EventHandler(this.saveToScriptFile);
			// 
			// sparaTillXMLfilToolStripMenuItem
			// 
			this.sparaTillXMLfilToolStripMenuItem.Name = "sparaTillXMLfilToolStripMenuItem";
			this.sparaTillXMLfilToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
			this.sparaTillXMLfilToolStripMenuItem.Text = "Spara till XML-fil";
			this.sparaTillXMLfilToolStripMenuItem.Click += new System.EventHandler(this.saveToXML);
			// 
			// stängToolStripMenuItem
			// 
			this.stängToolStripMenuItem.Name = "stängToolStripMenuItem";
			this.stängToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.stängToolStripMenuItem.Text = "Stäng";
			this.stängToolStripMenuItem.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 411);
			this.ControlBox = false;
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(720, 380);
			this.Name = "MainForm";
			this.ShowIcon = false;
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
		private System.Windows.Forms.Button btnSaveText;
		private System.Windows.Forms.TextBox txtChangelog;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ToolStripMenuItem sparaTillXMLfilToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stängToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sparaTillFilToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nyHotstringToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.TextBox txtFunctions;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TextBox txtHSText;
		public System.Windows.Forms.ListBox lstHotstrings;
	}
}
