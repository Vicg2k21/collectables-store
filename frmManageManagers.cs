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
    /// Provides functionality for managers to view, search,
    /// add, edit, disable, and remove manager accounts.
    /// </summary>
    public partial class frmManageManagers : Form
    {
        /// <summary>
        /// Stores the PersonID of the currently logged-in manager.
        /// This prevents the user from modifying their own account.
        /// </summary>
        private int loggedInPersonID;

        /// <summary>
        /// Initializes the Manage Managers form and stores
        /// the logged-in manager's PersonID.
        /// </summary>
        /// <param name="loggedInPersonID">
        /// The PersonID of the currently authenticated manager.
        /// </param>
        public frmManageManagers(int loggedInPersonID)
        {
            InitializeComponent();
            this.loggedInPersonID = loggedInPersonID;
        }

        /// <summary>
        /// Handles the form load event by preparing the DataGridView
        /// and loading all manager records.
        /// </summary>
        private async void frmManageManagers_Load(object sender, EventArgs e)
        {
            dgvManagers.AutoGenerateColumns = false;
            await LoadManagersAsync();

            UpdateDisableButtonText();
        }

        /// <summary>
        /// Retrieves all manager records from the database asynchronously
        /// and displays them in the DataGridView.
        /// </summary>
        private async Task LoadManagersAsync()
        {
            var dt = await Task.Run(() =>
                clsSQL.GetAllManagers(loggedInPersonID));

            dgvManagers.DataSource = dt; // Exclude logged-in manager
            dgvManagers.AutoResizeColumns();
        }

        /// <summary>
        /// Searches for managers using the text entered in the search box.
        /// Filters by first name, last name, or logon name.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = tbxSearch.Text.Trim();
            DataTable dt = clsSQL.GetAllManagers(loggedInPersonID);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"NameFirst LIKE '%{searchTerm}%' OR NameLast LIKE '%{searchTerm}%' OR LogonName LIKE '%{searchTerm}%'";
                dgvManagers.DataSource = dv.ToTable();
            }
            else
            {
                dgvManagers.DataSource = dt;
            }
        }

        /// <summary>
        /// Reloads the manager list from the database.
        /// </summary>
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadManagersAsync();
        }

        /// <summary>
        /// Opens the Add Manager form to create a new manager account.
        /// </summary>
        private async void btnAddManager_Click(object sender, EventArgs e)
        {
            frmAddEditManager addForm = new frmAddEditManager(); // Add mode
            if (addForm.ShowDialog() == DialogResult.OK)
                await LoadManagersAsync();
        }

        /// <summary>
        /// Opens the Edit Manager form for the selected manager.
        /// </summary>
        private async void btnEditManager_Click(object sender, EventArgs e)
        {
            if (dgvManagers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a manager to edit.");
                return;
            }

            int personID = Convert.ToInt32(dgvManagers.SelectedRows[0].Cells["PersonID"].Value);
            int logonID = Convert.ToInt32(dgvManagers.SelectedRows[0].Cells["LogonID"].Value);

            frmAddEditManager editForm = new frmAddEditManager(personID, logonID); // Edit mode
            if (editForm.ShowDialog() == DialogResult.OK)
                await LoadManagersAsync();
        }

        /// <summary>
        /// Enables or disables the selected manager account.
        /// </summary>
        private async void btnDisableManager_Click(object sender, EventArgs e)
        {
            if (dgvManagers.SelectedRows.Count == 0) // use SelectedRows like in Customers
            {
                MessageBox.Show("Select a manager to disable/enable.");
                return;
            }

            int logonID = Convert.ToInt32(dgvManagers.SelectedRows[0].Cells["LogonID"].Value);
            bool currentlyDisabled = Convert.ToBoolean(dgvManagers.SelectedRows[0].Cells["AccountDisabled"].Value);

            await Task.Run(() =>
                clsSQL.DisableAccount(logonID, !currentlyDisabled));
            await LoadManagersAsync();

            UpdateDisableButtonText();
        }

        /// <summary>
        /// Removes a manager account after confirmation.
        /// The logged-in manager cannot remove their own account.
        /// </summary>
        private async void btnDeleteManager_Click(object sender, EventArgs e)
        {
            if (dgvManagers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a manager to remove.");
                return;
            }

            int personID = Convert.ToInt32(dgvManagers.SelectedRows[0].Cells["PersonID"].Value);
            int logonID = Convert.ToInt32(dgvManagers.SelectedRows[0].Cells["LogonID"].Value);

            // do not let manager delete themselves
            if (personID == loggedInPersonID)
            {
                MessageBox.Show("You cannot remove your own account.");
                return;
            }

            var result = MessageBox.Show(
                "Are you sure you want to remove this manager?\n\n" +
                "This will disable the manager's account and remove them from the list,\n" +
                "but their historical data will remain.",
                "Confirm Remove Manager",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool success = await Task.Run(() =>
                    clsSQL.DeleteAccount(personID, logonID));

                if (success)
                {
                    MessageBox.Show("Manager removed successfully.");
                    await LoadManagersAsync();
                }
                else
                {
                    MessageBox.Show("Failed to remove manager.");
                }
            }
        }

        /// <summary>
        /// Closes the Manage Managers form and returns
        /// to the previous form.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Returns to frmManageAccounts
        }

        /// <summary>
        /// Updates the text of the Disable/Enable button based
        /// on the currently selected manager's account status.
        /// </summary>
        private void UpdateDisableButtonText()
        {
            if (dgvManagers.SelectedRows.Count == 0)
            {
                btnDisableManager.Text = "Disable/Enable Manager";
                return;
            }

            bool disabled =
                dgvManagers.SelectedRows[0].Cells["AccountDisabled"].Value != DBNull.Value &&
                Convert.ToInt32(dgvManagers.SelectedRows[0].Cells["AccountDisabled"].Value) == 1;

            btnDisableManager.Text = disabled ? "Enable Manager" : "Disable Manager";
        }

        /// <summary>
        /// Updates the Disable/Enable button when a new row
        /// is selected in the DataGridView.
        /// </summary>
        private void dgvManagers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDisableButtonText();
        }

        /// <summary>
        /// Opens the help form for manager account management assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("manage_managers");
            help.ShowDialog();
        }
    }
}
