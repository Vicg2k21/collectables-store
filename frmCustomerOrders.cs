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
    /// Displays a customer's order history and allows viewing
    /// the details of individual orders.
    /// </summary>
    public partial class frmCustomerOrders : Form
    {
        /// <summary>
        /// Stores the unique identifier of the currently logged-in customer.
        /// </summary>
        private int _personID;

        /// <summary>
        /// Initializes the customer orders form for the selected user.
        /// </summary>
        /// <param name="personID">Unique identifier of the logged-in customer.</param>
        public frmCustomerOrders(int personID)
        {
            InitializeComponent();
            _personID = personID;

            // handle row selection
            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;
        }

        /// <summary>
        /// Loads the customer's order history when the form opens.
        /// </summary>
        private async void frmCustomerOrders_Load(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        /// <summary>
        /// Retrieves the list of orders for the current customer
        /// and displays them in the orders grid.
        /// </summary>
        /// <returns>A task representing the asynchronous load operation.</returns>
        private async Task LoadOrdersAsync()
        {
            var dt = await Task.Run(() =>
                clsSQL.GetOrdersByPerson(_personID));

            if (dt != null && dt.Rows.Count > 0)
            {
                // Bind DataTable to DataGridView
                dgvOrders.DataSource = dt;

                // Set column headers
                dgvOrders.Columns["OrderID"].HeaderText = "Order #";
                dgvOrders.Columns["OrderDate"].HeaderText = "Order Date";
                dgvOrders.Columns["Subtotal"].HeaderText = "Subtotal";
                dgvOrders.Columns["DiscountCode"].HeaderText = "Discount";
                dgvOrders.Columns["Tax"].HeaderText = "Tax";
                dgvOrders.Columns["Total"].HeaderText = "Total (incl. tax)";

                // Format currency columns
                dgvOrders.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                dgvOrders.Columns["Tax"].DefaultCellStyle.Format = "C2";
                dgvOrders.Columns["Total"].DefaultCellStyle.Format = "C2";

                // Reorder columns to show Tax before Total
                dgvOrders.Columns["OrderID"].DisplayIndex = 0;
                dgvOrders.Columns["OrderDate"].DisplayIndex = 1;
                dgvOrders.Columns["Subtotal"].DisplayIndex = 2;
                dgvOrders.Columns["DiscountCode"].DisplayIndex = 3;
                dgvOrders.Columns["Tax"].DisplayIndex = 4;
                dgvOrders.Columns["Total"].DisplayIndex = 5;

                dgvOrders.ReadOnly = true;
                dgvOrders.AutoResizeColumns();

                // Automatically load first order's details
                if (dgvOrders.Rows.Count > 0)
                {
                    int firstOrderID = Convert.ToInt32(dgvOrders.Rows[0].Cells["OrderID"].Value);
                    await LoadOrderDetailsAsync(firstOrderID);
                }
            }
            else
            {
                dgvOrders.DataSource = null;
                dgvOrderDetails.DataSource = null;
                MessageBox.Show("No orders found.");
            }

        }

        /// <summary>
        /// Loads the details of the selected order when the user selects a row.
        /// </summary>
        private async void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null && dgvOrders.CurrentRow.Cells["OrderID"].Value != DBNull.Value)
            {
                int selectedOrderID = Convert.ToInt32(dgvOrders.CurrentRow.Cells["OrderID"].Value);
                await LoadOrderDetailsAsync(selectedOrderID);
            }
            else
            {
                // Clear the order details if no valid row is selected
                dgvOrderDetails.DataSource = null;
            }
        }

        /// <summary>
        /// Retrieves and displays the items included in a specific order.
        /// </summary>
        /// <param name="orderID">Unique identifier of the order.</param>
        /// <returns>A task representing the asynchronous load operation.</returns>
        private async Task LoadOrderDetailsAsync(int orderID)
        {
            var dtDetails = await Task.Run(() =>
                clsSQL.GetOrderDetailsByOrderID(orderID));

            if (dtDetails != null && dtDetails.Rows.Count > 0)
            {
                dgvOrderDetails.DataSource = dtDetails;

                dgvOrderDetails.Columns["ItemName"].HeaderText = "Item Name";
                dgvOrderDetails.Columns["Quantity"].HeaderText = "Qty";
                dgvOrderDetails.Columns["RetailPrice"].HeaderText = "Unit Price";
                dgvOrderDetails.Columns["LineTotal"].HeaderText = "Line Total";

                dgvOrderDetails.Columns["RetailPrice"].DefaultCellStyle.Format = "C2";
                dgvOrderDetails.Columns["LineTotal"].DefaultCellStyle.Format = "C2";

                dgvOrderDetails.ReadOnly = true;
                dgvOrderDetails.AutoResizeColumns();
            }
            else
            {
                dgvOrderDetails.DataSource = null;
            }
        }

        /// <summary>
        /// Closes the order history form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
