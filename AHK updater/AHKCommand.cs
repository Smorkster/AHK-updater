/**
 * Contains one AutoHotKey-command with name, text and system
 * Also contains functions for returning command formated for script- and XML-file
 * */

namespace AHK_updater
{
	public class AHKCommand
	{
		string name;
		string text;
		string system;

		/// <summary>
		/// Create a AHKCommand object
		/// </summary>
		/// <param name="name">Name of the command</param>
		/// <param name="text">Codetext of the command</param>
		/// <param name="system">System for the command</param>
		public AHKCommand(string name, string text, string system)
		{
			this.name = name;
			this.text = text;
			this.system = system;
		}
		
		/// <summary>
		/// Create a AHKCommand object from a AHKCommand
		/// </summary>
		/// <param name="hotstring">Created hotstring to be copied</param>
		public AHKCommand(AHKCommand hotstring)
		{
			this.name = hotstring.name;
			this.text = hotstring.text;
			this.system = hotstring.System;
		}

		public string Name { get { return name; } set { name = value; } }
		public string Text { get { return text; } set { text = value; } }
		public string System { get { return system; } set { system = value; } }

		/// <summary>
		/// Return property as XML-node 
		/// </summary>
		/// <returns>String with AHKCommand formated as XML</returns>
		public string getXmlString()
		{
			return string.Format("<ahkcommand><command>{0}</command><text>{1}</text><system>{2}</system></ahkcommand>", name, text, system);
		}

		/// <summary>
		/// Return property as AutoHotKey-scriptcommand 
		/// </summary>
		/// <returns>String with AHKCommand formated as script</returns>
		public string getScriptString()
		{
			string v = "";

			if (system.Equals("Variables"))
				v = name + " = " + text.Trim();
			else
				v = "::" + name + "::\r\n" + text.Trim();
			return v + "\r\n";
		}
	}
}