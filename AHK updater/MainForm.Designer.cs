﻿namespace AHK_updater
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
			this.components = new System.ComponentModel.Container();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lblname = new System.Windows.Forms.Label();
			this.txtHotstringName = new System.Windows.Forms.TextBox();
			this.btnUpdateHotstring = new System.Windows.Forms.Button();
			this.btnRemoveCommand = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtHotstringSystem = new System.Windows.Forms.TextBox();
			this.treeHotstrings = new System.Windows.Forms.TreeView();
			this.txtHotstringText = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFunctionName = new System.Windows.Forms.TextBox();
			this.btnUpdateFunction = new System.Windows.Forms.Button();
			this.lbFunctions = new System.Windows.Forms.ListBox();
			this.txtFunctionText = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.lbChangelogItems = new System.Windows.Forms.ListBox();
			this.btnUpdateChangelog = new System.Windows.Forms.Button();
			this.txtChangelog = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.btnRemoveExtract = new System.Windows.Forms.Button();
			this.lbExtractions = new System.Windows.Forms.ListBox();
			this.btnCancelExtract = new System.Windows.Forms.Button();
			this.btnExtract = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuNewCommand = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenScript = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenXML = new System.Windows.Forms.ToolStripMenuItem();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaveToFile = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.ttHotstringExists = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Controls.Add(this.tabPage3);
			this.tabControl.Controls.Add(this.tabPage4);
			this.tabControl.Location = new System.Drawing.Point(12, 27);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(690, 393);
			this.tabControl.TabIndex = 3;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			this.tabControl.Leave += new System.EventHandler(this.txtFunctionsText_Leave);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lblname);
			this.tabPage1.Controls.Add(this.txtHotstringName);
			this.tabPage1.Controls.Add(this.btnUpdateHotstring);
			this.tabPage1.Controls.Add(this.btnRemoveCommand);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtHotstringSystem);
			this.tabPage1.Controls.Add(this.treeHotstrings);
			this.tabPage1.Controls.Add(this.txtHotstringText);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(682, 367);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Hotstrings";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// lblname
			// 
			this.lblname.Location = new System.Drawing.Point(185, 321);
			this.lblname.Name = "lblname";
			this.lblname.Size = new System.Drawing.Size(47, 18);
			this.lblname.TabIndex = 8;
			this.lblname.Text = "Name";
			// 
			// txtHotstringName
			// 
			this.txtHotstringName.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringName.Location = new System.Drawing.Point(238, 320);
			this.txtHotstringName.Name = "txtHotstringName";
			this.txtHotstringName.Size = new System.Drawing.Size(331, 18);
			this.txtHotstringName.TabIndex = 7;
			this.txtHotstringName.TextChanged += new System.EventHandler(this.txtHotstringName_TextChanged);
			this.txtHotstringName.Leave += new System.EventHandler(this.txtHotstringText_Leave);
			// 
			// btnUpdateHotstring
			// 
			this.btnUpdateHotstring.AutoSize = true;
			this.btnUpdateHotstring.Enabled = false;
			this.btnUpdateHotstring.Location = new System.Drawing.Point(575, 315);
			this.btnUpdateHotstring.Name = "btnUpdateHotstring";
			this.btnUpdateHotstring.Size = new System.Drawing.Size(101, 23);
			this.btnUpdateHotstring.TabIndex = 6;
			this.btnUpdateHotstring.Text = "Update hotstring";
			this.btnUpdateHotstring.UseVisualStyleBackColor = true;
			this.btnUpdateHotstring.Click += new System.EventHandler(this.btnUpdateHotstring_Click);
			// 
			// btnRemoveCommand
			// 
			this.btnRemoveCommand.Enabled = false;
			this.btnRemoveCommand.Location = new System.Drawing.Point(575, 338);
			this.btnRemoveCommand.Name = "btnRemoveCommand";
			this.btnRemoveCommand.Size = new System.Drawing.Size(101, 23);
			this.btnRemoveCommand.TabIndex = 5;
			this.btnRemoveCommand.Text = "Remove";
			this.btnRemoveCommand.UseVisualStyleBackColor = true;
			this.btnRemoveCommand.Click += new System.EventHandler(this.btnRemoveHotstring_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(185, 343);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "System";
			// 
			// txtHotstringSystem
			// 
			this.txtHotstringSystem.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringSystem.Location = new System.Drawing.Point(238, 342);
			this.txtHotstringSystem.Name = "txtHotstringSystem";
			this.txtHotstringSystem.Size = new System.Drawing.Size(331, 18);
			this.txtHotstringSystem.TabIndex = 3;
			this.txtHotstringSystem.TextChanged += new System.EventHandler(this.txtSystem_TextChanged);
			this.txtHotstringSystem.Leave += new System.EventHandler(this.txtHotstringText_Leave);
			// 
			// treeHotstrings
			// 
			this.treeHotstrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.treeHotstrings.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.treeHotstrings.FullRowSelect = true;
			this.treeHotstrings.HideSelection = false;
			this.treeHotstrings.Indent = 19;
			this.treeHotstrings.Location = new System.Drawing.Point(6, 6);
			this.treeHotstrings.Name = "treeHotstrings";
			this.treeHotstrings.Size = new System.Drawing.Size(173, 355);
			this.treeHotstrings.TabIndex = 2;
			this.treeHotstrings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeHotstrings_AfterSelect);
			this.treeHotstrings.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeHotstrings_NodeMouseClick);
			// 
			// txtHotstringText
			// 
			this.txtHotstringText.AcceptsTab = true;
			this.txtHotstringText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotstringText.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringText.Location = new System.Drawing.Point(185, 6);
			this.txtHotstringText.Multiline = true;
			this.txtHotstringText.Name = "txtHotstringText";
			this.txtHotstringText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHotstringText.Size = new System.Drawing.Size(491, 308);
			this.txtHotstringText.TabIndex = 0;
			this.txtHotstringText.TabStop = false;
			this.txtHotstringText.TextChanged += new System.EventHandler(this.txtHotstringText_TextChanged);
			this.txtHotstringText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHotstringText_KeyUp);
			this.txtHotstringText.LostFocus += new System.EventHandler(this.txtHotstringText_Leave);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.txtFunctionName);
			this.tabPage2.Controls.Add(this.btnUpdateFunction);
			this.tabPage2.Controls.Add(this.lbFunctions);
			this.tabPage2.Controls.Add(this.txtFunctionText);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(682, 367);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Functions";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(185, 344);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 18);
			this.label2.TabIndex = 11;
			this.label2.Text = "Name";
			// 
			// txtFunctionName
			// 
			this.txtFunctionName.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtFunctionName.Location = new System.Drawing.Point(238, 343);
			this.txtFunctionName.Name = "txtFunctionName";
			this.txtFunctionName.Size = new System.Drawing.Size(331, 18);
			this.txtFunctionName.TabIndex = 10;
			this.txtFunctionName.TextChanged += new System.EventHandler(this.txtFunctionName_TextChanged);
			// 
			// btnUpdateFunction
			// 
			this.btnUpdateFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdateFunction.AutoSize = true;
			this.btnUpdateFunction.Enabled = false;
			this.btnUpdateFunction.Location = new System.Drawing.Point(575, 338);
			this.btnUpdateFunction.Name = "btnUpdateFunction";
			this.btnUpdateFunction.Size = new System.Drawing.Size(101, 23);
			this.btnUpdateFunction.TabIndex = 9;
			this.btnUpdateFunction.Text = "Update hotstring";
			this.btnUpdateFunction.UseVisualStyleBackColor = true;
			this.btnUpdateFunction.Click += new System.EventHandler(this.btnUpdateFunction_Click);
			// 
			// lbFunctions
			// 
			this.lbFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.lbFunctions.FormattingEnabled = true;
			this.lbFunctions.Location = new System.Drawing.Point(6, 6);
			this.lbFunctions.Name = "lbFunctions";
			this.lbFunctions.Size = new System.Drawing.Size(173, 355);
			this.lbFunctions.Sorted = true;
			this.lbFunctions.TabIndex = 4;
			this.lbFunctions.SelectedIndexChanged += new System.EventHandler(this.lbFunctions_SelectedIndexChanged);
			// 
			// txtFunctionText
			// 
			this.txtFunctionText.AcceptsTab = true;
			this.txtFunctionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctionText.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtFunctionText.Location = new System.Drawing.Point(185, 6);
			this.txtFunctionText.Multiline = true;
			this.txtFunctionText.Name = "txtFunctionText";
			this.txtFunctionText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtFunctionText.Size = new System.Drawing.Size(491, 326);
			this.txtFunctionText.TabIndex = 0;
			this.txtFunctionText.TabStop = false;
			this.txtFunctionText.TextChanged += new System.EventHandler(this.txtFunctions_TextChanged);
			this.txtFunctionText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFunctions_KeyUp);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.lbChangelogItems);
			this.tabPage3.Controls.Add(this.btnUpdateChangelog);
			this.tabPage3.Controls.Add(this.txtChangelog);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(682, 367);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Changelog";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// lbChangelogItems
			// 
			this.lbChangelogItems.FormattingEnabled = true;
			this.lbChangelogItems.Location = new System.Drawing.Point(6, 6);
			this.lbChangelogItems.Name = "lbChangelogItems";
			this.lbChangelogItems.Size = new System.Drawing.Size(173, 355);
			this.lbChangelogItems.TabIndex = 4;
			this.lbChangelogItems.SelectedIndexChanged += new System.EventHandler(this.lbChangelogItems_SelectedIndexChanged);
			// 
			// btnUpdateChangelog
			// 
			this.btnUpdateChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdateChangelog.AutoSize = true;
			this.btnUpdateChangelog.Enabled = false;
			this.btnUpdateChangelog.Location = new System.Drawing.Point(634, 6);
			this.btnUpdateChangelog.Name = "btnUpdateChangelog";
			this.btnUpdateChangelog.Size = new System.Drawing.Size(42, 23);
			this.btnUpdateChangelog.TabIndex = 2;
			this.btnUpdateChangelog.Text = "Save";
			this.btnUpdateChangelog.UseVisualStyleBackColor = true;
			this.btnUpdateChangelog.Visible = false;
			this.btnUpdateChangelog.Click += new System.EventHandler(this.btnUpdateChangelog_Click);
			// 
			// txtChangelog
			// 
			this.txtChangelog.AcceptsTab = true;
			this.txtChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtChangelog.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtChangelog.Location = new System.Drawing.Point(185, 6);
			this.txtChangelog.Multiline = true;
			this.txtChangelog.Name = "txtChangelog";
			this.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtChangelog.Size = new System.Drawing.Size(491, 355);
			this.txtChangelog.TabIndex = 0;
			this.txtChangelog.TextChanged += new System.EventHandler(this.txtChangelog_TextChanged);
			this.txtChangelog.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChangelog_KeyUp);
			this.txtChangelog.Leave += new System.EventHandler(this.txtChangelogText_Leave);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.btnRemoveExtract);
			this.tabPage4.Controls.Add(this.lbExtractions);
			this.tabPage4.Controls.Add(this.btnCancelExtract);
			this.tabPage4.Controls.Add(this.btnExtract);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(682, 367);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "To extract";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// btnRemoveExtract
			// 
			this.btnRemoveExtract.Location = new System.Drawing.Point(185, 35);
			this.btnRemoveExtract.Name = "btnRemoveExtract";
			this.btnRemoveExtract.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveExtract.TabIndex = 4;
			this.btnRemoveExtract.Text = "Remove";
			this.btnRemoveExtract.UseVisualStyleBackColor = true;
			this.btnRemoveExtract.Click += new System.EventHandler(this.btnRemoveExtract_Click);
			// 
			// lbExtractions
			// 
			this.lbExtractions.FormattingEnabled = true;
			this.lbExtractions.Location = new System.Drawing.Point(6, 6);
			this.lbExtractions.Name = "lbExtractions";
			this.lbExtractions.Size = new System.Drawing.Size(173, 355);
			this.lbExtractions.TabIndex = 3;
			// 
			// btnCancelExtract
			// 
			this.btnCancelExtract.Location = new System.Drawing.Point(185, 64);
			this.btnCancelExtract.Name = "btnCancelExtract";
			this.btnCancelExtract.Size = new System.Drawing.Size(75, 23);
			this.btnCancelExtract.TabIndex = 2;
			this.btnCancelExtract.Text = "Cancel";
			this.btnCancelExtract.UseVisualStyleBackColor = true;
			this.btnCancelExtract.Click += new System.EventHandler(this.btnCancelExtract_Click);
			// 
			// btnExtract
			// 
			this.btnExtract.Enabled = false;
			this.btnExtract.Location = new System.Drawing.Point(185, 6);
			this.btnExtract.Name = "btnExtract";
			this.btnExtract.Size = new System.Drawing.Size(75, 23);
			this.btnExtract.TabIndex = 1;
			this.btnExtract.Text = "Extract";
			this.btnExtract.UseVisualStyleBackColor = true;
			this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuNewCommand,
			this.openToolStripMenuItem,
			this.menuClose});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(714, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuNewCommand
			// 
			this.menuNewCommand.Name = "menuNewCommand";
			this.menuNewCommand.Size = new System.Drawing.Size(101, 20);
			this.menuNewCommand.Text = "New command";
			this.menuNewCommand.Click += new System.EventHandler(this.menuNewCommand_Click);
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
			this.btnSaveToFile.Location = new System.Drawing.Point(591, 422);
			this.btnSaveToFile.Name = "btnSaveToFile";
			this.btnSaveToFile.Size = new System.Drawing.Size(101, 23);
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
			this.lblStatus.Size = new System.Drawing.Size(573, 23);
			this.lblStatus.TabIndex = 6;
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.contextItem});
			this.contextMenu.Name = "contextMenuStrip1";
			this.contextMenu.Size = new System.Drawing.Size(110, 26);
			// 
			// contextItem
			// 
			this.contextItem.Name = "contextItem";
			this.contextItem.Size = new System.Drawing.Size(109, 22);
			this.contextItem.Text = "Extract";
			this.contextItem.Click += new System.EventHandler(this.contextItem_Click);
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
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(720, 457);
			this.Name = "MainForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AHK Updater";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		System.Windows.Forms.Button btnRemoveCommand;
		System.Windows.Forms.Button btnUpdateHotstring;
		System.Windows.Forms.Label label1;
		System.Windows.Forms.TextBox txtHotstringSystem;
		System.Windows.Forms.TreeView treeHotstrings;
		System.Windows.Forms.Button btnUpdateChangelog;
		System.Windows.Forms.TextBox txtChangelog;
		System.Windows.Forms.TabPage tabPage3;
		System.Windows.Forms.ToolStripMenuItem menuClose;
		System.Windows.Forms.ToolStripMenuItem menuNewCommand;
		System.Windows.Forms.MenuStrip menuStrip1;
		System.Windows.Forms.TextBox txtFunctionText;
		System.Windows.Forms.TabPage tabPage2;
		System.Windows.Forms.TabPage tabPage1;
		System.Windows.Forms.TabControl tabControl;
		System.Windows.Forms.TextBox txtHotstringText;
		System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		System.Windows.Forms.ToolStripMenuItem menuOpenScript;
		System.Windows.Forms.ToolStripMenuItem menuOpenXML;
		System.Windows.Forms.Button btnSaveToFile;
		System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblname;
		private System.Windows.Forms.TextBox txtHotstringName;
		private System.Windows.Forms.ToolTip ttHotstringExists;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem contextItem;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button btnCancelExtract;
		private System.Windows.Forms.Button btnExtract;
		private System.Windows.Forms.Button btnRemoveExtract;
		private System.Windows.Forms.ListBox lbExtractions;
		private System.Windows.Forms.ListBox lbChangelogItems;
		private System.Windows.Forms.ListBox lbFunctions;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFunctionName;
		private System.Windows.Forms.Button btnUpdateFunction;
	}
}
