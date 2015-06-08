using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace AHK_updater
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		bool test = false;
		string xmlFile, scriptFile;

		string scriptfilenameTest = "Example - Test.ahk",
				xmlfilenameTest = "Example - Test.xml",
				originalxmlfilenameTest = "C:\\Example - Test.xml",
				changelogfileTest = "Changelog - Test.txt";
		string scriptfilename = "Example.ahk",
				xmlfilename = "Example.xml",
				originalxmlfilename = "C:\\Example.xml",
				changelogfile = "Changelog.txt";
		AllData data = new AllData();
		AHKCommand currentItem;

		void MainFormLoad(object sender, EventArgs e)
		{
			Text = "AHK Updater " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			bool testXMLExists = File.Exists((test ? xmlfilenameTest : xmlfilename)),
				testOriginalXMLExists = File.Exists((test ? originalxmlfilenameTest : originalxmlfilename));

			//If file is present, open and read. Otherwise, read central file
			if (testXMLExists) {
				xmlFile = (test ? xmlfilenameTest : xmlfilename);
			} else if (testOriginalXMLExists) {
				xmlFile = test ? originalxmlfilenameTest : originalxmlfilename;
				MessageBox.Show("Ingen lokal XML-fil funnen, använder central fil.");
			}
			if (test) {
				menuStrip1.BackColor = Color.Red;
				scriptFile = scriptfilenameTest;
				xmlFile = xmlfilenameTest;
			} else {
				scriptFile = scriptfilename;
				xmlFile = xmlfilename;
			}
			getXMLCommands();
		}

		/**
		 * Reads the XML-file and sends the NodeLists for parsing
		 * If a username can not be found in the file, application asks user
		 *  
		 * filename: Name of the XML-file to read data
		 * */
		void getXMLCommands()
		{
			var xRead = new XmlTextReader(xmlFile);
			XmlDocument doc;

			doc = new XmlDocument();
			if (new FileInfo(xmlFile).Length != 0) {
				try {
					doc.Load(xRead);

					XmlNodeList name = doc.GetElementsByTagName("name"),
					command = doc.GetElementsByTagName("command"),
					text = doc.GetElementsByTagName("text"),
					system = doc.GetElementsByTagName("system"),
					functions = doc.GetElementsByTagName("functions"),
					changelogVersion = doc.GetElementsByTagName("version"),
					changelogEntry = doc.GetElementsByTagName("entry");
					xRead.WhitespaceHandling = WhitespaceHandling.None;
	
					insertCommands(command, text, system);
					insertFunctions(functions[0].InnerText);
					insertChangelog(changelogVersion, changelogEntry);

					//Ask for username, if not present in XML-file
					if (name.Count > 0) {
						if (name[0].InnerText.Equals("")) {
							userName();
						} else {
							data.UserName = name[0].InnerText;
						}
						Text = Text + " - " + data.UserName;
					} else {
						userName();
					}

					fillTreeView();

					xRead.Close();
				} catch (Exception e) {
					MessageBox.Show("XML-file wrongly coded.\r\n" + e);
				}
			}
		}

		void userName()
		{
			var un = new UserName();
			un.ShowDialog(this);
			if (!un.getName().Equals("")) {
				updatedData(true);
			}
			data.UserName = un.getName();
		}

		/**
		 * Add all hotstrings to the dataset
		 * 
		 * command, text, system: NodeLists containing data from XML-file
		 * */
		void insertCommands(XmlNodeList command, XmlNodeList text, XmlNodeList system)
		{
			if (command.Count > 0) {
				for (int i = 0; i < command.Count; i++) {
					data.addCommand(command[i].InnerText, text[i].InnerText.Trim(), system[i].InnerText);
				}
			}
		}

		/**
		 * Write all functions to txtFunctions
		 * 
		 * functions: string with text for functions
		 * */
		void insertFunctions(string functions)
		{
			if (functions.Length > 0) {
				txtFunctions.TextChanged -= txtFunctions_TextChanged;
				txtFunctions.Text = functions;
				txtFunctions.TextChanged += txtFunctions_TextChanged;
				data.Functions = functions;
			}
		}

		/**
		 * Get previous changelogentries
		 * 
		 * changlogVersion, changelogEntry: NodeLists with versionnumber and changelogentries
		 * */
		void insertChangelog(XmlNodeList changelogVersion, XmlNodeList changelogEntry)
		{
			if (changelogVersion.Count > 0) {
				for (int i = 0; i < changelogVersion.Count; i++) {
					data.updateChangelog(changelogVersion[i].InnerText, changelogEntry[i].InnerText);
				}
			}
			txtChangelog.Text = data.initiateChangelog();
		}

		/**
		 * Closes the application
		 * */
		void shutdown()
		{
			updatedData(false);
			Application.Exit();
		}

		/**
		 * Sets reads all commands in data.commandslist and inserts in tree
		 * If a system is not present, create a node under root
		 * */
		void fillTreeView()
		{
			treeHotstrings.Nodes.Clear();
			foreach (AHKCommand item in data.commandslist) {
				if (!item.System.Equals("")) {
					if (!treeHotstrings.Nodes.ContainsKey(item.System)) {
						var tn = new TreeNode(item.System);
						tn.Name = item.System;
						treeHotstrings.Nodes.Add(tn);
					}
					var newNode = new TreeNode(item.Command);
					newNode.Tag = item.Text;
					treeHotstrings.Nodes[item.System].Nodes.Add(newNode);
				}
			}
			treeHotstrings.Sort();
		}

		/**
		 * Collect the hotstrings and write to AutoHotKey scriptfile
		 * */
		void saveToScriptFile()
		{
			var writer = new StreamWriter((scriptFile), false, System.Text.Encoding.GetEncoding(1252));

			try {
				writer.WriteLine("SetTimer,UPDATEDSCRIPT,1000");
				writer.Write("UPDATEDSCRIPT:\nFileGetAttrib,attribs,%A_ScriptFullPath%\nIfInString,attribs,A\n{\nFileSetAttrib,-A,%A_ScriptFullPath%\nSplashTextOn,,,Updated script,\nSleep,500\nReload\n}\nReturn\n\n");
				writer.Write(fetchCommandsForScript());
				writer.Flush();
				writer.WriteLine("GuiClose:\r\nExitApp");
				writer.Close();
				statusUpdate(", Scriptfile", true);

				updatedData(false);
			} catch (Exception exc) {
				MessageBox.Show("Something went wrong when writing script-file.\nError:\n" + exc.Message, "Write error", MessageBoxButtons.OK);
			}
		}

		/**
		 * Collect the hotstrings and write to XML-file
		 * */
		void saveToXMLFile()
		{
			var writer = new StreamWriter((xmlFile), false, System.Text.Encoding.UTF8);

			try {
				writer.WriteLine("<?xml version=\"1.0\"?>\r\n<ahk>");
				writer.WriteLine("<ahkcommand><name>" + data.UserName + "</name></ahkcommand>");
				writer.Write(fetchCommandsForXML());
				writer.Flush();
				writer.WriteLine(fetchFunctions());
				writer.Write(fetchChangelogXML());
				writer.WriteLine("</ahk>");
				writer.Close();
				statusUpdate("Files have been saved: XMLfile", false);

				updatedData(false);
			} catch (Exception exc) {
				MessageBox.Show("Something went wrong when writing XML-file.\nError:\n" + exc.Message.ToString(), "Write error", MessageBoxButtons.OK);
			}
		}

		/**
		 * Write changelog
		 * */
		void saveToChangelog()
		{
			var writer = new StreamWriter((test ? changelogfileTest : changelogfile), false, System.Text.UnicodeEncoding.Unicode);

			try {
				writer.Write(data.getChangelogText());
				writer.Flush();
				writer.Close();
			} catch (Exception e) {
				MessageBox.Show("Something went wrong when writing Changelog.\nError:\n" + e.Message, "Write error", MessageBoxButtons.OK);
			}
		}

		/**
		 * Collect all hotstrings
		 * 
		 * Return as string
		 * */
		string fetchCommandsForXML()
		{
			var xmlText = "";

			foreach (AHKCommand item in data.commandslist) {
				if (item.System.Equals("Variables")) {
					xmlText = item.getXmlString() + "\r\n" + xmlText;
				} else {
					xmlText = xmlText + item.getXmlString() + "\r\n";
				}
			}

			return xmlText;
		}

		/**
		 * Collect all hotstrings
		 * 
		 * Return as XML-formated string
		 * */
		string fetchCommandsForScript()
		{
			string scriptData = "";
			foreach (AHKCommand item in data.commandslist) {
				if (item.System.Equals("Variables")) {
					scriptData = item.getScriptString() + "\r\n" + scriptData;
				} else {
					scriptData = scriptData + item.getScriptString() + "\r\n";
				}
			}

			return scriptData + txtFunctions.Text.Trim() + "\r\n";
		}

		/**
		 * Insert functiontext as XML-code
		 * 
		 * Return as string
		 * */
		string fetchFunctions()
		{
			return "<ahkcommand><functions>" + txtFunctions.Text + "</functions></ahkcommand>";
		}

		/**
		 * Get all changelogentries as XML
		 * 
		 * Return as string
		 * */
		string fetchChangelogXML()
		{
			return data.getChangelogXML();
		}

		/**
		 * Sets the status label with the newest information
		 * 
		 * newStatus: Information of that was last performed
		 * */
		void statusUpdate(string newStatus, bool addition)
		{
			if (addition)
				lblStatus.Text += newStatus;
			else
				lblStatus.Text = newStatus;
		}

		/**
		 * Open form for defining name of hotstring
		 * Change selected tab in tabControl if new function is to be created
		 * */
		void menuNewHotstring_Click(object sender, EventArgs e)
		{
			var f = new NewCommand(ref data);
			DialogResult a = f.ShowDialog(this);

			if (a == DialogResult.OK) {
				string commandName = f.getItem(), commandSystem = f.getSystem(), commandText;
				int commandType = f.getCommandType();
				TreeNode newNode = null;

				if (commandType == 2) {
					tabControl.SelectedIndex = 1;
					txtFunctions.Focus();
					txtFunctions.Text = txtFunctions.Text + "\r\n" + commandName + "\r\n{\r\n\r\n}";
				} else {
					currentItem = new AHKCommand(commandName, "", commandSystem);
					if (commandType == 0) {
						commandText = "SendInput,\r\n(\r\n\r\n)\r\nReturn";
					} else {
						commandSystem = "Variables";
						commandText = "";
					}
					data.addCommand(commandName, commandText, commandSystem);

					if (!treeHotstrings.Nodes.ContainsKey(commandSystem)) {
						var tn = new TreeNode(commandSystem);
						tn.Name = commandSystem;
						treeHotstrings.Nodes.Add(tn);
					}
					newNode = new TreeNode(commandName);
					treeHotstrings.Nodes[commandSystem].Nodes.Add(newNode);
				}
				updatedData(true);
				treeHotstrings.Sort();
				tabControl.SelectedIndex = 0;
				treeHotstrings.SelectedNode = newNode;
				ActiveControl = txtHotstringText;
			}
		}

		/**
		 * Called when text for hotstring is edited
		 * If currentItem is null an item have been removed and textbox is empty
		 * Otherwise checks against text in currentItem
		 * */
		void txtHotstringText_TextChanged(object sender, EventArgs e)
		{
			if (currentItem != null) {
				if (txtHotstringText.Text != currentItem.Text) {
					btnSaveHotstring.Enabled = true;
					btnSaveHotstring.Visible = true;
				} else {
					btnSaveHotstring.Enabled = false;
					btnSaveHotstring.Visible = false;
				}
			}
		}

		/**
		 * Called when textbox for funtions is edited
		 * Checks if data.Funtions is same as textbox
		 * */
		void txtFunctions_TextChanged(object sender, EventArgs e)
		{
			if (!data.Functions.Equals(txtFunctions.Text)) {
				btnSaveFunctions.Enabled = true;
				btnSaveFunctions.Visible = true;
			} else {
				btnSaveFunctions.Enabled = false;
				btnSaveFunctions.Visible = false;
			}
		}

		/**
		 * Text in textbox for system have changed,
		 * enable button for saving
		 * */
		void txtSystem_TextChanged(object sender, EventArgs e)
		{
			if (!currentItem.System.Equals(txtSystem.Text)) {
				btnSaveHotstring.Enabled = true;
				btnSaveHotstring.Visible = true;
			} else {
				btnSaveHotstring.Enabled = false;
				btnSaveHotstring.Visible = false;
			}
		}

		/**
		 * Text in textbox for changelog have changed,
		 * enable button for saving
		 * */
		void txtChangelog_TextChanged(object sender, EventArgs e)
		{
			string a = data.CurrentChangelogItem, b = txtChangelog.Text;

			if (!a.Equals(b)) {
				btnSaveChangelog.Enabled = true;
				btnSaveChangelog.Visible = true;
			} else {
				btnSaveChangelog.Enabled = false;
				btnSaveChangelog.Visible = false;
			}
		}

		/**
		 * Update item with the new text in textbox
		 * If the system of the command have changed, refill the tree
		 * */
		void btnSaveHotstring_Click(object sender, EventArgs e)
		{
			var temp = new ChangeLogText(currentItem.Command);
			temp.ShowDialog(this);
			
			if (temp.DialogResult == DialogResult.OK || temp.DialogResult == DialogResult.Cancel) {
				if (!currentItem.System.Equals(txtSystem.Text))
					fillTreeView();
				if (temp.DialogResult == DialogResult.OK)
				{
					data.updateCurrentChangelogItem(temp.getChangeInfo(), false);
					txtChangelog.Text = data.CurrentChangelogItem;
				}

				data.updateCommandItem(currentItem.Command, txtHotstringText.Text, txtSystem.Text);
				updatedData(true);
				statusUpdate("Hotstring " + currentItem.Command + " have been updated", false);
			} else if (temp.DialogResult == DialogResult.Abort) {
				statusUpdate("Hotstring " + currentItem.Command + " was not updated", false);
				txtHotstringText.Text = currentItem.Text;
				txtSystem.Text = currentItem.System;
			}

			treeHotstrings.HideSelection = false;
			btnSaveHotstring.Enabled = false;
			btnSaveHotstring.Visible = false;
			ActiveControl = txtHotstringText;
			txtHotstringText.Select(0, 0);
		}

		/**
		 * Update string for functions
		 * */
		void btnSaveFunctions_Click(object sender, EventArgs e)
		{
			var temp = new ChangeLogText();
			temp.ShowDialog(this);

			if (temp.DialogResult == DialogResult.OK || temp.DialogResult == DialogResult.Cancel) {
				if (temp.DialogResult == DialogResult.OK)
				{
					data.updateCurrentChangelogItem(temp.getChangeInfo(), false);
					txtChangelog.Text = data.CurrentChangelogItem;
				}
				data.Functions = txtFunctions.Text;
				updatedData(true);
				statusUpdate("Functions have been updated", false);
			} else if (temp.DialogResult == DialogResult.Abort) {
				statusUpdate("Functions was not updated", false);
				txtFunctions.Text = data.Functions;
			}

			btnSaveFunctions.Enabled = false;
			btnSaveFunctions.Visible = false;
			ActiveControl = txtFunctions;
		}

		/**
		 * Update current entry of changelog
		 * */
		void btnSaveChangelog_Click(object sender, EventArgs e)
		{
			data.updateCurrentChangelogItem(txtChangelog.Text, true);

			updatedData(true);
			statusUpdate("Changelog have been updated", false);
			btnSaveChangelog.Enabled = false;
			btnSaveChangelog.Visible = false;
			ActiveControl = txtChangelog;
		}

		/**
		 * Called when form is closing
		 * If anything have been updated, ask user if changes are to be saved
		 * Otherwise, close application
		 * */
		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (data.Updated) {
				DialogResult answer = MessageBox.Show("Unsaved changes have been made.\r\nDo you want to save?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

				if (answer == DialogResult.Yes) {
					saveToScriptFile();
					saveToXMLFile();
					shutdown();
				} else if (answer == DialogResult.No) {
					shutdown();
				} else {
					e.Cancel = true;
				}
			} else {
				shutdown();
			}
		}

		/**
		 * Close form
		 * */
		void menuClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/**
		 * Called when user clicks menuitem to remove command
		 * Ask user to remove item
		 * Remove item from tree and commandslist, if there are no other items with same system, remove system from root
		 * */
		void btnRemoveCommand_Click(object sender, EventArgs e)
		{
			DialogResult answer = MessageBox.Show("Remove command " + currentItem.Command + "?", "Remove", MessageBoxButtons.YesNo);

			if (answer == DialogResult.Yes) {
				data.deleteItem(currentItem.Command);
				treeHotstrings.Nodes.Remove(treeHotstrings.SelectedNode);
				if (treeHotstrings.Nodes[currentItem.System].Nodes.Count == 0) {
					treeHotstrings.Nodes.RemoveByKey(currentItem.System);
				}

				statusUpdate("Command " + currentItem.Command + " have been removed.", false);
				updatedData(true);
			}
		}

		/**
		 * User wants to change name of command
		 * Open form to ask for new name
		 * */
		void btnChangeName_Click(object sender, EventArgs e)
		{
			var nm = new NewName(currentItem.Command);
			nm.ShowDialog(this);

			if (nm.DialogResult == DialogResult.OK) {
				data.setNewName(currentItem.Command, nm.getNewName());
				updatedData(true);
				fillTreeView();
				ActiveControl = txtHotstringText;
				statusUpdate("New name (" + nm.getNewName() + ") of command " + currentItem.Command, false);
			}
		}

		/**
		 * A node in treeHotstrings have been selected
		 * Load the corresponting hotstring
		 * */
		void treeHotstrings_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Level != 0) {
				currentItem = data.commandslist.Find(x => x.Command.Equals(e.Node.Text));
				txtHotstringText.Text = currentItem.Text;
				txtSystem.Text = currentItem.System;

				ActiveControl = txtHotstringText;
				btnRemoveCommand.Visible = true;
				btnChangeName.Visible = true;
			} else {
				txtHotstringText.Text = "";
				currentItem = null;
				btnRemoveCommand.Visible = false;
				btnChangeName.Visible = false;
			}
		}

		/**
		 * Sets Updated to true and making menuitem for Save to file visible
		 * */
		void updatedData(bool updated)
		{
			data.Updated = updated;
			btnSaveToFile.Visible = updated;
		}

		/**
		 * Calls the texteditor to open specified file
		 * 
		 * fileToOpen: Name of file to be opened
		 * */
		void openFile(string fileToOpen)
		{
			var startInfo = new ProcessStartInfo();

			if(File.Exists(@"C:\Program Files\Notepad++\notepad++.exe"))
				startInfo.FileName = @"C:\Program Files\Notepad++\notepad++.exe";
			else
				startInfo.FileName = @"C:\Windows\notepad.exe";
			startInfo.Arguments = fileToOpen;
			Process.Start(startInfo);
			statusUpdate("File have been opened", false);
		}

		/**
		 * Called when the user wants to read the scriptfile
		 * */
		void menuOpenScript_Click(object sender, EventArgs e)
		{
			openFile(scriptFile);
		}

		/**
		 * Called when the user wants to read the XML-file
		 * */
		void menuOpenXML_Click(object sender, EventArgs e)
		{
			openFile(xmlFile);
		}

		/**
		 * Save the data to the script- and XML-file
		 * */
		void btnSaveToFile_Click(object sender, EventArgs e)
		{
			saveToXMLFile();
			saveToScriptFile();
			btnSaveToFile.Visible = false;
		}
	}
}
