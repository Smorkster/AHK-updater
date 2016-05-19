using System;

namespace AHK_updater
{
	/// <summary>
	/// Description of Function.
	/// </summary>
	public class Function
	{
		string name;
		string text;

		/// <summary>
		/// Create Function object
		/// </summary>
		/// <param name="name">Name of function</param>
		/// <param name="text">Codetext of function</param>
		public Function(string name, string text)
		{
			this.name = name;
			this.text = text;
		}

		public string Name { get {return name;} set {name = value;} }
		public string Text { get {return text;} set {text = value;} }

		/// <summary>
		/// Return property as XML-node 
		/// </summary>
		/// <returns>String with AHKCommand formated as XML</returns>
		public string getXmlString()
		{
			return string.Format("<ahkcommand><functionname>{0}</functionname><functiontext>{1}</functiontext></ahkcommand>", name, text);
		}

		/// <summary>
		/// Return property as AutoHotKey-scriptcommand 
		/// </summary>
		/// <returns>String with AHKCommand formated as script</returns>
		public string getScriptString()
		{
			return text;
		}
	}
}
