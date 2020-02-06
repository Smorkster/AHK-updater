namespace AHK_updater.Models
{
	/// <summary>
	/// Description of Variable.
	/// </summary>
	public class Variable : IType
	{
		string name;
		string text;

		public Variable(string name, string text)
		{
			this.name = name;
			this.text = text;
		}
		public string Name { get { return name; } set { name = value; } }
		public string Text { get { return text; } set { this.text = value; } }
	}
}
