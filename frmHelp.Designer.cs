namespace Module2LogonView
{
    partial class frmHelp
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
            this.tbxHelp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxHelp
            // 
            this.tbxHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHelp.Location = new System.Drawing.Point(12, 12);
            this.tbxHelp.Multiline = true;
            this.tbxHelp.Name = "tbxHelp";
            this.tbxHelp.ReadOnly = true;
            this.tbxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxHelp.Size = new System.Drawing.Size(737, 285);
            this.tbxHelp.TabIndex = 0;
            this.tbxHelp.TabStop = false;
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 309);
            this.Controls.Add(this.tbxHelp);
            this.Name = "frmHelp";
            this.Text = "frmHelp";
            this.Load += new System.EventHandler(this.frmHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxHelp;
    }
}