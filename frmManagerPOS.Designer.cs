namespace Module2LogonView
{
    partial class frmManagerPOS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxCustomerLookup = new System.Windows.Forms.GroupBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.PersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhonePrimary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountDisabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelectedCustomer = new System.Windows.Forms.Label();
            this.lblSearchCustomer = new System.Windows.Forms.Label();
            this.tbxSearchCustomer = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.gbxCart = new System.Windows.Forms.GroupBox();
            this.btnUpdateQuantity = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.gbxPromoCodes = new System.Windows.Forms.GroupBox();
            this.cbxPromoCode = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblPromoCode = new System.Windows.Forms.Label();
            this.gbxCheckout = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnSearchFigures = new System.Windows.Forms.Button();
            this.tbxSearchFigure = new System.Windows.Forms.TextBox();
            this.lblSearchFigure = new System.Windows.Forms.Label();
            this.pbxFigureImage = new System.Windows.Forms.PictureBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.gbxFiguresSearch = new System.Windows.Forms.GroupBox();
            this.cbxCategoryFilter = new System.Windows.Forms.ComboBox();
            this.lblFigureOutOfStock = new System.Windows.Forms.Label();
            this.lblFigureQuantityLabelOnly = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantityOfFigure = new System.Windows.Forms.Label();
            this.btnViewTransactions = new System.Windows.Forms.Button();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discontinued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHelp = new System.Windows.Forms.Button();
            this.gbxCustomerLookup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.gbxCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.gbxPromoCodes.SuspendLayout();
            this.gbxCheckout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFigureImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.gbxFiguresSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCustomerLookup
            // 
            this.gbxCustomerLookup.Controls.Add(this.dgvCustomers);
            this.gbxCustomerLookup.Controls.Add(this.lblSelectedCustomer);
            this.gbxCustomerLookup.Controls.Add(this.lblSearchCustomer);
            this.gbxCustomerLookup.Controls.Add(this.tbxSearchCustomer);
            this.gbxCustomerLookup.Controls.Add(this.btnSearchCustomer);
            this.gbxCustomerLookup.Location = new System.Drawing.Point(9, 9);
            this.gbxCustomerLookup.Name = "gbxCustomerLookup";
            this.gbxCustomerLookup.Size = new System.Drawing.Size(482, 366);
            this.gbxCustomerLookup.TabIndex = 0;
            this.gbxCustomerLookup.TabStop = false;
            this.gbxCustomerLookup.Text = "Customer Lookup";
            // 
            // dgvCustomers
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonID,
            this.LogonID,
            this.FirstName,
            this.LastName,
            this.Email,
            this.PhonePrimary,
            this.LogonName,
            this.AccountDisabled});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvCustomers.Location = new System.Drawing.Point(8, 68);
            this.dgvCustomers.Name = "dgvCustomers";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Size = new System.Drawing.Size(468, 257);
            this.dgvCustomers.TabIndex = 20;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // PersonID
            // 
            this.PersonID.DataPropertyName = "PersonID";
            this.PersonID.HeaderText = "PersonID";
            this.PersonID.MinimumWidth = 6;
            this.PersonID.Name = "PersonID";
            this.PersonID.Visible = false;
            this.PersonID.Width = 125;
            // 
            // LogonID
            // 
            this.LogonID.DataPropertyName = "LogonID";
            this.LogonID.HeaderText = "LogonID";
            this.LogonID.MinimumWidth = 6;
            this.LogonID.Name = "LogonID";
            this.LogonID.Visible = false;
            this.LogonID.Width = 125;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "NameFirst";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 125;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "NameLast";
            this.LastName.HeaderText = "Last Name";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            this.LastName.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // PhonePrimary
            // 
            this.PhonePrimary.DataPropertyName = "PhonePrimary";
            this.PhonePrimary.HeaderText = "Phone Primary";
            this.PhonePrimary.MinimumWidth = 6;
            this.PhonePrimary.Name = "PhonePrimary";
            this.PhonePrimary.Width = 125;
            // 
            // LogonName
            // 
            this.LogonName.DataPropertyName = "LogonName";
            this.LogonName.HeaderText = "Logon Name";
            this.LogonName.MinimumWidth = 6;
            this.LogonName.Name = "LogonName";
            this.LogonName.Width = 125;
            // 
            // AccountDisabled
            // 
            this.AccountDisabled.DataPropertyName = "AccountDisabled";
            this.AccountDisabled.HeaderText = "Account Disabled";
            this.AccountDisabled.MinimumWidth = 6;
            this.AccountDisabled.Name = "AccountDisabled";
            this.AccountDisabled.Width = 125;
            // 
            // lblSelectedCustomer
            // 
            this.lblSelectedCustomer.AutoSize = true;
            this.lblSelectedCustomer.Location = new System.Drawing.Point(21, 339);
            this.lblSelectedCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedCustomer.Name = "lblSelectedCustomer";
            this.lblSelectedCustomer.Size = new System.Drawing.Size(124, 16);
            this.lblSelectedCustomer.TabIndex = 14;
            this.lblSelectedCustomer.Text = "Selected Customer:";
            // 
            // lblSearchCustomer
            // 
            this.lblSearchCustomer.AutoSize = true;
            this.lblSearchCustomer.Location = new System.Drawing.Point(5, 31);
            this.lblSearchCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchCustomer.Name = "lblSearchCustomer";
            this.lblSearchCustomer.Size = new System.Drawing.Size(50, 16);
            this.lblSearchCustomer.TabIndex = 12;
            this.lblSearchCustomer.Text = "Search";
            // 
            // tbxSearchCustomer
            // 
            this.tbxSearchCustomer.Location = new System.Drawing.Point(59, 29);
            this.tbxSearchCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSearchCustomer.Name = "tbxSearchCustomer";
            this.tbxSearchCustomer.Size = new System.Drawing.Size(126, 22);
            this.tbxSearchCustomer.TabIndex = 11;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCustomer.Location = new System.Drawing.Point(189, 20);
            this.btnSearchCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(182, 43);
            this.btnSearchCustomer.TabIndex = 10;
            this.btnSearchCustomer.Text = "Search Customer";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // gbxCart
            // 
            this.gbxCart.Controls.Add(this.btnUpdateQuantity);
            this.gbxCart.Controls.Add(this.btnClearCart);
            this.gbxCart.Controls.Add(this.dgvCart);
            this.gbxCart.Controls.Add(this.btnRemoveItem);
            this.gbxCart.Location = new System.Drawing.Point(9, 404);
            this.gbxCart.Name = "gbxCart";
            this.gbxCart.Size = new System.Drawing.Size(622, 358);
            this.gbxCart.TabIndex = 2;
            this.gbxCart.TabStop = false;
            this.gbxCart.Text = "Shopping Cart";
            // 
            // btnUpdateQuantity
            // 
            this.btnUpdateQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateQuantity.Location = new System.Drawing.Point(453, 107);
            this.btnUpdateQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateQuantity.Name = "btnUpdateQuantity";
            this.btnUpdateQuantity.Size = new System.Drawing.Size(137, 32);
            this.btnUpdateQuantity.TabIndex = 15;
            this.btnUpdateQuantity.Text = "Update Quantity";
            this.btnUpdateQuantity.UseVisualStyleBackColor = true;
            this.btnUpdateQuantity.Click += new System.EventHandler(this.btnUpdateQuantity_Click);
            // 
            // btnClearCart
            // 
            this.btnClearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCart.Location = new System.Drawing.Point(453, 71);
            this.btnClearCart.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(137, 32);
            this.btnClearCart.TabIndex = 14;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // dgvCart
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle25;
            this.dgvCart.Location = new System.Drawing.Point(8, 35);
            this.dgvCart.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCart.Name = "dgvCart";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.RowHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 24;
            this.dgvCart.Size = new System.Drawing.Size(441, 247);
            this.dgvCart.TabIndex = 13;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.Location = new System.Drawing.Point(453, 35);
            this.btnRemoveItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(137, 32);
            this.btnRemoveItem.TabIndex = 10;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // gbxPromoCodes
            // 
            this.gbxPromoCodes.Controls.Add(this.cbxPromoCode);
            this.gbxPromoCodes.Controls.Add(this.lblDiscount);
            this.gbxPromoCodes.Controls.Add(this.lblPromoCode);
            this.gbxPromoCodes.Location = new System.Drawing.Point(637, 404);
            this.gbxPromoCodes.Name = "gbxPromoCodes";
            this.gbxPromoCodes.Size = new System.Drawing.Size(403, 245);
            this.gbxPromoCodes.TabIndex = 3;
            this.gbxPromoCodes.TabStop = false;
            this.gbxPromoCodes.Text = "Promo Codes";
            // 
            // cbxPromoCode
            // 
            this.cbxPromoCode.FormattingEnabled = true;
            this.cbxPromoCode.Location = new System.Drawing.Point(23, 66);
            this.cbxPromoCode.Name = "cbxPromoCode";
            this.cbxPromoCode.Size = new System.Drawing.Size(273, 24);
            this.cbxPromoCode.TabIndex = 22;
            this.cbxPromoCode.SelectedIndexChanged += new System.EventHandler(this.cbxPromoCode_SelectedIndexChanged);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(20, 173);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(62, 16);
            this.lblDiscount.TabIndex = 21;
            this.lblDiscount.Text = "Discount:";
            // 
            // lblPromoCode
            // 
            this.lblPromoCode.AutoSize = true;
            this.lblPromoCode.Location = new System.Drawing.Point(20, 35);
            this.lblPromoCode.Name = "lblPromoCode";
            this.lblPromoCode.Size = new System.Drawing.Size(86, 16);
            this.lblPromoCode.TabIndex = 20;
            this.lblPromoCode.Text = "Promo Code:";
            // 
            // gbxCheckout
            // 
            this.gbxCheckout.Controls.Add(this.lblTotal);
            this.gbxCheckout.Controls.Add(this.lblTax);
            this.gbxCheckout.Controls.Add(this.lblSubtotal);
            this.gbxCheckout.Controls.Add(this.btnBack);
            this.gbxCheckout.Controls.Add(this.btnCheckout);
            this.gbxCheckout.Location = new System.Drawing.Point(1046, 404);
            this.gbxCheckout.Name = "gbxCheckout";
            this.gbxCheckout.Size = new System.Drawing.Size(543, 189);
            this.gbxCheckout.TabIndex = 4;
            this.gbxCheckout.TabStop = false;
            this.gbxCheckout.Text = "Checkout";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(342, 146);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 16);
            this.lblTotal.TabIndex = 27;
            this.lblTotal.Text = "Total:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(342, 115);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(33, 16);
            this.lblTax.TabIndex = 26;
            this.lblTax.Text = "Tax:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(31, 115);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(59, 16);
            this.lblSubtotal.TabIndex = 24;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(202, 50);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(119, 40);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.Location = new System.Drawing.Point(34, 50);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(119, 40);
            this.btnCheckout.TabIndex = 15;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnSearchFigures
            // 
            this.btnSearchFigures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchFigures.Location = new System.Drawing.Point(189, 16);
            this.btnSearchFigures.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchFigures.Name = "btnSearchFigures";
            this.btnSearchFigures.Size = new System.Drawing.Size(173, 43);
            this.btnSearchFigures.TabIndex = 10;
            this.btnSearchFigures.Text = "Search Figures";
            this.btnSearchFigures.UseVisualStyleBackColor = true;
            this.btnSearchFigures.Click += new System.EventHandler(this.btnSearchFigures_Click);
            // 
            // tbxSearchFigure
            // 
            this.tbxSearchFigure.Location = new System.Drawing.Point(59, 29);
            this.tbxSearchFigure.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSearchFigure.Name = "tbxSearchFigure";
            this.tbxSearchFigure.Size = new System.Drawing.Size(126, 22);
            this.tbxSearchFigure.TabIndex = 11;
            // 
            // lblSearchFigure
            // 
            this.lblSearchFigure.AutoSize = true;
            this.lblSearchFigure.Location = new System.Drawing.Point(5, 31);
            this.lblSearchFigure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchFigure.Name = "lblSearchFigure";
            this.lblSearchFigure.Size = new System.Drawing.Size(50, 16);
            this.lblSearchFigure.TabIndex = 12;
            this.lblSearchFigure.Text = "Search";
            // 
            // pbxFigureImage
            // 
            this.pbxFigureImage.Location = new System.Drawing.Point(476, 74);
            this.pbxFigureImage.Margin = new System.Windows.Forms.Padding(2);
            this.pbxFigureImage.Name = "pbxFigureImage";
            this.pbxFigureImage.Size = new System.Drawing.Size(210, 198);
            this.pbxFigureImage.TabIndex = 15;
            this.pbxFigureImage.TabStop = false;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(537, 276);
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(91, 31);
            this.btnAddToCart.TabIndex = 17;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // dgvProducts
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Discontinued,
            this.CategoryName,
            this.RetailPrice,
            this.Quantity,
            this.InventoryID});
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle29;
            this.dgvProducts.Location = new System.Drawing.Point(8, 65);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(462, 246);
            this.dgvProducts.TabIndex = 18;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            // 
            // gbxFiguresSearch
            // 
            this.gbxFiguresSearch.Controls.Add(this.cbxCategoryFilter);
            this.gbxFiguresSearch.Controls.Add(this.lblFigureOutOfStock);
            this.gbxFiguresSearch.Controls.Add(this.lblFigureQuantityLabelOnly);
            this.gbxFiguresSearch.Controls.Add(this.numQuantity);
            this.gbxFiguresSearch.Controls.Add(this.lblQuantityOfFigure);
            this.gbxFiguresSearch.Controls.Add(this.dgvProducts);
            this.gbxFiguresSearch.Controls.Add(this.btnAddToCart);
            this.gbxFiguresSearch.Controls.Add(this.pbxFigureImage);
            this.gbxFiguresSearch.Controls.Add(this.lblSearchFigure);
            this.gbxFiguresSearch.Controls.Add(this.tbxSearchFigure);
            this.gbxFiguresSearch.Controls.Add(this.btnSearchFigures);
            this.gbxFiguresSearch.Location = new System.Drawing.Point(531, 16);
            this.gbxFiguresSearch.Name = "gbxFiguresSearch";
            this.gbxFiguresSearch.Size = new System.Drawing.Size(695, 382);
            this.gbxFiguresSearch.TabIndex = 1;
            this.gbxFiguresSearch.TabStop = false;
            this.gbxFiguresSearch.Text = "Figures Search";
            // 
            // cbxCategoryFilter
            // 
            this.cbxCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategoryFilter.FormattingEnabled = true;
            this.cbxCategoryFilter.Location = new System.Drawing.Point(368, 26);
            this.cbxCategoryFilter.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCategoryFilter.Name = "cbxCategoryFilter";
            this.cbxCategoryFilter.Size = new System.Drawing.Size(160, 24);
            this.cbxCategoryFilter.TabIndex = 24;
            this.cbxCategoryFilter.SelectionChangeCommitted += new System.EventHandler(this.cbxCategoryFilter_SelectionChangeCommitted);
            // 
            // lblFigureOutOfStock
            // 
            this.lblFigureOutOfStock.AutoSize = true;
            this.lblFigureOutOfStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureOutOfStock.ForeColor = System.Drawing.Color.Red;
            this.lblFigureOutOfStock.Location = new System.Drawing.Point(437, 327);
            this.lblFigureOutOfStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFigureOutOfStock.Name = "lblFigureOutOfStock";
            this.lblFigureOutOfStock.Size = new System.Drawing.Size(0, 25);
            this.lblFigureOutOfStock.TabIndex = 23;
            // 
            // lblFigureQuantityLabelOnly
            // 
            this.lblFigureQuantityLabelOnly.AutoSize = true;
            this.lblFigureQuantityLabelOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureQuantityLabelOnly.Location = new System.Drawing.Point(81, 332);
            this.lblFigureQuantityLabelOnly.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFigureQuantityLabelOnly.Name = "lblFigureQuantityLabelOnly";
            this.lblFigureQuantityLabelOnly.Size = new System.Drawing.Size(67, 16);
            this.lblFigureQuantityLabelOnly.TabIndex = 22;
            this.lblFigureQuantityLabelOnly.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(260, 330);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(160, 22);
            this.numQuantity.TabIndex = 21;
            // 
            // lblQuantityOfFigure
            // 
            this.lblQuantityOfFigure.AutoSize = true;
            this.lblQuantityOfFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityOfFigure.Location = new System.Drawing.Point(156, 332);
            this.lblQuantityOfFigure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantityOfFigure.Name = "lblQuantityOfFigure";
            this.lblQuantityOfFigure.Size = new System.Drawing.Size(96, 16);
            this.lblQuantityOfFigure.TabIndex = 20;
            this.lblQuantityOfFigure.Text = "Figure Quantity";
            // 
            // btnViewTransactions
            // 
            this.btnViewTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTransactions.Location = new System.Drawing.Point(1361, 171);
            this.btnViewTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewTransactions.Name = "btnViewTransactions";
            this.btnViewTransactions.Size = new System.Drawing.Size(147, 50);
            this.btnViewTransactions.TabIndex = 16;
            this.btnViewTransactions.Text = "View Transactions";
            this.btnViewTransactions.UseVisualStyleBackColor = true;
            this.btnViewTransactions.Click += new System.EventHandler(this.btnViewTransactions_Click);
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
            // Discontinued
            // 
            this.Discontinued.DataPropertyName = "Discontinued";
            this.Discontinued.HeaderText = "Discontinued";
            this.Discontinued.MinimumWidth = 6;
            this.Discontinued.Name = "Discontinued";
            this.Discontinued.ReadOnly = true;
            this.Discontinued.Visible = false;
            this.Discontinued.Width = 125;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "CategoryName";
            this.CategoryName.MinimumWidth = 6;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.Width = 125;
            // 
            // RetailPrice
            // 
            this.RetailPrice.DataPropertyName = "RetailPrice";
            dataGridViewCellStyle28.Format = "C2";
            dataGridViewCellStyle28.NullValue = null;
            this.RetailPrice.DefaultCellStyle = dataGridViewCellStyle28;
            this.RetailPrice.HeaderText = "RetailPrice";
            this.RetailPrice.MinimumWidth = 6;
            this.RetailPrice.Name = "RetailPrice";
            this.RetailPrice.ReadOnly = true;
            this.RetailPrice.Width = 125;
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
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(1324, 47);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(171, 37);
            this.btnHelp.TabIndex = 17;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmManagerPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 769);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnViewTransactions);
            this.Controls.Add(this.gbxCheckout);
            this.Controls.Add(this.gbxPromoCodes);
            this.Controls.Add(this.gbxCart);
            this.Controls.Add(this.gbxFiguresSearch);
            this.Controls.Add(this.gbxCustomerLookup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmManagerPOS";
            this.Text = "Manager POS";
            this.Load += new System.EventHandler(this.frmManagerPOS_Load);
            this.gbxCustomerLookup.ResumeLayout(false);
            this.gbxCustomerLookup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.gbxCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.gbxPromoCodes.ResumeLayout(false);
            this.gbxPromoCodes.PerformLayout();
            this.gbxCheckout.ResumeLayout(false);
            this.gbxCheckout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFigureImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.gbxFiguresSearch.ResumeLayout(false);
            this.gbxFiguresSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCustomerLookup;
        private System.Windows.Forms.Label lblSearchCustomer;
        private System.Windows.Forms.TextBox tbxSearchCustomer;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Label lblSelectedCustomer;
        private System.Windows.Forms.GroupBox gbxCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnUpdateQuantity;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.GroupBox gbxPromoCodes;
        private System.Windows.Forms.GroupBox gbxCheckout;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhonePrimary;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountDisabled;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPromoCode;
        private System.Windows.Forms.Button btnSearchFigures;
        private System.Windows.Forms.TextBox tbxSearchFigure;
        private System.Windows.Forms.Label lblSearchFigure;
        private System.Windows.Forms.PictureBox pbxFigureImage;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.GroupBox gbxFiguresSearch;
        private System.Windows.Forms.Label lblFigureQuantityLabelOnly;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantityOfFigure;
        private System.Windows.Forms.Label lblFigureOutOfStock;
        private System.Windows.Forms.ComboBox cbxPromoCode;
        private System.Windows.Forms.Button btnViewTransactions;
        private System.Windows.Forms.ComboBox cbxCategoryFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discontinued;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryID;
        private System.Windows.Forms.Button btnHelp;
    }
}