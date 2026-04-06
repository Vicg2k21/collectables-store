namespace Module2LogonView
{
    partial class frmCheckout
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
            this.gbxPaymentInformation = new System.Windows.Forms.GroupBox();
            this.mtbCVV = new System.Windows.Forms.MaskedTextBox();
            this.mtbExpirationDate = new System.Windows.Forms.MaskedTextBox();
            this.mtbCardNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblCVV = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.tbxCardName = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.lblNameOnCard = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblTax = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.gbxPaymentInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPaymentInformation
            // 
            this.gbxPaymentInformation.Controls.Add(this.mtbCVV);
            this.gbxPaymentInformation.Controls.Add(this.mtbExpirationDate);
            this.gbxPaymentInformation.Controls.Add(this.mtbCardNumber);
            this.gbxPaymentInformation.Controls.Add(this.lblCVV);
            this.gbxPaymentInformation.Controls.Add(this.lblExpirationDate);
            this.gbxPaymentInformation.Controls.Add(this.tbxCardName);
            this.gbxPaymentInformation.Controls.Add(this.lblCardNumber);
            this.gbxPaymentInformation.Controls.Add(this.lblNameOnCard);
            this.gbxPaymentInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPaymentInformation.Location = new System.Drawing.Point(414, 12);
            this.gbxPaymentInformation.Name = "gbxPaymentInformation";
            this.gbxPaymentInformation.Size = new System.Drawing.Size(380, 190);
            this.gbxPaymentInformation.TabIndex = 0;
            this.gbxPaymentInformation.TabStop = false;
            this.gbxPaymentInformation.Text = "Payment Information";
            // 
            // mtbCVV
            // 
            this.mtbCVV.Location = new System.Drawing.Point(139, 128);
            this.mtbCVV.Mask = "000";
            this.mtbCVV.Name = "mtbCVV";
            this.mtbCVV.Size = new System.Drawing.Size(40, 26);
            this.mtbCVV.TabIndex = 11;
            // 
            // mtbExpirationDate
            // 
            this.mtbExpirationDate.Location = new System.Drawing.Point(139, 96);
            this.mtbExpirationDate.Mask = "00/00";
            this.mtbExpirationDate.Name = "mtbExpirationDate";
            this.mtbExpirationDate.Size = new System.Drawing.Size(52, 26);
            this.mtbExpirationDate.TabIndex = 10;
            // 
            // mtbCardNumber
            // 
            this.mtbCardNumber.Location = new System.Drawing.Point(139, 64);
            this.mtbCardNumber.Mask = "0000-0000-0000-0000";
            this.mtbCardNumber.Name = "mtbCardNumber";
            this.mtbCardNumber.Size = new System.Drawing.Size(173, 26);
            this.mtbCardNumber.TabIndex = 9;
            // 
            // lblCVV
            // 
            this.lblCVV.AutoSize = true;
            this.lblCVV.Location = new System.Drawing.Point(87, 128);
            this.lblCVV.Name = "lblCVV";
            this.lblCVV.Size = new System.Drawing.Size(46, 20);
            this.lblCVV.TabIndex = 6;
            this.lblCVV.Text = "CVV:";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(11, 96);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(122, 20);
            this.lblExpirationDate.TabIndex = 5;
            this.lblExpirationDate.Text = "Expiration Date:";
            // 
            // tbxCardName
            // 
            this.tbxCardName.Location = new System.Drawing.Point(139, 28);
            this.tbxCardName.Name = "tbxCardName";
            this.tbxCardName.Size = new System.Drawing.Size(100, 26);
            this.tbxCardName.TabIndex = 3;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(26, 62);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(107, 20);
            this.lblCardNumber.TabIndex = 2;
            this.lblCardNumber.Text = "Card Number:";
            // 
            // lblNameOnCard
            // 
            this.lblNameOnCard.AutoSize = true;
            this.lblNameOnCard.Location = new System.Drawing.Point(15, 31);
            this.lblNameOnCard.Name = "lblNameOnCard";
            this.lblNameOnCard.Size = new System.Drawing.Size(118, 20);
            this.lblNameOnCard.TabIndex = 1;
            this.lblNameOnCard.Text = "Name On Card:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(12, 9);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(73, 20);
            this.lblSubtotal.TabIndex = 9;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(12, 43);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(76, 20);
            this.lblDiscount.TabIndex = 10;
            this.lblDiscount.Text = "Discount:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 114);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 20);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(318, 229);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(163, 32);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "Confirm Purchase";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(12, 79);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(82, 20);
            this.lblTax.TabIndex = 14;
            this.lblTax.Text = "Tax: $0.00";
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(12, 231);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(128, 30);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 273);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.gbxPaymentInformation);
            this.Name = "frmCheckout";
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.frmCheckout_Load);
            this.gbxPaymentInformation.ResumeLayout(false);
            this.gbxPaymentInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPaymentInformation;
        private System.Windows.Forms.Label lblNameOnCard;
        private System.Windows.Forms.Label lblCVV;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.TextBox tbxCardName;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.MaskedTextBox mtbCVV;
        private System.Windows.Forms.MaskedTextBox mtbExpirationDate;
        private System.Windows.Forms.MaskedTextBox mtbCardNumber;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Button btnHelp;
    }
}