using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace AHK_updater.Library
{
	public static class Extensions
	{
		/// <summary>
		/// Sort a collection of Change-objects
		/// </summary>
		/// <param name="c">Collection in extension to sort</param>
		public static void Sort<Change>(this ObservableCollection<Change> c, bool ascending)
		{
			List<Change> sorted;
			if (ascending)
				sorted = c.OrderBy(x => x).ToList();
			else
				sorted = c.OrderByDescending(x => x).ToList();
			for (int i = 0; i < sorted.Count(); i++)
			{
				c.Move(c.IndexOf(sorted[i]), i);
			}
		}

		/// <summary>
		/// Convert stringarray to AutoCompleteStringCollection
		/// </summary>
		/// <param name="names">Stringarray in extension to convert</param>
		/// <returns>Converted collection</returns>
		public static AutoCompleteStringCollection ToAutoCompleteStringCollection(this string[] names)
		{
			AutoCompleteStringCollection autocompletenames = new AutoCompleteStringCollection();
			foreach (string name in names) { autocompletenames.Add(name); }
			return autocompletenames;
		}

		/// <summary>
		/// Convert AutoCompleteStringCollection to stringarray
		/// </summary>
		/// <param name="names">Collection in extention to convert</param>
		/// <returns>Converted stringarray</returns>
		public static string[] ToStringCollection(this AutoCompleteStringCollection names)
		{
			string[] nameArray = new string[names.Count];
			for (int i = 0; i < names.Count; i++) { nameArray[i] = names[i]; }
			return nameArray;
		}

		/// <summary>
		/// Convert a stringarray to chararray
		/// </summary>
		/// <param name="s">Stringarray in extension to convert</param>
		/// <returns>Converted chararray</returns>
		public static char[] StrArrayToCharArray(this string[] s)
		{
			char[] c = new char[s.Length];
			for(int i = 0; i<s.Length;i++)
			{
				c[i] = Char.Parse(s[i]);
			}
			return c;
		}
	}
}
