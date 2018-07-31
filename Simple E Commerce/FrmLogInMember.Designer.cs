namespace Simple_E_Commerce
{
    partial class FrmLogInMember
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
            this.btnLogIn = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLogIn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLblSignUp = new System.Windows.Forms.LinkLabel();
            this.lblAccountError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnLogIn.Location = new System.Drawing.Point(388, 312);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(164, 55);
            this.btnLogIn.TabIndex = 17;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(308, 208);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(396, 31);
            this.txtPassword.TabIndex = 16;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(94, 208);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(134, 31);
            this.lblPassword.TabIndex = 15;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(308, 144);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(396, 31);
            this.txtUsername.TabIndex = 14;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(94, 144);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(139, 31);
            this.lblUsername.TabIndex = 13;
            this.lblUsername.Text = "Username";
            // 
            // lblLogIn
            // 
            this.lblLogIn.AutoSize = true;
            this.lblLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLogIn.Location = new System.Drawing.Point(345, 52);
            this.lblLogIn.Name = "lblLogIn";
            this.lblLogIn.Size = new System.Drawing.Size(126, 37);
            this.lblLogIn.TabIndex = 12;
            this.lblLogIn.Text = "LOG IN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 391);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 33);
            this.label1.TabIndex = 18;
            this.label1.Text = "Belum ada akun?";
            // 
            // linkLblSignUp
            // 
            this.linkLblSignUp.AutoSize = true;
            this.linkLblSignUp.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.linkLblSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblSignUp.Location = new System.Drawing.Point(471, 391);
            this.linkLblSignUp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLblSignUp.Name = "linkLblSignUp";
            this.linkLblSignUp.Size = new System.Drawing.Size(129, 33);
            this.linkLblSignUp.TabIndex = 19;
            this.linkLblSignUp.TabStop = true;
            this.linkLblSignUp.Text = "Sign up !";
            this.linkLblSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblSignUp_LinkClicked);
            // 
            // lblAccountError
            // 
            this.lblAccountError.AutoSize = true;
            this.lblAccountError.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountError.ForeColor = System.Drawing.Color.Red;
            this.lblAccountError.Location = new System.Drawing.Point(303, 269);
            this.lblAccountError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccountError.Name = "lblAccountError";
            this.lblAccountError.Size = new System.Drawing.Size(368, 25);
            this.lblAccountError.TabIndex = 20;
            this.lblAccountError.Text = "Username atau password anda salah";
            this.lblAccountError.Visible = false;
            // 
            // FrmLogInMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 442);
            this.Controls.Add(this.lblAccountError);
            this.Controls.Add(this.linkLblSignUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogInMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Log In Member";
            this.Load += new System.EventHandler(this.FrmLogInMember_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLogIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLblSignUp;
        private System.Windows.Forms.Label lblAccountError;
    }
}