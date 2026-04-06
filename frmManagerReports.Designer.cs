namespace Module2LogonView
{
    partial class frmManagerReports
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
            this.gbxReportsType = new System.Windows.Forms.GroupBox();
            this.rbInventory = new System.Windows.Forms.RadioButton();
            this.rbSalesTotals = new System.Windows.Forms.RadioButton();
            this.gbxSalesFilters = new System.Windows.Forms.GroupBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.cbxSalesView = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblReportView = new System.Windows.Forms.Label();
            this.gbxInventoryItems = new System.Windows.Forms.GroupBox();
            this.rbAllIncludingDiscontinued = new System.Windows.Forms.RadioButton();
            this.rbNeedRestock = new System.Windows.Forms.RadioButton();
            this.rbAvailable = new System.Windows.Forms.RadioButton();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.gbxReportsType.SuspendLayout();
            this.gbxSalesFilters.SuspendLayout();
            this.gbxInventoryItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxReportsType
            // 
            this.gbxReportsType.Controls.Add(this.rbInventory);
            this.gbxReportsType.Controls.Add(this.rbSalesTotals);
            this.gbxReportsType.Location = new System.Drawing.Point(44, 41);
            this.gbxReportsType.Name = "gbxReportsType";
            this.gbxReportsType.Size = new System.Drawing.Size(302, 188);
            this.gbxReportsType.TabIndex = 0;
            this.gbxReportsType.TabStop = false;
            this.gbxReportsType.Text = "Report Type";
            // 
            // rbInventory
            // 
            this.rbInventory.AutoSize = true;
            this.rbInventory.Location = new System.Drawing.Point(25, 108);
            this.rbInventory.Name = "rbInventory";
            this.rbInventory.Size = new System.Drawing.Size(82, 20);
            this.rbInventory.TabIndex = 1;
            this.rbInventory.TabStop = true;
            this.rbInventory.Text = "Inventory";
            this.rbInventory.UseVisualStyleBackColor = true;
            this.rbInventory.CheckedChanged += new System.EventHandler(this.rbInventory_CheckedChanged);
            // 
            // rbSalesTotals
            // 
            this.rbSalesTotals.AutoSize = true;
            this.rbSalesTotals.Location = new System.Drawing.Point(25, 42);
            this.rbSalesTotals.Name = "rbSalesTotals";
            this.rbSalesTotals.Size = new System.Drawing.Size(104, 20);
            this.rbSalesTotals.TabIndex = 0;
            this.rbSalesTotals.TabStop = true;
            this.rbSalesTotals.Text = "Sales Totals";
            this.rbSalesTotals.UseVisualStyleBackColor = true;
            this.rbSalesTotals.CheckedChanged += new System.EventHandler(this.rbSalesTotals_CheckedChanged);
            // 
            // gbxSalesFilters
            // 
            this.gbxSalesFilters.Controls.Add(this.lblEndDate);
            this.gbxSalesFilters.Controls.Add(this.cbxSalesView);
            this.gbxSalesFilters.Controls.Add(this.lblStartDate);
            this.gbxSalesFilters.Controls.Add(this.dtpEndDate);
            this.gbxSalesFilters.Controls.Add(this.dtpStartDate);
            this.gbxSalesFilters.Controls.Add(this.lblReportView);
            this.gbxSalesFilters.Location = new System.Drawing.Point(402, 41);
            this.gbxSalesFilters.Name = "gbxSalesFilters";
            this.gbxSalesFilters.Size = new System.Drawing.Size(492, 256);
            this.gbxSalesFilters.TabIndex = 1;
            this.gbxSalesFilters.TabStop = false;
            this.gbxSalesFilters.Text = "Sales Filters";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(259, 128);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(63, 16);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "End Date";
            // 
            // cbxSalesView
            // 
            this.cbxSalesView.FormattingEnabled = true;
            this.cbxSalesView.Location = new System.Drawing.Point(34, 164);
            this.cbxSalesView.Name = "cbxSalesView";
            this.cbxSalesView.Size = new System.Drawing.Size(157, 24);
            this.cbxSalesView.TabIndex = 4;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(259, 79);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(66, 16);
            this.lblStartDate.TabIndex = 3;
            this.lblStartDate.Text = "Start Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(34, 123);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 22);
            this.dtpEndDate.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(34, 79);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // lblReportView
            // 
            this.lblReportView.AutoSize = true;
            this.lblReportView.Location = new System.Drawing.Point(31, 42);
            this.lblReportView.Name = "lblReportView";
            this.lblReportView.Size = new System.Drawing.Size(80, 16);
            this.lblReportView.TabIndex = 0;
            this.lblReportView.Text = "Report View";
            // 
            // gbxInventoryItems
            // 
            this.gbxInventoryItems.Controls.Add(this.rbAllIncludingDiscontinued);
            this.gbxInventoryItems.Controls.Add(this.rbNeedRestock);
            this.gbxInventoryItems.Controls.Add(this.rbAvailable);
            this.gbxInventoryItems.Location = new System.Drawing.Point(972, 36);
            this.gbxInventoryItems.Name = "gbxInventoryItems";
            this.gbxInventoryItems.Size = new System.Drawing.Size(538, 261);
            this.gbxInventoryItems.TabIndex = 2;
            this.gbxInventoryItems.TabStop = false;
            this.gbxInventoryItems.Text = "Inventory Filters";
            // 
            // rbAllIncludingDiscontinued
            // 
            this.rbAllIncludingDiscontinued.AutoSize = true;
            this.rbAllIncludingDiscontinued.Location = new System.Drawing.Point(35, 153);
            this.rbAllIncludingDiscontinued.Name = "rbAllIncludingDiscontinued";
            this.rbAllIncludingDiscontinued.Size = new System.Drawing.Size(180, 20);
            this.rbAllIncludingDiscontinued.TabIndex = 2;
            this.rbAllIncludingDiscontinued.TabStop = true;
            this.rbAllIncludingDiscontinued.Text = "All Including Discontinued";
            this.rbAllIncludingDiscontinued.UseVisualStyleBackColor = true;
            // 
            // rbNeedRestock
            // 
            this.rbNeedRestock.AutoSize = true;
            this.rbNeedRestock.Location = new System.Drawing.Point(35, 99);
            this.rbNeedRestock.Name = "rbNeedRestock";
            this.rbNeedRestock.Size = new System.Drawing.Size(115, 20);
            this.rbNeedRestock.TabIndex = 1;
            this.rbNeedRestock.TabStop = true;
            this.rbNeedRestock.Text = "Need Restock";
            this.rbNeedRestock.UseVisualStyleBackColor = true;
            // 
            // rbAvailable
            // 
            this.rbAvailable.AutoSize = true;
            this.rbAvailable.Location = new System.Drawing.Point(35, 47);
            this.rbAvailable.Name = "rbAvailable";
            this.rbAvailable.Size = new System.Drawing.Size(85, 20);
            this.rbAvailable.TabIndex = 0;
            this.rbAvailable.TabStop = true;
            this.rbAvailable.Text = "Available";
            this.rbAvailable.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(700, 337);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(147, 35);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1364, 337);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 50);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(69, 333);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(171, 37);
            this.btnHelp.TabIndex = 19;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmManagerReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1614, 446);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.gbxInventoryItems);
            this.Controls.Add(this.gbxSalesFilters);
            this.Controls.Add(this.gbxReportsType);
            this.Name = "frmManagerReports";
            this.Text = "Manager Reports";
            this.Load += new System.EventHandler(this.frmManagerReports_Load);
            this.gbxReportsType.ResumeLayout(false);
            this.gbxReportsType.PerformLayout();
            this.gbxSalesFilters.ResumeLayout(false);
            this.gbxSalesFilters.PerformLayout();
            this.gbxInventoryItems.ResumeLayout(false);
            this.gbxInventoryItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxReportsType;
        private System.Windows.Forms.RadioButton rbInventory;
        private System.Windows.Forms.RadioButton rbSalesTotals;
        private System.Windows.Forms.GroupBox gbxSalesFilters;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblReportView;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.ComboBox cbxSalesView;
        private System.Windows.Forms.GroupBox gbxInventoryItems;
        private System.Windows.Forms.RadioButton rbAllIncludingDiscontinued;
        private System.Windows.Forms.RadioButton rbNeedRestock;
        private System.Windows.Forms.RadioButton rbAvailable;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHelp;
    }
}