using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2LogonView
{
    /// <summary>
    /// Represents the main form for manager users.
    /// Allows managers to access inventory management, account management,
    /// discount management, reports, and the point-of-sale system.
    /// </summary>
    public partial class frmManager : Form
    {
        /// <summary>
        /// The ID of the currently logged-in manager.
        /// </summary>
        private int _personID;

        /// <summary>
        /// Initializes the main form used by managers.
        /// </summary>
        /// <param name="personID">The ID of the logged-in manager.</param>
        public frmManager(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        /// <summary>
        /// Opens the inventory management form.
        /// </summary>
        private void btnManageInventory_Click(object sender, EventArgs e)
        {
            frmManagerInventory manInv = new frmManagerInventory();
            manInv.ShowDialog();
        }

        /// <summary>
        /// Opens the account management form for managing employees, customers and managers.
        /// </summary>
        private void btnManageAccounts_Click(object sender, EventArgs e)
        {
            // Pass the logged-in manager ID to frmManageAccounts
            frmManageAccounts accounts = new frmManageAccounts(_personID);
            accounts.ShowDialog();
        }

        /// <summary>
        /// Opens the discount management form where promotional discounts can be created or modified.
        /// </summary>
        private void btnManageDiscounts_Click(object sender, EventArgs e)
        {
            frmManagerDiscounts discount = new frmManagerDiscounts();
            discount.ShowDialog();
        }

        /// <summary>
        /// Opens the form to view sales and inventory reports.
        /// </summary>
        private void btnReports_Click(object sender, EventArgs e)
        {
            frmManagerReports reportsForm = new frmManagerReports(_personID);
            reportsForm.ShowDialog();
        }

        /// <summary>
        /// Opens the manager point-of-sale (POS) interface.
        /// </summary>
        private void btnPOS_Click(object sender, EventArgs e)
        {
            frmManagerPOS pos = new frmManagerPOS(_personID);
            pos.ShowDialog();
        }

        private void frmManager_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Logs out the manager and closes the manager form,
        /// returning the user to the login form.
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Return to login screen
        }

        /// <summary>
        /// Opens the help form with assistance for the manager form.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("manager_main");
            help.ShowDialog();
        }
    }
}
