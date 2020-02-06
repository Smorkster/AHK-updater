using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AHK_updater.Models
{
	public class WriteData
	{
		ObservableCollection<Change> changesToWrite;
		ObservableCollection<Function> functionsToWrite;
		ObservableCollection<Hotstring> hotstringsToWrite;
		ObservableCollection<Variable> variablesToWrite;
		List<Setting> settings;

		public bool FunctionsToWriteIsEmpty { get { return functionsToWrite.Count == 0; } }
		public bool VariablesToWriteIsEmpty { get { return variablesToWrite.Count == 0; } }

		public WriteData()
		{
			changesToWrite = new ObservableCollection<Change>();
			functionsToWrite = new ObservableCollection<Function>();
			hotstringsToWrite = new ObservableCollection<Hotstring>();
			variablesToWrite = new ObservableCollection<Variable>();
			settings = new List<Setting>();
		}

		public WriteData(ObservableCollection<Change> c,
						ObservableCollection<Function> f,
						ObservableCollection<Hotstring> h,
						ObservableCollection<Variable> v,
						List<Setting> s)
		{
			changesToWrite = c;
			functionsToWrite = f;
			hotstringsToWrite = h;
			variablesToWrite = v;
			settings = s;
		}

		/// <summary>
		/// Add a hotstring to be written to file.
		/// </summary>
		/// <param name="item">Item to be written</param>
		public bool AddItem(object item)
		{
			bool newExtraction = false;
			switch (item.GetType().Name)
			{
				case "Change":
					if (!changesToWrite.Contains((Change)item))
					{
						changesToWrite.Add((Change)item);
						newExtraction = true;
					}
					break;
				case "Function":
					if (!functionsToWrite.Contains((Function)item))
					{
						functionsToWrite.Add((Function)item);
						newExtraction = true;
					}
					break;
				case "Hotstring":
					if (!hotstringsToWrite.Contains((Hotstring) item))
					{
						hotstringsToWrite.Add((Hotstring) item);
						newExtraction = true;
					}
					break;
				case "Variable":
					if (!variablesToWrite.Contains((Variable)item))
					{
						variablesToWrite.Add((Variable)item);
						newExtraction = true;
					}
					break;
			}

			return newExtraction;
		}

		/// <summary>
		/// Clear this lists to cancel writing to file
		/// </summary>
		public void Clear()
		{
			hotstringsToWrite.Clear();
			variablesToWrite.Clear();
			functionsToWrite.Clear();
		}

		/// <summary>
		/// Return list of the functions to write
		/// </summary>
		/// <returns>List of functions</returns>
		public ObservableCollection<Change> GetChanges()
		{
			return changesToWrite;
		}

		/// <summary>
		/// Return list of the functions to write
		/// </summary>
		/// <returns>List of functions</returns>
		public ObservableCollection<Function> GetFunctions()
		{
			return functionsToWrite;
		}

		/// <summary>
		/// Return list of the hotstrings to write
		/// </summary>
		/// <returns>List of hotstrings</returns>
		public ObservableCollection<Hotstring> GetHotstrings()
		{
			return hotstringsToWrite;
		}

		/// <summary>
		/// Return list of the variables to write
		/// </summary>
		/// <returns>List of variables</returns>
		public ObservableCollection<Variable> GetVariables()
		{
			return variablesToWrite;
		}

		/// <summary>
		/// Return current settings
		/// </summary>
		/// <returns>Current settings</returns>
		public List<Setting> GetSettings()
		{
			return settings;
		}

		/// <summary>
		/// Removes the hotstring from extractionlist
		/// </summary>
		/// <param name="removeExtractedHotstring">Hotstring to remove</param>
		public void RemoveItem(object item)
		{
			switch (item.GetType().Name)
			{
				case "Change":
					changesToWrite.Remove((Change)item);
					break;
				case "Function":
					functionsToWrite.Remove((Function)item);
					break;
				case "Hotstring":
					hotstringsToWrite.Remove((Hotstring)item);
					break;
				case "Variable":
					variablesToWrite.Remove((Variable)item);
					break;
			}
		}
	}
}
