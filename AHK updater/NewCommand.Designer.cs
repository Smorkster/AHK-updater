﻿namespace AHK_updater
{
	partial class NewCommand
	{
		private System.ComponentModel.IContainer components = null;
		
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
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSystem = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(342, 9);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "OK";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(342, 38);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(182, 9);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(136, 20);
			this.txtName.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Namn på kommando";
			// 
			// cbType
			// 
			this.cbType.FormattingEnabled = true;
			this.cbType.Items.AddRange(new object[] {
									"Hotstring",
									"Variabel",
									"Funktion"});
			this.cbType.Location = new System.Drawing.Point(182, 35);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(136, 21);
			this.cbType.TabIndex = 5;
			this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 21);
			this.label2.TabIndex = 6;
			this.label2.Text = "Typ av kommando";
			// 
			// txtSystem
			// 
			this.txtSystem.Location = new System.Drawing.Point(182, 62);
			this.txtSystem.Name = "txtSystem";
			this.txtSystem.Size = new System.Drawing.Size(136, 20);
			this.txtSystem.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "System";
			// 
			// NewCommand
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(427, 92);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtSystem);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewCommand";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Command";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewCommand_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSystem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
	}
}
