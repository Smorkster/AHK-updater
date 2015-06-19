using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class NewName : Form
	{
		AllData data;
		public NewName(string commandname, ref AllData temp)
		{
			InitializeComponent();
			this.DialogResult = DialogResult.Cancel;
			txtNewName.Text += commandname;
			data = temp;
			this.ActiveControl = txtNewName;
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
			if (DialogResult == DialogResult.OK) {
				if (data.commandExists(txtNewName.Text)) {
					MessageBox.Show("A command with that name already exists.\nChoose another name.", "", MessageBoxButtons.OK);
					e.Cancel = true;
				} else if (txtNewName.Text.Length < 3 && txtNewName.Text.Length > 0) {
					var answer = MessageBox.Show("Length of the name is short, which is not encouraged.\nAre you sure you want it to be this short?", "Short name of command", MessageBoxButtons.YesNo);
					if (answer == DialogResult.No)
						e.Cancel = true;
				}
			}
		}
		void txtNewName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				DialogResult = DialogResult.OK;
		}
	}
}
