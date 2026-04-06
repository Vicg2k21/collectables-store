namespace Module2LogonView
{
    partial class frmManageManagers
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvManagers = new System.Windows.Forms.DataGridView();
            this.PersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhonePrimary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountDisabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddManager = new System.Windows.Forms.Button();
            this.btnEditManager = new System.Windows.Forms.Button();
            this.btnDisableManager = new System.Windows.Forms.Button();
            this.btnDeleteManager = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(206, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 37);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(24, 27);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(148, 22);
            this.tbxSearch.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(381, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 37);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvManagers
            // 
            this.dgvManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonID,
            this.LogonID,
            this.FirstName,
            this.LastName,
            this.Email,
            this.PhonePrimary,
            this.LogonName,
            this.AccountDisabled});
            this.dgvManagers.Location = new System.Drawing.Point(12, 60);
            this.dgvManagers.Name = "dgvManagers";
            this.dgvManagers.RowHeadersWidth = 51;
            this.dgvManagers.RowTemplate.Height = 24;
            this.dgvManagers.Size = new System.Drawing.Size(801, 378);
            this.dgvManagers.TabIndex = 3;
            this.dgvManagers.SelectionChanged += new System.EventHandler(this.dgvManagers_SelectionChanged);
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
            // btnAddManager
            // 
            this.btnAddManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddManager.Location = new System.Drawing.Point(36, 463);
            this.btnAddManager.Name = "btnAddManager";
            this.btnAddManager.Size = new System.Drawing.Size(173, 42);
            this.btnAddManager.TabIndex = 4;
            this.btnAddManager.Text = "Add Manager";
            this.btnAddManager.UseVisualStyleBackColor = true;
            this.btnAddManager.Click += new System.EventHandler(this.btnAddManager_Click);
            // 
            // btnEditManager
            // 
            this.btnEditManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditManager.Location = new System.Drawing.Point(306, 463);
            this.btnEditManager.Name = "btnEditManager";
            this.btnEditManager.Size = new System.Drawing.Size(173, 42);
            this.btnEditManager.TabIndex = 5;
            this.btnEditManager.Text = "Edit Manager";
            this.btnEditManager.UseVisualStyleBackColor = true;
            this.btnEditManager.Click += new System.EventHandler(this.btnEditManager_Click);
            // 
            // btnDisableManager
            // 
            this.btnDisableManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisableManager.Location = new System.Drawing.Point(555, 463);
            this.btnDisableManager.Name = "btnDisableManager";
            this.btnDisableManager.Size = new System.Drawing.Size(258, 42);
            this.btnDisableManager.TabIndex = 6;
            this.btnDisableManager.Text = "Disable Manager";
            this.btnDisableManager.UseVisualStyleBackColor = true;
            this.btnDisableManager.Click += new System.EventHandler(this.btnDisableManager_Click);
            // 
            // btnDeleteManager
            // 
            this.btnDeleteManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteManager.Location = new System.Drawing.Point(161, 541);
            this.btnDeleteManager.Name = "btnDeleteManager";
            this.btnDeleteManager.Size = new System.Drawing.Size(173, 42);
            this.btnDeleteManager.TabIndex = 7;
            this.btnDeleteManager.Text = "Delete Manager";
            this.btnDeleteManager.UseVisualStyleBackColor = true;
            this.btnDeleteManager.Click += new System.EventHandler(this.btnDeleteManager_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1021, 576);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 50);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(908, 60);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(171, 37);
            this.btnHelp.TabIndex = 18;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmManageManagers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 638);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteManager);
            this.Controls.Add(this.btnDisableManager);
            this.Controls.Add(this.btnEditManager);
            this.Controls.Add(this.btnAddManager);
            this.Controls.Add(this.dgvManagers);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmManageManagers";
            this.Text = "Manage Managers";
            this.Load += new System.EventHandler(this.frmManageManagers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvManagers;
        private System.Windows.Forms.Button btnAddManager;
        private System.Windows.Forms.Button btnEditManager;
        private System.Windows.Forms.Button btnDisableManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhonePrimary;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountDisabled;
        private System.Windows.Forms.Button btnDeleteManager;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHelp;
    }
}