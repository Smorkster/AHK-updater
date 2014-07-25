/**
 * A form shown when a hotstring is updated or created.
 * Purpose is to add text in changelog for what have been done.
 * */
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
		}

		void ChlCancelClick(object sender, EventArgs e) {this.Close();}

		void ChlSaveClick(object sender, EventArgs e) {this.Close();}

		public string changeInfo() {return txtChange.Text;}
	}
}
