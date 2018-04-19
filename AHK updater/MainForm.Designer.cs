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
			this.components = new System.ComponentModel.Container();
			this.btnCancelExtract = new System.Windows.Forms.Button();
			this.btnExtract = new System.Windows.Forms.Button();
			this.btnRemoveCommand = new System.Windows.Forms.Button();
			this.btnRemoveExtract = new System.Windows.Forms.Button();
			this.btnSaveToFile = new System.Windows.Forms.Button();
			this.btnUpdateChangelog = new System.Windows.Forms.Button();
			this.btnUpdateFunction = new System.Windows.Forms.Button();
			this.btnUpdateHotstring = new System.Windows.Forms.Button();
			this.contextItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbChangelogItems = new System.Windows.Forms.ListBox();
			this.lbExtractions = new System.Windows.Forms.ListBox();
			this.lbFunctions = new System.Windows.Forms.ListBox();
			this.lblname = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.menuNewCommand = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenScript = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenXML = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtHotstringName = new System.Windows.Forms.TextBox();
			this.txtHotstringSystem = new System.Windows.Forms.TextBox();
			this.treeHotstrings = new System.Windows.Forms.TreeView();
			this.txtHotstringText = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtFunctionName = new System.Windows.Forms.TextBox();
			this.txtFunctionText = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.txtChangelog = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.ttHotstringExists = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenu.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
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
			// btnRemoveCommand
			// 
			this.btnRemoveCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveCommand.Enabled = false;
			this.btnRemoveCommand.Location = new System.Drawing.Point(749, 508);
			this.btnRemoveCommand.Name = "btnRemoveCommand";
			this.btnRemoveCommand.Size = new System.Drawing.Size(101, 23);
			this.btnRemoveCommand.TabIndex = 5;
			this.btnRemoveCommand.Text = "Remove";
			this.btnRemoveCommand.UseVisualStyleBackColor = true;
			this.btnRemoveCommand.Click += new System.EventHandler(this.btnRemoveHotstring_Click);
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
			// btnSaveToFile
			// 
			this.btnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveToFile.Enabled = false;
			this.btnSaveToFile.Location = new System.Drawing.Point(765, 592);
			this.btnSaveToFile.Name = "btnSaveToFile";
			this.btnSaveToFile.Size = new System.Drawing.Size(101, 23);
			this.btnSaveToFile.TabIndex = 5;
			this.btnSaveToFile.Text = "Save to file";
			this.btnSaveToFile.UseVisualStyleBackColor = true;
			this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
			// 
			// btnUpdateChangelog
			// 
			this.btnUpdateChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdateChangelog.AutoSize = true;
			this.btnUpdateChangelog.Enabled = false;
			this.btnUpdateChangelog.Location = new System.Drawing.Point(808, 6);
			this.btnUpdateChangelog.Name = "btnUpdateChangelog";
			this.btnUpdateChangelog.Size = new System.Drawing.Size(42, 23);
			this.btnUpdateChangelog.TabIndex = 2;
			this.btnUpdateChangelog.Text = "Save";
			this.btnUpdateChangelog.UseVisualStyleBackColor = true;
			this.btnUpdateChangelog.Visible = false;
			this.btnUpdateChangelog.Click += new System.EventHandler(this.btnUpdateChangelog_Click);
			// 
			// btnUpdateFunction
			// 
			this.btnUpdateFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdateFunction.AutoSize = true;
			this.btnUpdateFunction.Enabled = false;
			this.btnUpdateFunction.Location = new System.Drawing.Point(749, 508);
			this.btnUpdateFunction.Name = "btnUpdateFunction";
			this.btnUpdateFunction.Size = new System.Drawing.Size(101, 23);
			this.btnUpdateFunction.TabIndex = 9;
			this.btnUpdateFunction.Text = "Update function";
			this.btnUpdateFunction.UseVisualStyleBackColor = true;
			this.btnUpdateFunction.Click += new System.EventHandler(this.btnUpdateFunction_Click);
			// 
			// btnUpdateHotstring
			// 
			this.btnUpdateHotstring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdateHotstring.AutoSize = true;
			this.btnUpdateHotstring.Enabled = false;
			this.btnUpdateHotstring.Location = new System.Drawing.Point(749, 485);
			this.btnUpdateHotstring.Name = "btnUpdateHotstring";
			this.btnUpdateHotstring.Size = new System.Drawing.Size(101, 23);
			this.btnUpdateHotstring.TabIndex = 6;
			this.btnUpdateHotstring.Text = "Update hotstring";
			this.btnUpdateHotstring.UseVisualStyleBackColor = true;
			this.btnUpdateHotstring.Click += new System.EventHandler(this.btnUpdateHotstring_Click);
			// 
			// contextItem
			// 
			this.contextItem.Name = "contextItem";
			this.contextItem.Size = new System.Drawing.Size(109, 22);
			this.contextItem.Text = "Extract";
			this.contextItem.Click += new System.EventHandler(this.contextItem_Click);
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.contextItem});
			this.contextMenu.Name = "contextMenuStrip1";
			this.contextMenu.Size = new System.Drawing.Size(110, 26);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(359, 513);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "System";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(359, 514);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 18);
			this.label2.TabIndex = 11;
			this.label2.Text = "Name";
			// 
			// lbChangelogItems
			// 
			this.lbChangelogItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.lbChangelogItems.FormattingEnabled = true;
			this.lbChangelogItems.Location = new System.Drawing.Point(6, 6);
			this.lbChangelogItems.Name = "lbChangelogItems";
			this.lbChangelogItems.Size = new System.Drawing.Size(173, 524);
			this.lbChangelogItems.TabIndex = 4;
			this.lbChangelogItems.SelectedIndexChanged += new System.EventHandler(this.lbChangelogItems_SelectedIndexChanged);
			// 
			// lbExtractions
			// 
			this.lbExtractions.FormattingEnabled = true;
			this.lbExtractions.Location = new System.Drawing.Point(6, 6);
			this.lbExtractions.Name = "lbExtractions";
			this.lbExtractions.Size = new System.Drawing.Size(173, 524);
			this.lbExtractions.TabIndex = 3;
			// 
			// lbFunctions
			// 
			this.lbFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.lbFunctions.FormattingEnabled = true;
			this.lbFunctions.Location = new System.Drawing.Point(6, 6);
			this.lbFunctions.Name = "lbFunctions";
			this.lbFunctions.Size = new System.Drawing.Size(173, 524);
			this.lbFunctions.Sorted = true;
			this.lbFunctions.TabIndex = 4;
			this.lbFunctions.SelectedIndexChanged += new System.EventHandler(this.lbFunctions_SelectedIndexChanged);
			// 
			// lblname
			// 
			this.lblname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblname.Location = new System.Drawing.Point(359, 491);
			this.lblname.Name = "lblname";
			this.lblname.Size = new System.Drawing.Size(47, 18);
			this.lblname.TabIndex = 8;
			this.lblname.Text = "Name";
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatus.Location = new System.Drawing.Point(12, 593);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(747, 23);
			this.lblStatus.TabIndex = 6;
			// 
			// menuClose
			// 
			this.menuClose.Name = "menuClose";
			this.menuClose.Size = new System.Drawing.Size(48, 20);
			this.menuClose.Text = "Close";
			this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
			// 
			// menuNewCommand
			// 
			this.menuNewCommand.Name = "menuNewCommand";
			this.menuNewCommand.Size = new System.Drawing.Size(101, 20);
			this.menuNewCommand.Text = "New command";
			this.menuNewCommand.Click += new System.EventHandler(this.menuNewCommand_Click);
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
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuNewCommand,
			this.openToolStripMenuItem,
			this.menuClose});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(888, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
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
			this.tabControl.Size = new System.Drawing.Size(864, 563);
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
			this.tabPage1.Size = new System.Drawing.Size(856, 537);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Hotstrings";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtHotstringName
			// 
			this.txtHotstringName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotstringName.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringName.Location = new System.Drawing.Point(412, 490);
			this.txtHotstringName.Name = "txtHotstringName";
			this.txtHotstringName.Size = new System.Drawing.Size(331, 18);
			this.txtHotstringName.TabIndex = 7;
			this.txtHotstringName.TextChanged += new System.EventHandler(this.txtHotstringName_TextChanged);
			this.txtHotstringName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHotstringName_KeyUp);
			this.txtHotstringName.Leave += new System.EventHandler(this.txtHotstringText_Leave);
			// 
			// txtHotstringSystem
			// 
			this.txtHotstringSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotstringSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtHotstringSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtHotstringSystem.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringSystem.Location = new System.Drawing.Point(412, 512);
			this.txtHotstringSystem.Name = "txtHotstringSystem";
			this.txtHotstringSystem.Size = new System.Drawing.Size(331, 18);
			this.txtHotstringSystem.TabIndex = 3;
			this.txtHotstringSystem.TextChanged += new System.EventHandler(this.txtHotstringSystem_TextChanged);
			this.txtHotstringSystem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHotstringSystem_KeyUp);
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
			this.treeHotstrings.Size = new System.Drawing.Size(259, 525);
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
			this.txtHotstringText.Location = new System.Drawing.Point(271, 6);
			this.txtHotstringText.Multiline = true;
			this.txtHotstringText.Name = "txtHotstringText";
			this.txtHotstringText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHotstringText.Size = new System.Drawing.Size(579, 478);
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
			this.tabPage2.Size = new System.Drawing.Size(856, 537);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Functions";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtFunctionName
			// 
			this.txtFunctionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctionName.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtFunctionName.Location = new System.Drawing.Point(412, 513);
			this.txtFunctionName.Name = "txtFunctionName";
			this.txtFunctionName.Size = new System.Drawing.Size(331, 18);
			this.txtFunctionName.TabIndex = 10;
			this.txtFunctionName.TextChanged += new System.EventHandler(this.txtFunctionName_TextChanged);
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
			this.txtFunctionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtFunctionText.Size = new System.Drawing.Size(665, 496);
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
			this.tabPage3.Size = new System.Drawing.Size(856, 537);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Changelog";
			this.tabPage3.UseVisualStyleBackColor = true;
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
			this.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChangelog.Size = new System.Drawing.Size(665, 525);
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
			this.tabPage4.Size = new System.Drawing.Size(856, 537);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "To extract";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(888, 621);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnSaveToFile);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.Icon = global::AHK_updater.Resources.ICON;
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(720, 457);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AHK Updater";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.contextMenu.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
        private System.Windows.Forms.Button btnCancelExtract;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnRemoveCommand;
        private System.Windows.Forms.Button btnRemoveExtract;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnUpdateChangelog;
        private System.Windows.Forms.Button btnUpdateFunction;
        private System.Windows.Forms.Button btnUpdateHotstring;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lbChangelogItems;
        private System.Windows.Forms.ListBox lbExtractions;
        private System.Windows.Forms.ListBox lbFunctions;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtChangelog;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.TextBox txtFunctionText;
        private System.Windows.Forms.TextBox txtHotstringName;
        private System.Windows.Forms.TextBox txtHotstringSystem;
        private System.Windows.Forms.TextBox txtHotstringText;
        private System.Windows.Forms.ToolStripMenuItem contextItem;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripMenuItem menuNewCommand;
        private System.Windows.Forms.ToolStripMenuItem menuOpenScript;
        private System.Windows.Forms.ToolStripMenuItem menuOpenXML;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolTip ttHotstringExists;
        private System.Windows.Forms.TreeView treeHotstrings;
	}
}
