using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class NewCommand : Form
	{
		AllData data;
		public NewCommand(ref AllData l)
		{
			InitializeComponent();
			this.ActiveControl = txtName;
			data = l;
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
		void BtnSave_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/**
		 * Disable savebutton if no index is selected
		 * Disable textbox for system if type function is selected
		 * */
		void cbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbType.SelectedIndex.ToString().Equals("-1"))
				btnSave.Enabled = false;
			else if (cbType.SelectedIndex.ToString().Equals("1"))
			{
				txtSystem.Enabled = false;
				btnSave.Enabled = true;
			}
			else
			{
				txtSystem.Enabled = true;
				btnSave.Enabled = true;
			}
		}

		/**
		 * Called when form is closing
		 * If button for saving is pressed, check if textbox for name or system is empty, notify user and focus textbox
		 * Checks if command exists, notify user
		 * */
		void NewCommand_FormClosing(object sender, FormClosingEventArgs e)
		{
			int i = cbType.SelectedIndex;
			DialogResult answer;

			if (this.DialogResult == DialogResult.OK)
			{
				if (i == 0 || i == 2)
				{
					if (txtName.Text.Equals("") || txtSystem.Text.Equals(""))
					{
						answer = MessageBox.Show("Textbox for name is empty.", "", MessageBoxButtons.OKCancel);
						e.Cancel = true;
					} else if (data.commandExists(txtName.Text)){
						MessageBox.Show("Command already exists.\r\nChoose a new name.");
						this.ActiveControl = txtName;
						e.Cancel = true;
					}
				}
				else
				{
					if (txtName.Text.Equals(""))
					{
						answer = MessageBox.Show("Textbox for name is empty.", "", MessageBoxButtons.OKCancel);
						e.Cancel = true;
					} else if (data.commandExists(txtName.Text)){
						MessageBox.Show("Command already exists.\r\nChoose a new name.");
						this.ActiveControl = txtName;
						e.Cancel = true;
					}
				}
			}
		}
		
		/**
		 * Set DialogResult and close form
		 * */
		void BtnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
