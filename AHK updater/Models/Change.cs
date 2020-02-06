using System;

namespace AHK_updater.Models
{
	/// <summary>
	/// Contains one entry of the changelog 
	/// </summary>
	public class Change : IComparable<Change>, IType
	{
		string name;
		string text;

		public Change() {}

		/// <summary>
		/// Create a ChangelogEntry entry
		/// </summary>
		/// <param name="version">Versionnumber of the entry</param>
		/// <param name="entry">Entrytext</param>
		public Change(string version, string entry)
		{
			this.name = version;
			this.text = entry;
		}

		public string Name { get { return name; } set { name = value; } }
		public string Text { get { return text; } set { text = value; } }

		public int CompareTo(Change item)
		{
			if (name == item.Name)
			{
				return 0; 
			}
			return Name.CompareTo(item.Name);
		}
	}
}
