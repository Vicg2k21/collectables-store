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
    /// Provides a management interface for managers to
    /// access account management features including managers,
    /// customers, and employees.
    /// </summary>
    public partial class frmManageAccounts : Form
    {
        /// <summary>
        /// Stores the PersonID of the currently logged-in manager.
        /// This value is passed to other management forms when needed.
        /// </summary>
        private int loggedInPersonID; // set this when logging in

        /// <summary>
        /// Initializes the Manage Accounts form and stores
        /// the logged-in manager's PersonID.
        /// </summary>
        /// <param name="loggedInPersonID">
        /// The PersonID of the currently authenticated manager.
        /// </param>
        public frmManageAccounts(int loggedInPersonID)
        {
            InitializeComponent();
            this.loggedInPersonID = loggedInPersonID;
        }

        // <summary>
        /// Opens the Manage Managers form and passes the
        /// logged-in manager's PersonID.
        /// </summary>
        private void btnManageManagers_Click(object sender, EventArgs e)
        {
            // Pass the logged-in manager's PersonID
            frmManageManagers manageManagersForm = new frmManageManagers(loggedInPersonID);
            manageManagersForm.ShowDialog();
        }

        /// <summary>
        /// Opens the Manage Customers form.
        /// </summary>
        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            frmManageCustomers manageCustomersForm = new frmManageCustomers();
            manageCustomersForm.ShowDialog();
        }

        /// <summary>
        /// Closes the Manage Accounts form and returns
        /// to the previous manager form.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();  // Return to Manager Screen
        }

        /// <summary>
        /// Opens the help form for account management assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("manage_accounts");
            help.ShowDialog();
        }

        /// <summary>
        /// Opens the Manage Employees form.
        /// </summary>
        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            frmManageEmployees manageEmployeesForm = new frmManageEmployees();
            manageEmployeesForm.ShowDialog();
        }
    }
}
