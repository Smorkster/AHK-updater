using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AHK_updater.Library
{
	public class MyScintilla : ScintillaNET.Scintilla
	{
		[DllImport("user32.dll")]
		static extern bool GetCaretPos(out Point lpPoint);
		ListBox lbAutoComplete;
		string[] autoCompleteFunctionsList;
		string[] autoCompleteVariablesList;
		string[] separators = { "|", "[", "]", "\r", " ", "\t", "(", ")", ";", ",", "/", ".", "!", "?", "\"", "\\" };
		string formerValue = string.Empty;
		int prevBreak;
		int nextBreak;
		int wordLength;
		public int CaretIndex => SelectionStart;

		public MyScintilla()
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
			set
			{
				autoCompleteFunctionsList = null;
				autoCompleteFunctionsList = value;
			}
		}

		/// <summary>
		/// Get/set the autocompletelist of variables for the textbox
		/// </summary>
		public string[] AutoCompleteVariablesList
		{
			get { return autoCompleteVariablesList; }
			set
			{
				autoCompleteVariablesList = null;
				autoCompleteVariablesList = value;
			}
		}

		/// <summary>
		/// Styling for listbox-items
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic DrawItemEventArgs</param>
		void AutoComplete_DrawItem(object sender, DrawItemEventArgs e)
		{
			// Get and check index of title for variable segment
			int varTitleIndex = lbAutoComplete.Items.IndexOf(":- Variables -:");
			varTitleIndex = varTitleIndex == -1 ? lbAutoComplete.Items.Count : varTitleIndex;

			e.DrawBackground();
			// Segmenttitles will not have background for selectedindex
			if (e.Index == lbAutoComplete.SelectedIndex &&
				lbAutoComplete.SelectedItem.ToString().StartsWith(":-"))
			{
				e.Graphics.DrawString(lbAutoComplete.Items[e.Index].ToString(),
					new Font(e.Font, FontStyle.Regular), Brushes.Black, e.Bounds, StringFormat.GenericDefault);
				e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
			}
			// Segmenttitles are drawn as normal
			if (e.Index == 0 || e.Index == varTitleIndex)
			{
				e.Graphics.DrawString(lbAutoComplete.Items[e.Index].ToString(),
					new Font(e.Font, FontStyle.Regular), Brushes.Black, e.Bounds, StringFormat.GenericDefault);
			}
			// Functions are styled bold
			else if (e.Index < varTitleIndex)
			{
				e.Graphics.DrawString(lbAutoComplete.Items[e.Index].ToString(),
					new Font(e.Font, FontStyle.Bold), Brushes.Black, e.Bounds, StringFormat.GenericDefault);
			}
			// Variables are styled italic and blue
			else if (e.Index > varTitleIndex)
			{
				e.Graphics.DrawString(lbAutoComplete.Items[e.Index].ToString(),
					new Font(e.Font, FontStyle.Italic), Brushes.Blue, e.Bounds, StringFormat.GenericDefault);
			}
			e.DrawFocusRectangle();
		}

		/// <summary>
		/// Get the word in the text (between the closest space-characters).
		/// </summary>
		/// <returns>Word around/closest to the caret</returns>
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
		/// Create the listbox for autocomplete and set eventhandlers.
		/// </summary>
		void InitializeComponent()
		{
			lbAutoComplete = new ListBox
			{
				DrawMode = DrawMode.OwnerDrawFixed
			};
			lbAutoComplete.DrawItem += AutoComplete_DrawItem;
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
					if (lbAutoComplete.Visible)
						return true;
					else
						return false;
				default:
					return base.IsInputKey(keyData);
			}
		}

		/// <summary>
		/// The listbox is no longer needed, hide it.
		/// </summary>
		public void ResetListBox()
		{
			lbAutoComplete.Visible = false;
		}

		/// <summary>
		/// Set a location for the listbox and display it.
		/// </summary>
		void ShowListBox()
		{
			Form parentForm = FindForm();
			if (parentForm == null) return;

			parentForm.Controls.Add(lbAutoComplete);
			GetCaretPos(out Point caretPosition);
			Point textboxPosition = FindForm().PointToClient(Parent.PointToScreen(Location));
			lbAutoComplete.Left = textboxPosition.X + caretPosition.X;
			lbAutoComplete.Top = textboxPosition.Y + caretPosition.Y + 15;

			lbAutoComplete.Visible = true;
			lbAutoComplete.BringToFront();
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
						if (lbAutoComplete.Visible)
						{
							if (lbAutoComplete.SelectedItem.ToString().Contains(":-"))
							{
								e.Handled = true;
							}
							else
							{
								Text = Text.Remove(prevBreak == 0 ? 0 : prevBreak + 1, prevBreak == 0 ? wordLength + 1 : wordLength);
								Text = Text.Insert(prevBreak == 0 ? 0 : prevBreak + 1, lbAutoComplete.SelectedItem.ToString());
								ResetListBox();
								formerValue = Text;
								SelectionStart = SelectionStart + lbAutoComplete.SelectedItem.ToString().Length;
								e.Handled = true;
							}
						}
						return;
					}
				case Keys.Down:
					{
						if (lbAutoComplete.Visible && (lbAutoComplete.SelectedIndex < lbAutoComplete.Items.Count - 1))
						{
							lbAutoComplete.SelectedIndex++;
							e.Handled = true;
						}
						return;
					}
				case Keys.Up:
					{
						if (lbAutoComplete.Visible && (lbAutoComplete.SelectedIndex > 0))
						{
							lbAutoComplete.SelectedIndex--;
							e.Handled = true;
						}
						return;
					}
				case Keys.Escape:
					{
						lbAutoComplete.Visible = false;
						e.Handled = true;
						return;
					}
				case Keys.Back:
					string t = Text.Substring(SelectionStart - 1, 1);
					if (t.Equals(" ") || Regex.Match(t, @"\W").Value.Equals(""))
					{
						lbAutoComplete.Visible = false;
					}
					return;
			}
			// Shortcuts
			if (e.KeyData == (Keys.Back | Keys.Control))
			{
				e.SuppressKeyPress = true;
				string text = "";
				foreach (string separator in separators)
				{
					// (\))?\W*$ not word
					// (\w)?\w*$ word
					Match m = Regex.Match(Text, $@"(\{separator})?\W*$");
					if (!m.Value.Equals(""))
					{
						text = Regex.Replace(Text.Substring(0, SelectionStart), $@"(\{separator})?\W?$", "");
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
			lbAutoComplete.Visible = false;
		}

		/// <summary>
		/// Update the autocomplete listbox with items and size
		/// </summary>
		void UpdateListBox()
		{
			if (Text == formerValue) return;
			if (Text.Length == 0)
			{
				lbAutoComplete.Visible = false;
				return;
			}

			formerValue = Text;
			prevBreak = Text.LastIndexOfAny(separators.StrArrayToCharArray(), CaretIndex > 0 ? CaretIndex - 1 : 0);
			if (prevBreak < 1) prevBreak = 0;
			nextBreak = Text.IndexOfAny(separators.StrArrayToCharArray(), prevBreak + 1);
			if (nextBreak == -1) nextBreak = CaretIndex;
			wordLength = nextBreak - prevBreak - 1;
			if (wordLength < 1) return;

			string word = Text.Substring(prevBreak + 1, wordLength).Trim();

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
					lbAutoComplete.BeginUpdate();
					lbAutoComplete.Items.Clear();
					lbAutoComplete.Items.AddRange(matches.ToArray());
					lbAutoComplete.SelectedIndex = 0;
					lbAutoComplete.Height = 0;
					lbAutoComplete.Width = 0;
					Focus();
					using (Graphics graphics = lbAutoComplete.CreateGraphics())
					{
						for (int i = 0; i < lbAutoComplete.Items.Count; i++)
						{
							if (i < 20)
								lbAutoComplete.Height += lbAutoComplete.GetItemHeight(i);
							string trr = ((string)lbAutoComplete.Items[i]) + "_";
							int itemWidth = (int)graphics.MeasureString(trr, lbAutoComplete.Font).Width;
							lbAutoComplete.Width = (lbAutoComplete.Width < itemWidth) ? itemWidth : lbAutoComplete.Width;
						}
					}
					lbAutoComplete.EndUpdate();
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
