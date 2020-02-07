using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using AHK_updater.Models;

namespace AHK_updater
{
	public class FileHandler
	{
		ChangeData changeData;
		FunctionData functionData;
		HotstringData hotstringData;
		VariableData variableData;
		WriteData writeData;
		XmlData xmlData;
		readonly bool test;
		/// <summary>
		/// File for writing changelog
		/// </summary>
		FileInfo changelogFile;
		/// <summary>
		/// File for writing script-file
		/// </summary>
		FileInfo scriptFile;
		/// <summary>
		/// File for writing XML-file
		/// </summary>
		FileInfo xmlFile;

		public FileHandler(bool test)
		{
			this.test = test;
		}

		/// <summary>
		/// Set the names of files to be used depending on if application is in test mode or not
		/// </summary>
		void NameTheFiles()
		{
			if (test)
			{
				changelogFile = new FileInfo(@"H:\Test\AHK Changelog Test.txt");
				scriptFile = new FileInfo(@"H:\Test\Test.ahk");
				xmlFile = new FileInfo(@"H:\Test\Standardsvar Test.xml");
			}
			else
			{
				changelogFile = new FileInfo(@"H:\Dokument\AHK - changelog.txt");
				scriptFile = new FileInfo(@"H:\Dokument\AHK - Standardsvar.ahk");
				xmlFile = new FileInfo(@"H:\Dokument\AHK - Standardsvar.xml");
			}
		}

		/// <summary>
		/// Read data from XML-file
		/// </summary>
		/// <returns></returns>
		public void Read()
		{
			NameTheFiles();
			if (!xmlFile.Exists)
			{
				MessageBox.Show("No file found. Starting without any previous settings.");
				changeData = new ChangeData();
				functionData = new FunctionData();
				hotstringData = new HotstringData();
				variableData = new VariableData();
				return;
			}

			xmlData = new XmlData(XElement.Load(xmlFile.FullName));
		}

		/// <summary>
		/// Calls a texteditor to open specified file 
		/// </summary>
		/// <param name="fileType">Name of file to be opened</param>
		public string OpenFileInExternalEditor(string fileType, string application)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = application
			};
			if (fileType.Equals("script"))
				startInfo.Arguments = scriptFile.FullName;
			else
				startInfo.Arguments = xmlFile.FullName;
			Process.Start(startInfo);
			return "File " + scriptFile.FullName + " has been opened";
		}

		/// <summary>
		/// Return all changedata
		/// </summary>
		/// <returns>Changedata</returns>
		public ChangeData GetChangeData()
		{
			changeData = new ChangeData(xmlData.GetChangelog());
			return changeData;
		}

		/// <summary>
		/// Return all functiondata
		/// </summary>
		/// <returns>Functiondata</returns>
		public FunctionData GetFunctionData()
		{
			functionData = new FunctionData(xmlData.GetFunctions());
			return functionData;
		}

		/// <summary>
		/// Return all hotstringdata
		/// </summary>
		/// <returns>Hotstringdata</returns>
		public HotstringData GetHotstringData()
		{
			hotstringData = new HotstringData(xmlData.GetHotstrings());
			return hotstringData;
		}

		/// <summary>
		/// Return settings from XML
		/// </summary>
		/// <returns>An Settings-object</returns>
		public SettingData GetSettingsData()
		{
			return xmlData.GetSettings();
		}

		/// <summary>
		/// Return all variabledata
		/// </summary>
		/// <returns>Variabledata</returns>
		public VariableData GetVariableData()
		{
			variableData = new VariableData(xmlData.GetVariables());
			return variableData;
		}

		/// <summary>
		/// Write the changelog to a file
		/// </summary>
		void WriteToChangelog()
		{
			StreamWriter writer = new StreamWriter(changelogFile.FullName, false, Encoding.UTF8);

			foreach (Change c in writeData.GetChanges())
			{
				if (!c.Text.Equals(""))
					writer.WriteLine(c.Name + "\r\n**********\r\n" + c.Text + "\r\n");
			}
			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// Write data to XML- and script-files
		/// </summary>
		/// <param name="d">Data to be written</param>
		/// <param name="files">Which files are to be written</param>
		/// <param name="includeMenu">If the scriptfile is to be formated with AHK-menus</param>
		public string WriteToFiles(WriteData d, int files, bool includeMenu)
		{
			writeData = d;
			if (files > 0)
			{
				SaveFileDialog dir = new SaveFileDialog();
				switch (files)
				{
					case 1:
						dir.FileName = "Extracted hotstrings.ahk";
						dir.ShowDialog();
						scriptFile = new FileInfo(dir.FileName);
						break;
					case 2:
						dir.FileName = "Extracted hotstrings.xml";
						dir.ShowDialog();
						xmlFile = new FileInfo(dir.FileName);
						break;
				}
			}
			else
			{
				NameTheFiles();
			}

			if (!scriptFile.FullName.Equals(""))
			{
				WriteScriptFile(includeMenu);
			}

			if (!xmlFile.FullName.Equals(""))
				WriteToXMLFile();

			WriteToChangelog();
			Console.Write(xmlFile.FullName);
			if (files == 1)
				return scriptFile.FullName;
			else if (files == 2)
				return xmlFile.FullName;
			else
				return xmlFile.FullName + " and " + scriptFile.FullName;
		}

		/// <summary>
		/// Collect the data and write to AutoHotKey scriptfile 
		/// </summary>
		void WriteScriptFile(bool includeMenu)
		{
			StreamWriter writer = new StreamWriter(scriptFile.FullName, false, Encoding.Default);

			try
			{
				writer.WriteLine($"; Created at {DateTime.UtcNow.ToShortDateString()}\r\n; {writeData.GetSettings().First(x => x.Name.Equals("TitleDivider"))}\r\n");

				if (includeMenu)
				{
					writer.WriteLine(CreateTitle("TitleMenuSection"));
					writer.WriteLine(CreateAHKMenu());

					writer.WriteLine(CreateTitle("TitleMenuTriggersSection"));
					writer.WriteLine(CreateAHKMenuTriggers());
				}
				else
				{
					writer.WriteLine("SetTimer,UPDATEDSCRIPT,1000");
					writer.WriteLine("UPDATEDSCRIPT:\r\nFileGetAttrib,attribs,%A_ScriptFullPath%\r\nIfInString,attribs,A\r\n{\r\nFileSetAttrib,-A,%A_ScriptFullPath%\r\nSplashTextOn,,,Updated script,\r\nSleep,500\r\nReload\r\n}\r\nReturn\r\n\r\n");

				}

				var listV = writeData.GetVariables().ToList();
				if (listV.Any())
				{
					writer.WriteLine(CreateTitle("TitleVariablesSection"));
					writer.WriteLine(FetchItemsForScript(listV, includeMenu));
					listV = null;
				}

				var listF = writeData.GetFunctions().ToList();
				if (listF.Any())
				{
					writer.WriteLine(CreateTitle("TitleFunctionsSection"));
					writer.WriteLine(FetchItemsForScript(listF, includeMenu));
					listF = null;
				}

				var listH = writeData.GetHotstrings().ToList();
				if (listH.Any())
				{
					writer.WriteLine(CreateTitle("TitleHotstringsSection"));
					writer.WriteLine(FetchItemsForScript(listH, includeMenu));
					listH = null;
				}

				if (includeMenu)
				{
					writer.WriteLine("SetTimer,UPDATEDSCRIPT,1000");
					writer.WriteLine("UPDATEDSCRIPT:\r\nFileGetAttrib,attribs,%A_ScriptFullPath%\r\nIfInString,attribs,A\r\n{\r\nFileSetAttrib,-A,%A_ScriptFullPath%\r\nSplashTextOn,,,Updated script,\r\nSleep,500\r\nReload\r\n}\r\nReturn\r\n\r\n");
				}

				writer.WriteLine("ExitApp");

				writer.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show("Something went wrong when writing script-file.\nError:\n" + e.Message + "\r\n\r\n" + e.TargetSite, "Write error");
			}
		}

		string CreateTitle(string section)
		{
			string title = "";

			title = $"; {writeData.GetSettings().First(x => x.Name.Equals("TitleDivider"))}\r\n{writeData.GetSettings().First(x => x.Name.Equals(section)).Text}\r\n{writeData.GetSettings().First(x => x.Name.Equals("TitleDivider"))}\r\n";

			return title;
		}

		/// <summary>
		/// Creates a string for the AutoHotKey-menutriggers
		/// </summary>
		/// <returns>String for the AutoHotKey-menutriggers</returns>
		string CreateAHKMenuTriggers()
		{
			string menutriggers = "";
			var systems = writeData.GetHotstrings().Select(x => x.System).Distinct();

			foreach (string system in systems)
			{
				menutriggers = menutriggers + $"::{writeData.GetSettings().First(x => x.Name.Equals("MenuTrigger")).Text}{system}::\r\nmenu, {system}Menu, show, %A_CaretX%, %A_CaretY%\r\nReturn\r\n\r\n";
			}
			return menutriggers;
		}

		/// <summary>
		/// Creates a string for the AutoHotKey-menu
		/// </summary>
		/// <returns>String for the AutoHotKey-menu</returns>
		string CreateAHKMenu()
		{
			string menu = "";
			var list = writeData.GetHotstrings().OrderBy(x => x.System).ThenBy(y => y.MenuTitle);
			foreach (Hotstring h in list)
			{
				// How to create menu in AHK:
				// menu, SystemMenu, add, MenuTitle, commandname
				string menuName = $"{ h.System.Replace(" ", "") }Menu";
				menu = menu + $"menu, { menuName }, add, { h.MenuTitle }, { h.Name }\r\n";
			}

			menu = menu + "Return\r\n";

			return menu;
		}

		/// <summary>
		/// Collect the hotstrings and write to XML-file 
		/// </summary>
		void WriteToXMLFile()
		{
			XmlData xmlData = new XmlData(writeData);
			try
			{
				XElement xml = xmlData.CreateXMLDocument();
				xml.Save(xmlFile.FullName);
			}
			catch (Exception exc)
			{
				MessageBox.Show("Something went wrong when writing XML-file.\nError:\n" + exc.Message.ToString(), "Write error");
			}
		}

		/// <summary>
		/// Loops through list of items and returns name and text as scripttext
		/// </summary>
		/// <returns>String with functions formated as AHK-script</returns>
		string FetchItemsForScript(object list, bool withMenu)
		{
			// String for collecting all text
			string scriptData = "";

			if (list.ToString().Contains("Variable"))
			{
				foreach (Variable v in list as List<Variable>)
				{
					scriptData = scriptData + $"{v.Name} = {v.Text}\r\n";
				}
			}
			else if (list.ToString().Contains("Hotstring"))
			{
				foreach (Hotstring h in list as List<Hotstring>)
				{
					if (withMenu)
					{
						scriptData = scriptData + $"::{h.Name}::\r\n{h.Name}:\r\n{h.Text}\r\n\r\n";
					}
					else
					{
						scriptData = scriptData + $"::{h.Name}::\r\n{h.Text}\r\n\r\n";
					}
				}
			}
			else if (list.ToString().Contains("Function"))
			{
				foreach (Function f in list as List<Function>)
				{
					scriptData = scriptData + f.Text + "\r\n";
				}
			}
			return scriptData;
		}
	}
}
