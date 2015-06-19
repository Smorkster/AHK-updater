namespace AHK_updater
{
	partial class UserName
	{
		// Designer variable used to keep track of non-visual components.
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
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.lblUserNameInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(326, 37);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(10, 40);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(310, 20);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
			// 
			// lblUserNameInfo
			// 
			this.lblUserNameInfo.Location = new System.Drawing.Point(12, 5);
			this.lblUserNameInfo.Name = "lblUserNameInfo";
			this.lblUserNameInfo.Size = new System.Drawing.Size(389, 32);
			this.lblUserNameInfo.TabIndex = 2;
			// 
			// UserName
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 72);
			this.Controls.Add(this.lblUserNameInfo);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.btnSave);
			this.Name = "UserName";
			this.Text = "Give a name as user";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		System.Windows.Forms.Label lblUserNameInfo;
		System.Windows.Forms.TextBox txtUserName;
		System.Windows.Forms.Button btnSave;
	}
}
