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
    /// Form used by managers to view, search, add, edit,
    /// disable, or delete customer accounts.
    /// </summary>
    public partial class frmManageCustomers : Form
    {
        /// <summary>
        /// Initializes the Manage Customers form.
        /// </summary>
        public frmManageCustomers()
        {
            InitializeComponent();  
        }

        /// <summary>
        /// Retrieves all customers from the database and loads them
        /// into the DataGridView asynchronously.
        /// </summary>
        private async Task LoadCustomersAsync()
        {
            var dt = await Task.Run(() =>
                clsSQL.GetAllCustomers());

            dgvCustomers.DataSource = dt;
            dgvCustomers.AutoResizeColumns();
        }

        /// <summary>
        /// Initializes the form and loads customer data
        /// when the form is first displayed.
        /// </summary>
        private async void frmManageCustomers_Load(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;
            await LoadCustomersAsync();
            UpdateDisableButtonText(); // Changes disable/enable text depending on customer selected
        }

        /// <summary>
        /// Searches for customers based on the entered keyword
        /// and filters the displayed results.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = tbxSearch.Text.Trim();
            DataTable dt = clsSQL.GetAllCustomers();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"NameFirst LIKE '%{searchTerm}%' OR " +
                               $"NameLast LIKE '%{searchTerm}%' OR " +
                               $"LogonName LIKE '%{searchTerm}%'";
                dgvCustomers.DataSource = dv.ToTable();
            }
            else
            {
                dgvCustomers.DataSource = dt;
            }
        }

        /// <summary>
        /// Reloads the full list of customers from the database.
        /// </summary>
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        /// <summary>
        /// Opens the Add Customer form and refreshes the grid
        /// if a new customer is successfully created.
        /// </summary>
        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomers addForm = new frmAddEditCustomers(); // Add mode
            if (addForm.ShowDialog() == DialogResult.OK)
                await LoadCustomersAsync();
        }

        /// <summary>
        /// Opens the Edit Customer form for the selected customer
        /// and refreshes the grid if changes are saved.
        /// </summary>
        private async void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.");
                return;
            }

            int personID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["PersonID"].Value);
            int logonID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["LogonID"].Value);

            frmAddEditCustomers editForm = new frmAddEditCustomers(personID, logonID);
            if (editForm.ShowDialog() == DialogResult.OK)
                await LoadCustomersAsync();
        }

        /// <summary>
        /// Toggles the enabled or disabled status of the selected customer account.
        /// </summary>
        private async void btnDisableCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a customer to disable.");
                return;
            }

            int logonID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["LogonID"].Value);
            bool currentlyDisabled = Convert.ToBoolean(dgvCustomers.SelectedRows[0].Cells["AccountDisabled"].Value);

            await Task.Run(() =>
                clsSQL.DisableAccount(logonID, !currentlyDisabled));
            await LoadCustomersAsync();

            UpdateDisableButtonText();
        }

        /// <summary>
        /// Deletes the selected customer account after confirmation.
        /// </summary>
        private async void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a customer to delete.");
                return;
            }

            int personID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["PersonID"].Value);
            int logonID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["LogonID"].Value);

            if (MessageBox.Show("Are you sure you want to delete this customer?",
                                "Confirm Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool success = await Task.Run(() =>
                    clsSQL.DeleteAccount(personID, logonID));

                if (success)
                {
                    MessageBox.Show("Customer deleted.");
                    await LoadCustomersAsync();
                }
                else
                {
                    MessageBox.Show("Failed to delete customer.");
                }
            }
        }

        /// <summary>
        /// Closes the Manage Customers form and returns to the previous screen.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Returns to frmManageAccounts
        }

        /// <summary>
        /// Updates the Disable/Enable button text based on the selected
        /// customer's current account status.
        /// </summary>
        private void UpdateDisableButtonText()
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                btnDisableCustomer.Text = "Disable/Enable Customer";
                return;
            }

            bool disabled =
                dgvCustomers.SelectedRows[0].Cells["AccountDisabled"].Value != DBNull.Value &&
                Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["AccountDisabled"].Value) == 1;

            btnDisableCustomer.Text = disabled ? "Enable Customer" : "Disable Customer";
        }

        /// <summary>
        /// Updates the disable/enable button text when the selected
        /// customer in the DataGridView changes.
        /// </summary>
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDisableButtonText();
        }

        /// <summary>
        /// Opens the help form for managing customers assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("manage_customers");
            help.ShowDialog();
        }
    }
}
