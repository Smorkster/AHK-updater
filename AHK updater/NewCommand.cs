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
		 * Catch keypress
		 * If Escape, close form
		 * If Enter, act as if createbutton is pressed
		 * */
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

		/**
		 * Set DialogResult and close form
		 * */
		void btnCreate_Click(object sender, EventArgs e)
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
						if (txtName.Text.Equals("")) {
							answer = MessageBox.Show("Textbox for name of the command is empty.", "", MessageBoxButtons.OKCancel);
							ActiveControl = txtName;
							e.Cancel = true;
						} else if  (txtSystem.Text.Equals("")) {
							answer = MessageBox.Show("Textbox for system of the command is empty.", "", MessageBoxButtons.OKCancel);
							ActiveControl = txtSystem;
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
							ActiveControl = txtName;
							e.Cancel = true;
						} else if (data.commandExists(txtName.Text)) {
							var type = "variable";
							if (cbType.SelectedIndex == 2) type = "function";
							MessageBox.Show("A hotstring with this name already exists. Can't have a " + type + " with the same name.\r\nChoose a new name.");
							ActiveControl = txtName;
							txtName.Select(0, txtName.Text.Length);
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
