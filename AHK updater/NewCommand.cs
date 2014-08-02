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

		public string getSystem()
		{
			return txtSystem.Text;
		}

		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}

		void BtnSaveClick(object sender, EventArgs e)
		{
			this.Close();
		}

		/**
		 * If Function is selected, disable textbox for naming it
		 * */
		void cbTypeSelectedIndexChanged(object sender, EventArgs e)
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
						answer = MessageBox.Show("Textrutan är tom.","",MessageBoxButtons.OKCancel);
						e.Cancel = true;
					} else if (data.commandExists(txtName.Text)){
						MessageBox.Show("Kommando finns redan.\r\nVälj nytt namn.");
						this.ActiveControl = txtName;
						e.Cancel = true;
					}
				}
				else
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
