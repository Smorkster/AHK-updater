using System.Windows.Forms;

namespace AHK_updater.Models
{
	/// <summary>
	/// Interface for declaring Data-object
	/// </summary>
	public interface IData
	{
		AutoCompleteStringCollection GetAutoCompletionNames();
		void Add(object item);
		/// <summary>
		/// Delete the named item
		/// </summary>
		/// <param name="name">Name of item to delete</param>
		void Delete(string name);
		bool Exists(string name);
		void Update(string old, object item);
	}
}
