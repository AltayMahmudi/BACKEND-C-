namespace Library_Management_System.Forms
{
	partial class LoginForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.BtnLogin = new System.Windows.Forms.Button();
			this.labelPassword = new System.Windows.Forms.Label();
			this.TxtboxPassword = new System.Windows.Forms.TextBox();
			this.TxtboxUsername = new System.Windows.Forms.TextBox();
			this.LabelLogin = new System.Windows.Forms.Label();
			this.labelUserName = new System.Windows.Forms.Label();
			this.Lock = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Lock)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.BtnLogin);
			this.panel1.Controls.Add(this.labelPassword);
			this.panel1.Controls.Add(this.TxtboxPassword);
			this.panel1.Controls.Add(this.TxtboxUsername);
			this.panel1.Controls.Add(this.LabelLogin);
			this.panel1.Controls.Add(this.labelUserName);
			this.panel1.Controls.Add(this.Lock);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(235, 353);
			this.panel1.TabIndex = 2;
			// 
			// BtnLogin
			// 
			this.BtnLogin.BackColor = System.Drawing.SystemColors.Highlight;
			this.BtnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.BtnLogin.Location = new System.Drawing.Point(43, 300);
			this.BtnLogin.Name = "BtnLogin";
			this.BtnLogin.Size = new System.Drawing.Size(149, 41);
			this.BtnLogin.TabIndex = 3;
			this.BtnLogin.Text = "Login";
			this.BtnLogin.UseVisualStyleBackColor = false;
			this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(24, 264);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(53, 13);
			this.labelPassword.TabIndex = 5;
			this.labelPassword.Text = "Password";
			// 
			// TxtboxPassword
			// 
			this.TxtboxPassword.Location = new System.Drawing.Point(89, 261);
			this.TxtboxPassword.Name = "TxtboxPassword";
			this.TxtboxPassword.PasswordChar = '*';
			this.TxtboxPassword.Size = new System.Drawing.Size(134, 20);
			this.TxtboxPassword.TabIndex = 2;
			// 
			// TxtboxUsername
			// 
			this.TxtboxUsername.Location = new System.Drawing.Point(89, 207);
			this.TxtboxUsername.Name = "TxtboxUsername";
			this.TxtboxUsername.Size = new System.Drawing.Size(134, 20);
			this.TxtboxUsername.TabIndex = 1;
			// 
			// LabelLogin
			// 
			this.LabelLogin.AutoSize = true;
			this.LabelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelLogin.Location = new System.Drawing.Point(42, 134);
			this.LabelLogin.Name = "LabelLogin";
			this.LabelLogin.Size = new System.Drawing.Size(150, 31);
			this.LabelLogin.TabIndex = 2;
			this.LabelLogin.Text = "Login Form";
			// 
			// labelUserName
			// 
			this.labelUserName.AutoSize = true;
			this.labelUserName.Location = new System.Drawing.Point(22, 207);
			this.labelUserName.Name = "labelUserName";
			this.labelUserName.Size = new System.Drawing.Size(55, 13);
			this.labelUserName.TabIndex = 1;
			this.labelUserName.Text = "Username";
			// 
			// Lock
			// 
			this.Lock.Image = ((System.Drawing.Image)(resources.GetObject("Lock.Image")));
			this.Lock.Location = new System.Drawing.Point(43, 13);
			this.Lock.Name = "Lock";
			this.Lock.Size = new System.Drawing.Size(149, 128);
			this.Lock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Lock.TabIndex = 0;
			this.Lock.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(40, 165);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 26);
			this.label1.TabIndex = 7;
			this.label1.Text = "Disclaimer: Use SHA256 Format in \r\n             Table for  password";
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(255, 374);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LoginForm";
			this.Text = "LoginForm";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Lock)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button BtnLogin;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TextBox TxtboxPassword;
		private System.Windows.Forms.TextBox TxtboxUsername;
		private System.Windows.Forms.Label LabelLogin;
		private System.Windows.Forms.Label labelUserName;
		private System.Windows.Forms.PictureBox Lock;
		private System.Windows.Forms.Label label1;
	}
}