using System;
using System.Windows.Forms;

namespace AHK_updater
{
	/**
	 * No lokal XML-file found, ask user for name to be used in script
	 * */
	public partial class UserName : Form
	{
		public UserName()
		{
			InitializeComponent();
			lblUserNameInfo.Text = "No local file for settings is found. Will be created.\r\nChoose a new to be used in commands:";
			this.ActiveControl = txtUserName;
		}

		/**
		 * Close form
		 * */
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/**
		 * Return the name chosen by user
		 * */
		public string getName() {return txtUserName.Text;}
	}
}
