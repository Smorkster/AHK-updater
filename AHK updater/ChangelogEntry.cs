﻿namespace AHK_updater
{
	public class ChangelogEntry
	{
		string version;
		string entry;

		public ChangelogEntry(string v, string e)
		{
			this.version = v;
			this.entry = e;
		}

		public string Version {get{return version;}}
		public string Entry {get{return entry;} set{entry = value;}}
		
		public string getXMLEntry()
		{
			return "<ahkcommand><version>" + version + "</version><entry>" + entry + "</entry></ahkcommand>\r\n";
		}
	}
}