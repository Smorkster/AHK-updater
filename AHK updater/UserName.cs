using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class UserName : Form
	{
		public UserName()
		{
			InitializeComponent();
			label1.Text = "Ingen lokal settings-fil funnen. Behöver därför skapas. Ange önskat namn för signatur i standardsvar:";
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		public string getName() {return textBox1.Text;}
	}
}
