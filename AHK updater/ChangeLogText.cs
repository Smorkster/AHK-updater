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
		/// <summary>
		/// Set textbox to name of new or changed command 
		/// </summary>
		/// <param name="command">Command to which changes have been made</param>
		public ChangeLogText(string command)
		{
			InitializeComponent();
			txtChange.Text = command;
			this.ActiveControl = txtChange;
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Initiate with empty textbox
		/// Called when something have changed and the user might want to save changeinfo of the change 
		/// </summary>
		public ChangeLogText()
		{
			InitializeComponent();
			btnSave.DialogResult = DialogResult.OK;
			this.ActiveControl = txtChange;
		}

		/// <summary>
		/// User cancels the changeloginfo
		/// Set DialogResult to Abort and close form 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Abort;
			Close();
		}

		/// <summary>
		/// User have entered changeinfo and wants to save
		/// Set DialogResult to OK and close form 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// The user does not want to submit any changeinfo
		/// Set DialogResult to Cancel and close form
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnNoChangeText_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Return specified changelog entry as string
		/// </summary>
		/// <returns>String of changeinfo</returns>
		public string getChangeInfo()
		{
			return txtChange.Text;
		}

		/// <summary>
		/// When the textbox gets focus, place the carret at end of text
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtChange_Enter(object sender, EventArgs e)
		{
			txtChange.Select(txtChange.Text.Length, 0);
		}
	}
}
