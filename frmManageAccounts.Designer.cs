namespace Module2LogonView
{
    partial class frmManageAccounts
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
            this.btnManageManagers = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageManagers
            // 
            this.btnManageManagers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageManagers.Location = new System.Drawing.Point(50, 33);
            this.btnManageManagers.Name = "btnManageManagers";
            this.btnManageManagers.Size = new System.Drawing.Size(224, 68);
            this.btnManageManagers.TabIndex = 0;
            this.btnManageManagers.Text = "Manage Managers";
            this.btnManageManagers.UseVisualStyleBackColor = true;
            this.btnManageManagers.Click += new System.EventHandler(this.btnManageManagers_Click);
            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageCustomers.Location = new System.Drawing.Point(311, 33);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(237, 68);
            this.btnManageCustomers.TabIndex = 1;
            this.btnManageCustomers.Text = "Manage Customers";
            this.btnManageCustomers.UseVisualStyleBackColor = true;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(585, 242);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(92, 49);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(13, 269);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(171, 37);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageEmployees.Location = new System.Drawing.Point(176, 127);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(237, 68);
            this.btnManageEmployees.TabIndex = 16;
            this.btnManageEmployees.Text = "Manage Employees";
            this.btnManageEmployees.UseVisualStyleBackColor = true;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            // 
            // frmManageAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 319);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnManageCustomers);
            this.Controls.Add(this.btnManageManagers);
            this.Name = "frmManageAccounts";
            this.Text = "Manage Accounts";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageManagers;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnManageEmployees;
    }
}