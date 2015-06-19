using System;
using System.Windows.Forms;

namespace AHK_updater
{
	/**
	 * No local XML-file found, ask user for name to be used in script
	 * */
	public partial class UserName : Form
	{
		public UserName()
		{
			InitializeComponent();
			lblUserNameInfo.Text = "No local file for settings is found. Will be created.\r\nChoose a name to be used in commands:";
			this.ActiveControl = txtUserName;
		}

		/**
		 * Close form
		 * */
		void btnSave_Click(object sender, EventArgs e)
		{
			Close();
		}

		/**
		 * Return the name chosen by user
		 * */
		public string getName()
		{
			return txtUserName.Text;
		}

		/**
		 * Catches keypress 
		 * */
		void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char) 13)
				btnSave_Click(null, null);
		}
	}
}
