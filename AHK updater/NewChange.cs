using System;
using System.Windows.Forms;

namespace AHK_updater
{
	/// <summary>
	/// With this form the user can specify the changes that have been made.
	/// If it is a new hotstring, a hotstring that have been modified or any changes to the functions.
	/// </summary>
	public partial class NewChange : Form
	{
		string noText;
		/// <summary>
		/// Set textbox to name of new or changed command 
		/// </summary>
		/// <param name="c">Command to which changes have been made</param>
		public NewChange(string c)
		{
			InitializeComponent();
			txtChange.Text = noText = c + " - ";
			this.ActiveControl = txtChange;
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Initiate with empty textbox
		/// Called when something have changed and the user might want to save changeinfo of the change 
		/// </summary>
		public NewChange()
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
		void BtnCancel_Click (object sender, EventArgs e)
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
		void BtnSave_Click (object sender, EventArgs e)
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
		void BtnNoChangeText_Click (object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Return specified changelog entry as string
		/// </summary>
		/// <returns>String of changeinfo</returns>
		public string GetChangeInfoText ()
		{
			if (txtChange.Text.Equals(noText))
				return "";
			return txtChange.Text;
		}

		/// <summary>
		/// When the textbox gets focus, place the carret at end of text
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtChange_Enter (object sender, EventArgs e)
		{
			txtChange.Select(txtChange.Text.Length, 0);
		}

		/// <summary>
		/// Checks if Enter is pressed in the textbox
		/// If so, handle as if the Save-button is pressed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic KeyPressEventArgs</param>
		void TxtChange_KeyPress (object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.Equals(Keys.Enter))
			{
				BtnSave_Click(null, null);
			} else if (e.KeyChar.Equals(Keys.Escape)) {
				BtnCancel_Click(null, null);
			}
		}
	}
}
