using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace AHK_updater.Models
{
	/// <summary>
	/// Model containing all data for hotstrings
	/// </summary>
	public class HotstringData : IData
	{
		AutoCompleteStringCollection autocompleteNames;
		AutoCompleteStringCollection autocompleteSystems;
		bool updated;
		public delegate void UpdatedEventHandler();
		public event UpdatedEventHandler UpdatedChange;
		ObservableCollection<Hotstring> hotstringsList;

		/// <summary>
		/// Initiate the lists 
		/// </summary>
		public HotstringData()
		{
			hotstringsList = new ObservableCollection<Hotstring>();
			autocompleteNames = new AutoCompleteStringCollection();
			autocompleteSystems = new AutoCompleteStringCollection();
		}

		/// <summary>
		/// Initiate the lists 
		/// </summary>
		public HotstringData(ObservableCollection<Hotstring> hotstrings)
		{
			hotstringsList = hotstrings;
			autocompleteNames = new AutoCompleteStringCollection();
			autocompleteSystems = new AutoCompleteStringCollection();
		}

		/// <summary>
		/// Save new hotstring
		/// </summary>
		/// <param name="name">Name of hotstring</param>
		/// <param name="text">Text of hotstring</param>
		/// <param name="system">System specifying type of hotstring</param>
		//public void Add(string name, string text, string system, string menuTitle)
		public void Add(object item)
		{
			hotstringsList.Add((Hotstring)item);
			DataUpdated = true;
		}

		/// <summary>
		/// Check and set if hotstringdata have been updated
		/// </summary>
		public bool DataUpdated
		{
			get { return updated; }
			set { updated = value;
				if (UpdatedChange != null) UpdatedChange(); }
		}

		/// <summary>
		/// Deletes hotstring from list
		/// If there are no more item with this system, clear it from autocompletionlist
		/// </summary>
		/// <param name="name">Name of hotstring to be deleted</param>
		public void Delete(string name)
		{
			Hotstring item = hotstringsList.Single(r => r.Name.Equals(name));
			hotstringsList.Remove(item);
			if (hotstringsList.Count(x => x.System.Equals(item.System)) == 0)
				autocompleteSystems.Remove(item.System);
			DataUpdated = true;
		}

		/// <summary>
		/// Checks if a command exists with same name 
		/// </summary>
		/// <param name="commandName">Name of command to be checked</param>
		/// <returns>True if another hotstring with same name exists</returns>
		public bool Exists(string commandName)
		{
			foreach (Hotstring item in hotstringsList)
			{
				if (item.Name.Equals(commandName))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Look up hotstring by name
		/// </summary>
		/// <param name="name">Name of hotstring to be searched</param>
		/// <returns>Hotstring being looked for</returns>
		public Hotstring Get(string name)
		{
			return hotstringsList.Single(r => r.Name.Equals(name));
		}

		/// <summary>
		/// Returns a autocompletionlist for hotstrings names
		/// </summary>
		/// <returns>Autocompletionlist</returns>
		public AutoCompleteStringCollection GetAutoCompletionNames()
		{
			autocompleteNames.AddRange(hotstringsList.Select(x => x.Name).ToArray());

			return autocompleteNames;
		}

		/// <summary>
		/// Returns a autocompletionlist for hotstrings systems
		/// </summary>
		/// <returns>Autocompletionlist</returns>
		public AutoCompleteStringCollection GetAutoCompletionSystems()
		{
			autocompleteSystems.AddRange(hotstringsList.Select(x => x.System).ToArray());

			return autocompleteSystems;
		}

		/// <summary>
		/// Get all hotstrings
		/// </summary>
		/// <returns>List of saved hotstrings</returns>
		public ObservableCollection<Hotstring> GetList()
		{
			return hotstringsList;
		}

		/// <summary>
		/// Update an existing hotstring 
		/// </summary>
		/// <param name="old">Name of hotstring to be updated</param>
		/// <param name="item">Updated hotstring</param>
		public void Update(string old, object item)
		{
			try
			{
				Hotstring h = hotstringsList.First(x => x.Name.Equals(old));
				int index = hotstringsList.IndexOf(h);
				hotstringsList[index].Name = (item as Hotstring).Name;
				hotstringsList[index].Text = (item as Hotstring).Text;
				hotstringsList[index].System = (item as Hotstring).System;
				hotstringsList[index].MenuTitle = (item as Hotstring).MenuTitle;
				DataUpdated = true;
			}
			catch
			{
				hotstringsList.Add((Hotstring)item);
			}
		}
	}
}
