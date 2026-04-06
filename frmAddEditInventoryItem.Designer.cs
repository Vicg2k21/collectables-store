namespace Module2LogonView
{
    partial class frmAddEditInventoryItem
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
            this.tbxItemName = new System.Windows.Forms.TextBox();
            this.tbxItemDescription = new System.Windows.Forms.TextBox();
            this.cbxCategoryID = new System.Windows.Forms.ComboBox();
            this.numRetailPrice = new System.Windows.Forms.NumericUpDown();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.numRestockThreshold = new System.Windows.Forms.NumericUpDown();
            this.ckxDiscontinued = new System.Windows.Forms.CheckBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.lblRetailPrice = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblRestockThreshold = new System.Windows.Forms.Label();
            this.lblDiscontinued = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbxFigureImage = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRetailPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestockThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFigureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxItemName
            // 
            this.tbxItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxItemName.Location = new System.Drawing.Point(140, 14);
            this.tbxItemName.Name = "tbxItemName";
            this.tbxItemName.Size = new System.Drawing.Size(747, 30);
            this.tbxItemName.TabIndex = 0;
            // 
            // tbxItemDescription
            // 
            this.tbxItemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxItemDescription.Location = new System.Drawing.Point(190, 57);
            this.tbxItemDescription.Name = "tbxItemDescription";
            this.tbxItemDescription.Size = new System.Drawing.Size(772, 30);
            this.tbxItemDescription.TabIndex = 1;
            // 
            // cbxCategoryID
            // 
            this.cbxCategoryID.FormattingEnabled = true;
            this.cbxCategoryID.Location = new System.Drawing.Point(168, 113);
            this.cbxCategoryID.Name = "cbxCategoryID";
            this.cbxCategoryID.Size = new System.Drawing.Size(168, 24);
            this.cbxCategoryID.TabIndex = 2;
            // 
            // numRetailPrice
            // 
            this.numRetailPrice.DecimalPlaces = 2;
            this.numRetailPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numRetailPrice.Location = new System.Drawing.Point(168, 166);
            this.numRetailPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRetailPrice.Name = "numRetailPrice";
            this.numRetailPrice.Size = new System.Drawing.Size(120, 22);
            this.numRetailPrice.TabIndex = 3;
            // 
            // numCost
            // 
            this.numCost.DecimalPlaces = 2;
            this.numCost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCost.Location = new System.Drawing.Point(109, 216);
            this.numCost.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCost.Name = "numCost";
            this.numCost.Size = new System.Drawing.Size(120, 22);
            this.numCost.TabIndex = 4;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(131, 284);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 22);
            this.numQuantity.TabIndex = 5;
            // 
            // numRestockThreshold
            // 
            this.numRestockThreshold.Location = new System.Drawing.Point(216, 340);
            this.numRestockThreshold.Name = "numRestockThreshold";
            this.numRestockThreshold.Size = new System.Drawing.Size(120, 22);
            this.numRestockThreshold.TabIndex = 6;
            // 
            // ckxDiscontinued
            // 
            this.ckxDiscontinued.AutoSize = true;
            this.ckxDiscontinued.Location = new System.Drawing.Point(168, 414);
            this.ckxDiscontinued.Name = "ckxDiscontinued";
            this.ckxDiscontinued.Size = new System.Drawing.Size(107, 20);
            this.ckxDiscontinued.TabIndex = 8;
            this.ckxDiscontinued.Text = "Discontinued";
            this.ckxDiscontinued.UseVisualStyleBackColor = true;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(12, 17);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(112, 25);
            this.lblItemName.TabIndex = 9;
            this.lblItemName.Text = "Item Name:";
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDescription.Location = new System.Drawing.Point(12, 62);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(157, 25);
            this.lblItemDescription.TabIndex = 10;
            this.lblItemDescription.Text = "Item Description:";
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.AutoSize = true;
            this.lblCategoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryID.Location = new System.Drawing.Point(12, 109);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(122, 25);
            this.lblCategoryID.TabIndex = 11;
            this.lblCategoryID.Text = "Category ID:";
            // 
            // lblRetailPrice
            // 
            this.lblRetailPrice.AutoSize = true;
            this.lblRetailPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetailPrice.Location = new System.Drawing.Point(12, 161);
            this.lblRetailPrice.Name = "lblRetailPrice";
            this.lblRetailPrice.Size = new System.Drawing.Size(115, 25);
            this.lblRetailPrice.TabIndex = 12;
            this.lblRetailPrice.Text = "Retail Price:";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(12, 213);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(59, 25);
            this.lblCost.TabIndex = 13;
            this.lblCost.Text = "Cost:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(12, 279);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(91, 25);
            this.lblQuantity.TabIndex = 14;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lblRestockThreshold
            // 
            this.lblRestockThreshold.AutoSize = true;
            this.lblRestockThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestockThreshold.Location = new System.Drawing.Point(15, 337);
            this.lblRestockThreshold.Name = "lblRestockThreshold";
            this.lblRestockThreshold.Size = new System.Drawing.Size(181, 25);
            this.lblRestockThreshold.TabIndex = 15;
            this.lblRestockThreshold.Text = "Restock Threshold:";
            // 
            // lblDiscontinued
            // 
            this.lblDiscontinued.AutoSize = true;
            this.lblDiscontinued.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscontinued.Location = new System.Drawing.Point(15, 409);
            this.lblDiscontinued.Name = "lblDiscontinued";
            this.lblDiscontinued.Size = new System.Drawing.Size(131, 25);
            this.lblDiscontinued.TabIndex = 17;
            this.lblDiscontinued.Text = "Discontinued:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(644, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 36);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(864, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 36);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbxFigureImage
            // 
            this.pbxFigureImage.Location = new System.Drawing.Point(551, 109);
            this.pbxFigureImage.Name = "pbxFigureImage";
            this.pbxFigureImage.Size = new System.Drawing.Size(269, 241);
            this.pbxFigureImage.TabIndex = 20;
            this.pbxFigureImage.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(826, 201);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(118, 50);
            this.btnUploadImage.TabIndex = 21;
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // frmAddEditInventoryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 493);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.pbxFigureImage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDiscontinued);
            this.Controls.Add(this.lblRestockThreshold);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblRetailPrice);
            this.Controls.Add(this.lblCategoryID);
            this.Controls.Add(this.lblItemDescription);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.ckxDiscontinued);
            this.Controls.Add(this.numRestockThreshold);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.numCost);
            this.Controls.Add(this.numRetailPrice);
            this.Controls.Add(this.cbxCategoryID);
            this.Controls.Add(this.tbxItemDescription);
            this.Controls.Add(this.tbxItemName);
            this.Name = "frmAddEditInventoryItem";
            this.Text = "Add/Edit Inventory Item";
            this.Load += new System.EventHandler(this.frmAddEditInventoryItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRetailPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestockThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFigureImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxItemName;
        private System.Windows.Forms.TextBox tbxItemDescription;
        private System.Windows.Forms.ComboBox cbxCategoryID;
        private System.Windows.Forms.NumericUpDown numRetailPrice;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numRestockThreshold;
        private System.Windows.Forms.CheckBox ckxDiscontinued;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.Label lblRetailPrice;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblRestockThreshold;
        private System.Windows.Forms.Label lblDiscontinued;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbxFigureImage;
        private System.Windows.Forms.Button btnUploadImage;
    }
}