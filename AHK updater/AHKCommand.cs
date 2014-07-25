namespace AHK_updater
{
	public class AHKCommand
	{
		string command;
		string text;
		string type;
		
		public AHKCommand(string c, string te, string ty)
		{
			this.command = c;
			this.text = te;
			this.type = ty;
		}

		public string Command {get{return command;}}

		public string Text {get{return text;} set{text = value;}}

		public string Type {get{return type;}}

		/**
		 * Return property as XML-node
		 * */
		public string XMLString()
		{
			return string.Format("<ahkcommand><command>{0}</command><text>{1}</text><type>{2}</type></ahkcommand>", command, text, type);
		}

		/**
		 * Return property as AutoHotKey hotstring-command
		 * */
		public string AHKString()
		{
			string v="";
			if (type.Equals("Variabel"))
				v = command + " = " + text;
			else if (type.Equals("Hotstring"))
				v = "::" + this.command + "::\r\n" + this.text.Trim();
			return v+"\r\n";
		}
	}
}
