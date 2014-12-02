
namespace AHK_updater
{
	partial class NewName
	{
		private System.ComponentModel.IContainer components = null;
		
		// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNewName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(269, 32);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(73, 25);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(348, 33);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "New name of command";
			// 
			// txtNewName
			// 
			this.txtNewName.Location = new System.Drawing.Point(12, 35);
			this.txtNewName.Name = "txtNewName";
			this.txtNewName.Size = new System.Drawing.Size(251, 20);
			this.txtNewName.TabIndex = 3;
			// 
			// NewName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(435, 68);
			this.Controls.Add(this.txtNewName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Name = "NewName";
			this.Text = "New name";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewName_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txtNewName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
	}
}
