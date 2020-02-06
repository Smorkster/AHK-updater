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
			this.components = new System.ComponentModel.Container();
			this.btnCreate = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtHotstringSystem = new System.Windows.Forms.TextBox();
			this.lblSystem = new System.Windows.Forms.Label();
			this.lblMenuTitle = new System.Windows.Forms.Label();
			this.txtHotstringMenuTitle = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCreate
			// 
			this.btnCreate.Enabled = false;
			this.btnCreate.Location = new System.Drawing.Point(302, 12);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 4;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(302, 41);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(126, 14);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(136, 20);
			this.txtName.TabIndex = 1;
			this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// txtHotstringSystem
			// 
			this.txtHotstringSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtHotstringSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtHotstringSystem.Location = new System.Drawing.Point(126, 40);
			this.txtHotstringSystem.Name = "txtHotstringSystem";
			this.txtHotstringSystem.Size = new System.Drawing.Size(136, 20);
			this.txtHotstringSystem.TabIndex = 2;
			this.txtHotstringSystem.Visible = false;
			this.txtHotstringSystem.TextChanged += new System.EventHandler(this.TxtHotstringSystem_TextChanged);
			// 
			// lblSystem
			// 
			this.lblSystem.AutoSize = true;
			this.lblSystem.Location = new System.Drawing.Point(12, 43);
			this.lblSystem.Name = "lblSystem";
			this.lblSystem.Size = new System.Drawing.Size(41, 13);
			this.lblSystem.TabIndex = 0;
			this.lblSystem.Text = "System";
			this.lblSystem.Visible = false;
			// 
			// lblMenuTitle
			// 
			this.lblMenuTitle.AutoSize = true;
			this.lblMenuTitle.Location = new System.Drawing.Point(12, 69);
			this.lblMenuTitle.Name = "lblMenuTitle";
			this.lblMenuTitle.Size = new System.Drawing.Size(108, 13);
			this.lblMenuTitle.TabIndex = 0;
			this.lblMenuTitle.Text = "Menutitle for hotstring";
			this.lblMenuTitle.Visible = false;
			// 
			// txtHotstringMenuTitle
			// 
			this.txtHotstringMenuTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtHotstringMenuTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtHotstringMenuTitle.Location = new System.Drawing.Point(126, 66);
			this.txtHotstringMenuTitle.Name = "txtHotstringMenuTitle";
			this.txtHotstringMenuTitle.Size = new System.Drawing.Size(136, 20);
			this.txtHotstringMenuTitle.TabIndex = 3;
			this.txtHotstringMenuTitle.Visible = false;
			this.txtHotstringMenuTitle.TextChanged += new System.EventHandler(this.TxtHotstringMenuTitle_TextChanged);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// NewCommand
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(393, 97);
			this.Controls.Add(this.lblMenuTitle);
			this.Controls.Add(this.txtHotstringMenuTitle);
			this.Controls.Add(this.lblSystem);
			this.Controls.Add(this.txtHotstringSystem);
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
			this.Text = "New ";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		System.Windows.Forms.Label lblSystem;
		System.Windows.Forms.TextBox txtHotstringSystem;
		System.Windows.Forms.Label label1;
		System.Windows.Forms.TextBox txtName;
		System.Windows.Forms.Button btnCancel;
		System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Label lblMenuTitle;
		private System.Windows.Forms.TextBox txtHotstringMenuTitle;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}
