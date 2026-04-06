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
    /// Provides functionality for managers to view, search, add,
    /// edit, enable/disable, and delete employee accounts.
    /// </summary>
    public partial class frmManageEmployees : Form
    {
        /// <summary>
        /// Initializes the Manage Employees form.
        /// </summary>
        public frmManageEmployees()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads employee records and initializes the employee grid
        /// when the form is displayed.
        /// </summary>
        private async void frmManageEmployees_Load(object sender, EventArgs e)
        {
            dgvEmployees.AutoGenerateColumns = false;
            await LoadEmployeesAsync();
            UpdateDisableButtonText();
        }

        /// <summary>
        /// Retrieves all employees from the database and populates the
        /// employee DataGridView asynchronously.
        /// </summary>
        private async Task LoadEmployeesAsync()
        {
            var dt = await Task.Run(() =>
                clsSQL.GetAllEmployees());

            dgvEmployees.DataSource = dt; // Returns employees/managers
            dgvEmployees.AutoResizeColumns();
        }

        /// <summary>
        /// Searches the employee list based on the entered search term
        /// and filters the results displayed in the grid.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = tbxSearch.Text.Trim();
            DataTable dt = clsSQL.GetAllEmployees();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"NameFirst LIKE '%{searchTerm}%' OR " +
                               $"NameLast LIKE '%{searchTerm}%' OR " +
                               $"LogonName LIKE '%{searchTerm}%'";
                dgvEmployees.DataSource = dv.ToTable();
            }
            else
            {
                dgvEmployees.DataSource = dt;
            }
        }

        /// <summary>
        /// Reloads the employee list from the database.
        /// </summary>
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadEmployeesAsync();
        }

        /// <summary>
        /// Opens the Add Employee form to create a new employee record.
        /// </summary>
        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddEditEmployee addForm = new frmAddEditEmployee(); // Add mode
            if (addForm.ShowDialog() == DialogResult.OK)
                await LoadEmployeesAsync();
        }

        /// <summary>
        /// Opens the Edit Employee form for the selected employee.
        /// </summary>
        private async void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to edit.");
                return;
            }

            int personID = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["PersonID"].Value);
            int logonID = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["LogonID"].Value);

            frmAddEditEmployee editForm = new frmAddEditEmployee(personID, logonID);
            if (editForm.ShowDialog() == DialogResult.OK)
                await LoadEmployeesAsync();
        }

        /// <summary>
        /// Toggles the selected employee account between enabled and disabled states.
        /// </summary>
        private async void btnDisableEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an employee to disable/enable.");
                return;
            }

            int logonID = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["LogonID"].Value);

            bool currentlyDisabled = Convert.ToBoolean(dgvEmployees.SelectedRows[0].Cells["AccountDisabled"].Value);

            await Task.Run(() =>
                clsSQL.DisableAccount(logonID, !currentlyDisabled));
            await LoadEmployeesAsync();
            UpdateDisableButtonText();
        }

        /// <summary>
        /// Deletes the selected employee account after user confirmation.
        /// </summary>
        private async void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an employee to delete.");
                return;
            }

            int personID = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["PersonID"].Value);
            int logonID = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["LogonID"].Value);

            if (MessageBox.Show("Are you sure you want to delete this employee?",
                                "Confirm Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool success = await Task.Run(() =>
                    clsSQL.DeleteAccount(personID, logonID));

                if (success)
                {
                    MessageBox.Show("Employee deleted.");
                    await LoadEmployeesAsync();
                }
                else
                {
                    MessageBox.Show("Failed to delete employee.");
                }
            }
        }

        /// <summary>
        /// Updates the Disable/Enable button text based on the selected
        /// employee account status.
        /// </summary>
        private void UpdateDisableButtonText()
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                btnDisableEmployee.Text = "Disable/Enable Employee";
                return;
            }

            bool disabled =
                dgvEmployees.SelectedRows[0].Cells["AccountDisabled"].Value != DBNull.Value &&
                Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["AccountDisabled"].Value) == 1;

            btnDisableEmployee.Text = disabled ? "Enable Employee" : "Disable Employee";
        }

        /// <summary>
        /// Updates the Disable/Enable button text when a different
        /// employee is selected in the grid.
        /// </summary>
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDisableButtonText();
        }

        /// <summary>
        /// Closes the Manage Employees form and returns to the previous screen.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens the help form for employee management assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("manage_employees");
            help.ShowDialog();
        }
    }
}
