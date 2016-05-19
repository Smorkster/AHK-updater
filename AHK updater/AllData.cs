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
		public List<AHKCommand> hotstringsList;
		public List<Function> functionsList;
		List<ChangelogEntry> changelogList;
		public ChangelogEntry currentChangelogEntry;
		string functions, username;
		bool updated = false;

		/// <summary>
		/// Initiate the lists 
		/// </summary>
		public AllData()
		{
			hotstringsList = new List<AHKCommand>();
			functionsList = new List<Function>();
			changelogList = new List<ChangelogEntry>();
			currentChangelogEntry = new ChangelogEntry();
		}
		public string Functions { get { return functions; } set { functions = value; } }
		public string UserName { get { return username; } set { username = value; } }
		public bool Updated { get { return updated; } set { updated = value; } }

		/// <summary>
		/// Checks if a command exists with same name 
		/// </summary>
		/// <param name="commandName">Name of command to be checked</param>
		/// <returns>True if another hotstring with same name exists</returns>
		public bool hotstringExists(string commandName)
		{
			foreach (AHKCommand item in hotstringsList) {
				if (item.Name.Equals(commandName))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Save new command to list of commands 
		/// </summary>
		/// <param name="command">Name of command</param>
		/// <param name="text">Text of command</param>
		/// <param name="system">System specifying type of command</param>
		public void addHotstring(string command, string text, string system)
		{
			hotstringsList.Add(new AHKCommand(command, text, system));
		}

		/// <summary>
		/// Update an existing hotstring 
		/// </summary>
		/// <param name="command">Name of hotstring to be updated</param>
		/// <param name="name">Possible new name of hotstring</param>
		/// <param name="text">Text of hotstring to be updated</param>
		/// <param name="system">System of hotstring to be updated</param>
		public void updateHotstring(string command, string name, string text, string system)
		{
			int hotstringIndex = hotstringsList.FindIndex(x => x.Name.Equals(command));

			hotstringsList[hotstringIndex].Name = name;
			hotstringsList[hotstringIndex].Text = text;
			hotstringsList[hotstringIndex].System = system;
		}

		/// <summary>
		/// Deletes hotstring 
		/// </summary>
		/// <param name="command">Name of hotstring to be deleted</param>
		public void deleteHotstring(string command)
		{
			AHKCommand item = hotstringsList.Single(r => r.Name.Equals(command));
			hotstringsList.Remove(item);
		}

		/// <summary>
		/// Look up hotstring by name
		/// </summary>
		/// <param name="hotstringName">Name of hotstring to be searched</param>
		/// <returns>Hotstring being looked for</returns>
		public AHKCommand getHotstring(string hotstringName)
		{
			return hotstringsList.Single(r => r.Name.Equals(hotstringName));
		}

		public void addFunction(string fname, string ftext)
		{
			functionsList.Add(new Function(fname, ftext));
		}
		public void updateFunction(string oldname, string fname, string ftext)
		{
			int functionIndex = functionsList.FindIndex(x => x.Name.Equals(oldname));
			
			functionsList[functionIndex].Name = fname;
			functionsList[functionIndex].Text = ftext;
		}
		public void deleteFunction(string fname)
		{
			Function item = functionsList.Single(x => x.Name.Equals(fname));
			functionsList.Remove(item);
		}
		public Function getFunction(string fname)
		{
			return functionsList.Single(x=>x.Name.Equals(fname));
		}
		public bool functionExists(string fname)
		{
			foreach(Function item in functionsList)
				if (item.Name.Equals(fname))
					return true;
			return false;
		}

		/// <summary>
		/// Format text of changelogentry to be written to changelog textbox 
		/// </summary>
		/// <returns>Return text as string</returns>
		public string getChangelogText()
		{
			string changelogText = "";
			for (int i = changelogList.Count - 1; i >= 0; i--) {
				changelogText = changelogText + changelogList[i].Version + "\r\n------------\r\n" + changelogList[i].Entry + "\r\n";
			}
			return changelogText;
		}

		/// <summary>
		/// Format changelogentry as XML
		/// If there have been no change made this time, use latest entry,
		/// set indexnumber to one to skip this while parsing through all entries
		/// </summary>
		/// <returns>Return text as string</returns>
		public string getChangelogXML()
		{
			string text = "";

			if (!currentChangelogEntry.Entry.Equals("")) {
				text = "<ahkcommand><version>" + currentChangelogEntry.Version + "</version><entry>" + currentChangelogEntry.Entry + "</entry></ahkcommand>\r\n";
			}

			for (int i = 0; i < changelogList.Count; i++)
				text = text + "<ahkcommand><version>" + changelogList[i].Version + "</version><entry>" + changelogList[i].Entry + "</entry></ahkcommand>\r\n";

			return text;
		}

		/// <summary>
		/// Adds previous changelogentries to changelog 
		/// </summary>
		/// <param name="version">Versionnumber of entry</param>
		/// <param name="entry">Text for changelogentry</param>
		public void updateChangelog(string version, string entry)
		{
			changelogList.Add(new ChangelogEntry(version, entry));
		}

		/// <summary>
		/// Save latest changelogentry to changelog
		/// Checks if entry is empty, otherwise add as new row/-s
		/// </summary>
		/// <param name="entry">Text of changelogentry</param>
		/// <param name="save"></param>
		public void updateCurrentChangelogItem(string entry, bool save)
		{
			if (currentChangelogEntry.Entry.Equals(""))
				currentChangelogEntry.Entry = entry;
			else if (save)
				currentChangelogEntry.Entry = entry;
			else
				currentChangelogEntry.Entry = currentChangelogEntry.Entry + "\r\n" + entry;
		}

		/// <summary>
		/// Create a changelog entry for changes made this time
		/// Entries are named for the current date 
		/// </summary>
		public void initiateChangelog()
		{
			DateTime currentDate = DateTime.Today;
			string temp=currentDate.ToString("yyyy-MM-dd");

			if (changelogList[0].Version.Equals(temp))
				currentChangelogEntry = new ChangelogEntry(changelogList[0].Version, changelogList[0].Entry);
			else
				currentChangelogEntry = new ChangelogEntry(currentDate.ToString("yyyy-MM-dd"), "");
		}
		
		public ChangelogEntry getChangelogEntry(string version)
		{
			return changelogList.Find(x => x.Version.Equals(version));
		}
	}
}
