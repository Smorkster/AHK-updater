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
			return txtNewName.Text;
		}

		void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		void btnSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
		
		void NewName_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (txtNewName.Text.Length < 3 && txtNewName.Text.Length > 0) {
				var answer = MessageBox.Show("Length of the name is short, which is not encouraged.\nAre you sure you want it to be this short?", "Short name of command", MessageBoxButtons.YesNo);

				if (answer == DialogResult.No)
					e.Cancel = true;
			}
		}
	}
}
