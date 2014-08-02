using System;
using System.ComponentModel;
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
		bool test = true;

		BindingList<AHKCommand> ListofCommands = new BindingList<AHKCommand>(),
								DataSourceList = new BindingList<AHKCommand>();
		string scriptfilenameTest = "AHK - Standardsvar Test.ahk",
				xmlfilenameTest = "AHK - Standardsvar Test.xml",
				originalxmlfilenameTest = "AHK - Standardsvar Test (Original).xml",
				changelogfileTest = "AHK Changelog.txt";
		string scriptfilename = "AHK - Standardsvar.ahk",
				xmlfilename = "AHK - Standardsvar.xml",
				originalxmlfilename = "AHK - Standardsvar (Original).xml",
				changelogfile = "AHK - changelog.txt";
		AllData data = new AllData();
		AHKCommand currentItem;

		void MainFormLoad(object sender, EventArgs e)
		{
			//If file is present, open and read. Otherwise, read central file
			if (File.Exists((test?xmlfilenameTest:xmlfilename)))
			{
				getXMLCommands((test?xmlfilenameTest:xmlfilename));
			} else if (File.Exists((test?originalxmlfilenameTest:originalxmlfilename))){
				getXMLCommands((test?originalxmlfilenameTest:originalxmlfilename));
			}
		}

		void getXMLCommands(string filename)
		{
			XmlTextReader xRead;
			XmlDocument doc;

			xRead = new XmlTextReader(filename);
			doc = new XmlDocument();
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
	   		insertFunctions(functions);
	   		insertChangelog(changelogVersion, changelogEntry);
	   		fillTree();

	   		//Ask for username, if not present in XML-file
	   		if (name.Count > 0)
	   		{
		   		if (name[0].InnerText.ToString().Equals(""))
		   		{
		   			UserName un = new UserName();
		   			un.ShowDialog(this);
		   			if(!un.getName().Equals(""))
		   			{
		   				data.addCommand("sign", "Med vänliga hälsningar{Enter}" + un.getName(), "Variabler");
			   			data.UserName = un.getName();
		   			}
		   		}
	   		}

	   		xRead.Close();
		}

		/**
		 * Add all hotstrings as separate row in ListofCommands and variables in ListofVariables
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
		 * */
		void insertFunctions(XmlNodeList functions)
		{
	   		if (functions.Count > 0)
	   		{
	   			txtFunctions.TextChanged -= TxtFunctions_TextChanged;
	   			txtFunctions.Text = functions[0].InnerText.ToString();
	   			txtFunctions.TextChanged += TxtFunctions_TextChanged;
	   			data.Functions = functions[0].InnerText.ToString();
	   		}
		}

		/**
		 * Get previous changelogentries
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

		void shutdown()
		{
			Application.Exit();
		}

		/**
		 * Sets datasource för listbox and rebinds it for list to be updated
		 * */
		void fillTree()
		{
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
		 * Collect the hotstrings and write to AutoHotKey script-file
		 * */
		void saveToScriptFile()
		{
			StreamWriter writer = new StreamWriter((test?scriptfilenameTest:scriptfilename), false, System.Text.UnicodeEncoding.Unicode);

            try
            {
            	writer.Write(fetchCommandsForScript());
            	writer.Flush();
            	writer.WriteLine("GuiClose:\r\nExitApp");
            	writer.Flush();
            	writer.Close();

            	MessageBox.Show("Skriptfil sparad");
				data.Updated = false;
            } catch(Exception exc)
            {
            	MessageBox.Show("Något gick fel när skriptfilen skulle sparas\nFel:\n" + exc.Message.ToString(), "Skrivfel", MessageBoxButtons.OK);
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
            	writer.Flush();
            	writer.Write(fetchChangelogXML());
            	writer.Flush();
            	writer.WriteLine("</ahk>");
            	writer.Flush();
            	writer.Close();

            	MessageBox.Show("XML-fil sparad");
				data.Updated = false;
            } catch(Exception exc)
            {
            	MessageBox.Show("Något gick fel när XML-filen skulle sparas\nFel:\n" + exc.Message.ToString(), "Skrivfel", MessageBoxButtons.OK);
            }
		}

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
				MessageBox.Show("Något gick fel när Changelog-filen skulle sparas\nFel:\n" + e.Message.ToString(), "Skrivfel", MessageBoxButtons.OK);
			}
		}

		/**
		 * Collect all hotstrings and return as string
		 * */
		string fetchCommandsForXML()
		{
			string i="";
			foreach (AHKCommand item in data.commandslist)
			{
				i = i + item.getXmlString() + "\r\n";
			}

			return i;
		}

		/**
		 * Collect all hotstrings and return as XML-formated string
		 * */
		string fetchCommandsForScript()
		{
			string i="";
			foreach (AHKCommand item in data.commandslist)
			{
				i = i + item.getScriptString()+"\r\n";
			}

			return i + txtFunctions.Text.Trim() + "\r\n";
		}

		/**
		 * Return all functions as XML-formated string
		 * */
		string fetchFunctions()
		{
			return "<ahkcommand><functions>" + txtFunctions.Text + "</functions></ahkcommand>";
		}

		string fetchChangelogXML()
		{
			return data.getChangelogXML();
		}

		void SaveToFile_Click(object sender, EventArgs e)
		{
			saveToXMLFile();
			saveToScriptFile();
		}

		/**
		 * Open form for defining name of hotstring
		 * Change tabControl selected tab if new function is to be created
		 * */
		void NewHotstring_Click(object sender, EventArgs e)
		{
			NewCommand f = new NewCommand(ref data);

			if (f.ShowDialog(this) == DialogResult.OK)
			{
				string commandName = f.getItem(), commandSystem = f.getSystem();
				int commandType = f.getCommandType();
				TreeNode newNode = null;

				if (commandType == 2)
				{
					tabControl1.SelectedIndex = 1;
					txtFunctions.Focus();
					txtFunctions.Text = txtFunctions.Text + "\r\n" + commandName + "\r\n{\r\n\r\n}";
				}
				else
				{
					currentItem = new AHKCommand(commandName, "", commandSystem);
					if (commandType == 0)
					{
						data.addCommand(commandName, "","");
						txtHSText.Text = "SendInput,\r\n(\r\n\r\n)\r\nReturn";
					}
					else
					{
						//data.updateVariables(commandName, "", "Variabler");
						commandSystem = "Variabler";
						txtHSText.Text = "= ";
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
				tabControl1.SelectedIndex = 0;
				treeHotstrings.SelectedNode = newNode;
				data.Updated = true;
				treeHotstrings.Sort();
			}
		}

		void TxtHSText_TextChanged(object sender, EventArgs e)
		{
			if (txtHSText.Text != currentItem.Text)
			{
				btnSaveHotstringText.Enabled = true;
				btnSaveHotstringText.Visible = true;
			} else {
				btnSaveHotstringText.Enabled = false;
				btnSaveHotstringText.Visible = false;
			}
		}

		void TxtFunctions_TextChanged(object sender, EventArgs e)
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
		 * When hotstring in lstHotstring is changed, load the corresponding hotstring text in txtboxText
		 * */
		void treeHotstrings_IndexChange(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Level != 0)
			{
				for (int i = 0; i < data.commandslist.Count; i++)
				{
					if (data.commandslist[i].Command.Equals(e.Node.Text))
					{
						currentItem = new AHKCommand(data.commandslist[i]);
						txtHSText.Text = data.commandslist[i].Text;
						break;
					}
				}
				this.ActiveControl = txtHSText;
				menuRemoveCommand.Visible = true;
			}
			else
			{
				menuRemoveCommand.Visible = false;
			}
		}

		/**
		 * Update listitem
		 * */
		void BtnSaveHotstringText_Click(object sender, EventArgs e)
		{
			data.updateCommandItem(currentItem.Command, txtHSText.Text);
			ChangeLogText temp = new ChangeLogText(currentItem.Command);
			temp.ShowDialog(this);
			data.updateCurrentChangelogItem(temp.getChangeInfo());
			txtChangelog.Text = data.CurrentChangelogItem;
			
			btnSaveHotstringText.Enabled = false;
			btnSaveHotstringText.Visible = false;
			this.ActiveControl = txtHSText;
		}

		void BtnSaveFunctions_Click(object sender, EventArgs e)
		{
			data.Functions = txtFunctions.Text;
			ChangeLogText temp = new ChangeLogText();
			temp.ShowDialog(this);
			data.updateCurrentChangelogItem(temp.getChangeInfo());
			txtChangelog.Text = data.CurrentChangelogItem;

			data.Updated = true;
			btnSaveFunctions.Enabled = false;
			btnSaveFunctions.Visible = false;
			this.ActiveControl = txtFunctions;
		}

		void BtnSaveChangelogClick(object sender, EventArgs e)
		{
			data.updateCurrentChangelogItem(txtFunctions.Text);

			data.Updated = true;
			btnSaveFunctions.Enabled = false;
			btnSaveFunctions.Visible = false;
			this.ActiveControl = txtChangelog;
		}

		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (data.Updated)
			{
				DialogResult answer = MessageBox.Show("Ändringar har gjorts, men har inte sparats.\r\nVill du spara?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

				if (answer == DialogResult.Yes)
				{
					saveToScriptFile();
					saveToXMLFile();
					shutdown();
				} else if (answer == DialogResult.No){
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
		
		void menuClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void menuRemoveCommand_Click(object sender, EventArgs e)
		{
			DialogResult answer = MessageBox.Show("Ta bort kommando " + currentItem.Command + "?", "Borttag", MessageBoxButtons.YesNo);
			if (answer == DialogResult.Yes)
			{
				treeHotstrings.Nodes.Remove(treeHotstrings.SelectedNode);//[currentItem.System].Nodes[currentItem.Command].Remove();
				if (treeHotstrings.Nodes[currentItem.System].Nodes.Count == 0)
					treeHotstrings.Nodes.RemoveByKey(currentItem.Command);
				data.commandslist.Remove(new AHKCommand(currentItem.Command, currentItem.Text, currentItem.System));
			}
		}
	}
}
