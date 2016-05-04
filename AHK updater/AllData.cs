﻿/**
 * This property contains all data needed for operating the commands, functions and changelog
 * Data is stored as in lists respectively
 * The list commandslist is made public to make it easy to access
 * */

using System;
using System.Collections.Generic;
using System.Linq;

namespace AHK_updater
{
	public class AllData
	{
		public List<AHKCommand> commandslist;
		List<ChangelogEntry> changelog, currentChangelogEntry;
		string functions, username;
		bool updated = false;

		/**
		 * Initiate the lists
		 * */
		public AllData()
		{
			commandslist = new List<AHKCommand>();
			changelog = new List<ChangelogEntry>();
			currentChangelogEntry = new List<ChangelogEntry>();
		}
		public string Functions { get { return functions; } set { functions = value; } }
		public string UserName { get { return username; } set { username = value; } }
		public bool Updated { get { return updated; } set { updated = value; } }
		public string CurrentChangelogItem { get { return currentChangelogEntry[0].Entry; } }

		/**
		 * Checks if a command exists with same name
		 * 
		 * commandName: Name of command to be checked
		 * */
		public bool commandExists(string commandName)
		{
			foreach (AHKCommand item in commandslist) {
				if (item.Name.Equals(commandName))
					return true;
			}
			return false;
		}

		/**
		 * Save new command to list of commands
		 * 
		 * command: Name of command
		 * text: Text for command
		 * system: System specifying type of command
		 * */
		public void addCommand(string command, string text, string system)
		{
			commandslist.Add(new AHKCommand(command, text, system));
		}

		/**
		 * Update an existing command with new text
		 * 
		 * command: Name of command to be updated
		 * text: Text of command to be updated
		 * */
		public void updateItemCommand(string command, string name, string text, string system)
		{
			int commandIndex = commandslist.FindIndex(x => x.Name.Equals(command));

			commandslist[commandIndex].Name = name;
			commandslist[commandIndex].Text = text;
			commandslist[commandIndex].System = system;
		}

		/**
		 * Deletes command from commandslist
		 * 
		 * command: Name of command to be deleted
		 * */
		public void deleteItem(string command)
		{
			AHKCommand item = commandslist.Single(r => r.Name.Equals(command));
			commandslist.Remove(item);
		}

		/**
		 * Format text of changelogentry to be written to changelog textbox
		 * 
		 * Return as string
		 * */
		public string getChangelogText()
		{
			string changelogText = "";
			for (int i = changelog.Count - 1; i >= 0; i--) {
				changelogText = changelogText + changelog[i].Version + "\r\n------------\r\n" + changelog[i].Entry + "\r\n";
			}
			return changelogText;
		}

		/**
		 * Format changelogentry as XML
		 * If there have been no change made this time, use latest entry,
		 * set indexnumber to one to skip this while parsing through all entries
		 * 
		 * Return as string
		 * */
		public string getChangelogXML()
		{
			string text = "";

			if (!currentChangelogEntry[0].Entry.Equals("")) {
				text = "<ahkcommand><version>" + currentChangelogEntry[0].Version + "</version><entry>" + currentChangelogEntry[0].Entry + "</entry></ahkcommand>\r\n";
			}

			for (int i = 0; i < changelog.Count; i++)
				text = text + "<ahkcommand><version>" + changelog[i].Version + "</version><entry>" + changelog[i].Entry + "</entry></ahkcommand>\r\n";
			return text;
		}

		/**
		 * Adds old changelogentries to changelog
		 * 
		 * version: Versionnumber of entry
		 * entry: Text for changelogentry
		 * */
		public void updateChangelog(string version, string entry)
		{
			changelog.Add(new ChangelogEntry(version, entry));
		}

		/**
		 * Save latest changelogentry to changelog
		 * Checks if entry is empty, otherwise add as new row/-s
		 * 
		 * entry: Text for changelogentry
		 * */
		public void updateCurrentChangelogItem(string entry, bool save)
		{
			if (currentChangelogEntry[0].Entry.Equals(""))
				currentChangelogEntry[0].Entry = entry;
			else if (save)
				currentChangelogEntry[0].Entry = entry;
			else
				currentChangelogEntry[0].Entry = currentChangelogEntry[0].Entry + "\r\n" + entry;
		}

		/**
		 * Create a changelog entry for changes made this time
		 * Entries are named for the current date
		 * 
		 * Return entry as string
		 * */
		public string initiateChangelog()
		{
			DateTime currentDate = DateTime.Today;

			if (changelog[0].Version.Equals(currentDate.ToString("yyyy-MM-dd"))) {
				currentChangelogEntry.Add(new ChangelogEntry(changelog[0].Version, changelog[0].Entry));
			} else {
				currentChangelogEntry.Add(new ChangelogEntry(currentDate.ToString("yyyy-MM-dd"), ""));
			}
			return currentChangelogEntry[0].Entry;
		}
	}
}
