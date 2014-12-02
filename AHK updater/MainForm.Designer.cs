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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
			this.menuSaveToFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
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
			resources.ApplyResources(this.txtHotstringText, "txtHotstringText");
			this.txtHotstringText.Name = "txtHotstringText";
			this.txtHotstringText.TabStop = false;
			this.txtHotstringText.TextChanged += new System.EventHandler(this.txtHSText_TextChanged);
			// 
			// tabControl
			// 
			resources.ApplyResources(this.tabControl, "tabControl");
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Controls.Add(this.tabPage3);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			// 
			// tabPage1
			// 
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Controls.Add(this.btnChangeName);
			this.tabPage1.Controls.Add(this.btnRemoveCommand);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtSystem);
			this.tabPage1.Controls.Add(this.treeHotstrings);
			this.tabPage1.Controls.Add(this.btnSaveHotstring);
			this.tabPage1.Controls.Add(this.txtHotstringText);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnChangeName
			// 
			resources.ApplyResources(this.btnChangeName, "btnChangeName");
			this.btnChangeName.Name = "btnChangeName";
			this.btnChangeName.UseVisualStyleBackColor = true;
			this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
			// 
			// btnRemoveCommand
			// 
			resources.ApplyResources(this.btnRemoveCommand, "btnRemoveCommand");
			this.btnRemoveCommand.Name = "btnRemoveCommand";
			this.btnRemoveCommand.UseVisualStyleBackColor = true;
			this.btnRemoveCommand.Click += new System.EventHandler(this.btnRemoveCommand_Click);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// txtSystem
			// 
			resources.ApplyResources(this.txtSystem, "txtSystem");
			this.txtSystem.Name = "txtSystem";
			this.txtSystem.TextChanged += new System.EventHandler(this.txtSystem_TextChanged);
			// 
			// treeHotstrings
			// 
			resources.ApplyResources(this.treeHotstrings, "treeHotstrings");
			this.treeHotstrings.FullRowSelect = true;
			this.treeHotstrings.HideSelection = false;
			this.treeHotstrings.Name = "treeHotstrings";
			this.treeHotstrings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeHotstrings_AfterSelect);
			// 
			// btnSaveHotstring
			// 
			resources.ApplyResources(this.btnSaveHotstring, "btnSaveHotstring");
			this.btnSaveHotstring.Name = "btnSaveHotstring";
			this.btnSaveHotstring.UseVisualStyleBackColor = true;
			this.btnSaveHotstring.Click += new System.EventHandler(this.btnSaveHotstring_Click);
			// 
			// tabPage2
			// 
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Controls.Add(this.btnSaveFunctions);
			this.tabPage2.Controls.Add(this.txtFunctions);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnSaveFunctions
			// 
			resources.ApplyResources(this.btnSaveFunctions, "btnSaveFunctions");
			this.btnSaveFunctions.Name = "btnSaveFunctions";
			this.btnSaveFunctions.UseVisualStyleBackColor = true;
			this.btnSaveFunctions.Click += new System.EventHandler(this.btnSaveFunctions_Click);
			// 
			// txtFunctions
			// 
			resources.ApplyResources(this.txtFunctions, "txtFunctions");
			this.txtFunctions.Name = "txtFunctions";
			this.txtFunctions.TextChanged += new System.EventHandler(this.txtFunctions_TextChanged);
			// 
			// tabPage3
			// 
			resources.ApplyResources(this.tabPage3, "tabPage3");
			this.tabPage3.Controls.Add(this.btnSaveChangelog);
			this.tabPage3.Controls.Add(this.txtChangelog);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// btnSaveChangelog
			// 
			resources.ApplyResources(this.btnSaveChangelog, "btnSaveChangelog");
			this.btnSaveChangelog.Name = "btnSaveChangelog";
			this.btnSaveChangelog.UseVisualStyleBackColor = true;
			this.btnSaveChangelog.Click += new System.EventHandler(this.btnSaveChangelog_Click);
			// 
			// txtChangelog
			// 
			this.txtChangelog.AcceptsTab = true;
			resources.ApplyResources(this.txtChangelog, "txtChangelog");
			this.txtChangelog.Name = "txtChangelog";
			this.txtChangelog.TextChanged += new System.EventHandler(this.txtChangelog_TextChanged);
			// 
			// menuStrip1
			// 
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuNewHotstring,
									this.menuSaveToFile,
									this.menuClose});
			this.menuStrip1.Name = "menuStrip1";
			// 
			// menuNewHotstring
			// 
			resources.ApplyResources(this.menuNewHotstring, "menuNewHotstring");
			this.menuNewHotstring.Name = "menuNewHotstring";
			this.menuNewHotstring.Click += new System.EventHandler(this.menuNewHotstring_Click);
			// 
			// menuSaveToFile
			// 
			resources.ApplyResources(this.menuSaveToFile, "menuSaveToFile");
			this.menuSaveToFile.Name = "menuSaveToFile";
			this.menuSaveToFile.Click += new System.EventHandler(this.menuSaveToFile_Click);
			// 
			// menuClose
			// 
			resources.ApplyResources(this.menuClose, "menuClose");
			this.menuClose.Name = "menuClose";
			this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
		private System.Windows.Forms.TextBox txtHotstringText;
	}
}
