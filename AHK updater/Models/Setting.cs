namespace AHK_updater.Models
{
	public class Setting : IType
	{
		string name;
		string text;
		string defaultValue;

		public Setting(string name, string text, string defaultValue)
		{
			this.name = name;
			this.text = text;
			this.defaultValue = defaultValue;
		}

		public string Name { get { return name; } set { name = value; } }
		public string Text { get { return text; } set { text = value; } }
		public string DefaultValue { get { return defaultValue; } }
	}
}
