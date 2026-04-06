namespace Module2LogonView
{
    partial class frmFigureDetails
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
            this.pbxFigure = new System.Windows.Forms.PictureBox();
            this.lblNameOfFigure = new System.Windows.Forms.Label();
            this.lblFigureDescription = new System.Windows.Forms.Label();
            this.lblPriceOfFigure = new System.Windows.Forms.Label();
            this.lblQuantityOfFigure = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblNeedToLoginToBuy = new System.Windows.Forms.Label();
            this.btnLoginForGuests = new System.Windows.Forms.Button();
            this.lblFigureNameLabelOnly = new System.Windows.Forms.Label();
            this.lblDescriptionLabelOnly = new System.Windows.Forms.Label();
            this.lblFigurePriceLabelOnly = new System.Windows.Forms.Label();
            this.lblFigureQuantityLabelOnly = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFigure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxFigure
            // 
            this.pbxFigure.Location = new System.Drawing.Point(12, 12);
            this.pbxFigure.Name = "pbxFigure";
            this.pbxFigure.Size = new System.Drawing.Size(353, 212);
            this.pbxFigure.TabIndex = 0;
            this.pbxFigure.TabStop = false;
            // 
            // lblNameOfFigure
            // 
            this.lblNameOfFigure.AutoSize = true;
            this.lblNameOfFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOfFigure.Location = new System.Drawing.Point(504, 12);
            this.lblNameOfFigure.Name = "lblNameOfFigure";
            this.lblNameOfFigure.Size = new System.Drawing.Size(153, 20);
            this.lblNameOfFigure.TabIndex = 1;
            this.lblNameOfFigure.Text = "Figure Name Details";
            // 
            // lblFigureDescription
            // 
            this.lblFigureDescription.AutoSize = true;
            this.lblFigureDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureDescription.Location = new System.Drawing.Point(504, 83);
            this.lblFigureDescription.Name = "lblFigureDescription";
            this.lblFigureDescription.Size = new System.Drawing.Size(138, 20);
            this.lblFigureDescription.TabIndex = 2;
            this.lblFigureDescription.Text = "Figure Description";
            // 
            // lblPriceOfFigure
            // 
            this.lblPriceOfFigure.AutoSize = true;
            this.lblPriceOfFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceOfFigure.Location = new System.Drawing.Point(504, 142);
            this.lblPriceOfFigure.Name = "lblPriceOfFigure";
            this.lblPriceOfFigure.Size = new System.Drawing.Size(93, 20);
            this.lblPriceOfFigure.TabIndex = 3;
            this.lblPriceOfFigure.Text = "Figure Price";
            // 
            // lblQuantityOfFigure
            // 
            this.lblQuantityOfFigure.AutoSize = true;
            this.lblQuantityOfFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityOfFigure.Location = new System.Drawing.Point(504, 198);
            this.lblQuantityOfFigure.Name = "lblQuantityOfFigure";
            this.lblQuantityOfFigure.Size = new System.Drawing.Size(117, 20);
            this.lblQuantityOfFigure.TabIndex = 4;
            this.lblQuantityOfFigure.Text = "Figure Quantity";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.Location = new System.Drawing.Point(339, 333);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(104, 33);
            this.btnAddToCart.TabIndex = 5;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(555, 333);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(214, 33);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back to Figure Catalog";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(627, 198);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 20);
            this.numQuantity.TabIndex = 7;
            // 
            // lblNeedToLoginToBuy
            // 
            this.lblNeedToLoginToBuy.AutoSize = true;
            this.lblNeedToLoginToBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeedToLoginToBuy.ForeColor = System.Drawing.Color.Red;
            this.lblNeedToLoginToBuy.Location = new System.Drawing.Point(12, 248);
            this.lblNeedToLoginToBuy.Name = "lblNeedToLoginToBuy";
            this.lblNeedToLoginToBuy.Size = new System.Drawing.Size(0, 20);
            this.lblNeedToLoginToBuy.TabIndex = 8;
            // 
            // btnLoginForGuests
            // 
            this.btnLoginForGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginForGuests.Location = new System.Drawing.Point(110, 333);
            this.btnLoginForGuests.Name = "btnLoginForGuests";
            this.btnLoginForGuests.Size = new System.Drawing.Size(98, 33);
            this.btnLoginForGuests.TabIndex = 9;
            this.btnLoginForGuests.Text = "Login";
            this.btnLoginForGuests.UseVisualStyleBackColor = true;
            this.btnLoginForGuests.Click += new System.EventHandler(this.btnLoginForGuests_Click);
            // 
            // lblFigureNameLabelOnly
            // 
            this.lblFigureNameLabelOnly.AutoSize = true;
            this.lblFigureNameLabelOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureNameLabelOnly.Location = new System.Drawing.Point(382, 12);
            this.lblFigureNameLabelOnly.Name = "lblFigureNameLabelOnly";
            this.lblFigureNameLabelOnly.Size = new System.Drawing.Size(116, 20);
            this.lblFigureNameLabelOnly.TabIndex = 10;
            this.lblFigureNameLabelOnly.Text = "Figure Name:";
            // 
            // lblDescriptionLabelOnly
            // 
            this.lblDescriptionLabelOnly.AutoSize = true;
            this.lblDescriptionLabelOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionLabelOnly.Location = new System.Drawing.Point(393, 83);
            this.lblDescriptionLabelOnly.Name = "lblDescriptionLabelOnly";
            this.lblDescriptionLabelOnly.Size = new System.Drawing.Size(105, 20);
            this.lblDescriptionLabelOnly.TabIndex = 11;
            this.lblDescriptionLabelOnly.Text = "Description:";
            // 
            // lblFigurePriceLabelOnly
            // 
            this.lblFigurePriceLabelOnly.AutoSize = true;
            this.lblFigurePriceLabelOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigurePriceLabelOnly.Location = new System.Drawing.Point(438, 142);
            this.lblFigurePriceLabelOnly.Name = "lblFigurePriceLabelOnly";
            this.lblFigurePriceLabelOnly.Size = new System.Drawing.Size(54, 20);
            this.lblFigurePriceLabelOnly.TabIndex = 12;
            this.lblFigurePriceLabelOnly.Text = "Price:";
            // 
            // lblFigureQuantityLabelOnly
            // 
            this.lblFigureQuantityLabelOnly.AutoSize = true;
            this.lblFigureQuantityLabelOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFigureQuantityLabelOnly.Location = new System.Drawing.Point(414, 198);
            this.lblFigureQuantityLabelOnly.Name = "lblFigureQuantityLabelOnly";
            this.lblFigureQuantityLabelOnly.Size = new System.Drawing.Size(81, 20);
            this.lblFigureQuantityLabelOnly.TabIndex = 13;
            this.lblFigureQuantityLabelOnly.Text = "Quantity:";
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(641, 263);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(128, 30);
            this.btnHelp.TabIndex = 14;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmFigureDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 433);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblFigureQuantityLabelOnly);
            this.Controls.Add(this.lblFigurePriceLabelOnly);
            this.Controls.Add(this.lblDescriptionLabelOnly);
            this.Controls.Add(this.lblFigureNameLabelOnly);
            this.Controls.Add(this.btnLoginForGuests);
            this.Controls.Add(this.lblNeedToLoginToBuy);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblQuantityOfFigure);
            this.Controls.Add(this.lblPriceOfFigure);
            this.Controls.Add(this.lblFigureDescription);
            this.Controls.Add(this.lblNameOfFigure);
            this.Controls.Add(this.pbxFigure);
            this.Name = "frmFigureDetails";
            this.Text = "Figure Details";
            this.Load += new System.EventHandler(this.frmFigureDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFigure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxFigure;
        private System.Windows.Forms.Label lblNameOfFigure;
        private System.Windows.Forms.Label lblFigureDescription;
        private System.Windows.Forms.Label lblPriceOfFigure;
        private System.Windows.Forms.Label lblQuantityOfFigure;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblNeedToLoginToBuy;
        private System.Windows.Forms.Button btnLoginForGuests;
        private System.Windows.Forms.Label lblFigureNameLabelOnly;
        private System.Windows.Forms.Label lblDescriptionLabelOnly;
        private System.Windows.Forms.Label lblFigurePriceLabelOnly;
        private System.Windows.Forms.Label lblFigureQuantityLabelOnly;
        private System.Windows.Forms.Button btnHelp;
    }
}