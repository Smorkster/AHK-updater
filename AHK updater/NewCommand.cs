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
			btnSave.DialogResult = DialogResult.OK;
			btnClose.DialogResult = DialogResult.Cancel;
			this.ActiveControl = txtName;
			data = l;
		}

		/**
		 * Returns the name of new commando
		 * */
		public string getItem()	{return txtName.Text;}

		/**
		 * Return type of command
		 * */
		public string getCommandType() {return cbType.SelectedItem.ToString();}

		/**
		 * Close the form
		 * */
		void BtnCloseClick(object sender, EventArgs e) {this.Close();}

		/**
		 * Close the form
		 * */
		void BtnSaveClick(object sender, EventArgs e) {this.Close();}

		/**
		 * If Function is selected, disable textbox since the function is named in the textbox
		 * */
		void cbTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			if(cbType.SelectedIndex.ToString().Equals("2"))
			{
				txtName.Enabled = false;
				btnSave.Enabled = true;
			}
			else if (cbType.SelectedIndex.ToString().Equals("-1"))
				btnSave.Enabled = false;
			else
			{
				txtName.Enabled = true;
				btnSave.Enabled = true;
			}
		}

		/**
		 * When the form is closing, check chosen index of combobox.
		 * If none is chosen, cancel closing
		 * If Hotstring or Variable is chosen, check if name is given, otherwise, cancel closing
		 * If command with same name exists, ask for new name, otherwise create command 
		 * */
		void NewCommand_FormClosing(object sender, FormClosingEventArgs e)
		{
			int i = Convert.ToInt16(cbType.SelectedIndex.ToString());
			DialogResult answer;

			if (this.DialogResult == DialogResult.OK)
			{
				if (i == -1)
				{
					if (!txtName.Text.Equals(""))
					{
						answer = MessageBox.Show("Val av typ måste göras.","",MessageBoxButtons.OKCancel);
						e.Cancel = true;
					}
				}
				else if (i == 0 || i == 1)
				{
					if (txtName.Text.Equals(""))
					{
						answer = MessageBox.Show("Textrutan är tom.","",MessageBoxButtons.OKCancel);
						e.Cancel = true;
					} else if (data.commandExists(txtName.Text)){
						MessageBox.Show("Kommando finns redan.\r\nVälj nytt namn.");
						this.ActiveControl = txtName;
						e.Cancel = true;
					}
				}
			}
		}
	}
}
