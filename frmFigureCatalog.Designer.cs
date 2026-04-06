namespace Module2LogonView
{
    partial class frmFigureCatalog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxCategoryFilter = new System.Windows.Forms.ComboBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewCart = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnViewOrderHistory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(16, 11);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(75, 25);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(104, 11);
            this.tbxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(132, 22);
            this.tbxSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(245, 11);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(121, 42);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxCategoryFilter
            // 
            this.cbxCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoryFilter.FormattingEnabled = true;
            this.cbxCategoryFilter.Location = new System.Drawing.Point(420, 14);
            this.cbxCategoryFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxCategoryFilter.Name = "cbxCategoryFilter";
            this.cbxCategoryFilter.Size = new System.Drawing.Size(160, 24);
            this.cbxCategoryFilter.TabIndex = 3;
            this.cbxCategoryFilter.SelectionChangeCommitted += new System.EventHandler(this.cbxCategoryFilter_SelectionChangeCommitted);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.InventoryID});
            this.dgvProducts.Location = new System.Drawing.Point(21, 60);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(824, 325);
            this.dgvProducts.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ItemName";
            this.Column1.HeaderText = "ItemName";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CategoryName";
            this.Column2.HeaderText = "CategoryName";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RetailPrice";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "RetailPrice";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Quantity";
            this.Column4.HeaderText = "Quantity";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // InventoryID
            // 
            this.InventoryID.DataPropertyName = "InventoryID";
            this.InventoryID.HeaderText = "InventoryID";
            this.InventoryID.MinimumWidth = 6;
            this.InventoryID.Name = "InventoryID";
            this.InventoryID.ReadOnly = true;
            this.InventoryID.Visible = false;
            this.InventoryID.Width = 125;
            // 
            // btnViewCart
            // 
            this.btnViewCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCart.Location = new System.Drawing.Point(180, 393);
            this.btnViewCart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewCart.Name = "btnViewCart";
            this.btnViewCart.Size = new System.Drawing.Size(164, 47);
            this.btnViewCart.TabIndex = 5;
            this.btnViewCart.Text = "View Cart";
            this.btnViewCart.UseVisualStyleBackColor = true;
            this.btnViewCart.Click += new System.EventHandler(this.btnViewCart_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.Location = new System.Drawing.Point(361, 393);
            this.btnViewDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(155, 47);
            this.btnViewDetails.TabIndex = 6;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(675, 11);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(171, 37);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnViewOrderHistory
            // 
            this.btnViewOrderHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewOrderHistory.Location = new System.Drawing.Point(536, 393);
            this.btnViewOrderHistory.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewOrderHistory.Name = "btnViewOrderHistory";
            this.btnViewOrderHistory.Size = new System.Drawing.Size(204, 47);
            this.btnViewOrderHistory.TabIndex = 16;
            this.btnViewOrderHistory.Text = "View Order History";
            this.btnViewOrderHistory.UseVisualStyleBackColor = true;
            this.btnViewOrderHistory.Click += new System.EventHandler(this.btnViewOrderHistory_Click);
            // 
            // frmFigureCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 482);
            this.Controls.Add(this.btnViewOrderHistory);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnViewCart);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.cbxCategoryFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lblSearch);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmFigureCatalog";
            this.Text = "Figure Catalog";
            this.Load += new System.EventHandler(this.frmProductCatalog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxCategoryFilter;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnViewCart;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryID;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnViewOrderHistory;
    }
}