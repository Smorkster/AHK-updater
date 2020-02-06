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
		[DllImport("user32.dll")]
		static extern bool GetCaretPos(out Point lpPoint);

		List<string> history = new List<string>();
		ListBox listBox;
		string[] autoCompleteFunctionsList;
		string[] autoCompleteVariablesList;
		string[] separators = { "|", "[", "]", "\r", " ", "\t", "(", ")", ";", ",", "/", ".", "!", "?", "\"", "\\" };
		string formerValue = string.Empty;
		int prevBreak;
		int nextBreak;
		int wordLength;
		public int CaretIndex => SelectionStart;


		public MyTextBox()
		{
			InitializeComponent();
			ResetListBox();
		}

		/// <summary>
		/// Get/set the autocompletelist of functionnames for the textbox
		/// </summary>
		public string[] AutoCompleteFunctionsList
		{
			get { return autoCompleteFunctionsList; }
			set { autoCompleteFunctionsList = null;
				autoCompleteFunctionsList = value; }
		}

		/// <summary>
		/// Get/set the autocompletelist of variables for the textbox
		/// </summary>
		public string[] AutoCompleteVariablesList
		{
			get { return autoCompleteVariablesList; }
			set { autoCompleteVariablesList = null;
				autoCompleteVariablesList = value; }
		}

		/// <summary>
		/// Clear edithistory for the textbox.
		/// </summary>
		public void ClearHistory()
		{
			history.Clear();
		}

		/// <summary>
		/// Get the word in the text (between the most closet space-characters).
		/// </summary>
		/// <returns></returns>
		string GetWord()
		{
			int posStart = Text.LastIndexOf(' ', (SelectionStart < 1) ? 0 : SelectionStart - 1);
			int posEnd = Text.IndexOf(' ', SelectionStart);

			posStart = (posStart == -1) ? 0 : posStart + 1;
			posEnd = (posEnd == -1) ? Text.Length : posEnd;

			int length = ((posEnd - posStart) < 0) ? 0 : posEnd - posStart;

			return Text.Substring(posStart, length);
		}

		/// <summary>
		/// Ignore changed made in the text.
		/// </summary>
		public bool IgnoreChange { get; set; }

		/// <summary>
		/// Create the listbox for autocomplete and set eventhandlers.
		/// </summary>
		void InitializeComponent()
		{
			listBox = new ListBox();

			KeyDown += This_KeyDown;
			KeyUp += This_KeyUp;
			Leave += This_Leave;
		}

		/// <summary>
		/// A word in the autocomplete-list was chosen, insert the word in the text.
		/// </summary>
		/// <param name="newTag">Word to insert in the text</param>
		void InsertWord(string newTag)
		{
			string text = Text;
			int pos = SelectionStart;

			int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
			posStart = (posStart == -1) ? 0 : posStart + 1;
			int posEnd = text.IndexOf(' ', pos);

			string firstPart = text.Substring(0, posStart) + newTag;
			string updatedText = firstPart + ((posEnd == -1) ? "" : text.Substring(posEnd, text.Length - posEnd));


			Text = updatedText;
			SelectionStart = firstPart.Length;
		}

		/// <summary>
		/// Check if inputkey should handle autocomplete-list items.
		/// </summary>
		/// <param name="keyData">Generic Keys</param>
		/// <returns>True if listbox is visible and inputkey is 'Tab'</returns>
		protected override bool IsInputKey(Keys keyData)
{
			switch (keyData)
			{
				case Keys.Tab:
					if (listBox.Visible)
						return true;
					else
						return false;
				default:
					return base.IsInputKey(keyData);
			}
		}

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

		/// <summary>
		/// The listbox is no longer needed, hide it.
		/// </summary>
		public void ResetListBox()
		{
			listBox.Visible = false;
		}

		/// <summary>
		/// Set a location for the listbox and display it.
		/// </summary>
		void ShowListBox()
		{
			Form parentForm = FindForm();
			if (parentForm == null) return;

			parentForm.Controls.Add(listBox);
			GetCaretPos(out Point caretPosition);
			Point textboxPosition = FindForm().PointToClient(Parent.PointToScreen(Location));
			listBox.Left = textboxPosition.X + caretPosition.X;
			listBox.Top = textboxPosition.Y + caretPosition.Y + 15;

			listBox.Visible = true;
			listBox.BringToFront();
		}

		/// <summary>
		/// At KeyDown-event, check keycombination and modify the listbox
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic KeyEventArgs</param>
		void This_KeyDown(object sender, KeyEventArgs e)
		{
			// Single keystrokes
			switch (e.KeyCode)
			{
				case Keys.Enter:
				case Keys.Tab:
				case Keys.Space:
					{
						if (listBox.Visible)
						{
							if (listBox.SelectedItem.ToString().Contains(":-"))
							{
								e.Handled = true;
							}
							else
							{
								Text = Text.Remove(prevBreak == 0 ? 0 : prevBreak + 1, prevBreak == 0 ? wordLength + 1 : wordLength);
								Text = Text.Insert(prevBreak == 0 ? 0 : prevBreak + 1, listBox.SelectedItem.ToString());
								ResetListBox();
								formerValue = Text;
								Select(Text.Length, 0);
								e.Handled = true;
							}
						}
						return;
					}
				case Keys.Down:
					{
						if (listBox.Visible && (listBox.SelectedIndex < listBox.Items.Count - 1))
						{
							listBox.SelectedIndex++;
							e.Handled = true;
						}
						return;
					}
				case Keys.Up:
					{
						if (listBox.Visible && (listBox.SelectedIndex > 0))
						{
							listBox.SelectedIndex--;
							e.Handled = true;
						}
						return;
					}
				case Keys.Escape:
					{
						listBox.Visible = false;
						e.Handled = true;
						return;
					}
				case Keys.Back:
					string t = Text.Substring(SelectionStart - 1, 1);
					if (t.Equals(" ") || Regex.Match(t, @"\W").Value.Equals(""))
					{
						listBox.Visible = false;
					}
					return;
			}
			// Shortcuts
			if (e.KeyData == (Keys.Back | Keys.Control))
			{
				e.SuppressKeyPress = true;
				string text="";
				foreach (string s in separators)
				{
					// (\))?\W*$ not word
					// (\w)?\w*$ word
					Match m = Regex.Match(Text, $@"(\{s})?\W*$");
					if (!m.Value.Equals(""))
					{
						text = Regex.Replace(Text.Substring(0, SelectionStart), $@"(\{s})?\W?$", "");
						break;
					}
				}
				if (text.Equals(""))
					text = Regex.Replace(Text.Substring(0, SelectionStart), @"(\w)?\w*$", "");
				Text = text + Text.Substring(SelectionStart);
				SelectionStart = text.Length;
			}
		}

		/// <summary>
		/// At KeyUp-event, begin update listbox
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic KeyEventArgs</param>
		void This_KeyUp(object sender, KeyEventArgs e)
		{
			UpdateListBox();
		}

		/// <summary>
		/// Hide the autocomplete-listbox if focus leaves textbox
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void This_Leave(object sender, EventArgs e)
		{
			listBox.Visible = false;
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

		/// <summary>
		/// Update the autocomplete listbox with items and size
		/// </summary>
		void UpdateListBox()
		{
			if (Text == formerValue) return;
			if (Text.Length == 0)
			{
				listBox.Visible = false;
				return;
			}

			formerValue = Text;
			prevBreak = Text.LastIndexOfAny(separators.StrArrayToCharArray(), CaretIndex > 0 ? CaretIndex - 1 : 0);
			if (prevBreak < 1) prevBreak = 0;
			nextBreak = Text.IndexOfAny(separators.StrArrayToCharArray(), prevBreak + 1);
			if (nextBreak == -1) nextBreak = CaretIndex;
			wordLength = nextBreak - prevBreak - 1;
			if (wordLength < 1) return;

			string word = Text.Substring(prevBreak + 1, wordLength);

			if ((autoCompleteFunctionsList != null || autoCompleteVariablesList != null) && word.Length > 0)
			{
				string[] functionMatches = Array.FindAll(autoCompleteFunctionsList,
					x => x.ToLower().Contains(word.ToLower()));
				string[] variableMatches = Array.FindAll(autoCompleteVariablesList,
					x => x.ToLower().Contains(word.ToLower()));
				List<string> matches = new List<string>();
				if (functionMatches.Length > 0)
				{
					matches.Add(":- Functions -:");
					matches.AddRange(functionMatches);
				}
				if (variableMatches.Length > 0)
				{
					matches.Add(":- Variables -:");
					matches.AddRange(variableMatches);
				}
				if (matches.Count > 0)
				{
					ShowListBox();
					listBox.BeginUpdate();
					listBox.Items.Clear();
					listBox.Items.AddRange(matches.ToArray());
					listBox.SelectedIndex = 0;
					listBox.Height = 0;
					listBox.Width = 0;
					Focus();
					using (Graphics graphics = listBox.CreateGraphics())
					{
						for (int i = 0; i < listBox.Items.Count; i++)
						{
							if (i < 20)
								listBox.Height += listBox.GetItemHeight(i);
							string trr = ((string)listBox.Items[i]) + "_";
							int itemWidth = (int)graphics.MeasureString(trr, listBox.Font).Width;
							listBox.Width = (listBox.Width < itemWidth) ? itemWidth : listBox.Width;
						}
					}
					listBox.EndUpdate();
				}
				else
				{
					ResetListBox();
				}
			}
			else
			{
				ResetListBox();
			}
		}
	}
}
