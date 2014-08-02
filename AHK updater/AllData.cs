using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AHK_updater
{
	public class AllData
	{
		public List<AHKCommand> commandslist;
		List<ChangelogEntry> changelog, currentChangelogEntry;
		string functions, username;
		bool updated = false;

		public AllData()
		{
			commandslist = new List<AHKCommand>();
			changelog = new List<ChangelogEntry>();
			currentChangelogEntry = new List<ChangelogEntry>();
		}
		public string Functions {get{return functions;} set{functions = value;}}
		public string UserName {get{return username;} set{username = value;}}
		public bool Updated {get{return updated;} set{updated = value;}}
		public string CurrentChangelogItem {get{return currentChangelogEntry[0].Entry;}}

		public string initiateChangelog()
		{
			DateTime changelogToday = DateTime.Today;

			if (changelog[0].Version.Equals(changelogToday.ToString("yyyy-MM-dd")))
			{
				currentChangelogEntry.Add(new ChangelogEntry(changelog[0].Version, changelog[0].Entry));
			}
			else
			{
				currentChangelogEntry.Add(new ChangelogEntry(changelogToday.ToString("yyyy-MM-dd"),""));
			}
			return currentChangelogEntry[0].Entry;
		}

		public bool commandExists(string commandName)
		{
			bool exists = false;
			foreach(AHKCommand item in commandslist)
			{
				if(item.Command.ToString().Equals(commandName))
					exists = true;
			}
			return exists;
		}

		public void updateChangelog(string version, string entry)
		{
			changelog.Add(new ChangelogEntry(version, entry));
		}

		public void updateCurrentChangelogItem(string entry)
		{
			string v = currentChangelogEntry[0].Entry;
			if (currentChangelogEntry[0].Entry.Equals(""))
				currentChangelogEntry[0].Entry = entry;
			else
				currentChangelogEntry[0].Entry = currentChangelogEntry[0].Entry + "\r\n" + entry;
		}

		public void addCommand(string command, string text, string system)
		{
			commandslist.Add(new AHKCommand(command, text, system));
		}

		public void updateCommandItem(string command, string text)
		{
			for (int i = 0; i < commandslist.Count; i++)
			{
				if(commandslist[i].Command.Equals(command))
					commandslist[i].Text = text;
			}
			updated = true;
		}

		public string getChangelogText()
		{
			string changelogText = "";
			for (int i = changelog.Count - 1; i >= 0; i--)
			{
				changelogText = changelogText + changelog[i].Version + "\r\n------------\r\n" + changelog[i].Entry + "\r\n";
			}
			return changelogText;
		}

		public string getChangelogXML()
		{
			string text = "";
			if (!currentChangelogEntry[0].Entry.Equals(""))
			{
				text = "<ahkcommand><version>" + currentChangelogEntry[0].Version + "</version><entry>" + currentChangelogEntry[0].Entry + "</entry></ahkcommand>\r\n";
			}
			foreach (ChangelogEntry item in changelog)
			{
				text = text + "<ahkcommand><version>" + item.Version + "</version><entry>" + item.Entry + "</entry></ahkcommand>\r\n";
			}
			return text;
		}
	}
}
