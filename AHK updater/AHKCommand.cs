namespace AHK_updater
{
	public class AHKCommand
	{
		string command;
		string text;
		string system;

		public AHKCommand(string c, string te, string sys)
		{
			this.command = c;
			this.text = te;
			this.system = sys;
		}
		public AHKCommand(AHKCommand c)
		{
			this.command = c.command;
			this.text = c.text;
			this.system = c.System;
		}

		public string Command {get{return command;}}
		public string Text {get{return text;} set{text = value;}}
		public string System {get{return system;}}

		/**
		 * Return property as XML-node
		 * */
		public string getXmlString()
		{
			return string.Format("<ahkcommand><command>{0}</command><text>{1}</text><system>{2}</system></ahkcommand>", command, text, system);
		}

		/**
		 * Return property as AutoHotKey hotstring-command
		 * */
		public string getScriptString()
		{
			string v = "";

			if (system.Equals("Variable"))
				v = command + " = " + text;
			else
				v = "::" + this.command + "::\r\n" + this.text.Trim();
			return v + "\r\n";
		}
	}
}