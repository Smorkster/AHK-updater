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
			lblUserNameInfo.Text = "Ingen lokal settings-fil funnen. Behöver därför skapas. Ange önskat namn för signatur i standardsvar:";
			this.ActiveControl = txtUserName;
		}

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
