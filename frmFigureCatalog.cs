using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2LogonView
{
    /// <summary>
    /// Displays the figure catalog and allows users to search,
    /// filter by category, view figure details, and access their cart.
    /// </summary>
    public partial class frmFigureCatalog : Form
    {
        /// <summary>
        /// Stores the unique identifier of the currently logged-in user.
        /// A value of -1 indicates a guest user.
        /// </summary>
        private int _personID;

        /// <summary>
        /// Initializes the catalog form for the current user.
        /// </summary>
        /// <param name="personID">Unique identifier of the logged-in user.</param>
        public frmFigureCatalog(int personID)
        {
            InitializeComponent();
            _personID = personID;

            // For guest only
            if (_personID == -1)
            {
                // Guest mode — disable cart features
                btnViewCart.Enabled = false;
                btnViewCart.Visible = false;

                btnViewOrderHistory.Enabled = false;
                btnViewOrderHistory.Visible = false;
            }
        }

        /// <summary>
        /// Loads inventory data from the database using an optional
        /// keyword search and category filter.
        /// </summary>
        /// <param name="keyword">Search keyword used to filter figures.</param>
        /// <param name="categoryID">Optional category identifier for filtering.</param>
        /// <returns>A task representing the asynchronous load operation.</returns>
        public async Task LoadInventoryDataAsync(string keyword = "", int? categoryID = null)
        {
            var dt = await Task.Run(() =>
                clsSQL.SearchInventory(keyword, categoryID, includeDiscontinued: false));

            if (dt != null)
            {
                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to load inventory data.");
            }
        }

        /// <summary>
        /// Loads the figure inventory and category filters when the form opens.
        /// </summary>
        private async void frmProductCatalog_Load(object sender, EventArgs e)
        {
            await LoadInventoryDataAsync();
            await LoadCategoriesAsync();
        }

        /// <summary>
        /// Opens the selected figure's detail page.
        /// </summary>
        private async void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                int inventoryID = Convert.ToInt32(dgvProducts.CurrentRow.Cells["InventoryID"].Value);
                frmFigureDetails detailForm = new frmFigureDetails(inventoryID, _personID, this);
                detailForm.ShowDialog();

                // Refresh inventory after returning from details form
                await LoadInventoryDataAsync();
            }
            else
            {
                MessageBox.Show("Please select a product first.");
            }
        }

        /// <summary>
        /// Searches the inventory based on the entered keyword and category.
        /// </summary>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = tbxSearch.Text.Trim();
            int? categoryID = null;

            if (cbxCategoryFilter.SelectedItem != null)
            {
                DataRowView selected = cbxCategoryFilter.SelectedItem as DataRowView;

                if (selected["CategoryID"] != DBNull.Value)
                    categoryID = Convert.ToInt32(selected["CategoryID"]);
            }

            await LoadInventoryDataAsync(keyword, categoryID);
        }

        /// <summary>
        /// Opens the shopping cart for the current user.
        /// </summary>
        private async void btnViewCart_Click(object sender, EventArgs e)
        {
            frmCart cartForm = new frmCart(_personID, this);
            cartForm.ShowDialog();

            // Refresh catalog when returning from Cart/Checkout
            await LoadInventoryDataAsync();
        }

        /// <summary>
        /// Loads figure categories into the category filter dropdown.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task LoadCategoriesAsync()
        {
            var categories = await Task.Run(() =>
                clsSQL.GetAllCategories());

            if (categories != null)
            {
                DataRow allRow = categories.NewRow();
                allRow["CategoryID"] = DBNull.Value;
                allRow["CategoryName"] = "All Categories";
                categories.Rows.InsertAt(allRow, 0);

                cbxCategoryFilter.DataSource = categories;
                cbxCategoryFilter.DisplayMember = "CategoryName";
                cbxCategoryFilter.ValueMember = "CategoryID";
                cbxCategoryFilter.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Failed to load categories.");
            }
        }

        /// <summary>
        /// Filters the catalog when the selected category changes.
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
                    categoryID = Convert.ToInt32(selected["CategoryID"]);
                }
            }

            await LoadInventoryDataAsync(keyword, categoryID);
        }

        /// <summary>
        /// Opens the help form for catalog assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp helpForm = new frmHelp("catalog");
            helpForm.ShowDialog();
        }

        /// <summary>
        /// Opens the order history for the current user.
        /// </summary>
        private async void btnViewOrderHistory_Click(object sender, EventArgs e)
        {
            if (_personID < 0)
            {
                MessageBox.Show("Please log in to view order history.");
                return;
            }

            DataTable dtOrders = await Task.Run(() =>
                clsSQL.GetOrdersByPerson(_personID));

            if (dtOrders == null || dtOrders.Rows.Count == 0)
            {
                MessageBox.Show("No past orders found.");
                return;
            }

            frmCustomerOrders ordersForm = new frmCustomerOrders(_personID);
            ordersForm.ShowDialog();
        }
    }
}
