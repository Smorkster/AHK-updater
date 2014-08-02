namespace AHK_updater
{
	partial class UserName
	{
		// Designer variable used to keep track of non-visual components.
		private System.ComponentModel.IContainer components = null;

		// Disposes resources used by the form.
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

		// This method is required for Windows Forms designer support.
		// Do not change the method contents inside the source code editor. The Forms designer might
		// not be able to load this method if it was changed manually.
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.lblUserNameInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(328, 28);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox1
			// 
			this.txtUserName.Location = new System.Drawing.Point(12, 31);
			this.txtUserName.Name = "textBox1";
			this.txtUserName.Size = new System.Drawing.Size(310, 20);
			this.txtUserName.TabIndex = 1;
			// 
			// label1
			// 
			this.lblUserNameInfo.Location = new System.Drawing.Point(12, 5);
			this.lblUserNameInfo.Name = "label1";
			this.lblUserNameInfo.Size = new System.Drawing.Size(389, 23);
			this.lblUserNameInfo.TabIndex = 2;
			// 
			// UserName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 63);
			this.Controls.Add(this.lblUserNameInfo);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.button1);
			this.Name = "UserName";
			this.Text = "Ange namn för signatur";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lblUserNameInfo;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Button button1;
	}
}
