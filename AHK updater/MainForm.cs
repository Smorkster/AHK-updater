using System;
using System.Collections.Generic;
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

		string scriptfilenameTest = @"H:\AHK - Standardsvar Test.ahk",
			xmlfilenameTest = @"H:\AHK - Standardsvar Test.xml",
			originalxmlfilenameTest = @"G:\Lit\Servicedesk\Verktyg\AutoHotKey\AHK - Standardsvar Test.xml",
			changelogfileTest = @"H:\AHK Changelog.txt";
		string scriptfilename = @"H:\AHK - Standardsvar.ahk",
			xmlfilename = @"H:\AHK - Standardsvar.xml",
			originalxmlfilename = @"G:\Lit\Servicedesk\Verktyg\AutoHotKey\AHK - Standardsvar.xml",
			changelogfile = @"G:\Lit\Servicedesk\Verktyg\AutoHotKey\AHK - changelog.txt";
		AllData data = new AllData();
		AHKCommand currentHotstring;
		Function currentFunction;
		List<AHKCommand> toExtract = new List<AHKCommand>();
		bool hotstringTextChanged, functionsTextChanged, changelogTextChanged;

		/// <summary>
		/// Set form title and check which XML-file to be read with data
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void MainForm_Load(object sender, EventArgs e)
		{
			Text = "AHK Updater " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

			if(test)
			{
				menuStrip1.BackColor = Color.Red;
				Text = "IN TEST MODE";
			}

			//If file is present, open and read. Otherwise, read original file
			if (File.Exists(test ? xmlfilenameTest : xmlfilename)) {
				xmlFile = test ? xmlfilenameTest : xmlfilename;
			} else if (File.Exists(test ? originalxmlfilenameTest : originalxmlfilename)) {
				xmlFile = test ? originalxmlfilenameTest : originalxmlfilename;
				MessageBox.Show("No local XML-file found. Using original.");
			}
			scriptFile = test ? scriptfilenameTest : scriptfilename;

			if (xmlFile != null)
				getXMLCommands();
			else
				MessageBox.Show("No file found. The list of commands will be empty.");
		}

		/// <summary>
		/// Reads the XML-file and sends the NodeLists for parsing
		/// If a username can not be found in the file, application asks user 
		/// </summary>
		void getXMLCommands()
		{
			var xRead = new XmlTextReader(xmlFile);
			var doc = new XmlDocument();

			if (new FileInfo(xmlFile).Length != 0) {
				try {
					doc.Load(xRead);
					xRead.WhitespaceHandling = WhitespaceHandling.None;

					XmlNodeList name = doc.GetElementsByTagName("name"),
								command = doc.GetElementsByTagName("command"),
								text = doc.GetElementsByTagName("text"),
								system = doc.GetElementsByTagName("system"),
								functionname = doc.GetElementsByTagName("functionname"),
								functiontext = doc.GetElementsByTagName("functiontext"),
								changelogVersion = doc.GetElementsByTagName("version"),
								changelogEntry = doc.GetElementsByTagName("entry");

					insertHotstrings(command, text, system);
					insertFunctions(functionname, functiontext);
					insertChangelog(changelogVersion, changelogEntry);

					//Check if username is present, if not, ask for username
					if (name.Count > 0) {
						if (name[0].InnerText.Equals("")) {
							askForUserName();
						} else {
							data.UserName = name[0].InnerText;
						}
						Text = Text + " - " + data.UserName;
					} else {
						askForUserName();
					}

					updateTreeView();

					xRead.Close();
				} catch (Exception e) {
					MessageBox.Show("Error while reading XML-file.\r\n" + e);
				}
			}
		}

		/// <summary>
		/// Ask the user to give a username to be available in scripts 
		/// </summary>
		void askForUserName()
		{
			var username = new UserName();
			username.ShowDialog(this);
			if (!username.getName().Equals("")) {
				updatedData(true);
			}
			data.UserName = username.getName();
			xmlFile = @"H:\AHK - Standardsvar.xml";
			scriptFile = @"H:\AHK - Standardsvar.ahk";
			saveToXMLFile();
			saveToScriptFile();
		}

		/// <summary>
		/// Add all hotstrings to the dataset 
		/// </summary>
		/// <param name="hotstringName">Name of the hotstring</param>
		/// <param name="hotstringText">Codetext of the hotstring</param>
		/// <param name="hotstringSystem">System of the hotstring for grouping</param>
		void insertHotstrings(XmlNodeList hotstringName, XmlNodeList hotstringText, XmlNodeList hotstringSystem)
		{
			if (hotstringName.Count > 0) {
				for (int i = 0; i < hotstringName.Count; i++) {
					data.addHotstring(hotstringName[i].InnerText, hotstringText[i].InnerText.Trim(), hotstringSystem[i].InnerText);
				}
			}
		}

		/// <summary>
		/// Write all functions to txtFunctions
		/// Remove eventhandler to avoid the button for saving to be shown
		/// </summary>
		/// <param name="functionname">Name of function</param>
		/// <param name="functiontext">Codetext of function</param>
		void insertFunctions(XmlNodeList functionname, XmlNodeList functiontext)
		{
			if (functionname.Count > 0) {
				for (int i = 0; i < functionname.Count; i++)
				{
					data.addFunction(functionname[i].InnerText, functiontext[i].InnerText);
					lbFunctions.Items.Add(functionname[i].InnerText);
				}

				/*txtFunctions.TextChanged -= txtFunctions_TextChanged;
				txtFunctions.Text = functions;
				txtFunctions.TextChanged += txtFunctions_TextChanged;
				data.Functions = functions;*/
			}
		}

		/// <summary>
		/// Get previous changelogentries 
		/// </summary>
		/// <param name="changelogVersion">NodeList with versionnumbers</param>
		/// <param name="changelogEntry">NodeList with changelogentries</param>
		void insertChangelog(XmlNodeList changelogVersion, XmlNodeList changelogEntry)
		{
			txtChangelog.TextChanged -= txtChangelog_TextChanged;
			if (changelogVersion.Count > 0) {
				for (int i = 0; i < changelogVersion.Count; i++) {
					data.updateChangelog(changelogVersion[i].InnerText, changelogEntry[i].InnerText);
					lbChangelogItems.Items.Add(changelogVersion[i].InnerText);
				}
			}
			data.initiateChangelog();
			txtChangelog.Text = data.currentChangelogEntry.Version + "\r\n----------\r\n\r\n" + data.currentChangelogEntry.Entry;
			txtChangelog.TextChanged += txtChangelog_TextChanged;
		}

		/// <summary>
		/// Closes the application 
		/// </summary>
		void shutdown()
		{
			hotstringTextChanged = functionsTextChanged = changelogTextChanged = false;
			updatedData(false);
			Application.Exit();
		}

		/// <summary>
		/// Sets all commands in data.commandslist and inserts in treeview
		/// If a system is not present, create a node under root
		/// </summary>
		void updateTreeView()
		{
			treeHotstrings.Nodes.Clear();
			foreach (AHKCommand item in data.hotstringsList) {
				if (!item.System.Equals("")) {
					if (!treeHotstrings.Nodes.ContainsKey(item.System)) {
						var treeNode = new TreeNode(item.System);
						treeNode.Name = item.System;
						treeHotstrings.Nodes.Add(treeNode);
					}
					var newNode = new TreeNode(item.Name);
					newNode.Tag = item.Text;
					treeHotstrings.Nodes[item.System].Nodes.Add(newNode);
				}
			}
			treeHotstrings.Sort();
		}

		void updateFunctionListBox()
		{
			lbFunctions.Items.Clear();
			foreach(Function item in data.functionsList)
				lbFunctions.Items.Add(item.Name);
		}
		/// <summary>
		/// Collect the hotstrings and write to AutoHotKey scriptfile 
		/// </summary>
		void saveToScriptFile()
		{
			var writer = new StreamWriter((scriptFile), false, System.Text.Encoding.GetEncoding(1252));

			try {
				writer.WriteLine("SetTimer,UPDATEDSCRIPT,1000");
				writer.Write("UPDATEDSCRIPT:\nFileGetAttrib,attribs,%A_ScriptFullPath%\nIfInString,attribs,A\n{\nFileSetAttrib,-A,%A_ScriptFullPath%\nSplashTextOn,,,Updated script,\nSleep,500\nReload\n}\nReturn\n\n");
				writer.Write(fetchHotstringsForScript());
				writer.Flush();
				writer.Write(fetchFunctionsForScript());
				writer.WriteLine("ExitApp");
				writer.Close();
				statusUpdate(", Scriptfile", true);

				updatedData(false);
			} catch (Exception e) {
				MessageBox.Show("Something went wrong when writing script-file.\nError:\n" + e.Message, "Write error", MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// Collect the hotstrings and write to XML-file 
		/// </summary>
		void saveToXMLFile()
		{
			var writer = new StreamWriter((xmlFile), false, System.Text.Encoding.UTF8);

			try {
				writer.WriteLine("<?xml version=\"1.0\"?>\r\n<ahk>");
				writer.WriteLine("<ahkcommand><name>" + data.UserName + "</name></ahkcommand>");
				writer.Write(fetchHotstringsForXML());
				writer.Flush();
				writer.WriteLine(fetchFunctionsXML());
				writer.Write(fetchChangelogXML());
				writer.WriteLine("</ahk>");
				writer.Close();
				statusUpdate("Files have been saved: XMLfile", false);

				updatedData(false);
			} catch (Exception exc) {
				MessageBox.Show("Something went wrong when writing XML-file.\nError:\n" + exc.Message.ToString(), "Write error", MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// Write changelog to file 
		/// </summary>
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

		/// <summary>
		/// Collect all hotstrings 
		/// </summary>
		/// <returns>Return each as XML-formated string</returns>
		string fetchHotstringsForXML()
		{
			var xmlText = "";

			foreach (AHKCommand item in data.hotstringsList) {
				if (item.System.Equals("Variables")) {
					xmlText = item.getXmlString() + "\r\n" + xmlText;
				} else {
					xmlText = xmlText + item.getXmlString() + "\r\n";
				}
			}

			return xmlText;
		}

		/// <summary>
		/// Collect all hotstrings 
		/// </summary>
		/// <returns>Return each as AHK-formated string</returns>
		string fetchHotstringsForScript()
		{
			string scriptData = "";

			foreach (AHKCommand item in data.hotstringsList) {
				if (item.System.Equals("Variables")) {
					scriptData = item.getScriptString() + "\r\n" + scriptData;
				} else {
					scriptData = scriptData + item.getScriptString() + "\r\n";
				}
			}

			return scriptData + "\r\n";
		}

		/// <summary>
		/// Insert functiontext as XML-code 
		/// </summary>
		/// <returns>XML-string of the functions</returns>
		string fetchFunctionsXML()
		{
			var xmlText = "";
			foreach(Function item in data.functionsList)
				xmlText = xmlText + "\r\n" + item.getXmlString();
			return xmlText;
		}

		string fetchFunctionsForScript()
		{
			string scriptData = "";
			
			foreach (Function item in data.functionsList)
				scriptData = scriptData + item.Text + "\r\n";
			return scriptData;
		}

		/// <summary>
		/// Collect all changelogentries 
		/// </summary>
		/// <returns>Return each as string</returns>
		string fetchChangelogXML()
		{
			return data.getChangelogXML();
		}

		/// <summary>
		/// Sets the status label with the newest information 
		/// </summary>
		/// <param name="newStatus">Information of that was last performed</param>
		/// <param name="addition">If the text is to be added to any previous text</param>
		void statusUpdate(string newStatus, bool addition)
		{
			if (addition)
				lblStatus.Text += newStatus;
			else
				lblStatus.Text = newStatus;
		}

		/// <summary>
		/// Sets Updated to true and making button for Save to file visible 
		/// </summary>
		/// <param name="updated">If data is to be updated</param>
		void updatedData(bool updated)
		{
			data.Updated = updated;
			btnSaveToFile.Visible = updated;
		}

		/// <summary>
		/// Calls a texteditor to open specified file 
		/// </summary>
		/// <param name="fileToOpen">Name of file to be opened</param>
		void openFile(string fileToOpen)
		{
			var startInfo = new ProcessStartInfo();

			startInfo.FileName = File.Exists(@"C:\Program Files\Notepad++\notepad++.exe") ? @"C:\Program Files\Notepad++\notepad++.exe" : @"C:\Windows\notepad.exe";
			startInfo.Arguments = fileToOpen;
			Process.Start(startInfo);
			statusUpdate("File has been opened", false);
		}

		/// <summary>
		/// Depending on which textbox is the sender, do the corresponding save 
		/// </summary>
		/// <param name="sender">Reference of which textbox the keystroke is made in</param>
		/// <param name="e">Generic KeyEventArgs</param>
		void shortcutSave(string sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.S) {
				switch (sender) {
					case "hotstring":
						if (currentHotstring != null)
							btnUpdateHotstring_Click(null, null);
						break;
					case "changelog":
						btnUpdateChangelog_Click(null, null);
						break;
					case "functions":
						btnUpdateFunction_Click(null, null);
						break;
				}
			}
		}

		/// <summary>
		/// Determine which textbox the event came from and ask user to save before changing focus
		/// </summary>
		/// <param name="sender">Reference of which textbox the event is made in</param>
		/// <param name="e">Generic Eventargs</param>
		void textbox_leave(string sender, EventArgs e)
		{
			var textType = "";
			switch (sender) {
				case "hotstring":
					textType = "Commandtext";
					break;
				case "changelog":
					textType = "Changelogtext";
					break;
				case "functions":
					textType = "Functionstext";
					break;
			}

			var ans = MessageBox.Show(textType + " have changed.\nDo you want to save?", "Text changed", MessageBoxButtons.YesNo);
			if (ans == DialogResult.Yes)
				btnUpdateHotstring_Click(null, null);
			else {
				btnUpdateHotstring.Enabled = false;
				hotstringTextChanged = false;
			}
		}

		/// <summary>
		/// Called when text for hotstring is edited
		/// If currentItem is null an item have been removed and textbox is empty
		/// Otherwise checks against text in currentItem 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtHotstringText_TextChanged(object sender, EventArgs e)
		{
			if (currentHotstring != null) {
				if (txtHotstringText.Text != currentHotstring.Text) {
					btnUpdateHotstring.Enabled = true;
					hotstringTextChanged = true;
				} else {
					btnUpdateHotstring.Enabled = false;
					hotstringTextChanged = false;
				}
			}
		}

		/// <summary>
		/// Called when textbox for funtions is edited
		/// Checks if data.Funtions is same as textbox
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtFunctions_TextChanged(object sender, EventArgs e)
		{
			if (!data.getFunction(lbFunctions.SelectedItem.ToString()).Text.Equals(txtFunctionText.Text)) {
				btnUpdateFunction.Enabled = true;
				btnUpdateFunction.Visible = true;
				functionsTextChanged = true;
			} else {
				btnUpdateFunction.Enabled = false;
				btnUpdateFunction.Visible = false;
				functionsTextChanged = false;
			}
		}

		/// <summary>
		/// Text in textbox for System have changed, enable button for saving 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtSystem_TextChanged(object sender, EventArgs e)
		{
			if(currentHotstring != null)
			{
				if (!currentHotstring.System.Equals(txtHotstringSystem.Text)) {
					btnUpdateHotstring.Enabled = true;
					hotstringTextChanged = true;
				} else {
					btnUpdateHotstring.Enabled = false;
					hotstringTextChanged = false;
				}
			}
		}

		/// <summary>
		/// Function to check if users want to save changes in textbox before changing focus 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtHotstringText_Leave(object sender, EventArgs e)
		{
			if (!btnUpdateHotstring.ContainsFocus)
			{
				if (hotstringTextChanged)
					textbox_leave("hotstring", e);
			}
			hotstringTextChanged = false;
		}
		/// <summary>
		/// Function to check if users want to save changes in textbox before changing focus 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtFunctionsText_Leave(object sender, EventArgs e)
		{
			if (!btnUpdateFunction.ContainsFocus)
				if (functionsTextChanged)
					textbox_leave("functions", e);
		}
		/// <summary>
		/// Function to check if users want to save changes in textbox before changing focus 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtChangelogText_Leave(object sender, EventArgs e)
		{
			if (!btnUpdateChangelog.ContainsFocus)
				if (changelogTextChanged)
					textbox_leave("changelog", e);
		}

		/// <summary>
		/// Text in textbox for HotstringName have changed, enable button for saving 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtHotstringName_TextChanged(object sender, EventArgs e)
		{
			if(currentHotstring != null)
			{
				ttHotstringExists.Hide(btnUpdateHotstring);
				if (!currentHotstring.Name.Equals(txtHotstringName.Text))
				{
					if (data.hotstringExists(txtHotstringName.Text))
					{
						ttHotstringExists.Show("Hotstring with this name already exists.\r\nChoose a new name.", txtHotstringName, 0, 18);
						btnUpdateHotstring.Enabled = false;
						hotstringTextChanged = false;
					} else {
						btnUpdateHotstring.Enabled = true;
						hotstringTextChanged = true;
				    }
				} else {
					btnUpdateHotstring.Enabled = false;
					hotstringTextChanged = false;
				}
			}
		}

		/// <summary>
		/// Text in textbox for changelog have changed, enable button for saving 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtChangelog_TextChanged(object sender, EventArgs e)
		{
			string en = txtChangelog.Text.Substring(26);
			if (!data.currentChangelogEntry.Entry.Equals(en)) {
				btnUpdateChangelog.Enabled = true;
				btnUpdateChangelog.Visible = true;
				changelogTextChanged = true;
			} else {
				btnUpdateChangelog.Enabled = false;
				btnUpdateChangelog.Visible = false;
				changelogTextChanged = true;
			}
		}

		void txtFunctionName_TextChanged(object sender, EventArgs e)
		{
			if(currentFunction != null)
			{
				if(!currentFunction.Name.Equals(txtFunctionName.Text))
				{
					if (data.functionExists(txtFunctionName.Text))
					{
						ttHotstringExists.Show("Hotstring with this name already exists.\r\nChoose a new name.", txtFunctionName, 0, 18);
						btnUpdateFunction.Enabled = false;
					} else {
						btnUpdateFunction.Enabled = true;
					}
				} else {
					btnUpdateFunction.Enabled = false;
				}
			}
		}

		/// <summary>
		/// Function to catch Ctrl+S for saving the text in textboxes
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic KeyEventArgs</param>
		void txtHotstringText_KeyUp(object sender, KeyEventArgs e)
		{
			if (hotstringTextChanged)
				shortcutSave("hotstring", e);
		}
		/// <summary>
		/// Function to catch Ctrl+S for saving the text in textboxes
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic KeyEventArgs</param>
		void txtFunctions_KeyUp(object sender, KeyEventArgs e)
		{
			if (functionsTextChanged)
				shortcutSave("functions", e);
		}
		/// <summary>
		/// Function to catch Ctrl+S for saving the text in textboxes
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic KeyEventArgs</param>
		void txtChangelog_KeyUp(object sender, KeyEventArgs e)
		{
			if (changelogTextChanged)
				shortcutSave("changelog", e);
		}

		/// <summary>
		/// Called when user clicks menuitem to remove command
		/// Ask user to remove item
		/// Remove item from tree and commandslist, if there are no other items with same system, remove system from root
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnRemoveHotstring_Click(object sender, EventArgs e)
		{
			if(currentHotstring != null)
			{
				DialogResult answer = MessageBox.Show("Remove command " + currentHotstring.Name + "?", "Remove", MessageBoxButtons.YesNo);

				if (answer == DialogResult.Yes) {
					var hotstringSystem = currentHotstring.System;
					var hotstringName = currentHotstring.Name;
					treeHotstrings.Nodes[hotstringSystem].Nodes.Remove(treeHotstrings.SelectedNode);
					data.deleteHotstring(hotstringName);
					if (treeHotstrings.Nodes[hotstringSystem].Nodes.Count == 0) {
						treeHotstrings.Nodes.RemoveByKey(hotstringSystem);
					}
	
					statusUpdate("Hotstring " + hotstringName + " have been removed.", false);
					updatedData(true);
				}
			}
		}

		/// <summary>
		/// Update current entry of changelog 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnUpdateChangelog_Click(object sender, EventArgs e)
		{
			data.updateCurrentChangelogItem(txtChangelog.Text.Substring(26), true);

			updatedData(true);
			changelogTextChanged = false;
			statusUpdate("Changelog have been updated", false);
			btnUpdateChangelog.Enabled = false;
			btnUpdateChangelog.Visible = false;
			ActiveControl = txtChangelog;
		}

		/// <summary>
		/// User wants to update command 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnUpdateHotstring_Click(object sender, EventArgs e)
		{
			if(currentHotstring != null)
			{
				var answer = new ChangeLogText(currentHotstring.Name);
				answer.ShowDialog(this);

				switch (answer.DialogResult) {
					case DialogResult.OK:
					case DialogResult.Cancel:
						if (!currentHotstring.System.Equals(txtHotstringSystem.Text))
							updateTreeView();
						if (answer.DialogResult == DialogResult.OK && !answer.getChangeInfo().Equals(currentHotstring.Name)) {
							data.updateCurrentChangelogItem(answer.getChangeInfo(), false);
							txtChangelog.TextChanged -= txtChangelog_TextChanged;
							txtChangelog.Text = data.currentChangelogEntry.Version + "\r\n----------\r\n" + data.currentChangelogEntry.Entry;
							txtChangelog.TextChanged += txtChangelog_TextChanged;
						}
						data.updateHotstring(currentHotstring.Name, txtHotstringName.Text, txtHotstringText.Text, txtHotstringSystem.Text);
						updatedData(true);
						hotstringTextChanged = false;
						statusUpdate("Hotstring " + currentHotstring.Name + " have been updated", false);
						updateTreeView();
						break;
					case DialogResult.Abort:
						statusUpdate("Hotstring " + currentHotstring.Name + " was not updated", false);
						txtHotstringText.Text = currentHotstring.Text;
						txtHotstringSystem.Text = currentHotstring.System;
						txtHotstringName.Text = currentHotstring.Name;
						break;
				}
			}
			treeHotstrings.HideSelection = false;
			btnUpdateHotstring.Enabled = false;
		}

		/// <summary>
		/// Update string for functions 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnUpdateFunction_Click(object sender, EventArgs e)
		{
			var newChangelogText = new ChangeLogText();
			newChangelogText.ShowDialog(this);

			switch (newChangelogText.DialogResult) {
				case DialogResult.OK:
				case DialogResult.Cancel:
					if (newChangelogText.DialogResult == DialogResult.OK)
					{
						data.updateCurrentChangelogItem(newChangelogText.getChangeInfo(), false);
						txtChangelog.TextChanged -= txtChangelog_TextChanged;
						txtChangelog.Text = data.currentChangelogEntry.Version + "\r\n----------\r\n" + data.currentChangelogEntry.Entry;
						txtChangelog.TextChanged += txtChangelog_TextChanged;
					}
					if (!currentFunction.Name.Equals(txtFunctionName))
						txtFunctionText.Text = txtFunctionText.Text.Replace(currentFunction.Name, txtFunctionName.Text);
					data.updateFunction(currentFunction.Name, txtFunctionName.Text, txtFunctionText.Text);
					updateFunctionListBox();

					updatedData(true);
					functionsTextChanged = false;
					statusUpdate("Function " + txtFunctionName.Text + "have been updated", false);

					break;
				case DialogResult.Abort:
					statusUpdate("Functions was not updated", false);
					txtFunctionText.Text = data.Functions;
					break;
			}

			btnUpdateFunction.Enabled = false;
			ActiveControl = txtFunctionText;
		}

		/**
		 * 
		 * */
		/// <summary>
		/// Save the data to the script- and XML-file 
		/// </summary>
		/// <param name="sender">Generid sender</param>
		/// <param name="e">Generic Eventargs</param>
		void btnSaveToFile_Click(object sender, EventArgs e)
		{
			saveToXMLFile();
			saveToScriptFile();
			btnSaveToFile.Enabled = false;
			MessageBox.Show("Scriptfile " + scriptFile + " have been saved.");
		}

		/// <summary>
		/// Close form 
		/// </summary>
		/// <param name="sender">Generid sender</param>
		/// <param name="e">Generic Eventargs</param>
		void menuClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/**
		 * 
		 * 
		 * */
		/// <summary>
		/// Open form for defining name of hotstring
		/// Change selected tab in tabControl if new function is to be created		
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void menuNewCommand_Click(object sender, EventArgs e)
		{
			var newCommand = new NewCommand(ref data);
			DialogResult newCommandDialog = newCommand.ShowDialog(this);

			if (newCommandDialog == DialogResult.OK) {
				string commandName = newCommand.getItem(), commandSystem = newCommand.getSystem(), commandText;
				int commandType = newCommand.getCommandType();
				TreeNode newNode = null;

				if (commandType == 2) {
					tabControl.SelectedIndex = 1;
					txtFunctionText.Focus();
					txtFunctionText.Text = "\r\n" + txtFunctionText.Text + "\r\n" + commandName + "()\r\n{\r\n\r\n}";
					txtFunctionText.Select(txtFunctionText.Text.Length - 2, 0);
					txtFunctionText.ScrollToCaret();
				} else {
					currentHotstring = new AHKCommand(commandName, "", commandSystem);
					if (commandType == 0) {
						commandText = "SendInput,\r\n(\r\n\r\n)\r\nReturn";
					} else {
						commandSystem = "Variables";
						commandText = commandName + " = ";
					}
					data.addHotstring(commandName, commandText, commandSystem);

					if (!treeHotstrings.Nodes.ContainsKey(commandSystem)) {
						var treeNode = new TreeNode(commandSystem);
						treeNode.Name = commandSystem;
						treeHotstrings.Nodes.Add(treeNode);
					}
					newNode = new TreeNode(commandName);
					treeHotstrings.Nodes[commandSystem].Nodes.Add(newNode);
					ActiveControl = txtHotstringText;
					treeHotstrings.Sort();
					tabControl.SelectedIndex = 0;
					treeHotstrings.SelectedNode = newNode;
					if(commandType == 0)
						txtHotstringText.Select(15, 0);
					else
						txtHotstringText.Select(commandText.Length, 0);
				}
				updatedData(true);
			}
		}

		/// <summary>
		/// Called when the user wants to read the scriptfile 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void menuOpenScript_Click(object sender, EventArgs e)
		{
			openFile(scriptFile);
		}

		/// <summary>
		/// Called when the user wants to read the XML-file 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void menuOpenXML_Click(object sender, EventArgs e)
		{
			openFile(xmlFile);
		}

		/// <summary>
		/// When tab is changed, set focus to the textbox
		/// Textbox for hotstring excluded
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(tabControl.SelectedIndex == 1)
				ActiveControl = txtFunctionText;
			else if (tabControl.SelectedIndex == 2)
				ActiveControl = txtChangelog;
		}

		/// <summary>
		/// A node in treeHotstrings have been selected
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic TreeVieEventArgs</param>
		void treeHotstrings_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Level != 0) {
				currentHotstring = data.hotstringsList.Find(x => x.Name.Equals(e.Node.Text));
				txtHotstringText.Text = currentHotstring.Text;
				txtHotstringSystem.Text = currentHotstring.System;
				txtHotstringName.Text = currentHotstring.Name;
				btnRemoveCommand.Enabled = true;

				ActiveControl = txtHotstringText;

			} else {
				currentHotstring = null;
				txtHotstringText.Text = "";
				txtHotstringSystem.Text = "";
				txtHotstringName.Text = "";
				btnUpdateHotstring.Enabled = false;
			}
		}

		/// <summary>
		/// Rightclick on a node to open contextmenu for extraction of the hotstring 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic TreeNodeMouseClick</param>
		void treeHotstrings_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				if(e.Node.Level != 0)
				{
					contextMenu.Show(treeHotstrings, e.Location);
					treeHotstrings.SelectedNode = e.Node;
				}
			}
		}

		/// <summary>
		/// Menuitem is clicked
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void contextItem_Click(object sender, EventArgs e)
		{
			lbExtractions.Items.Add(treeHotstrings.SelectedNode.Text);
			toExtract.Add(new AHKCommand(data.getHotstring(treeHotstrings.SelectedNode.Text)));
			btnExtract.Enabled = true;
		}

		/// <summary>
		/// Clear list and listbox of planed extractions 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnCancelExtract_Click(object sender, EventArgs e)
		{
			lbExtractions.Items.Clear();
			toExtract = null;
			btnExtract.Enabled = false;
		}

		/// <summary>
		/// Remove selected hotstring from list of extractions 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnRemoveExtract_Click(object sender, EventArgs e)
		{
			toExtract.RemoveAll(x => x.Name.Equals(lbExtractions.SelectedItem.ToString()));
			lbExtractions.Items.Remove(lbExtractions.SelectedItem);
			if (lbExtractions.Items.Count == 0)
				btnExtract.Enabled = false;
		}

		/// <summary>
		/// Ask the user what to name the extracted hotstrings and where to put it 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnExtract_Click(object sender, EventArgs e)
		{
			SaveFileDialog dir = new SaveFileDialog();
			dir.FileName = "Extracted hotstrings.ahk";
			dir.ShowDialog();

			StreamWriter writer = new StreamWriter (dir.FileName, false, System.Text.Encoding.GetEncoding(1252));

			foreach(AHKCommand item in toExtract)
			{
				writer.WriteLine(item.getScriptString());
			}
			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// User switches item in listbox
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void lbChangelogItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			var item = data.getChangelogEntry(lbChangelogItems.SelectedItem.ToString());
			txtChangelog.TextChanged -= txtChangelog_TextChanged;
			txtChangelog.Text = item.Version + "\r\n----------\r\n" + item.Entry;
			txtChangelog.TextChanged += txtChangelog_TextChanged;
		}

		void lbFunctions_SelectedIndexChanged(object sender, EventArgs e)
		{
			var item = data.getFunction(lbFunctions.SelectedItem.ToString());
			currentFunction = item;
			txtFunctionText.TextChanged -= txtFunctions_TextChanged;
			txtFunctionText.Text = item.Text;
			txtFunctionName.Text = item.Name;
			txtFunctionText.TextChanged += txtFunctions_TextChanged;
		}

		/// <summary>
		/// Called when form is closing
		/// If anything have been updated, ask user if changes are to be saved
		/// Otherwise, close application
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic FormClosingEventArgs</param>
		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (data.Updated) {
				DialogResult answer = MessageBox.Show("Unsaved changes have been made.\r\nDo you want to save?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

				switch (answer) {
					case DialogResult.Yes:
						saveToScriptFile();
						saveToXMLFile();
						shutdown();
						break;
					case DialogResult.No:
						shutdown();
						break;
					default:
						e.Cancel = true;
						break;
				}
			} else {
				shutdown();
			}
		}
	}
}
