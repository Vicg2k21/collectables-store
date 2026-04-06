namespace Module2LogonView
{
    partial class frmManagerDiscounts
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteDiscount = new System.Windows.Forms.Button();
            this.btnEditDiscount = new System.Windows.Forms.Button();
            this.btnAddDiscount = new System.Windows.Forms.Button();
            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
            this.DiscountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountDollarAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(317, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteDiscount
            // 
            this.btnDeleteDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDiscount.Location = new System.Drawing.Point(566, 467);
            this.btnDeleteDiscount.Name = "btnDeleteDiscount";
            this.btnDeleteDiscount.Size = new System.Drawing.Size(173, 42);
            this.btnDeleteDiscount.TabIndex = 14;
            this.btnDeleteDiscount.Text = "Delete Discount";
            this.btnDeleteDiscount.UseVisualStyleBackColor = true;
            this.btnDeleteDiscount.Click += new System.EventHandler(this.btnDeleteDiscount_Click);
            // 
            // btnEditDiscount
            // 
            this.btnEditDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDiscount.Location = new System.Drawing.Point(317, 467);
            this.btnEditDiscount.Name = "btnEditDiscount";
            this.btnEditDiscount.Size = new System.Drawing.Size(173, 42);
            this.btnEditDiscount.TabIndex = 13;
            this.btnEditDiscount.Text = "Edit Discount";
            this.btnEditDiscount.UseVisualStyleBackColor = true;
            this.btnEditDiscount.Click += new System.EventHandler(this.btnEditDiscount_Click);
            // 
            // btnAddDiscount
            // 
            this.btnAddDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDiscount.Location = new System.Drawing.Point(47, 467);
            this.btnAddDiscount.Name = "btnAddDiscount";
            this.btnAddDiscount.Size = new System.Drawing.Size(173, 42);
            this.btnAddDiscount.TabIndex = 12;
            this.btnAddDiscount.Text = "Add Discount";
            this.btnAddDiscount.UseVisualStyleBackColor = true;
            this.btnAddDiscount.Click += new System.EventHandler(this.btnAddDiscount_Click);
            // 
            // dgvDiscounts
            // 
            this.dgvDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DiscountCode,
            this.Description,
            this.DiscountLevel,
            this.DiscountType,
            this.DiscountPercentage,
            this.DiscountDollarAmount,
            this.ItemName,
            this.StartDate,
            this.ExpirationDate,
            this.DiscountID,
            this.InventoryID});
            this.dgvDiscounts.Location = new System.Drawing.Point(23, 64);
            this.dgvDiscounts.Name = "dgvDiscounts";
            this.dgvDiscounts.RowHeadersWidth = 51;
            this.dgvDiscounts.RowTemplate.Height = 24;
            this.dgvDiscounts.Size = new System.Drawing.Size(1176, 378);
            this.dgvDiscounts.TabIndex = 11;
            // 
            // DiscountCode
            // 
            this.DiscountCode.DataPropertyName = "DiscountCode";
            this.DiscountCode.HeaderText = "Discount Code";
            this.DiscountCode.MinimumWidth = 6;
            this.DiscountCode.Name = "DiscountCode";
            this.DiscountCode.Width = 125;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Width = 125;
            // 
            // DiscountLevel
            // 
            this.DiscountLevel.DataPropertyName = "DiscountLevel";
            this.DiscountLevel.HeaderText = "Discount Level";
            this.DiscountLevel.MinimumWidth = 6;
            this.DiscountLevel.Name = "DiscountLevel";
            this.DiscountLevel.Width = 125;
            // 
            // DiscountType
            // 
            this.DiscountType.DataPropertyName = "DiscountType";
            this.DiscountType.HeaderText = "Discount Type";
            this.DiscountType.MinimumWidth = 6;
            this.DiscountType.Name = "DiscountType";
            this.DiscountType.Width = 125;
            // 
            // DiscountPercentage
            // 
            this.DiscountPercentage.DataPropertyName = "DiscountPercentage";
            this.DiscountPercentage.HeaderText = "Discount Percentage";
            this.DiscountPercentage.MinimumWidth = 6;
            this.DiscountPercentage.Name = "DiscountPercentage";
            this.DiscountPercentage.Width = 125;
            // 
            // DiscountDollarAmount
            // 
            this.DiscountDollarAmount.DataPropertyName = "DiscountDollarAmount";
            this.DiscountDollarAmount.HeaderText = "Discount Dollar Amount";
            this.DiscountDollarAmount.MinimumWidth = 6;
            this.DiscountDollarAmount.Name = "DiscountDollarAmount";
            this.DiscountDollarAmount.Width = 125;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 125;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.MinimumWidth = 6;
            this.StartDate.Name = "StartDate";
            this.StartDate.Width = 125;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.DataPropertyName = "ExpirationDate";
            this.ExpirationDate.HeaderText = "Expiration Date";
            this.ExpirationDate.MinimumWidth = 6;
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.Width = 125;
            // 
            // DiscountID
            // 
            this.DiscountID.DataPropertyName = "DiscountID";
            this.DiscountID.HeaderText = "Discount ID";
            this.DiscountID.MinimumWidth = 6;
            this.DiscountID.Name = "DiscountID";
            this.DiscountID.Visible = false;
            this.DiscountID.Width = 125;
            // 
            // InventoryID
            // 
            this.InventoryID.DataPropertyName = "InventoryID";
            this.InventoryID.HeaderText = "Inventory ID";
            this.InventoryID.MinimumWidth = 6;
            this.InventoryID.Name = "InventoryID";
            this.InventoryID.Visible = false;
            this.InventoryID.Width = 125;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(392, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 37);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(35, 31);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(148, 22);
            this.tbxSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(217, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 37);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(1028, 550);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(171, 37);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmManagerDiscounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 638);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteDiscount);
            this.Controls.Add(this.btnEditDiscount);
            this.Controls.Add(this.btnAddDiscount);
            this.Controls.Add(this.dgvDiscounts);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmManagerDiscounts";
            this.Text = "Manager Discounts";
            this.Load += new System.EventHandler(this.frmManagerDiscounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteDiscount;
        private System.Windows.Forms.Button btnEditDiscount;
        private System.Windows.Forms.Button btnAddDiscount;
        private System.Windows.Forms.DataGridView dgvDiscounts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountDollarAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryID;
        private System.Windows.Forms.Button btnHelp;
    }
}