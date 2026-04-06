namespace Module2LogonView
{
    partial class frmAddEditDiscounts
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
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblDiscriptionPercentage = new System.Windows.Forms.Label();
            this.lblDiscountLevel = new System.Windows.Forms.Label();
            this.lblDiscountCode = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.cbxDiscountType = new System.Windows.Forms.ComboBox();
            this.tbxDiscountCode = new System.Windows.Forms.TextBox();
            this.lblInventoryID = new System.Windows.Forms.Label();
            this.lblDiscountDollarAmount = new System.Windows.Forms.Label();
            this.lblDiscountType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.numDiscountLevel = new System.Windows.Forms.NumericUpDown();
            this.numDiscountPercentage = new System.Windows.Forms.NumericUpDown();
            this.numDiscountDollarAmount = new System.Windows.Forms.NumericUpDown();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.cbxInventoryID = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountDollarAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.Location = new System.Drawing.Point(530, 135);
            this.lblExpirationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(150, 25);
            this.lblExpirationDate.TabIndex = 149;
            this.lblExpirationDate.Text = "Expiration Date:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(575, 89);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(105, 25);
            this.lblStartDate.TabIndex = 148;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblDiscriptionPercentage
            // 
            this.lblDiscriptionPercentage.AutoSize = true;
            this.lblDiscriptionPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscriptionPercentage.Location = new System.Drawing.Point(13, 235);
            this.lblDiscriptionPercentage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscriptionPercentage.Name = "lblDiscriptionPercentage";
            this.lblDiscriptionPercentage.Size = new System.Drawing.Size(199, 25);
            this.lblDiscriptionPercentage.TabIndex = 147;
            this.lblDiscriptionPercentage.Text = "Discount Percentage:";
            // 
            // lblDiscountLevel
            // 
            this.lblDiscountLevel.AutoSize = true;
            this.lblDiscountLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountLevel.Location = new System.Drawing.Point(13, 129);
            this.lblDiscountLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscountLevel.Name = "lblDiscountLevel";
            this.lblDiscountLevel.Size = new System.Drawing.Size(146, 25);
            this.lblDiscountLevel.TabIndex = 146;
            this.lblDiscountLevel.Text = "Discount Level:";
            // 
            // lblDiscountCode
            // 
            this.lblDiscountCode.AutoSize = true;
            this.lblDiscountCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountCode.Location = new System.Drawing.Point(13, 22);
            this.lblDiscountCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscountCode.Name = "lblDiscountCode";
            this.lblDiscountCode.Size = new System.Drawing.Size(147, 25);
            this.lblDiscountCode.TabIndex = 145;
            this.lblDiscountCode.Text = "Discount Code:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(136, 75);
            this.tbxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(414, 22);
            this.tbxDescription.TabIndex = 123;
            // 
            // cbxDiscountType
            // 
            this.cbxDiscountType.FormattingEnabled = true;
            this.cbxDiscountType.Location = new System.Drawing.Point(168, 185);
            this.cbxDiscountType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDiscountType.Name = "cbxDiscountType";
            this.cbxDiscountType.Size = new System.Drawing.Size(160, 24);
            this.cbxDiscountType.TabIndex = 119;
            this.cbxDiscountType.SelectedIndexChanged += new System.EventHandler(this.cbxDiscountType_SelectedIndexChanged);
            // 
            // tbxDiscountCode
            // 
            this.tbxDiscountCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDiscountCode.Location = new System.Drawing.Point(168, 24);
            this.tbxDiscountCode.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDiscountCode.Name = "tbxDiscountCode";
            this.tbxDiscountCode.Size = new System.Drawing.Size(176, 23);
            this.tbxDiscountCode.TabIndex = 121;
            // 
            // lblInventoryID
            // 
            this.lblInventoryID.AutoSize = true;
            this.lblInventoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryID.Location = new System.Drawing.Point(578, 189);
            this.lblInventoryID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInventoryID.Name = "lblInventoryID";
            this.lblInventoryID.Size = new System.Drawing.Size(122, 25);
            this.lblInventoryID.TabIndex = 126;
            this.lblInventoryID.Text = "Inventory ID:";
            // 
            // lblDiscountDollarAmount
            // 
            this.lblDiscountDollarAmount.AutoSize = true;
            this.lblDiscountDollarAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountDollarAmount.Location = new System.Drawing.Point(478, 24);
            this.lblDiscountDollarAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscountDollarAmount.Name = "lblDiscountDollarAmount";
            this.lblDiscountDollarAmount.Size = new System.Drawing.Size(222, 25);
            this.lblDiscountDollarAmount.TabIndex = 124;
            this.lblDiscountDollarAmount.Text = "Discount Dollar Amount:";
            // 
            // lblDiscountType
            // 
            this.lblDiscountType.AutoSize = true;
            this.lblDiscountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountType.Location = new System.Drawing.Point(13, 184);
            this.lblDiscountType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscountType.Name = "lblDiscountType";
            this.lblDiscountType.Size = new System.Drawing.Size(144, 25);
            this.lblDiscountType.TabIndex = 122;
            this.lblDiscountType.Text = "Discount Type:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(13, 75);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(115, 25);
            this.lblDescription.TabIndex = 120;
            this.lblDescription.Text = "Description:";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(297, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 40);
            this.btnSave.TabIndex = 152;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numDiscountLevel
            // 
            this.numDiscountLevel.Location = new System.Drawing.Point(166, 129);
            this.numDiscountLevel.Name = "numDiscountLevel";
            this.numDiscountLevel.Size = new System.Drawing.Size(120, 22);
            this.numDiscountLevel.TabIndex = 153;
            this.numDiscountLevel.ValueChanged += new System.EventHandler(this.numDiscountLevel_ValueChanged);
            // 
            // numDiscountPercentage
            // 
            this.numDiscountPercentage.Location = new System.Drawing.Point(239, 240);
            this.numDiscountPercentage.Name = "numDiscountPercentage";
            this.numDiscountPercentage.Size = new System.Drawing.Size(120, 22);
            this.numDiscountPercentage.TabIndex = 154;
            // 
            // numDiscountDollarAmount
            // 
            this.numDiscountDollarAmount.Location = new System.Drawing.Point(726, 22);
            this.numDiscountDollarAmount.Name = "numDiscountDollarAmount";
            this.numDiscountDollarAmount.Size = new System.Drawing.Size(120, 22);
            this.numDiscountDollarAmount.TabIndex = 155;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(687, 92);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDate.TabIndex = 156;
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Location = new System.Drawing.Point(687, 138);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(200, 22);
            this.dtpExpirationDate.TabIndex = 157;
            // 
            // cbxInventoryID
            // 
            this.cbxInventoryID.FormattingEnabled = true;
            this.cbxInventoryID.Location = new System.Drawing.Point(707, 188);
            this.cbxInventoryID.Name = "cbxInventoryID";
            this.cbxInventoryID.Size = new System.Drawing.Size(121, 24);
            this.cbxInventoryID.TabIndex = 158;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(568, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 40);
            this.btnClose.TabIndex = 159;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddEditDiscounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 524);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbxInventoryID);
            this.Controls.Add(this.dtpExpirationDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.numDiscountDollarAmount);
            this.Controls.Add(this.numDiscountPercentage);
            this.Controls.Add(this.numDiscountLevel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblExpirationDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblDiscriptionPercentage);
            this.Controls.Add(this.lblDiscountLevel);
            this.Controls.Add(this.lblDiscountCode);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.cbxDiscountType);
            this.Controls.Add(this.tbxDiscountCode);
            this.Controls.Add(this.lblInventoryID);
            this.Controls.Add(this.lblDiscountDollarAmount);
            this.Controls.Add(this.lblDiscountType);
            this.Controls.Add(this.lblDescription);
            this.Name = "frmAddEditDiscounts";
            this.Text = "Add/Edit Discounts";
            this.Load += new System.EventHandler(this.frmAddEditDiscounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountDollarAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblDiscriptionPercentage;
        private System.Windows.Forms.Label lblDiscountLevel;
        private System.Windows.Forms.Label lblDiscountCode;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.ComboBox cbxDiscountType;
        private System.Windows.Forms.TextBox tbxDiscountCode;
        private System.Windows.Forms.Label lblInventoryID;
        private System.Windows.Forms.Label lblDiscountDollarAmount;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numDiscountLevel;
        private System.Windows.Forms.NumericUpDown numDiscountPercentage;
        private System.Windows.Forms.NumericUpDown numDiscountDollarAmount;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.ComboBox cbxInventoryID;
        private System.Windows.Forms.Button btnClose;
    }
}