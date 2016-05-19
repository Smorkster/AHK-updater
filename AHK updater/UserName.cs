using System;
using System.Windows.Forms;

namespace AHK_updater
{
	/// <summary>
	/// No local XML-file found, ask user for name to be used in script 
	/// </summary>
	public partial class UserName : Form
	{
		public UserName()
		{
			InitializeComponent();
			lblUserNameInfo.Text = "No local file for settings is found. Will be created.\r\nChoose a name to be used in commands:";
			this.ActiveControl = txtUserName;
		}

		/// <summary>
		/// Close form 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnSave_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Return the name chosen by user 
		/// </summary>
		/// <returns>Name of user</returns>
		public string getName()
		{
			return txtUserName.Text;
		}

		/// <summary>
		/// Catches keypress 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic KeyPressEventArgs</param>
		void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char) 13)
				btnSave_Click(null, null);
		}
	}
}
