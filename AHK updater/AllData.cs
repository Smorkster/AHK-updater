using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AHK_updater
{
	public class AllData
	{
		List<AHKCommand> commandslist, variablelist;
		public BindingList<AHKCommand> joinedlist;
		string functions, changelog, username;

		public AllData()
		{
			commandslist = new List<AHKCommand>();
			variablelist = new List<AHKCommand>();
		}
		public string Functions {get{return functions;} set{functions = value;}}
		public string Changelog {get{return changelog;} set{changelog = value;}}
		public string UserName {get{return username;} set{username = value;}}

		/**
		 * Sort list of commands alphabeticaly
		 * */
		void sortCommands()
		{
			commandslist = commandslist.OrderBy(x => x.Command).ToList();
		}

		/**
		 * Sort list of variables alphabeticaly
		 * */
		void sortVariables()
		{
			variablelist = variablelist.OrderBy(x => x.Command).ToList();
		}

		/**
		 * Join lists to one to be used as DataSource for listbox 
		 * */
		public void joinLists()
		{
			sortVariables();
			sortCommands();
			joinedlist = new BindingList<AHKCommand>(variablelist.Concat(commandslist).ToList());
		}

		/**
		 * Update list of commands with new item
		 * */
		public void updateCommands(string command, string text, string type)
		{
			commandslist.Add(new AHKCommand(command, text, type));
			joinLists();
		}

		/**
		 * Update list of variables with new item
		 * */
		public void updateVariables(string command, string text, string type)
		{
			variablelist.Add(new AHKCommand(command, text, type));
			joinLists();
		}

		/**
		 * Used to check if the requested item exists
		 * */
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

		/**
		 * Finds the item and updates its text
		 * */
		public void updateItem(string command, string text)
		{
			for(int i = 0; i < joinedlist.Count; i++)
			{
				if(joinedlist[i].Command.Equals(command))
					joinedlist[i].Text = text;
			}
		}
	}
}
