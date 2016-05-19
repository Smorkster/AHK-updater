using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class NewCommand : Form
	{
		AllData data;
		public NewCommand(ref AllData temp)
		{
			InitializeComponent();
			this.ActiveControl = txtName;
			cbType.SelectedIndex = 0;
			this.DialogResult = DialogResult.Cancel;
			data = temp;
		}

		/// <summary>
		/// Return name of command specified by user 
		/// </summary>
		/// <returns>Name of the new command</returns>
		public string getItem()
		{
			return txtName.Text; 
		}

		/// <summary>
		/// Return type of command 
		/// </summary>
		/// <returns>Type of the new command</returns>
		public int getCommandType()
		{
			return cbType.SelectedIndex;
		}

		/// <summary>
		/// Return system specified by user 
		/// </summary>
		/// <returns>System of the new command</returns>
		public string getSystem()
		{
			return txtSystem.Text;
		}

		/// <summary>
		/// Catch keypress from user
		/// Escape: close form
		/// Enter: act as if createbutton is pressed
		/// </summary>
		/// <param name="msg">Generic Message</param>
		/// <param name="keyData">Generic Keys</param>
		/// <returns>Generic bool if character was processed</returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData){
				case Keys.Escape:
					Close();
					return true;
				case Keys.Enter:
					btnCreate_Click(null, null);
					break;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		/// <summary>
		/// User have finished entering data
		/// Set DialogResult to OK and close form 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnCreate_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// User wants to cancel creating new command
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Depending on which index is selected, enable or disable controls
		/// No index: disable savebutton
		/// Index 1 or 2 (Variable or Function): disable textbox for system 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void cbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(txtName.Text.Length != 0)
			{
				switch (cbType.SelectedIndex) {
					case -1:
						btnCreate.Enabled = false;
						break;
					case 1: case 2:
						txtSystem.Enabled = false;
						btnCreate.Enabled = true;
						break;
					default:
						txtSystem.Enabled = true;
						btnCreate.Enabled = true;
						break;
				}
			}
		}

		/// <summary>
		/// Disable button for create if no name is given
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void txtName_TextChanged(object sender, EventArgs e)
		{
			if(txtName.Text.Length < 1)
				btnCreate.Enabled = false;
		}

		/// <summary>
		/// The form is closing
		/// If button for saving is pressed, check if textbox for system is empty
		/// If so, notify user and focus textbox
		/// Checks if command exists, notify user
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic FormClosingEventArgs</param>
		void NewCommand_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult answer;

			if (DialogResult == DialogResult.OK) {
				switch (cbType.SelectedIndex) {
					case 0:
						if (txtSystem.Text.Equals("")) {
							answer = MessageBox.Show("Textbox for system of the command is empty.", "", MessageBoxButtons.OKCancel);
							ActiveControl = txtSystem;
							e.Cancel = true;
						} else if (data.hotstringExists(txtName.Text)) {
							MessageBox.Show("Command already exists.\r\nChoose a new name.");
							ActiveControl = txtName;
							e.Cancel = true;
						}
						break;
					default:
						if (txtName.Text.Equals("")) {
							answer = MessageBox.Show("Textbox for name is empty.", "", MessageBoxButtons.OKCancel);
							ActiveControl = txtName;
							e.Cancel = true;
						} else if (data.hotstringExists(txtName.Text)) {
							var type = "variable";
							if (cbType.SelectedIndex == 2)
								type = "function";
							MessageBox.Show("A hotstring with this name already exists. Can't have a " + type + " with the same name.\r\nChoose a new name.");
							ActiveControl = txtName;
							txtName.Select(0, txtName.Text.Length);
							e.Cancel = true;
						}
						break;
				}
			}
		}
	}
}
