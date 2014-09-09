using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class NewName : Form
	{
		public NewName(string commandname)
		{
			InitializeComponent();
			this.DialogResult = DialogResult.Cancel;
			txtNewName.Text = commandname;
		}

		public string getNewName()
		{
			return txtNewName.Text.ToString();
		}

		void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		void BtnSaveClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		void NewName_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (txtNewName.Text.Length < 3 && txtNewName.Text.Length > 0)
			{
				DialogResult answer = MessageBox.Show("Längden på namnet är kort, vilket inte uppmanas.\nÄr du säker att det ska vara så kort?", "Kort namn på kommando", MessageBoxButtons.YesNo);

				if (answer == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}
	}
}
