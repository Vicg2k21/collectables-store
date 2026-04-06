namespace Module2LogonView
{
    partial class frmResetPassword
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
            this.components = new System.ComponentModel.Container();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblQ1 = new System.Windows.Forms.Label();
            this.lblQ2 = new System.Windows.Forms.Label();
            this.lblQ3 = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.tbxA1 = new System.Windows.Forms.TextBox();
            this.tbxA2 = new System.Windows.Forms.TextBox();
            this.tbxA3 = new System.Windows.Forms.TextBox();
            this.tbxNewPassword = new System.Windows.Forms.TextBox();
            this.tbxConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblUsernameRestPassword = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.Location = new System.Drawing.Point(288, 249);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(160, 40);
            this.btnResetPassword.TabIndex = 1;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(-283, -173);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(87, 20);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // lblQ1
            // 
            this.lblQ1.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.lblQ1.AutoSize = true;
            this.lblQ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQ1.Location = new System.Drawing.Point(347, 42);
            this.lblQ1.Name = "lblQ1";
            this.lblQ1.Size = new System.Drawing.Size(151, 20);
            this.lblQ1.TabIndex = 3;
            this.lblQ1.Text = "Security Question 1:";
            // 
            // lblQ2
            // 
            this.lblQ2.AutoSize = true;
            this.lblQ2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQ2.Location = new System.Drawing.Point(347, 73);
            this.lblQ2.Name = "lblQ2";
            this.lblQ2.Size = new System.Drawing.Size(147, 20);
            this.lblQ2.TabIndex = 5;
            this.lblQ2.Text = "SecurityQuestion 2:";
            // 
            // lblQ3
            // 
            this.lblQ3.AutoSize = true;
            this.lblQ3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQ3.Location = new System.Drawing.Point(347, 108);
            this.lblQ3.Name = "lblQ3";
            this.lblQ3.Size = new System.Drawing.Size(147, 20);
            this.lblQ3.TabIndex = 7;
            this.lblQ3.Text = "SecurityQuestion 3:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(228, 156);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(113, 20);
            this.lblNewPassword.TabIndex = 9;
            this.lblNewPassword.Text = "New Password";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(204, 202);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(137, 20);
            this.lblConfirmPassword.TabIndex = 10;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(347, 14);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(100, 20);
            this.tbxUsername.TabIndex = 11;
            this.toolTip1.SetToolTip(this.tbxUsername, "Press Tab to load your security questions.");
            this.tbxUsername.Leave += new System.EventHandler(this.tbxUsername_Leave);
            // 
            // tbxA1
            // 
            this.tbxA1.Location = new System.Drawing.Point(241, 42);
            this.tbxA1.Name = "tbxA1";
            this.tbxA1.Size = new System.Drawing.Size(100, 20);
            this.tbxA1.TabIndex = 12;
            // 
            // tbxA2
            // 
            this.tbxA2.Location = new System.Drawing.Point(241, 73);
            this.tbxA2.Name = "tbxA2";
            this.tbxA2.Size = new System.Drawing.Size(100, 20);
            this.tbxA2.TabIndex = 13;
            // 
            // tbxA3
            // 
            this.tbxA3.Location = new System.Drawing.Point(241, 108);
            this.tbxA3.Name = "tbxA3";
            this.tbxA3.Size = new System.Drawing.Size(100, 20);
            this.tbxA3.TabIndex = 14;
            // 
            // tbxNewPassword
            // 
            this.tbxNewPassword.Location = new System.Drawing.Point(347, 156);
            this.tbxNewPassword.Name = "tbxNewPassword";
            this.tbxNewPassword.Size = new System.Drawing.Size(100, 20);
            this.tbxNewPassword.TabIndex = 15;
            // 
            // tbxConfirmPassword
            // 
            this.tbxConfirmPassword.Location = new System.Drawing.Point(348, 202);
            this.tbxConfirmPassword.Name = "tbxConfirmPassword";
            this.tbxConfirmPassword.Size = new System.Drawing.Size(100, 20);
            this.tbxConfirmPassword.TabIndex = 16;
            // 
            // lblUsernameRestPassword
            // 
            this.lblUsernameRestPassword.AutoSize = true;
            this.lblUsernameRestPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameRestPassword.Location = new System.Drawing.Point(258, 12);
            this.lblUsernameRestPassword.Name = "lblUsernameRestPassword";
            this.lblUsernameRestPassword.Size = new System.Drawing.Size(83, 20);
            this.lblUsernameRestPassword.TabIndex = 17;
            this.lblUsernameRestPassword.Text = "Username";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(606, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(120, 37);
            this.btnHelp.TabIndex = 18;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 322);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblUsernameRestPassword);
            this.Controls.Add(this.tbxConfirmPassword);
            this.Controls.Add(this.tbxNewPassword);
            this.Controls.Add(this.tbxA3);
            this.Controls.Add(this.tbxA2);
            this.Controls.Add(this.tbxA1);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblQ3);
            this.Controls.Add(this.lblQ2);
            this.Controls.Add(this.lblQ1);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnResetPassword);
            this.Name = "frmResetPassword";
            this.Text = "Reset Password";
            this.Load += new System.EventHandler(this.frmResetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblQ1;
        private System.Windows.Forms.Label lblQ2;
        private System.Windows.Forms.Label lblQ3;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.TextBox tbxA1;
        private System.Windows.Forms.TextBox tbxA2;
        private System.Windows.Forms.TextBox tbxA3;
        private System.Windows.Forms.TextBox tbxNewPassword;
        private System.Windows.Forms.TextBox tbxConfirmPassword;
        private System.Windows.Forms.Label lblUsernameRestPassword;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnHelp;
    }
}