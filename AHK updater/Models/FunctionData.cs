using AHK_updater.Library;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace AHK_updater.Models
{
	/// <summary>
	/// Model containing all data for functions
	/// </summary>
	public class FunctionData : IData
	{
		bool updated;
		public delegate void UpdatedEventHandler();
		public event UpdatedEventHandler UpdatedChange;
		ObservableCollection<Function> functionsList;
		AutoCompleteStringCollection autocompleteNames;

		public FunctionData()
		{
			functionsList = new ObservableCollection<Function>();

		}

		public FunctionData(ObservableCollection<Function> functions)
		{
			functionsList = functions;

		}

		/// <summary>
		/// Adds a new function
		/// </summary>
		/// <param name="fname">Name of the new function</param>
		/// <param name="ftext">AHK-code for the function</param>
		public void Add(object item)
		{
			functionsList.Add((Function)item);
			DataUpdated = true;
		}

		/// <summary>
		/// Control if data have been updated
		/// </summary>
		public bool DataUpdated
		{
			get { return updated; }
			set
			{
				updated = value;
				if (UpdatedChange != null) UpdatedChange();
			}
		}

		/// <summary>
		/// Deletes a function from the list
		/// </summary>
		/// <param name="name">Name of function to be removed</param>
		public void Delete(string name)
		{
			Function item = functionsList.Single(x => x.Name.Equals(name));
			functionsList.Remove(item);
			DataUpdated = true;
		}

		/// <summary>
		/// Checks if there is already a function existing with given name
		/// </summary>
		/// <param name="name">Name of eventual new function to check with</param>
		/// <returns>True if there is a function existing with given name. Otherwise false</returns>
		public bool Exists(string name)
		{
			foreach (Function item in functionsList)
				if (item.Name.Equals(name))
					return true;
			return false;
		}

		/// <summary>
		/// Get a function-object based on its name
		/// </summary>
		/// <param name="name">Name of function to search for</param>
		/// <returns>A function-object related to the name given on calling</returns>
		public Function Get(string name)
		{
			return functionsList.Single(x => x.Name.Equals(name));
		}

		/// <summary>
		/// Returns all saved functions as a list
		/// </summary>
		/// <returns>Functions as a list</returns>
		public ObservableCollection<Function> GetList()
		{
			return functionsList;
		}

		/// <summary>
		/// Create a AutoCompleteStringCollection for functionnames
		/// </summary>
		/// <returns>AutoCompleteStringCollection for names</returns>
		public AutoCompleteStringCollection GetAutoCompletionNames()
		{
			if (autocompleteNames == null)
				autocompleteNames = new AutoCompleteStringCollection();

			autocompleteNames = functionsList.Select(x => x.Name).ToArray().ToAutoCompleteStringCollection();

			return autocompleteNames;
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
				Function h = functionsList.First(x => x.Name.Equals(old));
				int index = functionsList.IndexOf(h);
				functionsList[index].Name = (item as Function).Name;
				functionsList[index].Text = (item as Function).Text;
			}
			catch
			{
				functionsList.Add((Function)item);
			}
			DataUpdated = true;
		}
	}
}
