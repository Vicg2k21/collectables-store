namespace Module2LogonView
{
    partial class frmManagerInventory
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
            this.cbxCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvManagerInventory = new System.Windows.Forms.DataGridView();
            this.InventoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RestockThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discontinued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnRestock = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDisableItem = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxCategoryFilter
            // 
            this.cbxCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoryFilter.FormattingEnabled = true;
            this.cbxCategoryFilter.Location = new System.Drawing.Point(417, 12);
            this.cbxCategoryFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCategoryFilter.Name = "cbxCategoryFilter";
            this.cbxCategoryFilter.Size = new System.Drawing.Size(160, 24);
            this.cbxCategoryFilter.TabIndex = 7;
            this.cbxCategoryFilter.SelectionChangeCommitted += new System.EventHandler(this.cbxCategoryFilter_SelectionChangeCommitted);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(242, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(121, 42);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(101, 9);
            this.tbxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(132, 22);
            this.tbxSearch.TabIndex = 5;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(13, 9);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(75, 25);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search";
            // 
            // dgvManagerInventory
            // 
            this.dgvManagerInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagerInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryID,
            this.Cost,
            this.Quantity,
            this.RestockThreshold,
            this.Discontinued,
            this.ItemName,
            this.CategoryName,
            this.ItemDescription,
            this.RetailPrice});
            this.dgvManagerInventory.Location = new System.Drawing.Point(7, 59);
            this.dgvManagerInventory.Margin = new System.Windows.Forms.Padding(4);
            this.dgvManagerInventory.MultiSelect = false;
            this.dgvManagerInventory.Name = "dgvManagerInventory";
            this.dgvManagerInventory.ReadOnly = true;
            this.dgvManagerInventory.RowHeadersWidth = 51;
            this.dgvManagerInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManagerInventory.Size = new System.Drawing.Size(1042, 323);
            this.dgvManagerInventory.TabIndex = 8;
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
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Cost";
            this.Cost.MinimumWidth = 6;
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 125;
            // 
            // RestockThreshold
            // 
            this.RestockThreshold.DataPropertyName = "RestockThreshold";
            this.RestockThreshold.HeaderText = "Restock Threshold";
            this.RestockThreshold.MinimumWidth = 6;
            this.RestockThreshold.Name = "RestockThreshold";
            this.RestockThreshold.ReadOnly = true;
            this.RestockThreshold.Width = 125;
            // 
            // Discontinued
            // 
            this.Discontinued.DataPropertyName = "Discontinued";
            this.Discontinued.HeaderText = "Discontinued";
            this.Discontinued.MinimumWidth = 6;
            this.Discontinued.Name = "Discontinued";
            this.Discontinued.ReadOnly = true;
            this.Discontinued.Width = 125;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 125;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.CategoryName.DefaultCellStyle = dataGridViewCellStyle1;
            this.CategoryName.HeaderText = "CategoryName";
            this.CategoryName.MinimumWidth = 6;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.Width = 125;
            // 
            // ItemDescription
            // 
            this.ItemDescription.DataPropertyName = "ItemDescription";
            this.ItemDescription.HeaderText = "Description";
            this.ItemDescription.MinimumWidth = 6;
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.ReadOnly = true;
            this.ItemDescription.Width = 125;
            // 
            // RetailPrice
            // 
            this.RetailPrice.DataPropertyName = "RetailPrice";
            this.RetailPrice.HeaderText = "Retail Price";
            this.RetailPrice.MinimumWidth = 6;
            this.RetailPrice.Name = "RetailPrice";
            this.RetailPrice.ReadOnly = true;
            this.RetailPrice.Width = 125;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(46, 417);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(140, 48);
            this.btnAddItem.TabIndex = 9;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.Location = new System.Drawing.Point(255, 417);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(140, 48);
            this.btnEditItem.TabIndex = 10;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnRestock
            // 
            this.btnRestock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestock.Location = new System.Drawing.Point(669, 417);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.Size = new System.Drawing.Size(140, 48);
            this.btnRestock.TabIndex = 12;
            this.btnRestock.Text = "Restock Item";
            this.btnRestock.UseVisualStyleBackColor = true;
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(46, 513);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 48);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(255, 509);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 52);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDisableItem
            // 
            this.btnDisableItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisableItem.Location = new System.Drawing.Point(463, 417);
            this.btnDisableItem.Name = "btnDisableItem";
            this.btnDisableItem.Size = new System.Drawing.Size(140, 48);
            this.btnDisableItem.TabIndex = 15;
            this.btnDisableItem.Text = "Disable Item";
            this.btnDisableItem.UseVisualStyleBackColor = true;
            this.btnDisableItem.Click += new System.EventHandler(this.btnDisableItem_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(878, 524);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(171, 37);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmManagerInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 633);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnDisableItem);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRestock);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.dgvManagerInventory);
            this.Controls.Add(this.cbxCategoryFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "frmManagerInventory";
            this.Text = "Manager Inventory";
            this.Load += new System.EventHandler(this.frmManagerInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCategoryFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvManagerInventory;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnRestock;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDisableItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestockThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discontinued;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailPrice;
        private System.Windows.Forms.Button btnHelp;
    }
}