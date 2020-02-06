using System;
using System.ComponentModel;

namespace AHK_updater.Models
{
	public class MarkedItem
	{
		/// Name, Value, System, Type, MenuTitle
		string name;
		string text;
		string system;
		string type;
		string menutitle;
		bool differentFromOriginal = false;
		public delegate void UpdatedEventHandler();
		public event UpdatedEventHandler DifferentChange;

		public MarkedItem() { }

		public string Name { get => name; set => name = value; }
		public string Text { get => text; set => this.text = value; }
		public string System { get => system; set => system = value; }
		public string DataType { get => type; set => type = value; }
		public string MenuTitle { get => menutitle; set => menutitle = value; }
		public bool IsEmpty { get { return name.Equals(""); } }

		/// <summary>
		/// Control if data have been updated
		/// </summary>
		public bool DifferentFromOriginal
	{
			get { return differentFromOriginal; }
			set
			{
				differentFromOriginal = value;
				if (DifferentChange != null) DifferentChange();
			}
		}

		/// <summary>
		/// Clear object
		/// </summary>
		internal void Clear()
		{
			name = text = system = type = menutitle = "";
			DifferentFromOriginal = false;
		}

		/// <summary>
		/// Sets the parameters for the object
		/// </summary>
		/// <param name="name">Name of object</param>
		/// <param name="text">Text of object</param>
		/// <param name="system">System of object</param>
		/// <param name="type">Type of object</param>
		/// <param name="menutitle">Menutitle of object</param>
		internal void Set(string name, string text, string system, string type, string menutitle)
		{
			this.name = name;
			this.text = text;
			this.system = system;
			this.type = type;
			this.menutitle = menutitle;
			DifferentFromOriginal = false;
		}

		/// <summary>
		/// Sets the parameters for the object
		/// </summary>
		/// <param name="name">Name of object</param>
		/// <param name="text">Text of object</param>
		/// <param name="type">Type of object</param>
		internal void Set(string name, string text, string type)
		{
			this.name = name;
			this.text = text;
			this.type = type;
			system = "";
			menutitle = "";
			DifferentFromOriginal = false;
		}
	}
}
