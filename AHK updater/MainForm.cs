using System;
using System.ComponentModel;
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

		BindingList<AHKCommand> ListofCommands = new BindingList<AHKCommand>(),
								ListofVariables = new BindingList<AHKCommand>(),
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

		void MainFormLoad(object sender, EventArgs e)
		{
			//If file is present, open and read. Otherwise, read central file
			if (File.Exists((test?xmlfilenameTest:xmlfilename)))
			{
				getXMLCommands((test?xmlfilenameTest:xmlfilename));
			} else if (File.Exists((test?originalxmlfilenameTest:originalxmlfilename))){
				getXMLCommands((test?originalxmlfilenameTest:originalxmlfilename));
			}
			if(!test)
			{
				testToolStripMenuItem.Visible = false;
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
		    	type = doc.GetElementsByTagName("type"),
		    	system = doc.GetElementsByTagName("system"),
		    	variables = doc.GetElementsByTagName("variable"),
		    	functions = doc.GetElementsByTagName("functions"),
		    	changelogVersion = doc.GetElementsByTagName("version"),
		    	changelogEntry = doc.GetElementsByTagName("entry");
	   		xRead.WhitespaceHandling = WhitespaceHandling.None;

	   		//Ask for username
	   		if (name.Count > 0)
	   		{
		   		if (name[0].InnerText.ToString().Equals(""))
		   		{
		   			UserName un = new UserName();
		   			un.ShowDialog(this);
		   			if(!un.getName().Equals(""))
		   			{
		   				data.updateVariables("sign", "Med vänliga hälsningar{Enter}" + un.getName(), "Variable");
			   			data.UserName = un.getName();
		   			}
		   		}
	   		}
	   		insertCommands(command, text, type, system);
	   		insertFunctions(functions);
	   		insertChangelog(changelogVersion, changelogEntry);
	   		setDataSource();
	   		xRead.Close();
		}

		/**
		 * Add all hotstrings as separate row in ListofCommands and variables in ListofVariables
		 * */
		void insertCommands(XmlNodeList command, XmlNodeList text, XmlNodeList type, XmlNodeList system)
		{
	   		if (command.Count > 0)
	   		{
		   		for (int i = 0; i < command.Count; i++)
		   		{
		   			if (type[i].InnerText.ToString().Equals("Hotstring"))
		   				data.updateCommands(command[i].InnerText.ToString(), text[i].InnerText.ToString().Trim(), type[i].InnerText.ToString(), system[i].InnerText.ToString());
		   			else
		   				data.updateVariables(command[i].InnerText.ToString(), text[i].InnerText.ToString().Trim(), type[i].InnerText.ToString());
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

		/**
		 * Close application
		 * */
		void BtnCloseClick(object sender, EventArgs e)
		{
			if (data.Updated)
			{
				DialogResult answer = MessageBox.Show("Ändringar har gjorts, men har inte sparats.\r\nVill du spara?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
				if (answer == DialogResult.Yes)
				{
					saveToScriptFile();
					saveToXMLFile();
					shutdown();
				} else {
					shutdown();
				}
			}
			else
			{
				shutdown();
			}
		}

		void shutdown()
		{
			this.Close();
			Application.Exit();
		}

		/**
		 * Sets datasource för listbox and rebinds it for list to be updated
		 * */
		void setDataSource()
		{
	   		lstBHotstrings.DataSource = data.joinedlist;

	   		lstBHotstrings.DisplayMember = "Command";
	   		lstBHotstrings.ValueMember = "Text";
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
			} catch (Exception exc)
			{
				MessageBox.Show("Något gick fel när Changelog-filen skulle sparas\nFel:\n" + exc.Message.ToString(), "Skrivfel", MessageBoxButtons.OK);
			}
		}

		/**
		 * Collect all hotstrings and return as string
		 * */
		string fetchCommandsForXML()
		{
			string i="";
			foreach (AHKCommand item in data.joinedlist)
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
			foreach (AHKCommand item in data.joinedlist)
			{
				if (item.Type.Equals("Hotstring"))
					i = i + item.getScriptString()+"\r\n";
				else
					i = i + item.getScriptString();
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
				string commandName = f.getItem();
				int commandType = f.getCommandType();

				if (commandType == 2)
				{
					tabControl1.SelectedIndex = 1;
					txtFunctions.Focus();
					txtFunctions.Text = txtFunctions.Text + "\r\n" + commandName + "\r\n{\r\n\r\n}";
				}
				else
				{
					if (commandType == 0)
					{
						data.updateCommands(commandName, "", "Hotstring","");
						txtHSText.Text = "SendInput,\r\n(\r\n\r\n)\r\nReturn";
					}
					else
					{
						data.updateVariables(commandName, "", "Variable");
						tabControl1.SelectedIndex = 0;
					}
					setDataSource();
					int i = lstBHotstrings.FindString(commandName);
					if (i != -1)
						lstBHotstrings.SetSelected(i,true);
				}
				data.Updated = true;
			}
		}

		void TxtHSText_TextChanged(object sender, EventArgs e)
		{
			if (txtHSText.Text != lstBHotstrings.SelectedValue.ToString())
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
		void lstHotstrings_ValueChange(object sender, EventArgs e)
		{
			if(lstBHotstrings.SelectedIndex != -1)
			{
				txtHSText.TextChanged -= TxtHSText_TextChanged;
				txtHSText.Text = lstBHotstrings.SelectedValue.ToString();
				txtHSText.Focus();
				txtHSText.SelectionStart = txtHSText.Text.Length + 1;
				txtHSText.TextChanged += TxtHSText_TextChanged;
			}
		}

		/**
		 * Update listitem
		 * */
		void BtnSaveHotstringText_Click(object sender, EventArgs e)
		{
			data.updateCommandItem(lstBHotstrings.GetItemText(lstBHotstrings.SelectedItem), txtHSText.Text);
			ChangeLogText temp = new ChangeLogText(lstBHotstrings.GetItemText(lstBHotstrings.SelectedItem));
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
		
		void TestToolStripMenuItemClick(object sender, EventArgs e)
		{
			Tree t = new Tree(data.joinedlist);
			t.ShowDialog(this);
		}
	}
}
