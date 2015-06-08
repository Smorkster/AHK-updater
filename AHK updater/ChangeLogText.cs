/**
 * With this form the user can specify the changes that have been made
 * If it is a new hotstring, a hotstring that have been modified or any changes to the functions
 * */
using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class ChangeLogText : Form
	{
		/**
		 * Set textbox to name of new or changed command 
		 * */
		public ChangeLogText(string command)
		{
			InitializeComponent();
			txtChange.Text = command;
			this.ActiveControl = txtChange;
			this.DialogResult = DialogResult.Cancel;
		}

		/**
		 * Initiate with empty textbox
		 * Called when textbox for functions is to be saved
		 * */
		public ChangeLogText()
		{
			InitializeComponent();
			btnSave.DialogResult = DialogResult.OK;
			this.ActiveControl = txtChange;
		}

		/**
		 * Set DialogResult and close form
		 * */
		void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Abort;
			Close();
		}

		/**
		 * Set DialogResult and close form
		 * */
		void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		/**
		 * Return specified changelog entry as string
		 * */
		public string getChangeInfo()
		{
			return txtChange.Text;
		}
		
		void txtChange_Enter(object sender, EventArgs e)
		{
			txtChange.Select(txtChange.Text.Length, 0);
		}

		void btnCancelChangeText_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
