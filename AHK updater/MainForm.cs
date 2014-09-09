using System;
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

		string scriptfilenameTest = "AHK - Test.ahk",
				xmlfilenameTest = "AHK - Test.xml",
				originalxmlfilenameTest = "AHK - Test (Original).xml",
				changelogfileTest = "AHK - Test Changelog.txt";
		string scriptfilename = "AHK.ahk",
				xmlfilename = "AHK.xml",
				originalxmlfilename = "AHK (Original).xml",
				changelogfile = "AHK.txt";
		AllData data = new AllData();
		AHKCommand currentItem;

		void MainFormLoad(object sender, EventArgs e)
		{
			string filename = "";
			//If file is present, open and read. Otherwise, read central file
			bool test1 = File.Exists((test?xmlfilenameTest:xmlfilename)),
				test2 = File.Exists((test?originalxmlfilenameTest:originalxmlfilename));
			if (test1)
			{
				filename = (test?xmlfilenameTest:xmlfilename);
			} else if (test2)
			{
				filename = test?originalxmlfilenameTest:originalxmlfilename;
			}
			getXMLCommands(filename);
		}

		/**
		 * Reads the XML-file and sends the NodeLists for parsing
		 * If a username can not be found in the file, application asks user
		 *  
		 * filename: Name of the XML-file to read data
		 * */
		void getXMLCommands(string filename)
		{
			XmlTextReader xRead = new XmlTextReader(filename);
			XmlDocument doc;

			doc = new XmlDocument();
			if (new FileInfo(filename).Length != 0)
			{
				try
				{
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
			   		insertFunctions(functions[0].InnerText.ToString());
			   		insertChangelog(changelogVersion, changelogEntry);

			   		//Ask for username, if not present in XML-file
			   		if (name.Count > 0)
			   		{
				   		if (name[0].InnerText.ToString().Equals(""))
				   		{
				   			userName();
				   		}
				   		else
				   		{
				   			data.UserName = name[0].InnerText.ToString();
				   		}
					   	this.Text = this.Text + " - " + data.UserName;
			   		} else
			   		{
			   			userName();
			   		}

			   		fillTree();

			   		xRead.Close();
				} catch (Exception e)
				{
					MessageBox.Show("XML-file is coded wrong.\r\n" + e.ToString());
				}
			}
		}

		void userName()
		{
   			UserName un = new UserName();
   			un.ShowDialog(this);
   			if(!un.getName().Equals(""))
   			{
   				if (!data.commandExists("sign"))
	   				data.addCommand("sign", "With kind regards{Enter}" + un.getName(), "Variables");
   				else
   					data.updateCommandItem("sign", "With kind regards{Enter}" + un.getName(), "Variables");
	   			data.Updated = true;
   			}
			data.UserName = un.getName();
		}

		/**
		 * Add all hotstrings to the data
		 * 
		 * command, text, system: NodeLists containing data from XML-file
		 * */
		void insertCommands(XmlNodeList command, XmlNodeList text, XmlNodeList system)
		{
	   		if (command.Count > 0)
	   		{
		   		for (int i = 0; i < command.Count; i++)
		   		{
	   				data.addCommand(command[i].InnerText.ToString(), text[i].InnerText.ToString().Trim(), system[i].InnerText.ToString());
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
	   		if (functions.Length > 0)
	   		{
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
	   		if (changelogVersion.Count > 0)
	   		{
	   			for (int i = 0; i < changelogVersion.Count; i++)
	   			{
	   				data.updateChangelog(changelogVersion[i].InnerText.ToString(), changelogEntry[i].InnerText.ToString());
	   			}
	   		}
	   		txtChangelog.Text = data.initiateChangelog();
		}

		/**
		 * Closes the application
		 * */
		void shutdown()
		{
			data.Updated = false;
			Application.Exit();
		}

		/**
		 * Sets reads all commands in data.commandslist and inserts in tree
		 * If a system is not present, create a node under root
		 * */
		void fillTree()
		{
			treeHotstrings.Nodes.Clear();
			foreach(AHKCommand item in data.commandslist)
			{
				if (!item.System.Equals(""))
				{
					if (!treeHotstrings.Nodes.ContainsKey(item.System))
					{
						TreeNode tn = new TreeNode(item.System);
						tn.Name = item.System;
						treeHotstrings.Nodes.Add(tn);
					}
					TreeNode newNode = new TreeNode(item.Command);
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
			StreamWriter writer = new StreamWriter((test?scriptfilenameTest:scriptfilename), false, System.Text.UnicodeEncoding.Unicode);

            try
            {
            	writer.Write(fetchCommandsForScript());
            	writer.Flush();
            	writer.WriteLine("GuiClose:\r\nExitApp");
            	writer.Close();

            	MessageBox.Show("Scriptfile saved");
				data.Updated = false;
            } catch(Exception exc)
            {
            	MessageBox.Show("Something went wrong while saving scriptfile\nError:\n" + exc.Message.ToString(), "Error while writing", MessageBoxButtons.OK);
            }
		}

		/**
		 * Collect the hotstrings and write to XML-file
		 * */
		void saveToXMLFile()
		{
			StreamWriter writer = new StreamWriter((test?xmlfilenameTest:xmlfilename), false, System.Text.UnicodeEncoding.Unicode);

            try
            {
            	writer.WriteLine("<?xml version=\"1.0\"?>\r\n<ahk>");
            	writer.WriteLine("<ahkcommand><name>" + data.UserName + "</name></ahkcommand>");
            	writer.Write(fetchCommandsForXML());
            	writer.Flush();
            	writer.WriteLine(fetchFunctions());
            	writer.Write(fetchChangelogXML());
            	writer.WriteLine("</ahk>");
            	writer.Close();

            	MessageBox.Show("XML-file saved");
				data.Updated = false;
            } catch(Exception exc)
            {
            	MessageBox.Show("Something went wrong while writing XML-file\r\nError:\n" + exc.Message.ToString(), "Error while writing", MessageBoxButtons.OK);
            }
		}

		/**
		 * Write changelog
		 * */
		void saveToChangelog()
		{
			StreamWriter writer = new StreamWriter((test?changelogfileTest:changelogfile), false, System.Text.UnicodeEncoding.Unicode);

			try
			{
				writer.Write(data.getChangelogText());
				writer.Flush();
				writer.Close();
			} catch (Exception e)
			{
				MessageBox.Show("Something went wrong while changelog was written\r\nError:\n" + e.Message.ToString(), "Error while writing", MessageBoxButtons.OK);
			}
		}

		/**
		 * Collect all hotstrings
		 * 
		 * Return as string
		 * */
		string fetchCommandsForXML()
		{
			string xmlFile = "";

			foreach (AHKCommand item in data.commandslist)
			{
				if (item.System.Equals("Variables"))
				{
					xmlFile = item.getXmlString() + "\r\n" + xmlFile;
				}
				else
				{
					xmlFile = xmlFile + item.getXmlString() + "\r\n";
				}
			}

			return xmlFile;
		}

		/**
		 * Collect all hotstrings
		 * 
		 * Return as XML-formated string
		 * */
		string fetchCommandsForScript()
		{
			string scriptFile = "";
			foreach (AHKCommand item in data.commandslist)
			{
				if(item.System.Equals("Variables"))
				{
					scriptFile = item.getScriptString() + "\r\n" + scriptFile;
				}
				else
				{
					scriptFile = scriptFile + item.getScriptString() + "\r\n";
				}
			}

			return scriptFile + txtFunctions.Text.Trim() + "\r\n";
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
		 * Called when menuiten SaveToFile is clicked
		 * Calls functions for saving to XML- and scriptfile
		 * */
		void SaveToFile_Click(object sender, EventArgs e)
		{
			saveToXMLFile();
			saveToScriptFile();
		}

		/**
		 * Open form for defining name of hotstring
		 * Change selected tab in tabControl if new function is to be created
		 * */
		void NewHotstring_Click(object sender, EventArgs e)
		{
			NewCommand f = new NewCommand(ref data);
			DialogResult a = f.ShowDialog(this);

			if (a == DialogResult.OK)
			{
				string commandName = f.getItem(), commandSystem = f.getSystem();
				int commandType = f.getCommandType();
				TreeNode newNode = null;

				if (commandType == 2)
				{
					tabControl.SelectedIndex = 1;
					txtFunctions.Focus();
					txtFunctions.Text = txtFunctions.Text + "\r\n" + commandName + "\r\n{\r\n\r\n}";
				}
				else
				{
					currentItem = new AHKCommand(commandName, "", commandSystem);
					if (commandType == 0)
					{
						data.addCommand(commandName, "", commandSystem);
						txtHSText.Text = "SendInput,\r\n(\r\n\r\n)\r\nReturn";
					}
					else
					{
						commandSystem = "Variables";
						txtHSText.Text = "";
					}

					if (!treeHotstrings.Nodes.ContainsKey(commandSystem))
					{
						TreeNode tn = new TreeNode(commandSystem);
						tn.Name = commandSystem;
						treeHotstrings.Nodes.Add(tn);
					}
					newNode = new TreeNode(commandName);
					newNode.Tag = "";
					treeHotstrings.Nodes[commandSystem].Nodes.Add(newNode);
				}
				tabControl.SelectedIndex = 0;
				treeHotstrings.SelectedNode = newNode;
				data.Updated = true;
				treeHotstrings.Sort();
			}
		}

		/**
		 * Called when text for hotstring is edited
		 * If currentItem is null an item have been removed and textbox is empty
		 * Otherwise checks against text in currentItem
		 * */
		void txtHSText_TextChanged(object sender, EventArgs e)
		{
			if (currentItem != null)
			{
				if (txtHSText.Text != currentItem.Text)
				{
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
			if (!data.Functions.Equals(txtFunctions.Text.ToString()))
			{
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
			if (!currentItem.System.Equals(txtSystem.Text.ToString()))
			{
				btnSaveHotstring.Enabled = true;
				btnSaveHotstring.Visible = true;
			}
			else
			{
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
			string a = data.CurrentChangelogItem, b= txtChangelog.Text.ToString();

			if (!a.Equals(b))
			{
				btnSaveChangelog.Enabled = true;
				btnSaveChangelog.Visible = true;
			}
			else
			{
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
			ChangeLogText temp = new ChangeLogText(currentItem.Command);
			temp.ShowDialog(this);

			if (temp.DialogResult == DialogResult.OK)
			{
				bool refillTree = !currentItem.System.Equals(txtSystem.Text);

				data.updateCommandItem(currentItem.Command, txtHSText.Text, txtSystem.Text);
				data.updateCurrentChangelogItem(temp.getChangeInfo(), false);
				txtChangelog.Text = data.CurrentChangelogItem;
				data.Updated = true;

				if (refillTree)
				{
					fillTree();
				}
			}

			treeHotstrings.HideSelection = false;
			btnSaveHotstring.Enabled = false;
			btnSaveHotstring.Visible = false;
			this.ActiveControl = txtHSText;
			txtHSText.Select(0, 0);
		}

		/**
		 * Update string for functions
		 * */
		void btnSaveFunctions_Click(object sender, EventArgs e)
		{
			data.Functions = txtFunctions.Text;
			ChangeLogText temp = new ChangeLogText();
			temp.ShowDialog(this);
			data.updateCurrentChangelogItem(temp.getChangeInfo(), false);
			txtChangelog.Text = data.CurrentChangelogItem;

			data.Updated = true;
			btnSaveFunctions.Enabled = false;
			btnSaveFunctions.Visible = false;
			this.ActiveControl = txtFunctions;
		}

		/**
		 * Update current entry of changelog
		 * */
		void btnSaveChangelog_Click(object sender, EventArgs e)
		{
			data.updateCurrentChangelogItem(txtChangelog.Text.ToString(), true);

			data.Updated = true;
			btnSaveChangelog.Enabled = false;
			btnSaveChangelog.Visible = false;
			this.ActiveControl = txtChangelog;
		}

		/**
		 * Called when form is closing
		 * If anything have been updated, ask user if changes are to be saved
		 * Otherwise, close application
		 * */
		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (data.Updated)
			{
				DialogResult answer = MessageBox.Show("There are unsaved changes.\r\nDo you want to save them?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

				if (answer == DialogResult.Yes)
				{
					saveToScriptFile();
					saveToXMLFile();
					shutdown();
				}
				else if (answer == DialogResult.No)
				{
					shutdown();
				}
				else
				{
					e.Cancel = true;
				}
			}
			else
			{
				shutdown();
			}
		}

		/**
		 * Close form
		 * */
		void menuClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/**
		 * Called when user clicks menuitem to remove command
		 * Ask user to remove item
		 * Remove item from tree and commandslist, if there are no other items with same system, remove system from root
		 * */
		void btnRemoveCommand_Click(object sender, EventArgs e)
		{
			DialogResult answer = MessageBox.Show("Do you want to remove " + currentItem.Command + "?", "Remove", MessageBoxButtons.YesNo);

			if (answer == DialogResult.Yes)
			{
				data.deleteItem(currentItem.Command);
				treeHotstrings.Nodes.Remove(treeHotstrings.SelectedNode);
				if (treeHotstrings.Nodes[currentItem.System].Nodes.Count == 0)
				{
					treeHotstrings.Nodes.RemoveByKey(currentItem.System);
				}

				data.Updated = true;
			}
		}

		/**
		 * User wants to change name of command
		 * Open form to ask for new name
		 * */
		void btnChangeName_Click(object sender, EventArgs e)
		{
			NewName nm = new NewName(currentItem.Command);
			nm.ShowDialog(this);

			if (nm.DialogResult == DialogResult.OK)
			{
				data.setNewName(currentItem.Command, nm.getNewName());
				data.Updated = true;
				fillTree();
				this.ActiveControl = txtHSText;
			}
		}

		/**
		 * A node in treeHotstrings have been selected
		 * Load the corresponting hotstring
		 * */
		void treeHotstrings_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Level != 0)
			{
				currentItem = data.commandslist.Find(x => x.Command.Equals(e.Node.Text));
				txtHSText.Text = currentItem.Text;
				txtSystem.Text = currentItem.System;

				this.ActiveControl = txtHSText;
				btnRemoveCommand.Visible = true;
				btnChangeName.Visible = true;
			}
			else
			{
				btnRemoveCommand.Visible = false;
				btnChangeName.Visible = false;
			}
		}
	}
}
