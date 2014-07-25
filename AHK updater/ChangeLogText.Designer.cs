/*
 * Created by SharpDevelop.
 * User: 6g1w
 * Date: 2014-07-17
 * Time: 10:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AHK_updater
{
	partial class ChangeLogText
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.chlSave = new System.Windows.Forms.Button();
			this.chlCancel = new System.Windows.Forms.Button();
			this.txtChange = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// chlSave
			// 
			this.chlSave.Location = new System.Drawing.Point(360, 12);
			this.chlSave.Name = "chlSave";
			this.chlSave.Size = new System.Drawing.Size(75, 23);
			this.chlSave.TabIndex = 0;
			this.chlSave.Text = "Save";
			this.chlSave.UseVisualStyleBackColor = true;
			this.chlSave.Click += new System.EventHandler(this.ChlSaveClick);
			// 
			// chlCancel
			// 
			this.chlCancel.Location = new System.Drawing.Point(441, 12);
			this.chlCancel.Name = "chlCancel";
			this.chlCancel.Size = new System.Drawing.Size(75, 23);
			this.chlCancel.TabIndex = 1;
			this.chlCancel.Text = "Cancel";
			this.chlCancel.UseVisualStyleBackColor = true;
			this.chlCancel.Click += new System.EventHandler(this.ChlCancelClick);
			// 
			// txtChange
			// 
			this.txtChange.Location = new System.Drawing.Point(12, 12);
			this.txtChange.Name = "txtChange";
			this.txtChange.Size = new System.Drawing.Size(342, 20);
			this.txtChange.TabIndex = 2;
			// 
			// ChangeLogText
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 45);
			this.Controls.Add(this.txtChange);
			this.Controls.Add(this.chlCancel);
			this.Controls.Add(this.chlSave);
			this.Name = "ChangeLogText";
			this.Text = "ChangeLogText";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txtChange;
		private System.Windows.Forms.Button chlCancel;
		private System.Windows.Forms.Button chlSave;
	}
}
