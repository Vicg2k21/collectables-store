namespace Module2LogonView
{
    partial class frmManager
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
            this.btnManageInventory = new System.Windows.Forms.Button();
            this.btnManageAccounts = new System.Windows.Forms.Button();
            this.btnManageDiscounts = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageInventory
            // 
            this.btnManageInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageInventory.Location = new System.Drawing.Point(54, 34);
            this.btnManageInventory.Name = "btnManageInventory";
            this.btnManageInventory.Size = new System.Drawing.Size(205, 44);
            this.btnManageInventory.TabIndex = 0;
            this.btnManageInventory.Text = "Manage Inventory";
            this.btnManageInventory.UseVisualStyleBackColor = true;
            this.btnManageInventory.Click += new System.EventHandler(this.btnManageInventory_Click);
            // 
            // btnManageAccounts
            // 
            this.btnManageAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageAccounts.Location = new System.Drawing.Point(430, 34);
            this.btnManageAccounts.Name = "btnManageAccounts";
            this.btnManageAccounts.Size = new System.Drawing.Size(205, 44);
            this.btnManageAccounts.TabIndex = 1;
            this.btnManageAccounts.Text = "Manage Accounts";
            this.btnManageAccounts.UseVisualStyleBackColor = true;
            this.btnManageAccounts.Click += new System.EventHandler(this.btnManageAccounts_Click);
            // 
            // btnManageDiscounts
            // 
            this.btnManageDiscounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageDiscounts.Location = new System.Drawing.Point(54, 142);
            this.btnManageDiscounts.Name = "btnManageDiscounts";
            this.btnManageDiscounts.Size = new System.Drawing.Size(205, 44);
            this.btnManageDiscounts.TabIndex = 2;
            this.btnManageDiscounts.Text = "Manage Discounts";
            this.btnManageDiscounts.UseVisualStyleBackColor = true;
            this.btnManageDiscounts.Click += new System.EventHandler(this.btnManageDiscounts_Click);
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(430, 142);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(205, 44);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOS.Location = new System.Drawing.Point(54, 247);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(205, 44);
            this.btnPOS.TabIndex = 4;
            this.btnPOS.Text = "POS / Checkout";
            this.btnPOS.UseVisualStyleBackColor = true;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(430, 247);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(205, 44);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(265, 335);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(171, 37);
            this.btnHelp.TabIndex = 14;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 412);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnPOS);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnManageDiscounts);
            this.Controls.Add(this.btnManageAccounts);
            this.Controls.Add(this.btnManageInventory);
            this.Name = "frmManager";
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.frmManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageInventory;
        private System.Windows.Forms.Button btnManageAccounts;
        private System.Windows.Forms.Button btnManageDiscounts;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHelp;
    }
}