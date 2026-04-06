namespace Module2LogonView
{
    partial class frmRestockItem
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblCurrentQuantity = new System.Windows.Forms.Label();
            this.lblEnterQuantity = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(12, 20);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(0, 25);
            this.lblItemName.TabIndex = 0;
            // 
            // lblCurrentQuantity
            // 
            this.lblCurrentQuantity.AutoSize = true;
            this.lblCurrentQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentQuantity.Location = new System.Drawing.Point(12, 72);
            this.lblCurrentQuantity.Name = "lblCurrentQuantity";
            this.lblCurrentQuantity.Size = new System.Drawing.Size(0, 25);
            this.lblCurrentQuantity.TabIndex = 1;
            // 
            // lblEnterQuantity
            // 
            this.lblEnterQuantity.AutoSize = true;
            this.lblEnterQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterQuantity.Location = new System.Drawing.Point(12, 126);
            this.lblEnterQuantity.Name = "lblEnterQuantity";
            this.lblEnterQuantity.Size = new System.Drawing.Size(271, 25);
            this.lblEnterQuantity.TabIndex = 2;
            this.lblEnterQuantity.Text = "Enter quantity to add/subtract:";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(308, 129);
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(120, 22);
            this.numAmount.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(112, 228);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 41);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(289, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 41);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmRestockItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 308);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblEnterQuantity);
            this.Controls.Add(this.lblCurrentQuantity);
            this.Controls.Add(this.lblItemName);
            this.Name = "frmRestockItem";
            this.Text = "Restock Item";
            this.Load += new System.EventHandler(this.frmRestockItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblCurrentQuantity;
        private System.Windows.Forms.Label lblEnterQuantity;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}