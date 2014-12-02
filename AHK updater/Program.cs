using System;
using System.Windows.Forms;

namespace AHK_updater
{
	// Class with program entry point.
	internal sealed class Program
	{
		// Program entry point.
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
