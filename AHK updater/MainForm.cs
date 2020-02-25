using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AHK_updater.Library;
using AHK_updater.Models;
using ScintillaNET;

namespace AHK_updater
{
	public partial class MainForm : Form
	{
		bool test = false;
		ChangeData changeData;
		ErrorTracker errorTracker;
		FileHandler fileHandler;
		FunctionData functionData;
		HotstringData hotstringData;
		MarkedItem markedItem;
		SettingData settingsData;
		Timer updateTimer;
		VariableData variableData;
		WriteData extractionData = null;

		public MainForm()
		{
			markedItem = new MarkedItem();
			fileHandler = new FileHandler(test);
			errorTracker = new ErrorTracker(errorProvider);

			InitializeComponent();
			InitializeData();
			InitializeBindings();
			InitializeEvents();
			SetUpTxtHotstringText();
		}

		/// <summary>
		/// Set form title depending on teststate
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void MainForm_Load(object sender, EventArgs e)
		{
			if (test)
			{
				menuStrip.BackColor = Color.Red;
				Text = "IN TEST MODE";
			}
			PopulateTreeView("");
			tabControl.SelectedIndex = 0;
			lbChanges.SelectedIndex = -1;
			lbFunctions.SelectedIndex = -1;
			lbVariables.SelectedIndex = -1;

			txtHotstringText.AutoCompleteFunctionsList = functionData.GetAutoCompletionNames().ToStringCollection();
			txtHotstringText.AutoCompleteVariablesList = variableData.GetAutoCompletionNames().ToStringCollection();

			EventsOn();
		}

		/// <summary>
		/// Called when form is closing
		/// If anything have been updated, ask user if changes are to be saved
		/// Otherwise, close application
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic FormClosingEventArgs</param>
		void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (functionData.DataUpdated || hotstringData.DataUpdated || variableData.DataUpdated || changeData.DataUpdated || settingsData.DataUpdated)
			{
				DialogResult answer = MessageBox.Show("There are unsaved changes.\r\nDo you want to save?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

				switch (answer)
				{
					case DialogResult.Yes:
						CreateWriteData();
						ClearUpdated();
						Shutdown();
						break;
					case DialogResult.No:
						Shutdown();
						break;
					default:
						e.Cancel = true;
						break;
				}
			}
			else
			{
				Shutdown();
			}
		}

		//////////////////////////////////////////////
		#region OperationalMethods
		//////////////////////////////////////////////

		/// <summary>
		/// Add a hotstring to extractionlist
		/// </summary>
		/// <param name="hotstring">Hotstring to extract</param>
		void AddHotstringForExtraction(Hotstring hotstring)
		{
			if (extractionData == null)
			{
				extractionData = new WriteData();
			}

			if (extractionData.AddItem(hotstring))
			{
				foreach (Variable var in extractionData.GetVariables())
				{
					if (hotstring.Text.Contains("%" + var.Name + "%"))
					{
						extractionData.AddItem(var);
					}
				}
				foreach (Function func in extractionData.GetFunctions())
				{
					if (hotstring.Text.Contains(func.Name + "("))
					{
						extractionData.AddItem(func);
					}
				}
			}
			if (lbHotstringExtractions.DataSource == null)
			{
				InitializeExtractionDataSources();
			}
			RefreshExtractionLists();
		}

		/// <summary>
		/// Set all DataUpdated values to false
		/// </summary>
		void ClearUpdated()
		{
			changeData.DataUpdated = false;
			functionData.DataUpdated = false;
			hotstringData.DataUpdated = false;
			variableData.DataUpdated = false;
		}

		/// <summary>
		/// Create an object holding data to be written to file
		/// </summary>
		/// <returns>Data to be written to file</returns>
		WriteData CreateWriteData()
		{
			return new WriteData(changeData.GetList(),
								functionData.GetList(),
								hotstringData.GetList(),
								variableData.GetList(),
								settingsData.GetList());
		}

		/// <summary>
		/// Turning eventhandlers off
		/// </summary>
		void EventsOff()
		{
			txtChangeText.IgnoreChange = true;
			lbChanges.SelectedValueChanged -= LbChangelogItems_SelectedValueChanged;
			lbFunctions.SelectedValueChanged -= LbFunctions_SelectedValueChanged;
			lbVariables.SelectedValueChanged -= LbVariables_SelectedValueChanged;
			treeHotstrings.AfterSelect -= TreeHotstrings_AfterSelect;
			txtChangeText.TextChanged -= TxtChangeText_TextChanged;
			txtFunctionName.TextChanged -= TxtFunctionName_TextChanged;
			txtFunctionText.TextChanged -= TxtFunctionText_TextChanged;
			txtHotstringMenuTitle.TextChanged -= TxtHotstringMenuTitle_TextChanged;
			txtHotstringName.TextChanged -= TxtHotstringName_TextChanged;
			txtHotstringSystem.TextChanged -= TxtHotstringSystem_TextChanged;
			txtHotstringText.TextChanged -= TxtHotstringText_TextChanged;
			txtScriptOperationsMenuTrigger.TextChanged -= TxtScriptOperationsMenuTrigger_TextChanged;
			txtVariableName.TextChanged -= TxtVariableName_TextChanged;
			txtVariableValue.TextChanged -= TxtVariableValue_TextChanged;
		}

		/// <summary>
		/// Turning eventhandlers on
		/// </summary>
		void EventsOn()
		{
			changeData.UpdatedChange += new ChangeData.UpdatedEventHandler(UpdatedData);
			lbChanges.SelectedValueChanged += LbChangelogItems_SelectedValueChanged;
			txtChangeText.IgnoreChange = false;
			txtChangeText.TextChanged += TxtChangeText_TextChanged;

			lbFunctions.SelectedValueChanged += LbFunctions_SelectedValueChanged;
			lbVariables.SelectedValueChanged += LbVariables_SelectedValueChanged;
			treeHotstrings.AfterSelect += TreeHotstrings_AfterSelect;
			txtFunctionName.TextChanged += TxtFunctionName_TextChanged;
			txtFunctionText.TextChanged += TxtFunctionText_TextChanged;
			txtHotstringMenuTitle.TextChanged += TxtHotstringMenuTitle_TextChanged;
			txtHotstringName.TextChanged += TxtHotstringName_TextChanged;
			txtHotstringSystem.TextChanged += TxtHotstringSystem_TextChanged;
			txtHotstringText.TextChanged += TxtHotstringText_TextChanged;
			txtHotstringText.TextChanged += TxtHotstringText_TextChanged;
			txtScriptOperationsMenuTrigger.TextChanged += TxtScriptOperationsMenuTrigger_TextChanged;
			txtVariableName.TextChanged += TxtVariableName_TextChanged;
			txtVariableValue.TextChanged += TxtVariableValue_TextChanged;

			functionData.UpdatedChange += new FunctionData.UpdatedEventHandler(UpdatedData);
			hotstringData.UpdatedChange += new HotstringData.UpdatedEventHandler(UpdatedData);
			variableData.UpdatedChange += new VariableData.UpdatedEventHandler(UpdatedData);
		}

		/// <summary>
		/// Create databindings for extractionlists
		/// </summary>
		void InitializeExtractionDataSources()
		{
			extractionData.GetHotstrings().CollectionChanged += ExtractedHotstring_CollectionUpdated;
			lbHotstringExtractions.DataSource = extractionData.GetHotstrings();
			lbHotstringExtractions.DisplayMember = "Name";

			extractionData.GetFunctions().CollectionChanged += ExtractedFunction_CollectionUpdated;
			lbFunctionExtractions.DataSource = extractionData.GetFunctions();
			lbFunctionExtractions.DisplayMember = "Name";

			extractionData.GetVariables().CollectionChanged += ExtractedVariable_CollectionUpdated;
			lbVariableExtractions.DataSource = extractionData.GetVariables();
			lbVariableExtractions.DisplayMember = "Name";
		}

		/// <summary>
		/// Set databindings for controls
		/// </summary>
		void InitializeBindings()
		{
			lbChanges.DataSource = changeData.GetList();
			lbChanges.DisplayMember = "Name";

			lbFunctions.DataSource = functionData.GetList();
			lbFunctions.DisplayMember = "Name";

			lbVariables.DataSource = variableData.GetList();
			lbVariables.DisplayMember = "Name";

			txtScriptOperationsMenuTrigger.DataBindings.Add("Text", settingsData.Get("MenuTrigger"), "Text");
			txtSectionTextTitleMenuSection.DataBindings.Add("Text", settingsData.Get("TitleMenuSection"), "Text");
			txtSectionTextTitleMenuTriggersSection.DataBindings.Add("Text", settingsData.Get("TitleMenuTriggersSection"), "Text");
			txtSectionTextTitleVariablesSection.DataBindings.Add("Text", settingsData.Get("TitleVariablesSection"), "Text");
			txtSectionTextTitleFunctionsSection.DataBindings.Add("Text", settingsData.Get("TitleFunctionsSection"), "Text");
			txtSectionTextTitleHotstringsSection.DataBindings.Add("Text", settingsData.Get("TitleHotstringsSection"), "Text");
			txtSectionTextTitleDivider.DataBindings.Add("Text", settingsData.Get("TitleDivider"), "Text");
		}

		/// <summary>
		/// Get data from file and populate Data-objects
		/// </summary>
		void InitializeData()
		{
			fileHandler.Read();
			changeData = fileHandler.GetChangeData();
			functionData = fileHandler.GetFunctionData();
			hotstringData = fileHandler.GetHotstringData();
			settingsData = fileHandler.GetSettingsData();
			variableData = fileHandler.GetVariableData();

			cbEditorToOpenFileWith.DataSource = new Editors().GetEditors();
			cbEditorToOpenFileWith.DisplayMember = "Name";
			cbEditorToOpenFileWith.SelectedIndex = -1;
		}

		/// <summary>
		/// Set events
		/// </summary>
		void InitializeEvents()
		{
			functionData.UpdatedChange += FunctionData_UpdatedChange;
			settingsData.UpdatedChange += SettingsData_UpdatedChange;
			variableData.UpdatedChange += VariableData_UpdatedChange;
			markedItem.DifferentChange += MarkedItem_DifferentChange;
		}

		/// <summary>
		/// Sets all commands in data.commandslist and inserts in treeview
		/// If a system is not present, create a node under root
		/// </summary>
		void PopulateTreeView(string mark)
		{
			treeHotstrings.Nodes.Clear();
			foreach (Hotstring item in hotstringData.GetList())
			{
				if (!item.System.Equals(""))
				{
					if (!treeHotstrings.Nodes.ContainsKey(item.System))
					{
						var treeNode = new TreeNode(item.System) { Name = item.System };
						treeHotstrings.Nodes.Add(treeNode);
					}
					var newNode = new TreeNode(item.Name) { Name = item.Name };
					treeHotstrings.Nodes[item.System].Nodes.Add(newNode);
				}
			}
			txtHotstringSystem.AutoCompleteCustomSource = null;
			txtHotstringSystem.AutoCompleteCustomSource = hotstringData.GetAutoCompletionSystems();
			treeHotstrings.Sort();
			treeHotstrings.SelectedNode = null;
			if (!mark.Equals(""))
			{
				TreeNode[] t = treeHotstrings.Nodes.Find(mark, true);
				treeHotstrings.SelectedNode = t[0];
			}
		}

		/// <summary>
		/// Extractionlists have updated, refresh lists
		/// </summary>
		void RefreshExtractionLists()
		{
			((CurrencyManager)lbHotstringExtractions.BindingContext[extractionData.GetHotstrings()]).Refresh();
			((CurrencyManager)lbFunctionExtractions.BindingContext[extractionData.GetFunctions()]).Refresh();
			((CurrencyManager)lbVariableExtractions.BindingContext[extractionData.GetVariables()]).Refresh();
		}

		/// <summary>
		/// Remove the specified item from data
		/// </summary>
		void RemoveItem()
		{
			DialogResult answer = MessageBox.Show($"Remove { markedItem.DataType } { markedItem.Name } ?", $"Remove { markedItem.DataType }", MessageBoxButtons.YesNo);

			if (answer == DialogResult.Yes)
			{
				switch (markedItem.DataType)
				{
					case "function":
						functionData.Delete(markedItem.Name);
						break;
					case "hotstring":
						hotstringData.Delete(markedItem.Name);
						PopulateTreeView("");
						break;
					case "variable":
						variableData.Delete(markedItem.Name);
						break;
				}
				StatusUpdate($"{ markedItem.DataType.First().ToString().ToUpper() + markedItem.DataType.Substring(1) } { markedItem.Name } have been removed", false);
				markedItem.Clear();
			}
		}

		/// <summary>
		/// Set the markedItem to contain the information of which item in treeview or listbox that is selected
		/// </summary>
		/// <param name="item">Object representing the selected item</param>
		void SetMarkedItem(object item)
		{
			if (item == null)
			{
				switch (tabControl.SelectedIndex)
				{
					case 0:
						gbHotstring.Enabled = false;
						break;
					case 1:
						gbVariable.Enabled = false;
						break;
					case 2:
						gbFunction.Enabled = false;
						break;
					case 3:
						gbChange.Enabled = false;
						break;
				}
				markedItem.Clear();
			}
			else
			{
				switch (item.GetType().Name)
				{
					case "Change":
						markedItem.Set((item as Change).Name, (item as Change).Text, "change");
						gbChange.Enabled = true;
						break;
					case "Function":
						markedItem.Set((item as Function).Name, (item as Function).Text, "function");
						gbFunction.Enabled = true;
						break;
					case "Hotstring":
						markedItem.Set((item as Hotstring).Name, (item as Hotstring).Text, (item as Hotstring).System, "hotstring", (item as Hotstring).MenuTitle);
						gbHotstring.Enabled = true;
						break;
					case "Variable":
						markedItem.Set((item as Variable).Name, (item as Variable).Text, "variable");
						gbVariable.Enabled = true;
						break;
				}
			}
		}

		/// <summary>
		/// Set necessary styling and keywords for lexer
		/// </summary>
		void SetUpTxtHotstringText()
		{
			txtHotstringText.StyleResetDefault();
			txtHotstringText.StyleResetDefault();
			txtHotstringText.Styles[Style.Default].Font = "Consolas";
			txtHotstringText.Styles[Style.Default].Size = 10;
			txtHotstringText.StyleClearAll();
			txtHotstringText.Styles[Style.Cpp.Word].Bold = true;
			txtHotstringText.Styles[Style.Cpp.Word2].Italic = true;
			txtHotstringText.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
			txtHotstringText.SetKeywords(0, functionData.GetNamesString());
			txtHotstringText.SetKeywords(1, variableData.GetNamesString());
		}

		/// <summary>
		/// Closes the application 
		/// </summary>
		void Shutdown()
		{
			Application.Exit();
		}

		/// <summary>
		/// Sets the status label with the newest information 
		/// </summary>
		/// <param name="newStatus">Information of what was done/updated</param>
		/// <param name="addition">If the text is to be added to any previous text</param>
		void StatusUpdate(string newStatus, bool addition)
		{
			if (addition)
				lblStatus.Text += newStatus;
			else
				lblStatus.Text = newStatus;
		}

		/// <summary>
		/// Sets Updated to true/false and making button for Save to file enabled/disabled
		/// </summary>
		/// <param name="updated">If data is to be updated</param>
		void UpdatedData()
		{
			if (changeData.DataUpdated || functionData.DataUpdated || hotstringData.DataUpdated || variableData.DataUpdated)
				btnSaveToFile.Enabled = true;
			else
				btnSaveToFile.Enabled = false;
		}

		/// <summary>
		/// Updates markeditem and inserts changetext.
		/// </summary>
		void UpdateItemInData()
		{
			if (markedItem.System.Equals("change"))
			{
				changeData.Update(markedItem.Name, new Change(txtChangeVersion.Text, txtChangeText.Text));
			}
			else
			{
				NewChange newCommand = new NewChange(markedItem.Name);
				newCommand.ShowDialog(this);

				DialogResult ans = newCommand.DialogResult;
				if (ans == DialogResult.OK || ans == DialogResult.Cancel)
				{
					object temp = "";
					if (!newCommand.GetChangeInfoText().Equals(""))
					{
						changeData.UpdateLatest(newCommand.GetChangeInfoText());
						EventsOff();
						txtChangeText.Text += "\r\n" + newCommand.GetChangeInfoText();
						EventsOn();
					}

					switch (markedItem.DataType)
					{
						case "function":
							temp = new Function(txtFunctionName.Text, txtFunctionText.Text);
							functionData.Update(markedItem.Name, temp);
							SetMarkedItem(temp);
							ActiveControl = txtFunctionText;
							break;
						case "hotstring":
							temp = new Hotstring(txtHotstringName.Text, txtHotstringText.Text, txtHotstringSystem.Text, txtHotstringMenuTitle.Text);
							hotstringData.Update(markedItem.Name, temp);
							SetMarkedItem(temp);
							PopulateTreeView(txtHotstringName.Text);
							ActiveControl = txtHotstringText;
							break;
						case "variable":
							temp = new Variable(txtVariableName.Text, txtVariableValue.Text);
							variableData.Update(markedItem.Name, temp);
							SetMarkedItem(temp);
							ActiveControl = txtVariableValue;
							break;
					}
					StatusUpdate(markedItem.Name + " have been updated.", false);
				}
				else
				{
					StatusUpdate("Update of " + markedItem.Name + " was cancelled.", false);
				}
			}
		}

		/// <summary>
		/// Validate the changed text in a settings textbox
		/// </summary>
		/// <param name="settingTextbox">Textbox for the setting</param>
		/// <param name="settingName">Name of setting</param>
		void ValidateSettingText(TextBox settingTextbox, string settingName)
		{
			if (!settingTextbox.Text.Equals(settingsData.Get(settingName).Text))
			{
				if (settingTextbox.Text.Equals(""))
				{
					settingTextbox.Text = settingsData.Get(settingName).Text;
					errorTracker.SetError(settingTextbox, $"{settingName} can not be empty");
				}
				else
				{
					settingsData.Update(settingName, settingTextbox.Text);
				}
			}
		}

		#endregion

		//////////////////////////////////////////////
		#region EventMethods
		//////////////////////////////////////////////

		/// <summary>
		/// Clear list and listbox of planed extractions 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnCancelExtract_Click(object sender, EventArgs e)
		{
			extractionData.Clear();
			btnExtractToAHK.Enabled = false;
			btnExtractToXML.Enabled = false;
			btnRemoveExtract.Enabled = false;
			btnCancelExtract.Enabled = false;
			RefreshExtractionLists();
			StatusUpdate("All commands have been remove from extraction", false);
		}

		/// <summary>
		/// Ask the user what to name the scriptfile for extracted hotstrings and where to put it 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnExtractToScript_Click(object sender, EventArgs e)
		{
			string file = new FileHandler(test).WriteToFiles(extractionData, 1, chbSaveWithMenu.Checked);
			StatusUpdate("Commands have been extracted to " + file, false);
		}

		/// <summary>
		/// Ask the user what to name the XML-file for extracted hotstrings and where to put it 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnExtractToXML_Click(object sender, EventArgs e)
		{
			string file = new FileHandler(test).WriteToFiles(extractionData, 2, chbSaveWithMenu.Checked);
			StatusUpdate("Command have been extracted to " + file, false);
		}

		/// <summary>
		/// Open the script-file in an external texteditor
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnOpenScript_Click(object sender, EventArgs e)
		{
			string filename = fileHandler.OpenFileInExternalEditor("script", cbEditorToOpenFileWith.SelectedItem.ToString());
		}

		/// <summary>
		/// Open the XML-file in an external texteditor
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnOpenXML_Click(object sender, EventArgs e)
		{
			string filename = fileHandler.OpenFileInExternalEditor("xml", cbEditorToOpenFileWith.SelectedItem.ToString());
		}

		/// <summary>
		/// Remove selected hotstring from list of extractions 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnRemoveExtractedHotstring_Click(object sender, EventArgs e)
		{
			Hotstring extractedHotstringToRemove = lbHotstringExtractions.SelectedItem as Hotstring;
			string statusupdate = extractedHotstringToRemove.Name;

			extractionData.RemoveItem(extractedHotstringToRemove);
			ObservableCollection<Variable> listV = extractionData.GetVariables();
			for (int i = 0; i < listV.Count; i++)
			{
				Variable v = listV[i];
				var searchVariable = extractionData.GetHotstrings().Where(x => x.Text.Contains("%" + v.Name + "%"));
				if (searchVariable.Count() > 0)
				{
					continue;
				}
				else
				{
					extractionData.RemoveItem(v);
				}
			}
			ObservableCollection<Function> listF = extractionData.GetFunctions();
			for (int i = 0; i < listF.Count; i++)
			{
				Function f = listF[i];
				var searchFunction = extractionData.GetHotstrings().Where(x => x.Text.Contains(f.Name));
				if (searchFunction.Count() > 0)
				{
					continue;
				}
				else
				{
					extractionData.RemoveItem(f);
				}
			}
			if (lbHotstringExtractions.Items.Count == 0)
			{
				btnExtractToAHK.Enabled = false;
				btnExtractToXML.Enabled = false;
				statusupdate = "All commands";
			}

			RefreshExtractionLists();
			StatusUpdate(statusupdate + " have been removed from extraction", false);
		}

		/// <summary>
		/// Remove a saved function
		/// Then populate controls from data
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnRemoveFunction_Click(object sender, EventArgs e)
		{
			if (!markedItem.IsEmpty)
			{
				RemoveItem();
			}
		}

		/// <summary>
		/// Called when user clicks menuitem to remove command
		/// Ask user to remove item
		/// Remove item from tree and commandslist, if there are no other items with same system, remove system from root
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnRemoveHotstring_Click(object sender, EventArgs e)
		{
			if (!markedItem.IsEmpty)
			{
				RemoveItem();
			}
		}

		/// <summary>
		/// Remove saved variable
		/// Then populate controls from data
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnRemoveVariable_Click(object sender, EventArgs e)
		{
			if (!markedItem.IsEmpty)
			{
				RemoveItem();
			}
		}

		/// <summary>
		/// Save the data to the script- and XML-file 
		/// </summary>
		/// <param name="sender">Generid sender</param>
		/// <param name="e">Generic Eventargs</param>
		void BtnSaveToFile_Click(object sender, EventArgs e)
		{
			new FileHandler(test).WriteToFiles(CreateWriteData(), 0, chbSaveWithMenu.Checked);
			ClearUpdated();
			MessageBox.Show("Files have been saved.");
		}

		/// <summary>
		/// Update current change
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnUpdateChange_Click(object sender, EventArgs e)
		{
			UpdateItemInData();
		}

		/// <summary>
		/// Update function
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnUpdateFunction_Click(object sender, EventArgs e)
		{
			UpdateItemInData();
		}

		/// <summary>
		/// User wants to update hotstring 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnUpdateHotstring_Click(object sender, EventArgs e)
		{
			UpdateItemInData();
		}

		/// <summary>
		/// A changed variable is to be saved
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnUpdateVariable_Click(object sender, EventArgs e)
		{
			UpdateItemInData();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void CbEditorToOpenFileWith_TextChanged(object sender, EventArgs e)
		{
			if (cbEditorToOpenFileWith.Text == "")
			{
				btnOpenScript.Enabled = btnOpenXML.Enabled = false;
			}
			else if (!new Editors().Contains(cbEditorToOpenFileWith.Text))
			{
				btnOpenScript.Enabled = btnOpenXML.Enabled = false;
			}
			else
			{
				btnOpenScript.Enabled = btnOpenXML.Enabled = true;
			}
		}

		/// <summary>
		/// Contextmenuitem for treeview is clicked, add hotstring/-s to extractionlist.
		/// If the treenode has level 0 (zero), add all hotstrings with that system.
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void ContextItem_Click(object sender, EventArgs e)
		{
			TreeNode node = treeHotstrings.SelectedNode;
			if (node.Level == 0)
			{
				foreach (Hotstring h in hotstringData.GetList().Where(x => x.System.Equals(node.Text)))
				{
					AddHotstringForExtraction(h);
				}
			}
			else
			{
				AddHotstringForExtraction(hotstringData.Get(node.Text));
			}
			btnExtractToAHK.Enabled = true;
			btnExtractToXML.Enabled = true;
		}

		/// <summary>
		/// List of functions to extract have been modified
		/// Show/hide groupbox
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void ExtractedFunction_CollectionUpdated(object sender, EventArgs e)
		{
			gbExtractFunctions.Visible = !extractionData.FunctionsToWriteIsEmpty;
		}

		/// <summary>
		/// List of hotstrings to extract have been modified
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void ExtractedHotstring_CollectionUpdated(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (extractionData.GetHotstrings().Count > 0)
			{
				tabExtraction.Text = $"To extract ({extractionData.GetHotstrings().Count})";
			}
			else
			{
				tabExtraction.Text = "To extract";
			}
		}

		/// <summary>
		/// List of variables to extract have been modified
		/// Show/hide controls and update list
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void ExtractedVariable_CollectionUpdated(object sender, EventArgs e)
		{
			gbExtractVariables.Visible = !extractionData.VariablesToWriteIsEmpty;
		}

		/// <summary>
		/// Functiondata is updated, refresh listbox
		/// </summary>
		void FunctionData_UpdatedChange()
		{
			((CurrencyManager)lbFunctions.BindingContext[functionData.GetList()]).Refresh();
			txtHotstringText.AutoCompleteFunctionsList = functionData.GetAutoCompletionNames().ToStringCollection();
			txtHotstringText.SetKeywords(0, functionData.GetNamesString());
		}

		/// <summary>
		/// When groupbox for hotstring is enabled/disabled, set same value for its buttons
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void GbHotstring_EnabledChanged(object sender, EventArgs e)
		{
			txtHotstringText.ResetListBox();
		}

		/// <summary>
		/// Click occured in listbox
		/// Get corresponding changelogitem and display in txtChangelogText
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void LbChangelogItems_MouseClick(object sender, MouseEventArgs e)
		{
			int index = lbChanges.IndexFromPoint(e.Location);
			if (index == -1)
			{
				lbChanges.ClearSelected();
			}
		}

		/// <summary>
		/// Item in listbox have changed
		/// Search for corresponding changelogentry and populate textboxes
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void LbChangelogItems_SelectedValueChanged(object sender, EventArgs e)
		{
			EventsOff();
			if (lbChanges.SelectedItem != null)
			{
				SetMarkedItem(changeData.Get((lbChanges.SelectedItem as Change).Name));
				gbChange.Enabled = true;
				txtChangeVersion.Text = markedItem.Name;
				txtChangeText.Text = markedItem.Text;
			}
			else
			{
				SetMarkedItem(null);
				txtChangeVersion.Text = "";
				txtChangeVersion.ReadOnly = true;
				txtChangeText.Text = "";
				txtChangeText.ReadOnly = true;
			}
			txtChangeText.ClearHistory();
			EventsOn();
		}

		/// <summary>
		/// List for functions have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void LbFunctions_DataSourceChanged(object sender, EventArgs e)
		{
			((CurrencyManager)lbFunctions.BindingContext[functionData.GetList()]).Refresh();
		}

		/// <summary>
		/// Listbox have been clicked, get item at point of click.
		/// If no item at point, disable groupbox, clear selection and textboxes
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic MouseEventArgs</param>
		void LbFunctions_MouseClick(object sender, MouseEventArgs e)
		{
			int index = lbFunctions.IndexFromPoint(e.Location);
			if (index == -1)
			{
				lbFunctions.ClearSelected();
			}
		}

		/// <summary>
		/// Item in listbox have changed
		/// Get the function and enter information in textboxes
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void LbFunctions_SelectedValueChanged(object sender, EventArgs e)
		{
			EventsOff();
			if (lbFunctions.SelectedItem != null)
			{
				SetMarkedItem(functionData.Get((lbFunctions.SelectedItem as Function).Name));
				gbFunction.Enabled = true;
				txtFunctionName.Text = markedItem.Name;
				txtFunctionText.Text = markedItem.Text;
			}
			else
			{
				SetMarkedItem(null);
				gbFunction.Enabled = false;
				txtFunctionName.Text = "";
				txtFunctionText.Text = "";
			}
			txtFunctionText.ClearHistory();
			EventsOn();
		}

		/// <summary>
		/// DataSource for functionextractions have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void LbFunctionExtractions_DataSourceChanged(object sender, EventArgs e)
		{
			gbExtractFunctions.Visible = !extractionData.FunctionsToWriteIsEmpty;
		}

		/// <summary>
		/// Mouseclick in LbHotstringExtractions was made
		/// Disable buttons for remove and cancel
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic MouseEventArgs</param>
		void LbHotstringExtractions_MouseClick(object sender, MouseEventArgs e)
		{
			int index = lbFunctions.IndexFromPoint(e.Location);
			if (index == -1)
			{
				btnCancelExtract.Enabled = false;
				btnRemoveExtract.Enabled = false;
			}
		}

		/// <summary>
		/// Item selected in LbHotstringExtractions have changed
		/// Enable the buttons for remove and cancel
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void LbHotstringExtractions_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbHotstringExtractions.SelectedItem != null)
			{
				btnRemoveExtract.Enabled = true;
				btnCancelExtract.Enabled = true;
			}
		}

		/// <summary>
		/// The text in the label have changed
		/// Start countdown for clearing the text
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void LblStatus_TextChanged(object sender, EventArgs e)
		{
			updateTimer = new Timer { Interval = 3000 };
			updateTimer.Tick += UpdateTimer_Tick;
			updateTimer.Start();
		}

		/// <summary>
		/// DataSource for variableextractions have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void LbVariableExtractions_DataSourceChanged(object sender, EventArgs e)
		{
			gbExtractVariables.Visible = !extractionData.VariablesToWriteIsEmpty;
		}

		/// <summary>
		/// Listbox have been clicked, get item at point of click.
		/// If no item at point, clear selection
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic MouseEventArgs</param>
		void LbVariables_MouseClick(object sender, MouseEventArgs e)
		{
			int index = lbVariables.IndexFromPoint(e.Location);
			if (index == -1)
			{
				lbVariables.ClearSelected();
			}
		}

		/// <summary>
		/// Selected item have changed.
		/// Get the variable and populate textboxes, or clear if no item was selected.
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void LbVariables_SelectedValueChanged(object sender, EventArgs e)
		{
			EventsOff();
			if (lbVariables.SelectedItem != null)
			{
				SetMarkedItem(variableData.Get((lbVariables.SelectedItem as Variable).Name));
				gbVariable.Enabled = true;
				txtVariableName.Text = markedItem.Name;
				txtVariableValue.Text = markedItem.Text;
			}
			else
			{
				SetMarkedItem(null);
				gbVariable.Enabled = false;
				txtVariableName.Text = "";
				txtVariableValue.Text = "";
			}
			EventsOn();
		}

		/// <summary>
		/// Data have changed, set enable updatebutton according to difference to markeditem
		/// </summary>
		void MarkedItem_DifferentChange()
		{
			switch (tabControl.SelectedIndex)
			{
				case 0:
					btnUpdateHotstring.Enabled = markedItem.DifferentFromOriginal;
					break;
				case 1:
					btnUpdateVariable.Enabled = markedItem.DifferentFromOriginal;
					break;
				case 2:
					btnUpdateFunction.Enabled = markedItem.DifferentFromOriginal;
					break;
			}
		}

		/// <summary>
		/// Close form
		/// </summary>
		/// <param name="sender">Generid sender</param>
		/// <param name="e">Generic Eventargs</param>
		void MenuClose_Click(object sender, EventArgs e)
		{
			Shutdown();
		}

		/// <summary>
		/// Settings have been updated. Enable button to save to file.
		/// </summary>
		void SettingsData_UpdatedChange()
		{
			btnSaveToFile.Enabled = settingsData.DataUpdated;
		}

		void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
		{
			if (markedItem.DifferentFromOriginal)
			{
				DialogResult ans = MessageBox.Show($"Data for {markedItem.Name} have changed, do you want to save?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
				switch (ans)
				{
					case DialogResult.Yes:
						UpdateItemInData();
						break;
					case DialogResult.No:
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
		}

		void TabFunctions_Enter(object sender, EventArgs e)
		{
			if (gbFunction.Enabled)
			{
				SetMarkedItem(functionData.Get((lbFunctions.SelectedItem as Function).Name));
			}
		}

		void TabHotstrings_Enter(object sender, EventArgs e)
		{
			if (gbHotstring.Enabled)
			{
				SetMarkedItem(hotstringData.Get(treeHotstrings.SelectedNode.Text));
			}
		}

		void TabVariables_Enter(object sender, EventArgs e)
		{
			if (gbVariable.Enabled)
			{
				SetMarkedItem(variableData.Get((lbVariables.SelectedItem as Variable).Name));
			}
		}

		/// <summary>
		/// A node in treeHotstrings have been clicked.
		/// If a hotstring, load data to textboxes.
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic TreeViewEventArgs</param>
		void TreeHotstrings_AfterSelect(object sender, TreeViewEventArgs e)
		{
			EventsOff();
			if (e.Node.Level != 0)
			{ // Hotstring have been selected
				SetMarkedItem(hotstringData.Get(e.Node.Text));
				gbHotstring.Enabled = true;
				txtHotstringName.Text = markedItem.Name;
				txtHotstringText.Text = markedItem.Text;
				txtHotstringSystem.Text = markedItem.System;
				txtHotstringMenuTitle.Text = markedItem.MenuTitle;
				ActiveControl = txtHotstringText;
			}
			else
			{ // No item selected, clear controls
				SetMarkedItem(null);
				gbHotstring.Enabled = false;
				txtHotstringText.Text = txtHotstringSystem.Text = txtHotstringName.Text = txtHotstringMenuTitle.Text = "";
			}
			EventsOn();
		}

		void TreeHotstrings_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			if (markedItem.DifferentFromOriginal)
			{
				DialogResult answer = MessageBox.Show($"Changes have been made to '{markedItem.Name}', but not saved.\rDo you want to save before changing hotstring?\r(Cancel to return to editing)", "Unsaved changes", MessageBoxButtons.YesNoCancel);
				switch (answer)
				{
					case DialogResult.Yes:
						UpdateItemInData();
						break;
					case DialogResult.No:
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						ActiveControl = txtHotstringText;
						break;
				}
			}
		}

		/// <summary>
		/// Eventhandler for clicks in treeHotstrings.
		/// Rightclick on a node to open contextmenu for extraction of the hotstring.
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic TreeNodeMouseClick</param>
		void TreeHotstrings_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{

			if (e.Button == MouseButtons.Right)
			{
				contextMenu.Show(treeHotstrings, e.Location);
				treeHotstrings.SelectedNode = e.Node;
			}
			if (e.Node.Level == 0)
			{
				if (!e.Node.IsExpanded)
				{
					treeHotstrings.CollapseAll();
					e.Node.Expand();
					treeHotstrings.SelectedNode = e.Node;
				}
				gbHotstring.Enabled = false;
			}
		}

		/// <summary>
		/// Menuitem for new function is clicked
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TsmiNewFunction_Click(object sender, EventArgs e)
		{
			NewCommand newCommand = new NewCommand("fuction",
													functionData.GetAutoCompletionNames());
			DialogResult dialog = newCommand.ShowDialog(this);
			if (dialog == DialogResult.OK)
			{
				Function newFunc = new Function(newCommand.GetName(),
												$"{ newCommand.GetName() }()\r\n{{\r\n \r\n}}");
				functionData.Add(newFunc);
				SetMarkedItem(newFunc);
				tabControl.SelectedIndex = 2;
				lbFunctions.SetSelected(lbFunctions.FindString(newFunc.Name), true);
				ActiveControl = txtFunctionText;
				txtFunctionText.Select(newCommand.GetName().Length + 7, 1);
			}
		}

		/// <summary>
		/// Menuitem for new hotstring is clicked
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TsmiNewHotstring_Click(object sender, EventArgs e)
		{
			NewCommand newCommand = new NewCommand(hotstringData.GetAutoCompletionNames(),
													hotstringData.GetAutoCompletionSystems());
			DialogResult dialog = newCommand.ShowDialog(this);
			if (dialog == DialogResult.OK)
			{
				hotstringData.Add(new Hotstring(newCommand.GetName(),
									"text=\r\n(\r\n \r\n)\r\nPrintText(text)\r\nReturn",
									newCommand.GetSystem(),
									$"Menuitem for {newCommand.GetName()}"));
				tabControl.SelectedIndex = 0;
				PopulateTreeView(newCommand.GetName());
				ActiveControl = txtHotstringText;
				txtHotstringText.SelectionStart = 11;
			}
		}

		/// <summary>
		/// Menuitem for new variable is clicked
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TsmiNewVariable_Click(object sender, EventArgs e)
		{
			NewCommand newCommand = new NewCommand("variable", variableData.GetAutoCompletionNames());
			DialogResult dialog = newCommand.ShowDialog(this);
			if (dialog == DialogResult.OK)
			{
				Variable newVar = new Variable(newCommand.GetName(), "");
				variableData.Add(newVar);
				SetMarkedItem(newVar);
				tabControl.SelectedIndex = 1;
				lbVariables.SetSelected(lbVariables.FindString(newVar.Name), true);
				ActiveControl = txtVariableValue;
			}
		}

		/// <summary>
		/// Text in textbox for changelog have changed, enable button for saving 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtChangeText_TextChanged(object sender, EventArgs e)
		{
			if (!txtChangeText.Text.Equals(markedItem.Text))
			{
				markedItem.DifferentFromOriginal = true;
			}
		}

		/// <summary>
		/// Name of the function have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtFunctionName_TextChanged(object sender, EventArgs e)
		{
			if (txtFunctionName.Text.Length < 3)
			{
				errorTracker.SetError(txtFunctionName, "Name of function must be longer than 3 characters.");
				btnUpdateFunction.Enabled = false;
			}
			else if (!txtFunctionName.Text.Equals(markedItem.Name))
			{
				errorTracker.SetError(txtFunctionName, "");
				markedItem.DifferentFromOriginal = true;
			}
		}

		/// <summary>
		/// Text for functions have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtFunctionText_TextChanged(object sender, EventArgs e)
		{
			if (!txtFunctionText.Text.Equals(markedItem.Text))
			{
				markedItem.DifferentFromOriginal = true;
			}
		}

		/// <summary>
		/// Text in textbox for HotstringName have changed, enable button for saving 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtHotstringName_TextChanged(object sender, EventArgs e)
		{
			if (txtHotstringName.Text.Length < 3)
			{
				errorTracker.SetError(txtHotstringName, "Name of hotstring must be longer than 3 characters.");
				btnUpdateHotstring.Enabled = false;
			}
			else if (!txtHotstringName.Text.Equals(markedItem.Name))
			{
				errorTracker.SetError(txtHotstringName, "");
				markedItem.DifferentFromOriginal = true;
			}
		}

		/// <summary>
		/// Text in textbox for hotstringsystem have changed, enable button for saving 
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtHotstringSystem_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtHotstringSystem.Text))
			{
				errorTracker.SetError(txtHotstringSystem, "System must be specified");
				btnUpdateHotstring.Enabled = false;
			}
			else if (!txtHotstringSystem.Text.Equals(markedItem.System))
			{
				errorTracker.SetError(txtHotstringSystem, "");
				markedItem.DifferentFromOriginal = true;
			}
		}

		/// <summary>
		/// Text for hotstring is edited
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtHotstringText_TextChanged(object sender, EventArgs e)
		{
			if (!txtHotstringText.Text.Equals(markedItem.Text))
			{
				markedItem.DifferentFromOriginal = true;
			}
		}

		/// <summary>
		/// Text for menutitle have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtHotstringMenuTitle_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtHotstringMenuTitle.Text))
			{
				btnUpdateHotstring.Enabled = false;
				errorTracker.SetError(txtHotstringMenuTitle, "Menutitle can not be empty.");
			}
			else if (txtHotstringMenuTitle.Text.Contains(","))
			{
				btnUpdateHotstring.Enabled = false;
				errorTracker.SetError(txtHotstringMenuTitle, "Menutitle can not contain comma (',')");
			}
			else if (!txtHotstringMenuTitle.Text.Equals(markedItem.MenuTitle))
			{
				errorTracker.SetError(txtHotstringMenuTitle, "");
				markedItem.DifferentFromOriginal = true;
			}
		}

		/// <summary>
		/// Text for MenuTrigger have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtScriptOperationsMenuTrigger_TextChanged(object sender, EventArgs e)
		{
			ValidateSettingText(txtScriptOperationsMenuTrigger, "MenuTrigger");
		}

		/// <summary>
		/// Text for TitleDivider have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtSectionTextTitleDivider_TextChanged(object sender, EventArgs e)
		{
			ValidateSettingText(txtSectionTextTitleDivider, "TitleDivider");
		}

		/// <summary>
		/// Text for TitleFunctionsSection have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtSectionTextTitleFunctionsSection_TextChanged(object sender, EventArgs e)
		{
			ValidateSettingText(txtSectionTextTitleFunctionsSection, "TitleFunctionsSection");
		}

		/// <summary>
		/// Text for TitleHotstringsSection have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtSectionTextTitleHotstringsSection_TextChanged(object sender, EventArgs e)
		{
			ValidateSettingText(txtSectionTextTitleHotstringsSection, "TitleHotstringsSection");
		}

		/// <summary>
		/// Text for TitleMenuSection have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtSectionTextTitleMenuSection_TextChanged(object sender, EventArgs e)
		{
			ValidateSettingText(txtSectionTextTitleMenuSection, "TitleMenuSection");
		}

		/// <summary>
		/// Text for TitleMenuTriggersSection have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtSectionTextTitleMenuTriggersSection_TextChanged(object sender, EventArgs e)
		{
			ValidateSettingText(txtSectionTextTitleMenuTriggersSection, "TitleMenuTriggersSection");
		}

		/// <summary>
		/// Text for TitleVariablesSection have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtSectionTextTitleVariablesSection_TextChanged(object sender, EventArgs e)
		{
			ValidateSettingText(txtSectionTextTitleVariablesSection, "TitleVariablesSection");
		}

		/// <summary>
		/// Text for the variable name have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtVariableName_TextChanged(object sender, EventArgs e)
		{
			if (!txtVariableName.Text.Equals(markedItem.Name))
			{
				errorTracker.SetError(txtVariableName, "");
				markedItem.DifferentFromOriginal = true;
			}
			else if (string.IsNullOrWhiteSpace(txtVariableName.Text))
			{
				btnUpdateVariable.Enabled = false;
				errorTracker.SetError(txtVariableName, "Name of variable can't be empty.");
			}
		}

		/// <summary>
		/// Text for the variable value have changed
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtVariableValue_TextChanged(object sender, EventArgs e)
		{
			if (!txtVariableValue.Text.Equals(markedItem.Text))
			{
				markedItem.DifferentFromOriginal = true;
			}
		}

		/// <summary>
		/// Timer for updateinfo have elapsed. Clear statuslabel
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic ElapsedEventArgs</param>
		void UpdateTimer_Tick(object sender, EventArgs e)
		{
			lblStatus.Text = "";
			updateTimer.Stop();
		}

		/// <summary>
		/// Variabledata is updated, refresh listbox
		/// </summary>
		void VariableData_UpdatedChange()
		{
			((CurrencyManager)lbVariables.BindingContext[variableData.GetList()]).Refresh();
			txtHotstringText.AutoCompleteVariablesList = variableData.GetAutoCompletionNames().ToStringCollection();
			txtHotstringText.SetKeywords(1, variableData.GetNamesString());
		}
		#endregion EventMethods
	}
}
