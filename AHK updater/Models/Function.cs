namespace AHK_updater.Models
{
	/// <summary>
	/// Description of Function.
	/// </summary>
	public class Function : IType
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
	}
}
