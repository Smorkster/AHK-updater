namespace AHK_updater
{
	partial class MainForm
	{
		System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		void InitializeComponent()
		{
			this.txtHotstringText = new System.Windows.Forms.TextBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnChangeName = new System.Windows.Forms.Button();
			this.btnRemoveCommand = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSystem = new System.Windows.Forms.TextBox();
			this.treeHotstrings = new System.Windows.Forms.TreeView();
			this.btnSaveHotstring = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnSaveFunctions = new System.Windows.Forms.Button();
			this.txtFunctions = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnSaveChangelog = new System.Windows.Forms.Button();
			this.txtChangelog = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuNewHotstring = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenScript = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenXML = new System.Windows.Forms.ToolStripMenuItem();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaveToFile = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtHotstringText
			// 
			this.txtHotstringText.AcceptsTab = true;
			this.txtHotstringText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotstringText.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringText.Location = new System.Drawing.Point(185, 32);
			this.txtHotstringText.Multiline = true;
			this.txtHotstringText.Name = "txtHotstringText";
			this.txtHotstringText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHotstringText.Size = new System.Drawing.Size(488, 329);
			this.txtHotstringText.TabIndex = 0;
			this.txtHotstringText.TabStop = false;
			this.txtHotstringText.TextChanged += new System.EventHandler(this.txtHotstringText_TextChanged);
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Controls.Add(this.tabPage3);
			this.tabControl.Location = new System.Drawing.Point(12, 27);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(690, 393);
			this.tabControl.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnChangeName);
			this.tabPage1.Controls.Add(this.btnRemoveCommand);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtSystem);
			this.tabPage1.Controls.Add(this.treeHotstrings);
			this.tabPage1.Controls.Add(this.btnSaveHotstring);
			this.tabPage1.Controls.Add(this.txtHotstringText);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(682, 367);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Hotstrings";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnChangeName
			// 
			this.btnChangeName.AutoSize = true;
			this.btnChangeName.Location = new System.Drawing.Point(462, 3);
			this.btnChangeName.Name = "btnChangeName";
			this.btnChangeName.Size = new System.Drawing.Size(83, 23);
			this.btnChangeName.TabIndex = 6;
			this.btnChangeName.Text = "Change name";
			this.btnChangeName.UseVisualStyleBackColor = true;
			this.btnChangeName.Visible = false;
			this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
			// 
			// btnRemoveCommand
			// 
			this.btnRemoveCommand.Location = new System.Drawing.Point(551, 3);
			this.btnRemoveCommand.Name = "btnRemoveCommand";
			this.btnRemoveCommand.Size = new System.Drawing.Size(57, 23);
			this.btnRemoveCommand.TabIndex = 5;
			this.btnRemoveCommand.Text = "Remove";
			this.btnRemoveCommand.UseVisualStyleBackColor = true;
			this.btnRemoveCommand.Visible = false;
			this.btnRemoveCommand.Click += new System.EventHandler(this.btnRemoveCommand_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(185, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "System";
			// 
			// txtSystem
			// 
			this.txtSystem.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtSystem.Location = new System.Drawing.Point(238, 6);
			this.txtSystem.Name = "txtSystem";
			this.txtSystem.Size = new System.Drawing.Size(218, 18);
			this.txtSystem.TabIndex = 3;
			this.txtSystem.TextChanged += new System.EventHandler(this.txtSystem_TextChanged);
			// 
			// treeHotstrings
			// 
			this.treeHotstrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.treeHotstrings.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.treeHotstrings.FullRowSelect = true;
			this.treeHotstrings.HideSelection = false;
			this.treeHotstrings.Location = new System.Drawing.Point(6, 6);
			this.treeHotstrings.Name = "treeHotstrings";
			this.treeHotstrings.Size = new System.Drawing.Size(173, 355);
			this.treeHotstrings.TabIndex = 2;
			this.treeHotstrings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeHotstrings_AfterSelect);
			// 
			// btnSaveHotstring
			// 
			this.btnSaveHotstring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveHotstring.AutoSize = true;
			this.btnSaveHotstring.Enabled = false;
			this.btnSaveHotstring.Location = new System.Drawing.Point(631, 32);
			this.btnSaveHotstring.Name = "btnSaveHotstring";
			this.btnSaveHotstring.Size = new System.Drawing.Size(42, 23);
			this.btnSaveHotstring.TabIndex = 1;
			this.btnSaveHotstring.Text = "Save";
			this.btnSaveHotstring.UseVisualStyleBackColor = true;
			this.btnSaveHotstring.Visible = false;
			this.btnSaveHotstring.Click += new System.EventHandler(this.btnSaveHotstring_Click);
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
			this.btnSaveFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveFunctions.AutoSize = true;
			this.btnSaveFunctions.Enabled = false;
			this.btnSaveFunctions.Location = new System.Drawing.Point(634, 6);
			this.btnSaveFunctions.Name = "btnSaveFunctions";
			this.btnSaveFunctions.Size = new System.Drawing.Size(42, 23);
			this.btnSaveFunctions.TabIndex = 1;
			this.btnSaveFunctions.Text = "Save";
			this.btnSaveFunctions.UseVisualStyleBackColor = true;
			this.btnSaveFunctions.Visible = false;
			this.btnSaveFunctions.Click += new System.EventHandler(this.btnSaveFunctions_Click);
			// 
			// txtFunctions
			// 
			this.txtFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctions.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtFunctions.Location = new System.Drawing.Point(6, 6);
			this.txtFunctions.Multiline = true;
			this.txtFunctions.Name = "txtFunctions";
			this.txtFunctions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtFunctions.Size = new System.Drawing.Size(670, 355);
			this.txtFunctions.TabIndex = 0;
			this.txtFunctions.TextChanged += new System.EventHandler(this.txtFunctions_TextChanged);
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
			this.btnSaveChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveChangelog.AutoSize = true;
			this.btnSaveChangelog.Enabled = false;
			this.btnSaveChangelog.Location = new System.Drawing.Point(634, 6);
			this.btnSaveChangelog.Name = "btnSaveChangelog";
			this.btnSaveChangelog.Size = new System.Drawing.Size(42, 23);
			this.btnSaveChangelog.TabIndex = 2;
			this.btnSaveChangelog.Text = "Save";
			this.btnSaveChangelog.UseVisualStyleBackColor = true;
			this.btnSaveChangelog.Visible = false;
			this.btnSaveChangelog.Click += new System.EventHandler(this.btnSaveChangelog_Click);
			// 
			// txtChangelog
			// 
			this.txtChangelog.AcceptsTab = true;
			this.txtChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtChangelog.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtChangelog.Location = new System.Drawing.Point(6, 6);
			this.txtChangelog.Multiline = true;
			this.txtChangelog.Name = "txtChangelog";
			this.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtChangelog.Size = new System.Drawing.Size(670, 355);
			this.txtChangelog.TabIndex = 0;
			this.txtChangelog.TextChanged += new System.EventHandler(this.txtChangelog_TextChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuNewHotstring,
			this.openToolStripMenuItem,
			this.menuClose});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(714, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuNewHotstring
			// 
			this.menuNewHotstring.Name = "menuNewHotstring";
			this.menuNewHotstring.Size = new System.Drawing.Size(94, 20);
			this.menuNewHotstring.Text = "New hotstring";
			this.menuNewHotstring.Click += new System.EventHandler(this.menuNewHotstring_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuOpenScript,
			this.menuOpenXML});
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.openToolStripMenuItem.Text = "Open...";
			// 
			// menuOpenScript
			// 
			this.menuOpenScript.Name = "menuOpenScript";
			this.menuOpenScript.Size = new System.Drawing.Size(120, 22);
			this.menuOpenScript.Text = "Scriptfile";
			this.menuOpenScript.Click += new System.EventHandler(this.menuOpenScript_Click);
			// 
			// menuOpenXML
			// 
			this.menuOpenXML.Name = "menuOpenXML";
			this.menuOpenXML.Size = new System.Drawing.Size(120, 22);
			this.menuOpenXML.Text = "XMLfile";
			this.menuOpenXML.Click += new System.EventHandler(this.menuOpenXML_Click);
			// 
			// menuClose
			// 
			this.menuClose.Name = "menuClose";
			this.menuClose.Size = new System.Drawing.Size(48, 20);
			this.menuClose.Text = "Close";
			this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
			// 
			// btnSaveToFile
			// 
			this.btnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveToFile.Location = new System.Drawing.Point(622, 423);
			this.btnSaveToFile.Name = "btnSaveToFile";
			this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
			this.btnSaveToFile.TabIndex = 5;
			this.btnSaveToFile.Text = "Save to file";
			this.btnSaveToFile.UseVisualStyleBackColor = true;
			this.btnSaveToFile.Visible = false;
			this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatus.Location = new System.Drawing.Point(12, 423);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(609, 23);
			this.lblStatus.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 451);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnSaveToFile);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(720, 457);
			this.Name = "MainForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AHK Updater";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tabControl.ResumeLayout(false);
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
		System.Windows.Forms.Button btnRemoveCommand;
		System.Windows.Forms.Button btnChangeName;
		System.Windows.Forms.Label label1;
		System.Windows.Forms.TextBox txtSystem;
		System.Windows.Forms.TreeView treeHotstrings;
		System.Windows.Forms.Button btnSaveChangelog;
		System.Windows.Forms.TextBox txtChangelog;
		System.Windows.Forms.Button btnSaveFunctions;
		System.Windows.Forms.Button btnSaveHotstring;
		System.Windows.Forms.TabPage tabPage3;
		System.Windows.Forms.ToolStripMenuItem menuClose;
		System.Windows.Forms.ToolStripMenuItem menuNewHotstring;
		System.Windows.Forms.MenuStrip menuStrip1;
		System.Windows.Forms.TextBox txtFunctions;
		System.Windows.Forms.TabPage tabPage2;
		System.Windows.Forms.TabPage tabPage1;
		System.Windows.Forms.TabControl tabControl;
		System.Windows.Forms.TextBox txtHotstringText;
		System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem menuOpenScript;
		System.Windows.Forms.ToolStripMenuItem menuOpenXML;
		System.Windows.Forms.Button btnSaveToFile;
		System.Windows.Forms.Label lblStatus;
	}
}
