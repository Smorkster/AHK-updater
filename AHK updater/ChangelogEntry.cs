namespace AHK_updater
{
	/// <summary>
	/// Contains one entry of the changelog 
	/// </summary>
	public class ChangelogEntry
	{
		readonly string version;
		string entry;

		public ChangelogEntry() {}
		/// <summary>
		/// Create a ChangelogEntry entry
		/// </summary>
		/// <param name="version">Versionnumber of the entry</param>
		/// <param name="entry">Entrytext</param>
		public ChangelogEntry(string version, string entry)
		{
			this.version = version;
			this.entry = entry;
		}

		public string Version { get { return version; } }
		public string Entry { get { return entry; } set { entry = value; } }

		/// <summary>
		/// Return the entry as an XML-coded string 
		/// </summary>
		/// <returns>String of changelogentry formated as XML</returns>
		public string getXMLEntry()
		{
			return "<ahkcommand><version>" + version + "</version><entry>" + entry + "</entry></ahkcommand>\r\n";
		}
	}
}
