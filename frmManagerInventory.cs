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
    /// Provides functionality for managers to view, search, filter,
    /// add, edit, restock, and disable inventory items.
    /// </summary>
    public partial class frmManagerInventory : Form
    {
        /// <summary>
        /// Initializes the Manager Inventory form.
        /// </summary>
        public frmManagerInventory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event by loading inventory data
        /// and category filter options.
        /// </summary>
        private async void frmManagerInventory_Load(object sender, EventArgs e)
        {
            await LoadInventoryDataAsync();
            await LoadCategoriesAsync(); // Load category options
        }

        /// <summary>
        /// Retrieves inventory data from the database based on
        /// the provided keyword and category filter.
        /// </summary>
        /// <param name="keyword">
        /// Optional search keyword used to filter inventory items.
        /// </param>
        /// <param name="categoryID">
        /// Optional category ID used to filter inventory items.
        /// </param>
        /// <returns>
        /// An asynchronous Task representing the operation.
        /// </returns>
        public async Task LoadInventoryDataAsync(string keyword = "", int? categoryID = null)
        {
            var dt = await Task.Run(() =>
                clsSQL.SearchInventory(keyword, categoryID, includeDiscontinued: true));

            if (dt != null)
            {
                dgvManagerInventory.AutoGenerateColumns = false; // Prevent duplication
                dgvManagerInventory.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to load inventory data.");
            }
        }

        /// <summary>
        /// Handles the search button click event and filters
        /// inventory based on the entered keyword and selected category.
        /// </summary>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = tbxSearch.Text.Trim();
            int? categoryID = null;

            if (cbxCategoryFilter.SelectedItem != null)
            {
                DataRowView selected = cbxCategoryFilter.SelectedItem as DataRowView;

                if (selected["CategoryID"] != DBNull.Value)
                    categoryID = (int)(long)selected["CategoryID"];
            }

            await LoadInventoryDataAsync(keyword, categoryID);
        }

        /// <summary>
        /// Loads all inventory categories and binds them to the
        /// category filter ComboBox, including an "All Categories" option.
        /// </summary>
        /// <returns>
        /// An asynchronous Task representing the operation.
        /// </returns>
        private async Task LoadCategoriesAsync()
        {
            var categories = await Task.Run(() =>
                clsSQL.GetAllCategories());
            if (categories != null)
            {
                // Add All Categories row at the top
                DataRow allRow = categories.NewRow();
                allRow["CategoryID"] = DBNull.Value;
                allRow["CategoryName"] = "All Categories";
                categories.Rows.InsertAt(allRow, 0);

                cbxCategoryFilter.DataSource = categories;
                cbxCategoryFilter.DisplayMember = "CategoryName";
                cbxCategoryFilter.ValueMember = "CategoryID";
                cbxCategoryFilter.SelectedIndex = 0; // Default to "All Categories"
            }
            else
            {
                MessageBox.Show("Failed to load categories.");
            }
        }

        /// <summary>
        /// Handles category selection changes and updates the
        /// inventory list based on the selected category.
        /// </summary>
        private async void cbxCategoryFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string keyword = tbxSearch.Text.Trim();
            int? categoryID = null;

            if (cbxCategoryFilter.SelectedItem != null)
            {
                DataRowView selected = cbxCategoryFilter.SelectedItem as DataRowView;

                if (selected["CategoryID"] != DBNull.Value)
                {
                    categoryID = (int)(long)selected["CategoryID"];
                }
            }

            await LoadInventoryDataAsync(keyword, categoryID);
        }

        /// <summary>
        /// Opens the Add Inventory Item form to create a new item.
        /// </summary>
        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            frmAddEditInventoryItem addForm = new frmAddEditInventoryItem();

            // Show as a modal dialog
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadInventoryDataAsync();  // refresh the datagrid
            }
        }

        /// <summary>
        /// Opens the Restock Item form to adjust the quantity
        /// of the selected inventory item.
        /// </summary>
        private async void btnRestock_Click(object sender, EventArgs e)
        {
            if (dgvManagerInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to restock.");
                return;
            }

            // Get item info from DataGridView
            string itemName = dgvManagerInventory.CurrentRow.Cells["ItemName"].Value.ToString();
            int id = (int)(long)dgvManagerInventory.CurrentRow.Cells["InventoryID"].Value;
            int currentQty = (int)(long)dgvManagerInventory.CurrentRow.Cells["Quantity"].Value;

            // Open restock form
            frmRestockItem restockForm = new frmRestockItem(itemName, currentQty);

            if (restockForm.ShowDialog() == DialogResult.OK)
            {
                int amountToAdd = restockForm.RestockAmount;

                bool success = clsSQL.RestockItem(id, amountToAdd);

                if (success)
                {
                    MessageBox.Show("Inventory updated successfully.");
                    await LoadInventoryDataAsync(); // Refresh grid
                }
                else
                {
                    MessageBox.Show("Failed to update inventory.");
                }
            }
        }

        /// <summary>
        /// Reloads all inventory data from the database.
        /// </summary>
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadInventoryDataAsync();
        }

        /// <summary>
        /// Closes the Manager Inventory form and returns
        /// to the previous form.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Disables the selected inventory item after confirmation.
        /// </summary>
        private async void btnDisableItem_Click(object sender, EventArgs e)
        {
            if (dgvManagerInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to disable.");
                return;
            }

            int id = (int)(long)dgvManagerInventory.SelectedRows[0].Cells["InventoryID"].Value;

            if (MessageBox.Show("Disable this item?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsSQL.DisableInventoryItem(id))
                {
                    MessageBox.Show("Item disabled.");
                    await LoadInventoryDataAsync();
                }
                else
                {
                    MessageBox.Show("Operation failed.");
                }
            }
        }

        /// <summary>
        /// Opens the Edit Inventory Item form for the selected item.
        /// </summary>
        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            if (dgvManagerInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to edit.");
                return;
            }

            int id = (int)(long)dgvManagerInventory.SelectedRows[0].Cells["InventoryID"].Value;

            frmAddEditInventoryItem editForm = new frmAddEditInventoryItem(id);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await LoadInventoryDataAsync();  // refresh after editing
            }
        }

        /// <summary>
        /// Opens the help form for inventory management assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("inventory");
            help.ShowDialog();
        }
    }
}
