using System;
using System.Windows.Forms;

namespace AHK_updater
{
	public partial class NewCommand : Form
	{
		ErrorTracker tracker;

		public NewCommand(AutoCompleteStringCollection names,
							AutoCompleteStringCollection systems)
		{
			InitializeComponent();
			txtName.AutoCompleteCustomSource = names;
			lblSystem.Visible = txtHotstringSystem.Visible = true;
			txtHotstringSystem.AutoCompleteCustomSource = systems;
			lblMenuTitle.Visible = txtHotstringMenuTitle.Visible = true;
			Text = $"{Text} hotstring";
			Initialize();
		}

		public NewCommand(string type, AutoCompleteStringCollection names)
		{
			InitializeComponent();
			txtName.AutoCompleteCustomSource = names;
			Text = $"{Text} {type}";
			Initialize();
		}

		void Initialize()
		{
			tracker = new ErrorTracker(errorProvider);
			ActiveControl = txtName;
			DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Return name of command
		/// </summary>
		/// <returns>Name of the new command</returns>
		public string GetName()
		{
			return txtName.Text;
		}

		/// <summary>
		/// Return system
		/// </summary>
		/// <returns>System of the new command</returns>
		public string GetSystem()
		{
			return txtHotstringSystem.Text;
		}

		/// <summary>
		/// Return menutitle
		/// </summary>
		/// <returns>System of the new command</returns>
		public string GetMenuTitle()
		{
			return txtHotstringMenuTitle.Text;
		}

		/// <summary>
		/// Validate that the textboxes have correct strings
		/// </summary>
		void ValidateCommand()
		{
			if (tracker.Count == 0 && ValidName() && ValidSystem() && ValidMenuTitle())
			{
				btnCreate.Enabled = true;
			}
			else
			{
				btnCreate.Enabled = false;
			}
		}

		bool ValidMenuTitle()
		{
			if (!txtHotstringMenuTitle.Visible)
			{ return true; }
			else if (txtHotstringMenuTitle.Text.Length > 0)
			{ return true; }

			return false;
		}

		bool ValidSystem()
		{
			if (!txtHotstringSystem.Visible)
			{ return true; }
			else if (txtHotstringSystem.Text.Length > 0)
			{ return true; }

			return false;
		}

		bool ValidName()
		{
			if (txtName.Text.Length > 0)
			{ return true; }

			return false;
		}

		/// <summary>
		/// Cancel creation of new command
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Close form to create command
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void BtnCreate_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// Text have changed, verify if it is correct
		/// If incorrect, disable button to create command
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtHotstringMenuTitle_TextChanged(object sender, EventArgs e)
		{
			if (txtHotstringMenuTitle.Text.Length < 1)
			{
				btnCreate.Enabled = false;
				tracker.SetError(txtHotstringMenuTitle, "Menutitle can not be empty");
			}
			else
			{
				tracker.SetError(txtHotstringMenuTitle, "");
				ValidateCommand();
			}
		}

		/// <summary>
		/// Text have changed, verify if it is correct
		/// If incorrect, disable button to create command
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtHotstringSystem_TextChanged(object sender, EventArgs e)
		{
			if (txtHotstringSystem.Text.Length < 1)
			{
				btnCreate.Enabled = false;
				tracker.SetError(txtHotstringSystem, "System can not be empty");
			}
			else
			{
				tracker.SetError(txtHotstringSystem, "");
				ValidateCommand();
			}
		}

		/// <summary>
		/// Disable button for create if no name is given
		/// </summary>
		/// <param name="sender">Generic object</param>
		/// <param name="e">Generic EventArgs</param>
		void TxtName_TextChanged(object sender, EventArgs e)
		{
			if (txtName.Text.Length < 1)
			{
				btnCreate.Enabled = false;
				tracker.SetError(txtName, "Name can not be empty");
			}
			else if (txtName.AutoCompleteCustomSource.Contains(txtName.Text))
			{
				btnCreate.Enabled = false;
				tracker.SetError(txtName, "Name already exists");
			}
			else
			{
				tracker.SetError(txtName, "");
				ValidateCommand();
			}
		}
	}
}
