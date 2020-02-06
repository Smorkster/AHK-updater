using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace AHK_updater.Models
{
	/// <summary>
	/// Model containing all data for variables
	/// </summary>
	public class VariableData : IData
	{
		bool updated;
		public delegate void UpdatedEventHandler();
		public event UpdatedEventHandler UpdatedChange;
		ObservableCollection<Variable> variablesList;
		AutoCompleteStringCollection autocompleteNames;

		public VariableData()
		{
			variablesList = new ObservableCollection<Variable>();

		}

		public VariableData(ObservableCollection<Variable> variables)
		{
			variablesList = variables;

		}

		/// <summary>
		/// Add a new variable
		/// </summary>
		/// <param name="newVariable">The variable to be added</param>
		public void Add(object item)
		{
			variablesList.Add((Variable)item);
			DataUpdated = true;
		}

		/// <summary>
		/// Control if data have been updated
		/// </summary>
		public bool DataUpdated
		{
			get { return updated; }
			set { updated = value;
				if (UpdatedChange != null) UpdatedChange(); }
		}

		/// <summary>
		/// Removes a saved variable
		/// </summary>
		/// <param name="variableName">Name of variable to be removed</param>
		public void Delete(string variableName)
		{
			Variable variable = variablesList.Single(x => x.Name.Equals(variableName));
			variablesList.Remove(variable);
			DataUpdated = true;
		}

		/// <summary>
		/// Checks if a variable with specified name exist
		/// </summary>
		/// <param name="name">A name to check</param>
		/// <returns>If a variable exists</returns>
		public bool Exists(string name)
		{
			return variablesList.Any(x => x.Name.Equals(name));
		}

		/// <summary>
		/// Get a saved variable
		/// </summary>
		/// <param name="variableName">Name of variable to return</param>
		/// <returns>Return a variable object</returns>
		public Variable Get(string variableName)
		{
			return variablesList.First(x => x.Name.Equals(variableName));
		}

		/// <summary>
		/// Create and return a AutoCompleteStringCollection
		/// </summary>
		/// <returns>AutoCompleteStringCollection for name of variables</returns>
		public AutoCompleteStringCollection GetAutoCompletionNames()
		{
			if (autocompleteNames == null)
				autocompleteNames = new AutoCompleteStringCollection();
			autocompleteNames.Clear();
			autocompleteNames.AddRange(variablesList.Select(x => x.Name).ToArray());

			return autocompleteNames;
		}

		/// <summary>
		/// Get the variable list
		/// </summary>
		/// <returns>The variable list</returns>
		public ObservableCollection<Variable> GetList()
		{
			return variablesList;
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
				Variable v = variablesList.First(x => x.Name.Equals(old));
				int index = variablesList.IndexOf(v);
				variablesList[index].Name = (item as Variable).Name;
				variablesList[index].Text = (item as Variable).Text;
				DataUpdated = true;
			}
			catch
			{
				variablesList.Add((Variable)item);
			}
		}
	}
}
