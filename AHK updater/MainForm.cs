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

		BindingList<AHKCommand> ListofCommands = new BindingList<AHKCommand>(),
								ListofVariables = new BindingList<AHKCommand>(),
								DataSourceList = new BindingList<AHKCommand>();
		string scriptfilename = "AHK script - Test.ahk",
				xmlfilename = "AHK script - Test.xml",
				originalxmlfilename = "AHK script - Test.xml";
		AllData data = new AllData();

		void MainFormLoad(object sender, EventArgs e)
		{
			//If file is present, open and read. Otherwise, read central file
			if(File.Exists(xmlfilename))
			{
				getXMLCommands(xmlfilename);
			} else if (File.Exists(originalxmlfilename)){
				getXMLCommands(originalxmlfilename);
			}
		}

		/**
		 * Open XML-file, read commands to corresponding nodelists and insert to bindingslist
		 * Checks if name have been given to file, otherwise, ask user
		 * */
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
		    	functions = doc.GetElementsByTagName("functions"),
		    	changelog = doc.GetElementsByTagName("changelog");
	   		xRead.WhitespaceHandling = WhitespaceHandling.None;

			//Add all hotstrings and variables to lists in data
	   		if (command.Count > 0)
	   		{
		   		for(int i = 0; i < command.Count; i++)
		   		{
		   			if(type[i].InnerText.ToString().Equals("Hotstring"))
		   				data.updateCommands(command[i].InnerText.ToString(),text[i].InnerText.ToString().Trim(),type[i].InnerText.ToString());
		   			else if (type[i].InnerText.ToString().Equals("Variable"))
		   				data.updateVariables(command[i].InnerText.ToString(),text[i].InnerText.ToString().Trim(),type[i].InnerText.ToString());
		   		}
	   		}

	   		//Write all functions to txtFunctions
	   		if(functions.Count > 0)
	   			txtFunctions.Text = functions[0].InnerText.ToString();
	   		//Write changelog to txtChangelog
	   		if(changelog.Count > 0)
	   			txtChangelog.Text = changelog[0].InnerText.ToString();

	   		if (name[0].InnerText.ToString().Equals(""))
	   		{
	   			UserName un = new UserName();
	   			un.ShowDialog(this);
	   			data.updateVariables("sign", "Med vänliga hälsningar{Enter}" + un.getName(), "Variable");
	   			data.UserName = un.getName();
	   		}
	   		setDataSource();

	   		xRead.Close();
		}

		/**
		 * Close application
		 * */
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
			Application.Exit();
		}

		/**
		 * Sets datasource of listbox to update items
		 * */
		void setDataSource()
		{
	   		lstHotstrings.DataSource = data.joinedlist;
	   		lstHotstrings.DisplayMember = "Command";
	   		lstHotstrings.ValueMember = "Text";
		}

		/**
		 * Open form to define name of new hotstring
		 * Change tabControl selected tab if new function is to be created
		 * */
		void newHotstring(object sender, EventArgs e)
		{
			NewCommand f = new NewCommand(ref data);

			if (f.ShowDialog(this) == DialogResult.OK)
			{
				string commandName = f.getItem();
				string commandType = f.getCommandType();

				if(commandType.Equals("Funktion"))
				{
					tabControl1.SelectedIndex = 1;
					txtFunctions.Focus();
					txtFunctions.SelectionStart = txtFunctions.Text.Length + 1;
				}
				else
				{
					if(commandType.ToString().Equals("Hotstring"))
						data.updateCommands(commandName, "", commandType);
					else
						data.updateVariables(commandName, "",commandType);
					setDataSource();
					//Selects row in listbox for new item
					int i = lstHotstrings.FindString(commandName);
					if (i != -1)
						lstHotstrings.SetSelected(i,true);
				}
			}
		}

		/**
		 * Collect the hotstrings and write to AutoHotKey script-file
		 * */
		void saveToScriptFile(object sender, EventArgs e)
		{
            StreamWriter writer = new StreamWriter(scriptfilename, false, System.Text.UnicodeEncoding.Unicode);

            try
            {
            	writer.Write(fetchAHKCommands());
            	writer.Flush();
            	writer.WriteLine("GuiClose:\r\nExitApp");
            	writer.Flush();
            	writer.Close();
            	
            	MessageBox.Show("Skriptfil sparad");
            } catch(Exception exc)
            {
            	MessageBox.Show("Något gick fel när skriptfilen skulle sparas\nFel:\n"+exc.Message.ToString(),"Skrivfel",MessageBoxButtons.OK);
            }
		}

		/**
		 * Collect the hotstrings and write to XML-file
		 * */
		void saveToXML(object sender, EventArgs e)
		{
            StreamWriter writer = new StreamWriter(xmlfilename, false, System.Text.UnicodeEncoding.Unicode);

            try
            {
            	writer.WriteLine("<?xml version=\"1.0\"?>\r\n<ahk>");
            	writer.WriteLine("<ahkcommand><name>" + data.UserName + "</name></ahkcommand>");
            	writer.Write(fetchCommands());
            	writer.Flush();
            	writer.WriteLine(fetchFunctions());
            	writer.Flush();
            	writer.WriteLine(fetchChangelog());
            	writer.WriteLine("</ahk>");
            	writer.Flush();
            	writer.Close();
            	
            	MessageBox.Show("XML-fil sparad");
            } catch(Exception exc)
            {
            	MessageBox.Show("Något gick fel när XML-filen skulle sparas\nFel:\n"+exc.Message.ToString(),"Skrivfel",MessageBoxButtons.OK);
            }
		}

		/**
		 * Collect all hotstrings and return as string
		 * */
		string fetchCommands()
		{
			string i="";
			foreach(AHKCommand item in data.joinedlist)
			{
				i = i + item.XMLString() + "\r\n";
			}
			return i;
		}

		/**
		 * Collect all hotstrings and return as XML-formated string
		 * */
		string fetchAHKCommands()
		{
			string i="";
			foreach(AHKCommand item in data.joinedlist)
			{
				i = i + item.AHKString()+"\r\n";
			}
			
			return i + txtFunctions.Text.Trim() + "\r\n";
		}

		/**
		 * Return all functions as XML-formated string
		 * */
		string fetchFunctions()	{return "<ahkcommand><functions>" + txtFunctions.Text + "</functions></ahkcommand>";}

		/**
		 * Return changelog
		 * */
		string fetchChangelog() {return "<ahkcommand><changelog>" + txtChangelog.Text + "</changelog></ahkcommand>";}

		/**
		 * If text have changed, check if different from original, then show button for saving
		 * */
		void TxtHSText_TextChanged(object sender, EventArgs e)
		{
			if (txtHSText.Text != lstHotstrings.SelectedValue.ToString())
			{
				btnSaveText.Enabled = true;
				btnSaveText.Visible = true;
			} else {
				btnSaveText.Enabled = false;
				btnSaveText.Visible = false;
			}
		}

		/**
		 * When hotstring in lstHotstring is changed, load the corresponding hotstring text in txtboxText
		 * Disable event for TextChanged so the savebutton isn't shown
		 * */
		void lstHotstrings_ValueChange(object sender, EventArgs e)
		{
			if(lstHotstrings.SelectedIndex != -1)
			{
				txtHSText.TextChanged -= TxtHSText_TextChanged;
				txtHSText.Text = lstHotstrings.SelectedValue.ToString();
				txtHSText.Focus();
				txtHSText.SelectionStart = txtHSText.Text.Length + 1;
				txtHSText.TextChanged += TxtHSText_TextChanged;
			}
		}

		/**
		 * Update listitem
		 * */
		void BtnSaveTextClick(object sender, EventArgs e)
		{
			data.updateItem(lstHotstrings.GetItemText(lstHotstrings.SelectedItem), txtHSText.Text);
			btnSaveText.Enabled = false;
			btnSaveText.Visible = false;
		}
	}
}
