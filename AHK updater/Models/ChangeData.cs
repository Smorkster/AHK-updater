using System;
using System.Collections.ObjectModel;
using System.Linq;
using AHK_updater.Library;

namespace AHK_updater.Models
{
	/// <summary>
	/// Model containing all data for Changelog
	/// </summary>
	public class ChangeData
	{
		bool updated;
		public delegate void UpdatedEventHandler();
		public event UpdatedEventHandler UpdatedChange;
		ObservableCollection<Change> changelog;
		public string TodaysDate;

		public ChangeData() { }
		public ChangeData(ObservableCollection<Change> changes)
		{
			changelog = changes;
			TodaysDate = DateTime.Today.ToString("yyyy-MM-dd");
		}

		/// <summary>
		/// Adds change to changelog 
		/// </summary>
		/// <param name="version">Versionnumber of entry</param>
		/// <param name="entry">Text for changelogentry</param>
		public void Add(object item)
		{
			changelog.Add((Change)item);
			DataUpdated = true;
		}

		/// <summary>
		/// Control if data have been updated
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
		/// Get a change for specific version
		/// </summary>
		/// <param name="changeVersion"></param>
		/// <returns>The reqested change</returns>
		public Change Get(string name)
		{
			return changelog.First(x => x.Name.Equals(name));
		}

		/// <summary>
		/// Return the whole changelog as an listobject
		/// </summary>
		/// <returns>Changelog as a list</returns>
		public ObservableCollection<Change> GetList()
		{
			changelog.Sort(false);
			return changelog;
		}

		/// <summary>
		/// Update an existing hotstring 
		/// </summary>
		/// <param name="old">Name of hotstring to be updated</param>
		/// <param name="item">Updated hotstring</param>
		public void Update(string old, object item)
		{
			try
			{
				Change c = changelog.First(x => x.Name.Equals(old));
				int index = changelog.IndexOf(c);
				changelog[index].Name = (item as Change).Name;
				changelog[index].Text = (item as Change).Text;
			}
			catch
			{
				changelog.Add((Change)item);
			}
			DataUpdated = true;
		}

		/// <summary>
		/// Update the currently active (latest) change
		/// </summary>
		/// <param name="updateInfo">Information about update to change</param>
		public void UpdateLatest(string updateInfo)
		{
			if (!changelog.Any(x => x.Name.Equals(TodaysDate)))
			{
				Add(new Change(TodaysDate, ""));
			}
			Change change = changelog.First(x => x.Name.Equals(TodaysDate));
			change.Text += "\r\n" + updateInfo;
			DataUpdated = true;
		}
	}
}
