using System.Collections.Generic;

namespace AHK_updater.Models
{
	public class SettingData
	{
		bool updated;
		public delegate void UpdatedEventHandler();
		public event UpdatedEventHandler UpdatedChange;
		List<Setting> settings;

		public SettingData()
		{
			settings = new List<Setting>();
		}

		public SettingData(List<Setting> s)
		{
			settings = s;
		}

		/// <summary>
		/// Add setting
		/// </summary>
		/// <param name="setting">Setting to be added</param>
		public void Add(Setting setting)
		{
			settings.Add(setting);
		}

		/// <summary>
		/// Check and set if settings have been updated
		/// </summary>
		public bool DataUpdated
		{
			get { return updated; }
			set
			{
				updated = value;
				if (UpdatedChange != null) UpdatedChange();
			}
		}

		/// <summary>
		/// Get the setting with the given name
		/// </summary>
		/// <param name="name">Name of setting</param>
		/// <returns>Named setting</returns>
		public Setting Get(string name)
		{
			return settings.Find(x => x.Name.Equals(name));
		}

		/// <summary>
		/// Get the list of settings
		/// </summary>
		/// <returns>Current settings</returns>
		public List<Setting> GetList()
		{
			return settings;
		}

		/// <summary>
		/// Update a setting
		/// </summary>
		/// <param name="settingName">Name of setting to update</param>
		/// <param name="newText">New setting value</param>
		public void Update(string settingName, string newText)
		{
			int i = settings.FindIndex(x => x.Name.Equals(settingName));
			settings[i].Text = newText;
			DataUpdated = true;
		}
	}
}
