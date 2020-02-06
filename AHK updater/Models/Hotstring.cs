using System;

namespace AHK_updater.Models
{
	/// <summary>
	/// Contains one AutoHotKey-command with name, text and system
	/// Also contains functions for returning command formated for script- and XML-file
	/// </summary>
	public class Hotstring : IType
	{
		string name;
		string text;
		string system;
		string menuTitle;

		/// <summary>
		/// Create a AHKCommand object
		/// </summary>
		/// <param name="name">Name of the command</param>
		/// <param name="text">Codetext of the command</param>
		/// <param name="system">System for the command</param>
		public Hotstring(string name, string text, string system, string menuTitle)
		{
			this.name = name;
			this.text = text;
			this.system = system;
			this.menuTitle = menuTitle;
		}
		
		/// <summary>
		/// Create a AHKCommand object from a AHKCommand
		/// </summary>
		/// <param name="hotstring">Created hotstring to be copied</param>
		public Hotstring(Hotstring hotstring)
		{
			this.name = hotstring.name;
			this.text = hotstring.text;
			this.system = hotstring.System;
			this.menuTitle = hotstring.menuTitle;
		}

		public string Name { get { return name; } set { name = value; } }
		public string Text { get { return text; } set { text = value; } }
		public string System { get { return system; } set { system = value; } }
		public string MenuTitle { get { return menuTitle; } set { menuTitle = value; } }
	}
}