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
			data = temp;
		}

		/**
		 * Return name of command specified by user
		 * */
		public string getItem()
		{
			return txtName.Text; 
		}

		/**
		 * Return type of command
		 * */
		public int getCommandType()
		{
			return cbType.SelectedIndex;
		}

		/**
		 * Return system specified by user
		 * */
		public string getSystem()
		{
			return txtSystem.Text;
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
		 * Disable savebutton if no index is selected
		 * Disable textbox for system if type function is selected
		 * */
		void cbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (cbType.SelectedIndex) {
				case -1:
					btnSave.Enabled = false;
					break;
				case 1:
					txtSystem.Enabled = false;
					btnSave.Enabled = true;
					break;
				default:
					txtSystem.Enabled = true;
					btnSave.Enabled = true;
					break;
			}
		}

		/**
		 * Called when form is closing
		 * If button for saving is pressed, check if textbox for name or system is empty, notify user and focus textbox
		 * Checks if command exists, notify user
		 * */
		void NewCommand_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult answer;

			if (DialogResult == DialogResult.OK) {
				switch (cbType.SelectedIndex) {
					case 0:
					case 2:
						if (txtName.Text.Equals("") || txtSystem.Text.Equals("")) {
							answer = MessageBox.Show("Textbox for name is empty.", "", MessageBoxButtons.OKCancel);
							e.Cancel = true;
						} else if (data.commandExists(txtName.Text)) {
							MessageBox.Show("Command already exists.\r\nChoose a new name.");
							ActiveControl = txtName;
							e.Cancel = true;
						}
						break;
					default:
						if (txtName.Text.Equals("")) {
							answer = MessageBox.Show("Textbox for name is empty.", "", MessageBoxButtons.OKCancel);
							e.Cancel = true;
						} else if (data.commandExists(txtName.Text)) {
							MessageBox.Show("Command already exists.\r\nChoose a new name.");
							ActiveControl = txtName;
							e.Cancel = true;
						}
						break;
				}
			}
		}
		
		/**
		 * Set DialogResult and close form
		 * */
		void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
