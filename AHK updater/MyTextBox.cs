using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public class MyTextBox : TextBox
	{
		/// <summary>
		/// Handling commandkeys to check if CTRL+Backspace was pressed
		/// If so, text will be deleted between each stopping point
		/// </summary>
		/// <param name="msg">Generic Message</param>
		/// <param name="keyData">Generic Keys</param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys.Back | Keys.Control)) {
				for (int i = SelectionStart - 1; i > 0; i--) {
					// A case for each stopping point when deleting
					switch (Text.Substring(i, 1)) {
						case "\n":
						case " ":
						case ";":
						case ",":
						case "/":
						case "\\":
						case ".":
						case ")":
						case "(":
							Text = Text.Remove(i, SelectionStart - i);
							SelectionStart = i;
							return true;
					}
				}
				Clear();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
