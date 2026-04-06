namespace Module2LogonView
{
    partial class frmCart
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
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tbxPromoCode = new System.Windows.Forms.TextBox();
            this.btnApplyPromo = new System.Windows.Forms.Button();
            this.btnUpdateQuantity = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblPromoCodeMessage = new System.Windows.Forms.Label();
            this.btnContinueShopping = new System.Windows.Forms.Button();
            this.lblTax = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(12, 12);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(337, 171);
            this.dgvCart.TabIndex = 0;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(416, 12);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(69, 20);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(413, 46);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(72, 20);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Discount";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(441, 113);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 20);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total";
            // 
            // tbxPromoCode
            // 
            this.tbxPromoCode.Location = new System.Drawing.Point(491, 157);
            this.tbxPromoCode.Name = "tbxPromoCode";
            this.tbxPromoCode.Size = new System.Drawing.Size(100, 20);
            this.tbxPromoCode.TabIndex = 4;
            // 
            // btnApplyPromo
            // 
            this.btnApplyPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyPromo.Location = new System.Drawing.Point(363, 147);
            this.btnApplyPromo.Name = "btnApplyPromo";
            this.btnApplyPromo.Size = new System.Drawing.Size(122, 36);
            this.btnApplyPromo.TabIndex = 5;
            this.btnApplyPromo.Text = "Apply Promo";
            this.btnApplyPromo.UseVisualStyleBackColor = true;
            this.btnApplyPromo.Click += new System.EventHandler(this.btnApplyPromo_Click);
            // 
            // btnUpdateQuantity
            // 
            this.btnUpdateQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateQuantity.Location = new System.Drawing.Point(43, 224);
            this.btnUpdateQuantity.Name = "btnUpdateQuantity";
            this.btnUpdateQuantity.Size = new System.Drawing.Size(133, 36);
            this.btnUpdateQuantity.TabIndex = 6;
            this.btnUpdateQuantity.Text = "Update Quantity";
            this.btnUpdateQuantity.UseVisualStyleBackColor = true;
            this.btnUpdateQuantity.Click += new System.EventHandler(this.btnUpdateQuantity_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.Location = new System.Drawing.Point(201, 228);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(128, 28);
            this.btnRemoveItem.TabIndex = 7;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnClearCart
            // 
            this.btnClearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCart.Location = new System.Drawing.Point(284, 277);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(100, 28);
            this.btnClearCart.TabIndex = 8;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.Location = new System.Drawing.Point(599, 267);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(114, 38);
            this.btnCheckout.TabIndex = 9;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // lblPromoCodeMessage
            // 
            this.lblPromoCodeMessage.AutoSize = true;
            this.lblPromoCodeMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromoCodeMessage.Location = new System.Drawing.Point(359, 196);
            this.lblPromoCodeMessage.Name = "lblPromoCodeMessage";
            this.lblPromoCodeMessage.Size = new System.Drawing.Size(166, 20);
            this.lblPromoCodeMessage.TabIndex = 10;
            this.lblPromoCodeMessage.Text = "Promo Code Message";
            // 
            // btnContinueShopping
            // 
            this.btnContinueShopping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinueShopping.Location = new System.Drawing.Point(43, 277);
            this.btnContinueShopping.Name = "btnContinueShopping";
            this.btnContinueShopping.Size = new System.Drawing.Size(177, 34);
            this.btnContinueShopping.TabIndex = 11;
            this.btnContinueShopping.Text = "Continue Shopping";
            this.btnContinueShopping.UseVisualStyleBackColor = true;
            this.btnContinueShopping.Click += new System.EventHandler(this.btnContinueShopping_Click);
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(403, 82);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(82, 20);
            this.lblTax.TabIndex = 12;
            this.lblTax.Text = "Tax: $0.00";
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(756, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(128, 30);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 353);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.btnContinueShopping);
            this.Controls.Add(this.lblPromoCodeMessage);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnUpdateQuantity);
            this.Controls.Add(this.btnApplyPromo);
            this.Controls.Add(this.tbxPromoCode);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.dgvCart);
            this.Name = "frmCart";
            this.Text = "Shopping Cart";
            this.Load += new System.EventHandler(this.frmCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox tbxPromoCode;
        private System.Windows.Forms.Button btnApplyPromo;
        private System.Windows.Forms.Button btnUpdateQuantity;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblPromoCodeMessage;
        private System.Windows.Forms.Button btnContinueShopping;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Button btnHelp;
    }
}