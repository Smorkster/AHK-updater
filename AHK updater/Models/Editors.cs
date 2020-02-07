using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AHK_updater.Models
{
	public class Editors
	{
		List<FileInfo> editors = new List<FileInfo>
			{
				new FileInfo (@"C:\Program Files (x86)\Notepad++\notepad++.exe"),
				new FileInfo (@"C:\Windows\System32\notepad.exe")
			};

		internal List<FileInfo> GetEditors()
		{
			return editors.Where(x => x.Exists).ToList();
		}

		internal bool Contains(string text)
		{
			return editors.Any(x => x.Name.Equals(text));
		}
	}
}
