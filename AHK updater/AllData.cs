using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AHK_updater
{
	public class AllData
	{
		List<AHKCommand> commandslist, variablelist;
		List<ChangelogEntry> changelog, currentChangelogEntry;
		public BindingList<AHKCommand> joinedlist;
		string functions, username;
		bool updated = false;

		public AllData()
		{
			commandslist = new List<AHKCommand>();
			variablelist = new List<AHKCommand>();
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

		void sortCommands()
		{
			commandslist = commandslist.OrderBy(x => x.Command).ToList();
		}

		void sortVariables()
		{
			variablelist = variablelist.OrderBy(x => x.Command).ToList();
		}

		public void joinLists()
		{
			sortVariables();
			sortCommands();
			joinedlist = new BindingList<AHKCommand>(variablelist.Concat(commandslist).ToList());
		}

		public bool commandExists(string commandName)
		{
			bool exists = false;
			foreach(AHKCommand item in joinedlist)
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

		public void updateCommands(string command, string text, string type, string system)
		{
			commandslist.Add(new AHKCommand(command, text, type, system));
			joinLists();
		}

		public void updateVariables(string command, string text, string type)
		{
			variablelist.Add(new AHKCommand(command, text, type, ""));
			joinLists();
		}

		public void updateCommandItem(string command, string text)
		{
			for (int i = 0; i < joinedlist.Count; i++)
			{
				if(joinedlist[i].Command.Equals(command))
					joinedlist[i].Text = text;
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
