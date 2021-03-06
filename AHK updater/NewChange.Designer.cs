﻿namespace AHK_updater
{
	partial class NewChange
	{
		System.ComponentModel.IContainer components = null;

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

		void InitializeComponent()
		{
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancelChange = new System.Windows.Forms.Button();
			this.txtChange = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnNoChangeText = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(236, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// btnCancelChange
			// 
			this.btnCancelChange.AutoSize = true;
			this.btnCancelChange.Location = new System.Drawing.Point(427, 12);
			this.btnCancelChange.Name = "btnCancelChange";
			this.btnCancelChange.Size = new System.Drawing.Size(89, 23);
			this.btnCancelChange.TabIndex = 2;
			this.btnCancelChange.Text = "Cancel change";
			this.btnCancelChange.UseVisualStyleBackColor = true;
			this.btnCancelChange.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// txtChange
			// 
			this.txtChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtChange.Location = new System.Drawing.Point(12, 44);
			this.txtChange.Name = "txtChange";
			this.txtChange.Size = new System.Drawing.Size(504, 20);
			this.txtChange.TabIndex = 3;
			this.txtChange.Enter += new System.EventHandler(this.TxtChange_Enter);
			this.txtChange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtChange_KeyPress);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(197, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "What type of change have you made?";
			// 
			// btnNoChangeText
			// 
			this.btnNoChangeText.AutoSize = true;
			this.btnNoChangeText.Location = new System.Drawing.Point(317, 12);
			this.btnNoChangeText.Name = "btnNoChangeText";
			this.btnNoChangeText.Size = new System.Drawing.Size(104, 23);
			this.btnNoChangeText.TabIndex = 1;
			this.btnNoChangeText.Text = "No changelog text";
			this.btnNoChangeText.UseVisualStyleBackColor = true;
			this.btnNoChangeText.Click += new System.EventHandler(this.BtnNoChangeText_Click);
			// 
			// ChangeLogText
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 76);
			this.Controls.Add(this.btnNoChangeText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtChange);
			this.Controls.Add(this.btnCancelChange);
			this.Controls.Add(this.btnSave);
			this.Name = "ChangeLogText";
			this.Text = "Change to changelog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		System.Windows.Forms.Label label1;
		System.Windows.Forms.TextBox txtChange;
		System.Windows.Forms.Button btnCancelChange;
		System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnNoChangeText;
	}
}
