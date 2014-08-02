namespace AHK_updater
{
	public class AHKCommand
	{
		string command;
		string text;
		string type;
		string system;

		public AHKCommand(string c, string te, string ty, string sys)
		{
			this.command = c;
			this.text = te;
			this.type = ty;
			this.system = sys;
		}

		public string Command {get{return command;}}
		public string Text {get{return text;} set{text = value;}}
		public string Type {get{return type;}}
		public string System {get{return system;}}

		/**
		 * Return property as XML-node
		 * */
		public string getXmlString()
		{
			return string.Format("<ahkcommand><command>{0}</command><text>{1}</text><type>{2}</type><system>{3}</system></ahkcommand>", command, text, type, system);
		}

		/**
		 * Return property as AutoHotKey hotstring-command
		 * */
		public string getScriptString()
		{
			string v = "";

			if (type.Equals("Variable"))
				v = command + " = " + text;
			else if (type.Equals("Hotstring"))
				v = "::" + this.command + "::\r\n" + this.text.Trim();
			return v + "\r\n";
		}
	}
}