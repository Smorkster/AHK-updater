namespace AHK_updater
{
	partial class NewCommand
	{
		System.ComponentModel.IContainer components = null;
		
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
			this.btnCreate = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSystem = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCreate
			// 
			this.btnCreate.Enabled = false;
			this.btnCreate.Location = new System.Drawing.Point(342, 9);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(342, 38);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
			this.label1.Text = "Name of command";
			// 
			// cbType
			// 
			this.cbType.FormattingEnabled = true;
			this.cbType.Items.AddRange(new object[] {
			"Hotstring",
			"Variable",
			"Function"});
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
			this.label2.Text = "Type of command";
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
			this.Controls.Add(this.btnCreate);
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
		System.Windows.Forms.Label label3;
		System.Windows.Forms.TextBox txtSystem;
		System.Windows.Forms.Label label2;
		System.Windows.Forms.ComboBox cbType;
		System.Windows.Forms.Label label1;
		System.Windows.Forms.TextBox txtName;
		System.Windows.Forms.Button btnCancel;
		System.Windows.Forms.Button btnCreate;
	}
}
