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
			this.btnExtractToAHK = new System.Windows.Forms.Button();
			this.btnRemoveHotstring = new System.Windows.Forms.Button();
			this.btnRemoveExtract = new System.Windows.Forms.Button();
			this.btnSaveToFile = new System.Windows.Forms.Button();
			this.btnUpdateChange = new System.Windows.Forms.Button();
			this.btnUpdateFunction = new System.Windows.Forms.Button();
			this.btnUpdateHotstring = new System.Windows.Forms.Button();
			this.contextItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbChanges = new System.Windows.Forms.ListBox();
			this.lbHotstringExtractions = new System.Windows.Forms.ListBox();
			this.lbFunctions = new System.Windows.Forms.ListBox();
			this.lblname = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.menuNewCommand = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiNewFunction = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiNewHotstring = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiNewVariable = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabHotstrings = new System.Windows.Forms.TabPage();
			this.gbHotstring = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtHotstringName = new System.Windows.Forms.TextBox();
			this.txtHotstringSystem = new System.Windows.Forms.TextBox();
			this.txtHotstringMenuTitle = new System.Windows.Forms.TextBox();
			this.treeHotstrings = new System.Windows.Forms.TreeView();
			this.tabVariables = new System.Windows.Forms.TabPage();
			this.gbVariable = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRemoveVariable = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnUpdateVariable = new System.Windows.Forms.Button();
			this.txtVariableValue = new System.Windows.Forms.TextBox();
			this.txtVariableName = new System.Windows.Forms.TextBox();
			this.lbVariables = new System.Windows.Forms.ListBox();
			this.tabFunctions = new System.Windows.Forms.TabPage();
			this.gbFunction = new System.Windows.Forms.GroupBox();
			this.btnRemoveFunction = new System.Windows.Forms.Button();
			this.txtFunctionName = new System.Windows.Forms.TextBox();
			this.tabChangelog = new System.Windows.Forms.TabPage();
			this.gbChange = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtChangeVersion = new System.Windows.Forms.TextBox();
			this.tabExtraction = new System.Windows.Forms.TabPage();
			this.gbExtractFunctions = new System.Windows.Forms.GroupBox();
			this.lbFunctionExtractions = new System.Windows.Forms.ListBox();
			this.gbExtractVariables = new System.Windows.Forms.GroupBox();
			this.lbVariableExtractions = new System.Windows.Forms.ListBox();
			this.btnExtractToXML = new System.Windows.Forms.Button();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.gbApplicationSettings = new System.Windows.Forms.GroupBox();
			this.btnOpenXML = new System.Windows.Forms.Button();
			this.btnOpenScript = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.cbEditorToOpenFileWith = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnResetMenuTrigger = new System.Windows.Forms.Button();
			this.txtScriptOperationsMenuTrigger = new System.Windows.Forms.TextBox();
			this.lblMenuTrigger = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtSectionTextTitleDivider = new System.Windows.Forms.TextBox();
			this.btnResetTitleDivider = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.btnResetTitleMenuSection = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.txtSectionTextTitleMenuSection = new System.Windows.Forms.TextBox();
			this.txtSectionTextTitleHotstringsSection = new System.Windows.Forms.TextBox();
			this.btnResetTitleMenuTriggersSection = new System.Windows.Forms.Button();
			this.btnResetTitleHotstringsSection = new System.Windows.Forms.Button();
			this.txtSectionTextTitleMenuTriggersSection = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtSectionTextTitleFunctionsSection = new System.Windows.Forms.TextBox();
			this.btnResetTitleVariablesSection = new System.Windows.Forms.Button();
			this.btnResetTitleFunctionsSection = new System.Windows.Forms.Button();
			this.txtSectionTextTitleVariablesSection = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.ttGeneralTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.chbSaveWithMenu = new System.Windows.Forms.CheckBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.txtHotstringText = new AHK_updater.MyTextBox();
			this.txtFunctionText = new AHK_updater.MyTextBox();
			this.txtChangeText = new AHK_updater.MyTextBox();
			this.contextMenu.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabHotstrings.SuspendLayout();
			this.gbHotstring.SuspendLayout();
			this.tabVariables.SuspendLayout();
			this.gbVariable.SuspendLayout();
			this.tabFunctions.SuspendLayout();
			this.gbFunction.SuspendLayout();
			this.tabChangelog.SuspendLayout();
			this.gbChange.SuspendLayout();
			this.tabExtraction.SuspendLayout();
			this.gbExtractFunctions.SuspendLayout();
			this.gbExtractVariables.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.gbApplicationSettings.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancelExtract
			// 
			this.btnCancelExtract.Enabled = false;
			this.btnCancelExtract.Location = new System.Drawing.Point(185, 64);
			this.btnCancelExtract.Name = "btnCancelExtract";
			this.btnCancelExtract.Size = new System.Drawing.Size(112, 23);
			this.btnCancelExtract.TabIndex = 2;
			this.btnCancelExtract.Text = "Cancel";
			this.btnCancelExtract.UseVisualStyleBackColor = true;
			this.btnCancelExtract.Click += new System.EventHandler(this.BtnCancelExtract_Click);
			// 
			// btnExtractToAHK
			// 
			this.btnExtractToAHK.AutoSize = true;
			this.btnExtractToAHK.Enabled = false;
			this.btnExtractToAHK.Location = new System.Drawing.Point(185, 6);
			this.btnExtractToAHK.Name = "btnExtractToAHK";
			this.btnExtractToAHK.Size = new System.Drawing.Size(112, 23);
			this.btnExtractToAHK.TabIndex = 1;
			this.btnExtractToAHK.Text = "Extract to a scriptfile";
			this.btnExtractToAHK.UseVisualStyleBackColor = true;
			this.btnExtractToAHK.Click += new System.EventHandler(this.BtnExtractToScript_Click);
			// 
			// btnRemoveHotstring
			// 
			this.btnRemoveHotstring.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnRemoveHotstring.Enabled = false;
			this.btnRemoveHotstring.Location = new System.Drawing.Point(466, 48);
			this.btnRemoveHotstring.Name = "btnRemoveHotstring";
			this.btnRemoveHotstring.Size = new System.Drawing.Size(101, 23);
			this.btnRemoveHotstring.TabIndex = 5;
			this.btnRemoveHotstring.Text = "Remove";
			this.btnRemoveHotstring.UseVisualStyleBackColor = true;
			this.btnRemoveHotstring.Click += new System.EventHandler(this.BtnRemoveHotstring_Click);
			// 
			// btnRemoveExtract
			// 
			this.btnRemoveExtract.Enabled = false;
			this.btnRemoveExtract.Location = new System.Drawing.Point(185, 35);
			this.btnRemoveExtract.Name = "btnRemoveExtract";
			this.btnRemoveExtract.Size = new System.Drawing.Size(112, 23);
			this.btnRemoveExtract.TabIndex = 4;
			this.btnRemoveExtract.Text = "Remove";
			this.btnRemoveExtract.UseVisualStyleBackColor = true;
			this.btnRemoveExtract.Click += new System.EventHandler(this.BtnRemoveExtractedHotstring_Click);
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
			this.btnSaveToFile.Click += new System.EventHandler(this.BtnSaveToFile_Click);
			// 
			// btnUpdateChange
			// 
			this.btnUpdateChange.AutoSize = true;
			this.btnUpdateChange.Enabled = false;
			this.btnUpdateChange.Location = new System.Drawing.Point(558, 11);
			this.btnUpdateChange.Name = "btnUpdateChange";
			this.btnUpdateChange.Size = new System.Drawing.Size(101, 23);
			this.btnUpdateChange.TabIndex = 2;
			this.btnUpdateChange.Text = "Save";
			this.btnUpdateChange.UseVisualStyleBackColor = true;
			this.btnUpdateChange.Click += new System.EventHandler(this.BtnUpdateChange_Click);
			// 
			// btnUpdateFunction
			// 
			this.btnUpdateFunction.AutoSize = true;
			this.btnUpdateFunction.Enabled = false;
			this.btnUpdateFunction.Location = new System.Drawing.Point(451, 19);
			this.btnUpdateFunction.Name = "btnUpdateFunction";
			this.btnUpdateFunction.Size = new System.Drawing.Size(101, 23);
			this.btnUpdateFunction.TabIndex = 9;
			this.btnUpdateFunction.Text = "Update function";
			this.btnUpdateFunction.UseVisualStyleBackColor = true;
			this.btnUpdateFunction.Click += new System.EventHandler(this.BtnUpdateFunction_Click);
			// 
			// btnUpdateHotstring
			// 
			this.btnUpdateHotstring.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnUpdateHotstring.AutoSize = true;
			this.btnUpdateHotstring.Enabled = false;
			this.btnUpdateHotstring.Location = new System.Drawing.Point(466, 19);
			this.btnUpdateHotstring.Name = "btnUpdateHotstring";
			this.btnUpdateHotstring.Size = new System.Drawing.Size(101, 23);
			this.btnUpdateHotstring.TabIndex = 6;
			this.btnUpdateHotstring.Text = "Update hotstring";
			this.btnUpdateHotstring.UseVisualStyleBackColor = true;
			this.btnUpdateHotstring.Click += new System.EventHandler(this.BtnUpdateHotstring_Click);
			// 
			// contextItem
			// 
			this.contextItem.Name = "contextItem";
			this.contextItem.Size = new System.Drawing.Size(109, 22);
			this.contextItem.Text = "Extract";
			this.contextItem.Click += new System.EventHandler(this.ContextItem_Click);
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
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Location = new System.Drawing.Point(6, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "System";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 18);
			this.label2.TabIndex = 11;
			this.label2.Text = "Name";
			// 
			// lbChanges
			// 
			this.lbChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbChanges.FormattingEnabled = true;
			this.lbChanges.Location = new System.Drawing.Point(6, 6);
			this.lbChanges.Name = "lbChanges";
			this.lbChanges.Size = new System.Drawing.Size(173, 524);
			this.lbChanges.TabIndex = 4;
			this.lbChanges.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LbChangelogItems_MouseClick);
			// 
			// lbHotstringExtractions
			// 
			this.lbHotstringExtractions.FormattingEnabled = true;
			this.lbHotstringExtractions.Location = new System.Drawing.Point(6, 6);
			this.lbHotstringExtractions.Name = "lbHotstringExtractions";
			this.lbHotstringExtractions.Size = new System.Drawing.Size(173, 524);
			this.lbHotstringExtractions.TabIndex = 3;
			this.lbHotstringExtractions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LbHotstringExtractions_MouseClick);
			this.lbHotstringExtractions.SelectedIndexChanged += new System.EventHandler(this.LbHotstringExtractions_SelectedIndexChanged);
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
			this.lbFunctions.UseTabStops = false;
			this.lbFunctions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LbFunctions_MouseClick);
			this.lbFunctions.DataSourceChanged += new System.EventHandler(this.LbFunctions_DataSourceChanged);
			// 
			// lblname
			// 
			this.lblname.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblname.Location = new System.Drawing.Point(6, 24);
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
			this.lblStatus.Size = new System.Drawing.Size(519, 23);
			this.lblStatus.TabIndex = 6;
			this.lblStatus.TextChanged += new System.EventHandler(this.LblStatus_TextChanged);
			// 
			// menuClose
			// 
			this.menuClose.Name = "menuClose";
			this.menuClose.Size = new System.Drawing.Size(48, 20);
			this.menuClose.Text = "Close";
			this.menuClose.Click += new System.EventHandler(this.MenuClose_Click);
			// 
			// menuNewCommand
			// 
			this.menuNewCommand.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewFunction,
            this.tsmiNewHotstring,
            this.tsmiNewVariable});
			this.menuNewCommand.Name = "menuNewCommand";
			this.menuNewCommand.Size = new System.Drawing.Size(101, 20);
			this.menuNewCommand.Text = "New command";
			// 
			// tsmiNewFunction
			// 
			this.tsmiNewFunction.Name = "tsmiNewFunction";
			this.tsmiNewFunction.Size = new System.Drawing.Size(124, 22);
			this.tsmiNewFunction.Text = "Function";
			this.tsmiNewFunction.Click += new System.EventHandler(this.TsmiNewFunction_Click);
			// 
			// tsmiNewHotstring
			// 
			this.tsmiNewHotstring.Name = "tsmiNewHotstring";
			this.tsmiNewHotstring.Size = new System.Drawing.Size(124, 22);
			this.tsmiNewHotstring.Text = "Hotstring";
			this.tsmiNewHotstring.Click += new System.EventHandler(this.TsmiNewHotstring_Click);
			// 
			// tsmiNewVariable
			// 
			this.tsmiNewVariable.Name = "tsmiNewVariable";
			this.tsmiNewVariable.Size = new System.Drawing.Size(124, 22);
			this.tsmiNewVariable.Text = "Variable";
			this.tsmiNewVariable.Click += new System.EventHandler(this.TsmiNewVariable_Click);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewCommand,
            this.menuClose});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(888, 24);
			this.menuStrip.TabIndex = 4;
			this.menuStrip.Text = "menuStrip1";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabHotstrings);
			this.tabControl.Controls.Add(this.tabVariables);
			this.tabControl.Controls.Add(this.tabFunctions);
			this.tabControl.Controls.Add(this.tabChangelog);
			this.tabControl.Controls.Add(this.tabExtraction);
			this.tabControl.Controls.Add(this.tabSettings);
			this.tabControl.Location = new System.Drawing.Point(12, 27);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(864, 563);
			this.tabControl.TabIndex = 3;
			// 
			// tabHotstrings
			// 
			this.tabHotstrings.Controls.Add(this.gbHotstring);
			this.tabHotstrings.Controls.Add(this.treeHotstrings);
			this.tabHotstrings.Location = new System.Drawing.Point(4, 22);
			this.tabHotstrings.Name = "tabHotstrings";
			this.tabHotstrings.Padding = new System.Windows.Forms.Padding(3);
			this.tabHotstrings.Size = new System.Drawing.Size(856, 537);
			this.tabHotstrings.TabIndex = 0;
			this.tabHotstrings.Text = "Hotstrings";
			this.tabHotstrings.UseVisualStyleBackColor = true;
			// 
			// gbHotstring
			// 
			this.gbHotstring.Controls.Add(this.lblname);
			this.gbHotstring.Controls.Add(this.btnUpdateHotstring);
			this.gbHotstring.Controls.Add(this.txtHotstringText);
			this.gbHotstring.Controls.Add(this.label6);
			this.gbHotstring.Controls.Add(this.txtHotstringName);
			this.gbHotstring.Controls.Add(this.txtHotstringSystem);
			this.gbHotstring.Controls.Add(this.btnRemoveHotstring);
			this.gbHotstring.Controls.Add(this.txtHotstringMenuTitle);
			this.gbHotstring.Controls.Add(this.label1);
			this.gbHotstring.Enabled = false;
			this.gbHotstring.Location = new System.Drawing.Point(274, 6);
			this.gbHotstring.Name = "gbHotstring";
			this.gbHotstring.Size = new System.Drawing.Size(573, 525);
			this.gbHotstring.TabIndex = 9;
			this.gbHotstring.TabStop = false;
			this.gbHotstring.EnabledChanged += new System.EventHandler(this.GbHotstring_EnabledChanged);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.Location = new System.Drawing.Point(6, 77);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 18);
			this.label6.TabIndex = 10;
			this.label6.Text = "Menu title";
			// 
			// txtHotstringName
			// 
			this.txtHotstringName.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtHotstringName.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringName.Location = new System.Drawing.Point(81, 23);
			this.txtHotstringName.Name = "txtHotstringName";
			this.txtHotstringName.Size = new System.Drawing.Size(379, 18);
			this.txtHotstringName.TabIndex = 7;
			// 
			// txtHotstringSystem
			// 
			this.txtHotstringSystem.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtHotstringSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtHotstringSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtHotstringSystem.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringSystem.Location = new System.Drawing.Point(81, 52);
			this.txtHotstringSystem.Name = "txtHotstringSystem";
			this.txtHotstringSystem.Size = new System.Drawing.Size(379, 18);
			this.txtHotstringSystem.TabIndex = 3;
			// 
			// txtHotstringMenuTitle
			// 
			this.txtHotstringMenuTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtHotstringMenuTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtHotstringMenuTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtHotstringMenuTitle.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringMenuTitle.Location = new System.Drawing.Point(81, 76);
			this.txtHotstringMenuTitle.Name = "txtHotstringMenuTitle";
			this.txtHotstringMenuTitle.Size = new System.Drawing.Size(379, 18);
			this.txtHotstringMenuTitle.TabIndex = 9;
			// 
			// treeHotstrings
			// 
			this.treeHotstrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeHotstrings.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.treeHotstrings.HideSelection = false;
			this.treeHotstrings.Indent = 19;
			this.treeHotstrings.Location = new System.Drawing.Point(6, 6);
			this.treeHotstrings.Name = "treeHotstrings";
			this.treeHotstrings.Size = new System.Drawing.Size(259, 525);
			this.treeHotstrings.TabIndex = 2;
			this.treeHotstrings.TabStop = false;
			this.treeHotstrings.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeHotstrings_BeforeSelect);
			this.treeHotstrings.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeHotstrings_NodeMouseClick);
			// 
			// tabVariables
			// 
			this.tabVariables.Controls.Add(this.gbVariable);
			this.tabVariables.Controls.Add(this.lbVariables);
			this.tabVariables.Location = new System.Drawing.Point(4, 22);
			this.tabVariables.Name = "tabVariables";
			this.tabVariables.Size = new System.Drawing.Size(856, 537);
			this.tabVariables.TabIndex = 4;
			this.tabVariables.Text = "Variables";
			this.tabVariables.UseVisualStyleBackColor = true;
			// 
			// gbVariable
			// 
			this.gbVariable.Controls.Add(this.label3);
			this.gbVariable.Controls.Add(this.btnRemoveVariable);
			this.gbVariable.Controls.Add(this.label4);
			this.gbVariable.Controls.Add(this.btnUpdateVariable);
			this.gbVariable.Controls.Add(this.txtVariableValue);
			this.gbVariable.Controls.Add(this.txtVariableName);
			this.gbVariable.Enabled = false;
			this.gbVariable.Location = new System.Drawing.Point(179, 3);
			this.gbVariable.Name = "gbVariable";
			this.gbVariable.Size = new System.Drawing.Size(671, 153);
			this.gbVariable.TabIndex = 7;
			this.gbVariable.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Name";
			// 
			// btnRemoveVariable
			// 
			this.btnRemoveVariable.Location = new System.Drawing.Point(113, 117);
			this.btnRemoveVariable.Name = "btnRemoveVariable";
			this.btnRemoveVariable.Size = new System.Drawing.Size(101, 23);
			this.btnRemoveVariable.TabIndex = 3;
			this.btnRemoveVariable.Text = "Remove";
			this.btnRemoveVariable.UseVisualStyleBackColor = true;
			this.btnRemoveVariable.Click += new System.EventHandler(this.BtnRemoveVariable_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Value";
			// 
			// btnUpdateVariable
			// 
			this.btnUpdateVariable.Enabled = false;
			this.btnUpdateVariable.Location = new System.Drawing.Point(6, 117);
			this.btnUpdateVariable.Name = "btnUpdateVariable";
			this.btnUpdateVariable.Size = new System.Drawing.Size(101, 23);
			this.btnUpdateVariable.TabIndex = 2;
			this.btnUpdateVariable.Text = "Update";
			this.btnUpdateVariable.UseVisualStyleBackColor = true;
			this.btnUpdateVariable.Click += new System.EventHandler(this.BtnUpdateVariable_Click);
			// 
			// txtVariableValue
			// 
			this.txtVariableValue.Location = new System.Drawing.Point(6, 91);
			this.txtVariableValue.Name = "txtVariableValue";
			this.txtVariableValue.Size = new System.Drawing.Size(495, 20);
			this.txtVariableValue.TabIndex = 1;
			// 
			// txtVariableName
			// 
			this.txtVariableName.Location = new System.Drawing.Point(6, 42);
			this.txtVariableName.Name = "txtVariableName";
			this.txtVariableName.Size = new System.Drawing.Size(495, 20);
			this.txtVariableName.TabIndex = 4;
			// 
			// lbVariables
			// 
			this.lbVariables.FormattingEnabled = true;
			this.lbVariables.Location = new System.Drawing.Point(0, 3);
			this.lbVariables.Name = "lbVariables";
			this.lbVariables.Size = new System.Drawing.Size(173, 524);
			this.lbVariables.TabIndex = 0;
			this.lbVariables.UseTabStops = false;
			this.lbVariables.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LbVariables_MouseClick);
			// 
			// tabFunctions
			// 
			this.tabFunctions.Controls.Add(this.gbFunction);
			this.tabFunctions.Controls.Add(this.lbFunctions);
			this.tabFunctions.Location = new System.Drawing.Point(4, 22);
			this.tabFunctions.Name = "tabFunctions";
			this.tabFunctions.Padding = new System.Windows.Forms.Padding(3);
			this.tabFunctions.Size = new System.Drawing.Size(856, 537);
			this.tabFunctions.TabIndex = 1;
			this.tabFunctions.Text = "Functions";
			this.tabFunctions.UseVisualStyleBackColor = true;
			// 
			// gbFunction
			// 
			this.gbFunction.Controls.Add(this.label2);
			this.gbFunction.Controls.Add(this.btnUpdateFunction);
			this.gbFunction.Controls.Add(this.txtFunctionText);
			this.gbFunction.Controls.Add(this.btnRemoveFunction);
			this.gbFunction.Controls.Add(this.txtFunctionName);
			this.gbFunction.Location = new System.Drawing.Point(185, 6);
			this.gbFunction.Name = "gbFunction";
			this.gbFunction.Size = new System.Drawing.Size(665, 524);
			this.gbFunction.TabIndex = 13;
			this.gbFunction.TabStop = false;
			// 
			// btnRemoveFunction
			// 
			this.btnRemoveFunction.Location = new System.Drawing.Point(558, 19);
			this.btnRemoveFunction.Name = "btnRemoveFunction";
			this.btnRemoveFunction.Size = new System.Drawing.Size(101, 23);
			this.btnRemoveFunction.TabIndex = 12;
			this.btnRemoveFunction.Text = "Remove";
			this.btnRemoveFunction.UseVisualStyleBackColor = true;
			this.btnRemoveFunction.Click += new System.EventHandler(this.BtnRemoveFunction_Click);
			// 
			// txtFunctionName
			// 
			this.txtFunctionName.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtFunctionName.Location = new System.Drawing.Point(59, 23);
			this.txtFunctionName.Name = "txtFunctionName";
			this.txtFunctionName.Size = new System.Drawing.Size(386, 18);
			this.txtFunctionName.TabIndex = 10;
			// 
			// tabChangelog
			// 
			this.tabChangelog.Controls.Add(this.gbChange);
			this.tabChangelog.Controls.Add(this.lbChanges);
			this.tabChangelog.Location = new System.Drawing.Point(4, 22);
			this.tabChangelog.Name = "tabChangelog";
			this.tabChangelog.Size = new System.Drawing.Size(856, 537);
			this.tabChangelog.TabIndex = 2;
			this.tabChangelog.Text = "Changelog";
			this.tabChangelog.UseVisualStyleBackColor = true;
			// 
			// gbChange
			// 
			this.gbChange.Controls.Add(this.label5);
			this.gbChange.Controls.Add(this.txtChangeText);
			this.gbChange.Controls.Add(this.txtChangeVersion);
			this.gbChange.Controls.Add(this.btnUpdateChange);
			this.gbChange.Enabled = false;
			this.gbChange.Location = new System.Drawing.Point(185, 6);
			this.gbChange.Name = "gbChange";
			this.gbChange.Size = new System.Drawing.Size(665, 524);
			this.gbChange.TabIndex = 7;
			this.gbChange.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Versionname";
			// 
			// txtChangeVersion
			// 
			this.txtChangeVersion.Location = new System.Drawing.Point(80, 13);
			this.txtChangeVersion.Name = "txtChangeVersion";
			this.txtChangeVersion.ReadOnly = true;
			this.txtChangeVersion.Size = new System.Drawing.Size(472, 20);
			this.txtChangeVersion.TabIndex = 5;
			// 
			// tabExtraction
			// 
			this.tabExtraction.Controls.Add(this.gbExtractFunctions);
			this.tabExtraction.Controls.Add(this.gbExtractVariables);
			this.tabExtraction.Controls.Add(this.btnExtractToXML);
			this.tabExtraction.Controls.Add(this.btnRemoveExtract);
			this.tabExtraction.Controls.Add(this.lbHotstringExtractions);
			this.tabExtraction.Controls.Add(this.btnCancelExtract);
			this.tabExtraction.Controls.Add(this.btnExtractToAHK);
			this.tabExtraction.Location = new System.Drawing.Point(4, 22);
			this.tabExtraction.Name = "tabExtraction";
			this.tabExtraction.Size = new System.Drawing.Size(856, 537);
			this.tabExtraction.TabIndex = 3;
			this.tabExtraction.Text = "To extract";
			this.tabExtraction.UseVisualStyleBackColor = true;
			// 
			// gbExtractFunctions
			// 
			this.gbExtractFunctions.Controls.Add(this.lbFunctionExtractions);
			this.gbExtractFunctions.Location = new System.Drawing.Point(420, 119);
			this.gbExtractFunctions.Name = "gbExtractFunctions";
			this.gbExtractFunctions.Size = new System.Drawing.Size(190, 315);
			this.gbExtractFunctions.TabIndex = 11;
			this.gbExtractFunctions.TabStop = false;
			this.gbExtractFunctions.Text = "Functions that also will be extracted";
			this.gbExtractFunctions.Visible = false;
			// 
			// lbFunctionExtractions
			// 
			this.lbFunctionExtractions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbFunctionExtractions.FormattingEnabled = true;
			this.lbFunctionExtractions.Location = new System.Drawing.Point(6, 19);
			this.lbFunctionExtractions.Name = "lbFunctionExtractions";
			this.lbFunctionExtractions.Size = new System.Drawing.Size(178, 290);
			this.lbFunctionExtractions.TabIndex = 7;
			this.lbFunctionExtractions.TabStop = false;
			this.lbFunctionExtractions.DataSourceChanged += new System.EventHandler(this.LbFunctionExtractions_DataSourceChanged);
			// 
			// gbExtractVariables
			// 
			this.gbExtractVariables.Controls.Add(this.lbVariableExtractions);
			this.gbExtractVariables.Location = new System.Drawing.Point(185, 119);
			this.gbExtractVariables.Name = "gbExtractVariables";
			this.gbExtractVariables.Size = new System.Drawing.Size(190, 315);
			this.gbExtractVariables.TabIndex = 0;
			this.gbExtractVariables.TabStop = false;
			this.gbExtractVariables.Text = "Variables that also will be extracted";
			this.gbExtractVariables.Visible = false;
			// 
			// lbVariableExtractions
			// 
			this.lbVariableExtractions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbVariableExtractions.FormattingEnabled = true;
			this.lbVariableExtractions.Location = new System.Drawing.Point(6, 19);
			this.lbVariableExtractions.Name = "lbVariableExtractions";
			this.lbVariableExtractions.Size = new System.Drawing.Size(178, 290);
			this.lbVariableExtractions.TabIndex = 6;
			this.lbVariableExtractions.TabStop = false;
			this.lbVariableExtractions.DataSourceChanged += new System.EventHandler(this.LbVariableExtractions_DataSourceChanged);
			// 
			// btnExtractToXML
			// 
			this.btnExtractToXML.AutoSize = true;
			this.btnExtractToXML.Enabled = false;
			this.btnExtractToXML.Location = new System.Drawing.Point(303, 6);
			this.btnExtractToXML.Name = "btnExtractToXML";
			this.btnExtractToXML.Size = new System.Drawing.Size(118, 23);
			this.btnExtractToXML.TabIndex = 5;
			this.btnExtractToXML.Text = "Extract to an XML-file";
			this.btnExtractToXML.UseVisualStyleBackColor = true;
			this.btnExtractToXML.Click += new System.EventHandler(this.BtnExtractToXML_Click);
			// 
			// tabSettings
			// 
			this.tabSettings.Controls.Add(this.gbApplicationSettings);
			this.tabSettings.Controls.Add(this.groupBox4);
			this.tabSettings.Controls.Add(this.groupBox3);
			this.tabSettings.Location = new System.Drawing.Point(4, 22);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.Size = new System.Drawing.Size(856, 537);
			this.tabSettings.TabIndex = 5;
			this.tabSettings.Text = "Settings";
			this.tabSettings.UseVisualStyleBackColor = true;
			// 
			// gbApplicationSettings
			// 
			this.gbApplicationSettings.Controls.Add(this.btnOpenXML);
			this.gbApplicationSettings.Controls.Add(this.btnOpenScript);
			this.gbApplicationSettings.Controls.Add(this.label13);
			this.gbApplicationSettings.Controls.Add(this.cbEditorToOpenFileWith);
			this.gbApplicationSettings.Location = new System.Drawing.Point(9, 319);
			this.gbApplicationSettings.Name = "gbApplicationSettings";
			this.gbApplicationSettings.Size = new System.Drawing.Size(488, 100);
			this.gbApplicationSettings.TabIndex = 6;
			this.gbApplicationSettings.TabStop = false;
			this.gbApplicationSettings.Text = "Application settings";
			// 
			// btnOpenXML
			// 
			this.btnOpenXML.Enabled = false;
			this.btnOpenXML.Location = new System.Drawing.Point(431, 17);
			this.btnOpenXML.Name = "btnOpenXML";
			this.btnOpenXML.Size = new System.Drawing.Size(45, 23);
			this.btnOpenXML.TabIndex = 3;
			this.btnOpenXML.Text = "XML";
			this.btnOpenXML.UseVisualStyleBackColor = true;
			this.btnOpenXML.Click += new System.EventHandler(this.BtnOpenXML_Click);
			// 
			// btnOpenScript
			// 
			this.btnOpenScript.Enabled = false;
			this.btnOpenScript.Location = new System.Drawing.Point(381, 17);
			this.btnOpenScript.Name = "btnOpenScript";
			this.btnOpenScript.Size = new System.Drawing.Size(45, 23);
			this.btnOpenScript.TabIndex = 2;
			this.btnOpenScript.Text = "Script";
			this.btnOpenScript.UseVisualStyleBackColor = true;
			this.btnOpenScript.Click += new System.EventHandler(this.BtnOpenScript_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(13, 22);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(111, 13);
			this.label13.TabIndex = 1;
			this.label13.Text = "Editor to open file with";
			// 
			// cbEditorToOpenFileWith
			// 
			this.cbEditorToOpenFileWith.FormattingEnabled = true;
			this.cbEditorToOpenFileWith.Location = new System.Drawing.Point(187, 19);
			this.cbEditorToOpenFileWith.Name = "cbEditorToOpenFileWith";
			this.cbEditorToOpenFileWith.Size = new System.Drawing.Size(170, 21);
			this.cbEditorToOpenFileWith.Sorted = true;
			this.cbEditorToOpenFileWith.TabIndex = 0;
			this.cbEditorToOpenFileWith.TextChanged += new System.EventHandler(this.CbEditorToOpenFileWith_TextChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.groupBox1);
			this.groupBox4.Location = new System.Drawing.Point(9, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(488, 82);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Functional settings";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnResetMenuTrigger);
			this.groupBox1.Controls.Add(this.txtScriptOperationsMenuTrigger);
			this.groupBox1.Controls.Add(this.lblMenuTrigger);
			this.groupBox1.Location = new System.Drawing.Point(6, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(476, 57);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Scriptoperations";
			// 
			// btnResetMenuTrigger
			// 
			this.btnResetMenuTrigger.Location = new System.Drawing.Point(375, 19);
			this.btnResetMenuTrigger.Name = "btnResetMenuTrigger";
			this.btnResetMenuTrigger.Size = new System.Drawing.Size(95, 23);
			this.btnResetMenuTrigger.TabIndex = 1;
			this.btnResetMenuTrigger.Text = "Reset to default";
			this.btnResetMenuTrigger.UseVisualStyleBackColor = true;
			// 
			// txtScriptOperationsMenuTrigger
			// 
			this.txtScriptOperationsMenuTrigger.Location = new System.Drawing.Point(181, 21);
			this.txtScriptOperationsMenuTrigger.Name = "txtScriptOperationsMenuTrigger";
			this.txtScriptOperationsMenuTrigger.Size = new System.Drawing.Size(170, 20);
			this.txtScriptOperationsMenuTrigger.TabIndex = 2;
			this.ttGeneralTooltip.SetToolTip(this.txtScriptOperationsMenuTrigger, "Leading string when accessing the AHK-menu. This string will preceed each systemn" +
        "ame.");
			// 
			// lblMenuTrigger
			// 
			this.lblMenuTrigger.AutoSize = true;
			this.lblMenuTrigger.Location = new System.Drawing.Point(7, 28);
			this.lblMenuTrigger.Name = "lblMenuTrigger";
			this.lblMenuTrigger.Size = new System.Drawing.Size(90, 13);
			this.lblMenuTrigger.TabIndex = 3;
			this.lblMenuTrigger.Text = "AHK menu trigger";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.groupBox2);
			this.groupBox3.Location = new System.Drawing.Point(9, 91);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(488, 222);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Scriptsettings";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.txtSectionTextTitleDivider);
			this.groupBox2.Controls.Add(this.btnResetTitleDivider);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.btnResetTitleMenuSection);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.txtSectionTextTitleMenuSection);
			this.groupBox2.Controls.Add(this.txtSectionTextTitleHotstringsSection);
			this.groupBox2.Controls.Add(this.btnResetTitleMenuTriggersSection);
			this.groupBox2.Controls.Add(this.btnResetTitleHotstringsSection);
			this.groupBox2.Controls.Add(this.txtSectionTextTitleMenuTriggersSection);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.txtSectionTextTitleFunctionsSection);
			this.groupBox2.Controls.Add(this.btnResetTitleVariablesSection);
			this.groupBox2.Controls.Add(this.btnResetTitleFunctionsSection);
			this.groupBox2.Controls.Add(this.txtSectionTextTitleVariablesSection);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Location = new System.Drawing.Point(6, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(476, 197);
			this.groupBox2.TabIndex = 20;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Section texts";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(7, 171);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(58, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "Titledivider";
			// 
			// txtSectionTextTitleDivider
			// 
			this.txtSectionTextTitleDivider.Location = new System.Drawing.Point(181, 164);
			this.txtSectionTextTitleDivider.Name = "txtSectionTextTitleDivider";
			this.txtSectionTextTitleDivider.Size = new System.Drawing.Size(170, 20);
			this.txtSectionTextTitleDivider.TabIndex = 20;
			this.ttGeneralTooltip.SetToolTip(this.txtSectionTextTitleDivider, "This text will surround the sectiontitle in the script");
			this.txtSectionTextTitleDivider.TextChanged += new System.EventHandler(this.TxtSectionTextTitleDivider_TextChanged);
			// 
			// btnResetTitleDivider
			// 
			this.btnResetTitleDivider.Location = new System.Drawing.Point(375, 162);
			this.btnResetTitleDivider.Name = "btnResetTitleDivider";
			this.btnResetTitleDivider.Size = new System.Drawing.Size(95, 23);
			this.btnResetTitleDivider.TabIndex = 19;
			this.btnResetTitleDivider.Text = "Reset to default";
			this.btnResetTitleDivider.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(108, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Title for menu-section";
			// 
			// btnResetTitleMenuSection
			// 
			this.btnResetTitleMenuSection.Location = new System.Drawing.Point(375, 17);
			this.btnResetTitleMenuSection.Name = "btnResetTitleMenuSection";
			this.btnResetTitleMenuSection.Size = new System.Drawing.Size(95, 23);
			this.btnResetTitleMenuSection.TabIndex = 4;
			this.btnResetTitleMenuSection.Text = "Reset to default";
			this.btnResetTitleMenuSection.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(7, 142);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(127, 13);
			this.label11.TabIndex = 18;
			this.label11.Text = "Title for hotstrings-section";
			// 
			// txtSectionTextTitleMenuSection
			// 
			this.txtSectionTextTitleMenuSection.Location = new System.Drawing.Point(181, 19);
			this.txtSectionTextTitleMenuSection.Name = "txtSectionTextTitleMenuSection";
			this.txtSectionTextTitleMenuSection.Size = new System.Drawing.Size(170, 20);
			this.txtSectionTextTitleMenuSection.TabIndex = 5;
			this.ttGeneralTooltip.SetToolTip(this.txtSectionTextTitleMenuSection, "Text for title of section in the script, creating the menu");
			this.txtSectionTextTitleMenuSection.TextChanged += new System.EventHandler(this.TxtSectionTextTitleMenuSection_TextChanged);
			// 
			// txtSectionTextTitleHotstringsSection
			// 
			this.txtSectionTextTitleHotstringsSection.Location = new System.Drawing.Point(181, 135);
			this.txtSectionTextTitleHotstringsSection.Name = "txtSectionTextTitleHotstringsSection";
			this.txtSectionTextTitleHotstringsSection.Size = new System.Drawing.Size(170, 20);
			this.txtSectionTextTitleHotstringsSection.TabIndex = 17;
			this.ttGeneralTooltip.SetToolTip(this.txtSectionTextTitleHotstringsSection, "Text for title of section in the script, containing all hotstrings");
			this.txtSectionTextTitleHotstringsSection.TextChanged += new System.EventHandler(this.TxtSectionTextTitleHotstringsSection_TextChanged);
			// 
			// btnResetTitleMenuTriggersSection
			// 
			this.btnResetTitleMenuTriggersSection.Location = new System.Drawing.Point(375, 46);
			this.btnResetTitleMenuTriggersSection.Name = "btnResetTitleMenuTriggersSection";
			this.btnResetTitleMenuTriggersSection.Size = new System.Drawing.Size(95, 23);
			this.btnResetTitleMenuTriggersSection.TabIndex = 7;
			this.btnResetTitleMenuTriggersSection.Text = "Reset to default";
			this.btnResetTitleMenuTriggersSection.UseVisualStyleBackColor = true;
			// 
			// btnResetTitleHotstringsSection
			// 
			this.btnResetTitleHotstringsSection.Location = new System.Drawing.Point(375, 133);
			this.btnResetTitleHotstringsSection.Name = "btnResetTitleHotstringsSection";
			this.btnResetTitleHotstringsSection.Size = new System.Drawing.Size(95, 23);
			this.btnResetTitleHotstringsSection.TabIndex = 16;
			this.btnResetTitleHotstringsSection.Text = "Reset to default";
			this.btnResetTitleHotstringsSection.UseVisualStyleBackColor = true;
			// 
			// txtSectionTextTitleMenuTriggersSection
			// 
			this.txtSectionTextTitleMenuTriggersSection.Location = new System.Drawing.Point(181, 48);
			this.txtSectionTextTitleMenuTriggersSection.Name = "txtSectionTextTitleMenuTriggersSection";
			this.txtSectionTextTitleMenuTriggersSection.Size = new System.Drawing.Size(170, 20);
			this.txtSectionTextTitleMenuTriggersSection.TabIndex = 8;
			this.ttGeneralTooltip.SetToolTip(this.txtSectionTextTitleMenuTriggersSection, "Text for title of section in the script, creating the menutriggers");
			this.txtSectionTextTitleMenuTriggersSection.TextChanged += new System.EventHandler(this.TxtSectionTextTitleMenuTriggersSection_TextChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(7, 113);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(125, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "Title for functions-section";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 55);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(142, 13);
			this.label8.TabIndex = 9;
			this.label8.Text = "Title for menutriggers-section";
			// 
			// txtSectionTextTitleFunctionsSection
			// 
			this.txtSectionTextTitleFunctionsSection.Location = new System.Drawing.Point(181, 106);
			this.txtSectionTextTitleFunctionsSection.Name = "txtSectionTextTitleFunctionsSection";
			this.txtSectionTextTitleFunctionsSection.Size = new System.Drawing.Size(170, 20);
			this.txtSectionTextTitleFunctionsSection.TabIndex = 14;
			this.ttGeneralTooltip.SetToolTip(this.txtSectionTextTitleFunctionsSection, "Text for title of section in the script, containing all functions");
			this.txtSectionTextTitleFunctionsSection.TextChanged += new System.EventHandler(this.TxtSectionTextTitleFunctionsSection_TextChanged);
			// 
			// btnResetTitleVariablesSection
			// 
			this.btnResetTitleVariablesSection.Location = new System.Drawing.Point(375, 75);
			this.btnResetTitleVariablesSection.Name = "btnResetTitleVariablesSection";
			this.btnResetTitleVariablesSection.Size = new System.Drawing.Size(95, 23);
			this.btnResetTitleVariablesSection.TabIndex = 10;
			this.btnResetTitleVariablesSection.Text = "Reset to default";
			this.btnResetTitleVariablesSection.UseVisualStyleBackColor = true;
			// 
			// btnResetTitleFunctionsSection
			// 
			this.btnResetTitleFunctionsSection.Location = new System.Drawing.Point(375, 104);
			this.btnResetTitleFunctionsSection.Name = "btnResetTitleFunctionsSection";
			this.btnResetTitleFunctionsSection.Size = new System.Drawing.Size(95, 23);
			this.btnResetTitleFunctionsSection.TabIndex = 13;
			this.btnResetTitleFunctionsSection.Text = "Reset to default";
			this.btnResetTitleFunctionsSection.UseVisualStyleBackColor = true;
			// 
			// txtSectionTextTitleVariablesSection
			// 
			this.txtSectionTextTitleVariablesSection.Location = new System.Drawing.Point(181, 77);
			this.txtSectionTextTitleVariablesSection.Name = "txtSectionTextTitleVariablesSection";
			this.txtSectionTextTitleVariablesSection.Size = new System.Drawing.Size(170, 20);
			this.txtSectionTextTitleVariablesSection.TabIndex = 11;
			this.ttGeneralTooltip.SetToolTip(this.txtSectionTextTitleVariablesSection, "Text for title of section in the script, containing all variables");
			this.txtSectionTextTitleVariablesSection.TextChanged += new System.EventHandler(this.TxtSectionTextTitleVariablesSection_TextChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(7, 84);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(124, 13);
			this.label9.TabIndex = 12;
			this.label9.Text = "Title for variables-section";
			// 
			// ttGeneralTooltip
			// 
			this.ttGeneralTooltip.AutomaticDelay = 0;
			// 
			// chbSaveWithMenu
			// 
			this.chbSaveWithMenu.AutoSize = true;
			this.chbSaveWithMenu.Location = new System.Drawing.Point(616, 596);
			this.chbSaveWithMenu.Name = "chbSaveWithMenu";
			this.chbSaveWithMenu.Size = new System.Drawing.Size(143, 17);
			this.chbSaveWithMenu.TabIndex = 7;
			this.chbSaveWithMenu.Text = "Save scriptfile with menu";
			this.chbSaveWithMenu.UseVisualStyleBackColor = true;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// txtHotstringText
			// 
			this.txtHotstringText.AcceptsTab = true;
			this.txtHotstringText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHotstringText.AutoCompleteFunctionsList = null;
			this.txtHotstringText.AutoCompleteVariablesList = null;
			this.txtHotstringText.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtHotstringText.IgnoreChange = false;
			this.txtHotstringText.Location = new System.Drawing.Point(6, 100);
			this.txtHotstringText.Multiline = true;
			this.txtHotstringText.Name = "txtHotstringText";
			this.txtHotstringText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHotstringText.Size = new System.Drawing.Size(561, 419);
			this.txtHotstringText.TabIndex = 0;
			this.txtHotstringText.TabStop = false;
			// 
			// txtFunctionText
			// 
			this.txtFunctionText.AcceptsTab = true;
			this.txtFunctionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFunctionText.AutoCompleteFunctionsList = null;
			this.txtFunctionText.AutoCompleteVariablesList = null;
			this.txtFunctionText.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtFunctionText.IgnoreChange = false;
			this.txtFunctionText.Location = new System.Drawing.Point(6, 45);
			this.txtFunctionText.Multiline = true;
			this.txtFunctionText.Name = "txtFunctionText";
			this.txtFunctionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtFunctionText.Size = new System.Drawing.Size(653, 470);
			this.txtFunctionText.TabIndex = 0;
			this.txtFunctionText.TabStop = false;
			// 
			// txtChangeText
			// 
			this.txtChangeText.AcceptsTab = true;
			this.txtChangeText.AutoCompleteFunctionsList = null;
			this.txtChangeText.AutoCompleteVariablesList = null;
			this.txtChangeText.Font = new System.Drawing.Font("Lucida Console", 8.25F);
			this.txtChangeText.IgnoreChange = false;
			this.txtChangeText.Location = new System.Drawing.Point(6, 39);
			this.txtChangeText.Multiline = true;
			this.txtChangeText.Name = "txtChangeText";
			this.txtChangeText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChangeText.Size = new System.Drawing.Size(653, 479);
			this.txtChangeText.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(888, 621);
			this.Controls.Add(this.chbSaveWithMenu);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnSaveToFile);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip);
			this.Icon = global::AHK_updater.Resources.ICON;
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(720, 457);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AHK Updater";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.contextMenu.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabHotstrings.ResumeLayout(false);
			this.gbHotstring.ResumeLayout(false);
			this.gbHotstring.PerformLayout();
			this.tabVariables.ResumeLayout(false);
			this.gbVariable.ResumeLayout(false);
			this.gbVariable.PerformLayout();
			this.tabFunctions.ResumeLayout(false);
			this.gbFunction.ResumeLayout(false);
			this.gbFunction.PerformLayout();
			this.tabChangelog.ResumeLayout(false);
			this.gbChange.ResumeLayout(false);
			this.gbChange.PerformLayout();
			this.tabExtraction.ResumeLayout(false);
			this.tabExtraction.PerformLayout();
			this.gbExtractFunctions.ResumeLayout(false);
			this.gbExtractVariables.ResumeLayout(false);
			this.tabSettings.ResumeLayout(false);
			this.gbApplicationSettings.ResumeLayout(false);
			this.gbApplicationSettings.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void BtnExtractToAHK_Click1(object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException();
		}

		private System.Windows.Forms.Button btnCancelExtract;
        private System.Windows.Forms.Button btnExtractToAHK;
        private System.Windows.Forms.Button btnRemoveHotstring;
        private System.Windows.Forms.Button btnRemoveExtract;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnUpdateChange;
        private System.Windows.Forms.Button btnUpdateFunction;
        private System.Windows.Forms.Button btnUpdateHotstring;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lbChanges;
        private System.Windows.Forms.ListBox lbFunctions;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHotstrings;
        private System.Windows.Forms.TabPage tabFunctions;
        private System.Windows.Forms.TabPage tabChangelog;
        private System.Windows.Forms.TabPage tabExtraction;
        private AHK_updater.MyTextBox txtChangeText;
        private System.Windows.Forms.TextBox txtFunctionName;
        private AHK_updater.MyTextBox txtFunctionText;
        private System.Windows.Forms.TextBox txtHotstringName;
        private System.Windows.Forms.TextBox txtHotstringSystem;
        private AHK_updater.MyTextBox txtHotstringText;
        private System.Windows.Forms.ToolStripMenuItem contextItem;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripMenuItem menuNewCommand;
        private System.Windows.Forms.ToolTip ttGeneralTooltip;
        private System.Windows.Forms.TreeView treeHotstrings;
		private System.Windows.Forms.Button btnExtractToXML;
		private System.Windows.Forms.TabPage tabVariables;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtVariableName;
		private System.Windows.Forms.Button btnRemoveVariable;
		private System.Windows.Forms.Button btnUpdateVariable;
		private System.Windows.Forms.TextBox txtVariableValue;
		private System.Windows.Forms.ListBox lbVariables;
		private System.Windows.Forms.Button btnRemoveFunction;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtChangeVersion;
		private System.Windows.Forms.ListBox lbFunctionExtractions;
		private System.Windows.Forms.ListBox lbVariableExtractions;
		private System.Windows.Forms.GroupBox gbExtractFunctions;
		private System.Windows.Forms.GroupBox gbExtractVariables;
		private System.Windows.Forms.CheckBox chbSaveWithMenu;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtHotstringMenuTitle;
		private System.Windows.Forms.GroupBox gbHotstring;
		private System.Windows.Forms.GroupBox gbVariable;
		private System.Windows.Forms.GroupBox gbFunction;
		private System.Windows.Forms.GroupBox gbChange;
		private System.Windows.Forms.ListBox lbHotstringExtractions;
		private System.Windows.Forms.TabPage tabSettings;
		private System.Windows.Forms.Label lblMenuTrigger;
		private System.Windows.Forms.TextBox txtScriptOperationsMenuTrigger;
		private System.Windows.Forms.Button btnResetMenuTrigger;
		private System.Windows.Forms.ToolStripMenuItem tsmiNewFunction;
		private System.Windows.Forms.ToolStripMenuItem tsmiNewHotstring;
		private System.Windows.Forms.ToolStripMenuItem tsmiNewVariable;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtSectionTextTitleMenuSection;
		private System.Windows.Forms.Button btnResetTitleMenuSection;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtSectionTextTitleFunctionsSection;
		private System.Windows.Forms.Button btnResetTitleFunctionsSection;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtSectionTextTitleVariablesSection;
		private System.Windows.Forms.Button btnResetTitleVariablesSection;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtSectionTextTitleMenuTriggersSection;
		private System.Windows.Forms.Button btnResetTitleMenuTriggersSection;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtSectionTextTitleHotstringsSection;
		private System.Windows.Forms.Button btnResetTitleHotstringsSection;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtSectionTextTitleDivider;
		private System.Windows.Forms.Button btnResetTitleDivider;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.GroupBox gbApplicationSettings;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cbEditorToOpenFileWith;
		private System.Windows.Forms.Button btnOpenXML;
		private System.Windows.Forms.Button btnOpenScript;
	}
}
