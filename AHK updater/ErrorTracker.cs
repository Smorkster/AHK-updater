using System.Collections.Generic;
using System.Windows.Forms;

namespace AHK_updater
{
	/// <summary>
	/// Keeps track of validationerrors
	/// </summary>
	public class ErrorTracker
	{
		HashSet<Control> mErrors = new HashSet<Control>();
		ErrorProvider mProvider;

		/// <summary>
		/// Create new tracker
		/// </summary>
		/// <param name="provider">Errorprovider to keep track of</param>
		public ErrorTracker(ErrorProvider provider)
		{
			mProvider = provider;
		}

		/// <summary>
		/// Set a new error for specified control
		/// </summary>
		/// <param name="control">Control to attach error to</param>
		/// <param name="text">Errormessage to be set for the control</param>
		public void SetError(Control control, string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				mErrors.Remove(control);
			}
			else if (!mErrors.Contains(control))
			{
				mErrors.Add(control);
			}

			mProvider.SetError(control, text);
			new ToolTip().Show(text, control, 0, 18, 2000);
		}

		/// <summary>
		/// Return number of currently active errors
		/// </summary>
		public int Count { get { return mErrors.Count; } }
	}
}
