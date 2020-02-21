using AHK_updater.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AHK_updater
{
	public class MyTextBox : TextBox
	{
		List<string> history = new List<string>();

		public MyTextBox(){}

		/// <summary>
		/// Clear edithistory for the textbox.
		/// </summary>
		public void ClearHistory()
		{
			history.Clear();
		}

		/// <summary>
		/// Ignore changed made in the text.
		/// </summary>
		public bool IgnoreChange { get; set; }

		/// <summary>
		/// Initialize the editinghistory
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			history = new List<string>();
		}

		/// <summary>
		/// Text in textbox have changed, should it be added to editinghistory?
		/// </summary>
		/// <param name="e">Generic EventArgs</param>
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);

			if (!IgnoreChange)
				history.Add(Text);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyData == (Keys.Control | Keys.Z))
				Undo();
			base.OnKeyDown(e);
		}

		/// <summary>
		/// Go back one step in the textboxes editing history
		/// </summary>
		new public void Undo()
		{
			if (history.Count > 0)
			{
				IgnoreChange = true;
				Text = history[history.Count - 1];
				history.RemoveAt(history.Count - 1);
				IgnoreChange = false;
			}
		}
	}
}
