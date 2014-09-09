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
			this.txtHSText = new System.Windows.Forms.TextBox();
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
			this.menuSaveToFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtHSText
			// 
			this.txtHSText.AcceptsTab = true;
			this.txtHSText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHSText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHSText.Location = new System.Drawing.Point(185, 32);
			this.txtHSText.Multiline = true;
			this.txtHSText.Name = "txtHSText";
			this.txtHSText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHSText.Size = new System.Drawing.Size(488, 329);
			this.txtHSText.TabIndex = 0;
			this.txtHSText.TabStop = false;
			this.txtHSText.TextChanged += new System.EventHandler(this.txtHSText_TextChanged);
			// 
			// tabControl
			// 
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
			this.tabPage1.Controls.Add(this.txtHSText);
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
			this.btnChangeName.Location = new System.Drawing.Point(462, 4);
			this.btnChangeName.Name = "btnChangeName";
			this.btnChangeName.Size = new System.Drawing.Size(73, 23);
			this.btnChangeName.TabIndex = 6;
			this.btnChangeName.Text = "Change name";
			this.btnChangeName.UseVisualStyleBackColor = true;
			this.btnChangeName.Visible = false;
			this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
			// 
			// btnRemoveCommand
			// 
			this.btnRemoveCommand.Location = new System.Drawing.Point(541, 4);
			this.btnRemoveCommand.Name = "btnRemoveCommand";
			this.btnRemoveCommand.Size = new System.Drawing.Size(49, 23);
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
			this.txtSystem.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSystem.Location = new System.Drawing.Point(238, 6);
			this.txtSystem.Name = "txtSystem";
			this.txtSystem.Size = new System.Drawing.Size(218, 18);
			this.txtSystem.TabIndex = 3;
			this.txtSystem.TextChanged += new System.EventHandler(this.txtSystem_TextChanged);
			// 
			// treeHotstrings
			// 
			this.treeHotstrings.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
			this.btnSaveHotstring.AutoSize = true;
			this.btnSaveHotstring.Enabled = false;
			this.btnSaveHotstring.Location = new System.Drawing.Point(632, 4);
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
			this.txtFunctions.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
			this.txtChangelog.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
									this.menuSaveToFile,
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
			this.menuNewHotstring.Size = new System.Drawing.Size(85, 20);
			this.menuNewHotstring.Text = "New hotstring";
			this.menuNewHotstring.Click += new System.EventHandler(this.NewHotstring_Click);
			// 
			// menuSaveToFile
			// 
			this.menuSaveToFile.Name = "menuSaveToFile";
			this.menuSaveToFile.Size = new System.Drawing.Size(77, 20);
			this.menuSaveToFile.Text = "Save to file";
			this.menuSaveToFile.Click += new System.EventHandler(this.SaveToFile_Click);
			// 
			// menuClose
			// 
			this.menuClose.Name = "menuClose";
			this.menuClose.Size = new System.Drawing.Size(49, 20);
			this.menuClose.Text = "Close";
			this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 451);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
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
		private System.Windows.Forms.Button btnRemoveCommand;
		private System.Windows.Forms.Button btnChangeName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSystem;
		private System.Windows.Forms.TreeView treeHotstrings;
		private System.Windows.Forms.Button btnSaveChangelog;
		private System.Windows.Forms.TextBox txtChangelog;
		private System.Windows.Forms.Button btnSaveFunctions;
		private System.Windows.Forms.Button btnSaveHotstring;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ToolStripMenuItem menuClose;
		private System.Windows.Forms.ToolStripMenuItem menuSaveToFile;
		private System.Windows.Forms.ToolStripMenuItem menuNewHotstring;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.TextBox txtFunctions;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TextBox txtHSText;
	}
}
