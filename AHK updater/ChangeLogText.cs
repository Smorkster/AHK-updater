using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class ChangeLogText : Form
	{
		public ChangeLogText(string command)
		{
			InitializeComponent();
			chlSave.DialogResult = DialogResult.OK;
			txtChange.Text = command;
			this.ActiveControl = txtChange;
		}
		public ChangeLogText()
		{
			InitializeComponent();
			chlSave.DialogResult = DialogResult.OK;
		}

		void ChlCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}

		void ChlSaveClick(object sender, EventArgs e)
		{
			this.Close();
		}

		public string getChangeInfo()
		{
			return txtChange.Text;
		}
	}
}
