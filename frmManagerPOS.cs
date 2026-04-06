// Copy and pasted old class from github to redo the class for threading and optimization - 3/5/2026
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2LogonView
{
    /// <summary>
    /// Manager Point-of-Sale (POS) form.
    /// Allows managers to search products, manage a cart,
    /// select customers, apply discounts, and complete sales transactions.
    /// </summary>
    public partial class frmManagerPOS : Form
    {
        private int _managerID;       // store manager personID
        private string _managerName;

        /// <summary>
        /// Stores the selected customer ID.
        /// A value of -1 indicates no customer has been selected.
        /// </summary>
        private int _customerID = -1; // will be set when manager selects customer

        /// <summary>
        /// Indicates the current discount level.
        /// -1 = none, 0 = cart-level, 1 = item-level.
        /// </summary>
        private int _discountLevel = -1;

        /// <summary>
        /// Indicates the discount type.
        /// -1 = none, 0 = percentage, 1 = fixed dollar amount.
        /// </summary>
        private int _discountType = -1;

        /// <summary>
        /// Stores the percentage value for the currently applied discount.
        /// </summary>
        private decimal _discountPercentage = 0;

        /// <summary>
        /// Stores the name of the item associated with an item-level discount.
        /// </summary>
        private string _discountItemName = "";

        private DataTable _customerCache;

        // <summary>
        /// Initializes the Manager POS form and loads the manager's information.
        /// </summary>
        /// <param name="managerID">The PersonID of the logged-in manager.</param>
        public frmManagerPOS(int managerID)
        {
            InitializeComponent();
            _managerID = managerID;

            // Retrieve manager's name from database
            var managerRow = clsSQL.GetPersonInfo(managerID);
            if (managerRow != null)
            {
                _managerName = $"{managerRow["NameFirst"]} {managerRow["NameLast"]}";
            }
            else
            {
                _managerName = "Manager"; // Fallback if database fails
            }
        }

        /// <summary>
        /// Handles figure search based on keyword and selected category.
        /// </summary>
        private async void btnSearchFigures_Click(object sender, EventArgs e)
        {
            string keyword = tbxSearchFigure.Text.Trim();
            int? categoryID = null;

            if (cbxCategoryFilter.SelectedItem is DataRowView selected &&
                selected["CategoryID"] != DBNull.Value)
            {
                categoryID = Convert.ToInt32(selected["CategoryID"]);
            }

            await LoadProductDataAsync(keyword, categoryID);
        }

        /// <summary>
        /// Retrieves all inventory categories from the database and binds them
        /// to the category filter ComboBox, including an "All Categories" option.
        /// </summary>
        /// <returns>
        /// An asynchronous Task representing the operation.
        /// </returns>
        private async Task LoadCategoriesAsync()
        {
            DataTable categories = await Task.Run(() => clsSQL.GetAllCategories());

            if (categories == null)
            {
                MessageBox.Show("Failed to load categories.");
                return;
            }

            DataRow allRow = categories.NewRow();
            allRow["CategoryID"] = DBNull.Value;
            allRow["CategoryName"] = "All Categories";
            categories.Rows.InsertAt(allRow, 0);

            cbxCategoryFilter.DataSource = categories;
            cbxCategoryFilter.DisplayMember = "CategoryName";
            cbxCategoryFilter.ValueMember = "CategoryID";
            cbxCategoryFilter.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds the selected product to the cart after validating availability
        /// and ensuring the item is not discontinued.
        /// </summary>
        private async void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to add.");
                return;
            }

            int inventoryID = (int)(long)dgvProducts.CurrentRow.Cells["InventoryID"].Value;

            DataRow row = await Task.Run(() =>
                clsSQL.GetProductDetailsByID(inventoryID));

            if (row == null)
            {
                MessageBox.Show("Could not retrieve product details.");
                return;
            }

            // Check if product is discontinued
            bool discontinued = row["Discontinued"] != DBNull.Value &&
                    Convert.ToInt32((long)row["Discontinued"]) == 1;
            if (discontinued)
            {
                MessageBox.Show("This item has been discontinued and cannot be added to the cart.");
                return;
            }

            int requestedQty = (int)numQuantity.Value;

            int availableQty = await Task.Run(() =>
                clsSQL.GetAvailableInventoryQuantity(inventoryID));

            if (requestedQty > availableQty)
            {
                MessageBox.Show($"Only {availableQty} units available. Please reduce quantity.");
                return;
            }

            var item = new CartItem
            {
                InventoryID = inventoryID,
                ProductName = row["ItemName"].ToString(),
                Price = Convert.ToDecimal(row["RetailPrice"]),
                Quantity = requestedQty
            };

            clsCart.AddItem(item);
            MessageBox.Show("Item added to cart!");

            LoadCart(); // Refresh cart
        }

        /// <summary>
        /// Removes the selected item from the cart.
        /// </summary>
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                int inventoryID = Convert.ToInt32(
                    dgvCart.CurrentRow.Cells["InventoryID"].Value
                    );
                clsCart.RemoveItem(inventoryID);
                LoadCart();
            }
        }

        /// <summary>
        /// Clears all items from the cart after confirmation.
        /// </summary>
        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear the entire cart?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clsCart.ClearCart();
                LoadCart();
            }
        }

        /// <summary>
        /// Updates item quantities in the cart and validates against available inventory.
        /// </summary>
        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            dgvCart.EndEdit();

            if (dgvCart.IsCurrentCellInEditMode)
            {
                dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            bool anyErrors = false;
            var currentCart = clsCart.GetCartItems();

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                try
                {
                    int inventoryID = (int)row.Cells["InventoryID"].Value;
                    int newQty = Convert.ToInt32(row.Cells["Quantity"].Value);

                    int availableQty = clsSQL.GetAvailableInventoryQuantity(inventoryID);
                    var item = currentCart.FirstOrDefault(i => i.InventoryID == inventoryID);

                    if (item == null) continue;

                    if (newQty <= 0)
                    {
                        clsCart.RemoveItem(inventoryID);
                    }
                    else if (newQty > availableQty)
                    {
                        anyErrors = true;
                        MessageBox.Show($"Only {availableQty} units available for {row.Cells["ProductName"].Value}. Please reduce quantity.");

                        row.Cells["Quantity"].Value = item.Quantity;
                    }
                    else
                    {
                        item.Quantity = newQty;
                    }
                }
                catch
                {
                    anyErrors = true;
                    MessageBox.Show("There was an error updating quantity. Please check the input values.");
                }
            }

            LoadCart();

            if (!anyErrors)
                MessageBox.Show("Cart quantities updated successfully.");
        }

        /// <summary>
        /// Processes the checkout operation:
        /// validates customer and cart,
        /// applies discounts,
        /// creates the order,
        /// updates inventory,
        /// and generates a receipt.
        /// </summary>
        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            // Check if a customer is selected
            if (_customerID < 0)
            {
                MessageBox.Show("Please select a customer before checking out.");
                return;
            }

            // Check if cart is not empty
            var cartItems = clsCart.GetCartItems();
            if (cartItems == null || cartItems.Count == 0)
            {
                MessageBox.Show("The cart is empty. Please add items before checking out.");
                return;
            }

            // NEW: Check for discontinued items in the cart
            foreach (var cartItem in cartItems)
            {
                DataRow productRow = await Task.Run(() =>
                    clsSQL.GetProductDetailsByID(cartItem.InventoryID));

                if (productRow != null && productRow["Discontinued"] != DBNull.Value &&
                    Convert.ToInt32((long)productRow["Discontinued"]) == 1)
                {
                    MessageBox.Show($"Item '{cartItem.ProductName}' has been discontinued and cannot be purchased.");
                    return; // Stop checkout process if discontinued item found
                }
            }

            // Retrieve customer info
            var customerRow = await Task.Run(() =>
                clsSQL.GetPersonInfo(_customerID));

            if (customerRow == null)
            {
                MessageBox.Show("Could not retrieve customer information.");
                return;
            }
            string customerName = $"{customerRow["NameFirst"]} {customerRow["NameLast"]}";
            string customerPhone = customerRow["PhonePrimary"]?.ToString() ?? "N/A";

            // Retrieve discount info (if promo code entered)
            int? discountID = null;
            DataRow discountRow = null;
            string promoCode = cbxPromoCode.Text.Trim();
            if (!string.IsNullOrWhiteSpace(promoCode))
            {
                discountRow = clsSQL.GetDiscountByCode(promoCode);
                if (discountRow != null)
                {
                    discountID = Convert.ToInt32(discountRow["DiscountID"]);
                }
            }

            // Insert order into database
            Order newOrder = new Order
            {
                PersonID = _customerID,
                ManagerID = _managerID,  // ensure manager is linked to sale
                OrderDate = DateTime.Now,
                DiscountID = discountID,
                CC_Number = "ManagerPOS",
                ExpDate = DateTime.Now.ToString("MM/yy"),
                CCV = "N/A"
            };

            int orderID = await Task.Run(() =>
                clsSQL.InsertOrder(newOrder));

            if (orderID <= 0)
            {
                MessageBox.Show("Failed to process the order. Please try again.");
                return;
            }

            // Insert order details and update inventory
            foreach (var item in cartItems)
            {
                OrderDetail detail = new OrderDetail
                {
                    OrderID = orderID,
                    InventoryID = item.InventoryID,
                    Quantity = item.Quantity,
                    DiscountID = discountID
                };

                await Task.Run(() =>
                {
                    clsSQL.InsertOrderDetail(detail);
                    clsSQL.UpdateInventoryQuantity(item.InventoryID, item.Quantity);
                });
            }

            // Calculate totals for receipt
            decimal subtotal = clsCart.GetSubtotal();
            decimal discountedTotal = clsCart.GetDiscountedTotal(promoCode, out decimal discountAmt, out int discountType);
            decimal taxRate = 0.0825m;
            decimal tax = discountedTotal * taxRate;
            decimal finalTotal = discountedTotal + tax;

            decimal discountRate = 0m;
            if (discountRow != null)
            {
                discountRate = (int)(long)discountRow["DiscountType"] == 0
                    ? Convert.ToDecimal(discountRow["DiscountPercentage"])
                    : Convert.ToDecimal(discountRow["DiscountDollarAmount"]);
            }

            // Generate HTML receipt with manager info
            clsHTML.GenerateReceipt(
                cartItems,
                subtotal,
                discountAmt,
                taxRate,
                finalTotal,
                orderID,
                promoCode,
                customerName,
                customerPhone,
                discountType,
                discountRate,
                _managerName // manager name displayed on receipt
            );

            // Clear cart and reload UI
            clsCart.ClearCart();
            LoadCart();

            // Reset promo code system after checkout
            cbxPromoCode.SelectedIndex = 0;   // returns to "No Promo"
            lblPromoCode.Visible = false;

            _discountLevel = -1;
            _discountType = -1;
            _discountPercentage = 0;
            _discountItemName = "";

            MessageBox.Show("Sale completed successfully!");
        }

        /// <summary>
        /// Initializes the form by loading customers, products, and categories.
        /// </summary>
        private async void frmManagerPOS_Load(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = false;

            await LoadCustomersAsync();
            await LoadProductDataAsync();
            await LoadCategoriesAsync();
        }

        /// <summary>
        /// Retrieves all active customers from the database and binds them
        /// to the customers DataGridView, excluding disabled accounts.
        /// </summary>
        /// <returns>
        /// An asynchronous Task representing the operation.
        /// </returns>
        private async Task LoadCustomersAsync()
        {
            _customerCache = await Task.Run(() => clsSQL.GetAllCustomers());

            if (_customerCache == null)
            {
                MessageBox.Show("Failed to load customers.");
                return;
            }

            _customerCache.DefaultView.RowFilter = "AccountDisabled = false";
            dgvCustomers.DataSource = _customerCache.DefaultView.ToTable();
        }

        /// <summary>
        /// Filters the customer list based on the search input.
        /// </summary>
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (_customerCache == null) return;

            string term = tbxSearchCustomer.Text.Trim();
            DataView dv = _customerCache.DefaultView;

            if (!string.IsNullOrWhiteSpace(term))
            {
                dv.RowFilter = $@"
                AccountDisabled = false AND (
                    NameFirst LIKE '%{term}%' OR
                    NameLast LIKE '%{term}%' OR
                    Email LIKE '%{term}%' OR
                    PhonePrimary LIKE '%{term}%' OR
                    LogonName LIKE '%{term}%'
                )";
            }
            else
            {
                dv.RowFilter = "AccountDisabled = false";
            }

            dgvCustomers.DataSource = dv.ToTable();
        }

        /// <summary>
        /// Handles customer selection from the grid.
        /// Sets the selected customer ID and displays their information,
        /// while preventing disabled accounts from being used.
        /// </summary>
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

            bool disabled = row.Cells["AccountDisabled"].Value != DBNull.Value &&
                    Convert.ToInt32((long)row.Cells["AccountDisabled"].Value) == 1;
            if (disabled)
            {
                MessageBox.Show("This customer account is disabled and cannot be used at POS.");
                return;
            }

            _customerID = (int)(long)row.Cells["PersonID"].Value;

            string first = row.Cells["FirstName"].Value.ToString();
            string last = row.Cells["LastName"].Value.ToString();
            string phone = row.Cells["PhonePrimary"].Value.ToString();

            lblSelectedCustomer.Text = $"{first} {last} ({phone})";
        }

        /// <summary>
        /// Retrieves inventory data from the database based on the provided keyword
        /// and optional category filter, then binds the results to the products DataGridView.
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
        private async Task LoadProductDataAsync(string keyword = "", int? categoryID = null)
        {
            DataTable dt = await Task.Run(() => clsSQL.SearchInventory(keyword, categoryID));

            if (dt != null)
            {
                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = dt;
            }
        }

        /// <summary>
        /// Loads cart items into the grid, formats columns,
        /// and enables editing only for quantity.
        /// Also updates totals and UI state.
        /// </summary>
        private void LoadCart()
        {
            var cartItems = clsCart.GetCartItems();
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems;

            dgvCart.Columns["InventoryID"].Visible = false;  // Hide backend ID
            dgvCart.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvCart.Columns["Price"].DefaultCellStyle.Format = "C2";

            // Set entire grid as read-only first
            // Set all columns to read-only after binding
            foreach (DataGridViewColumn col in dgvCart.Columns)
            {
                col.ReadOnly = true;
            }

            // Allow only the Quantity column to be editable
            if (dgvCart.Columns.Contains("Quantity"))
            {
                dgvCart.Columns["Quantity"].ReadOnly = false;
            }

            UpdateTotals();

            // Disable Update button if cart is empty
            btnUpdateQuantity.Enabled = dgvCart.Rows.Count > 0;
        }

        /// <summary>
        /// Calculates and updates subtotal, discounts, tax, and final total
        /// based on the current cart and applied promo code.
        /// </summary>
        private void UpdateTotals()
        {
            // Original subtotal before discount
            decimal originalSubtotal = clsCart.GetSubtotal();

            // Calculate discount and discounted total
            decimal discountAmount = 0m;
            int discountType = -1;
            decimal discountedSubtotal = clsCart.GetDiscountedTotal(cbxPromoCode.Text.Trim(), out discountAmount, out discountType);

            // Tax based on discounted subtotal
            decimal tax = Math.Round(discountedSubtotal * 0.0825m, 2, MidpointRounding.AwayFromZero);
            decimal finalTotal = discountedSubtotal + tax;

            // Show discounted subtotal
            lblSubtotal.Text = $"Subtotal: {discountedSubtotal:C2}";

            // Show discount label if any
            if (discountAmount > 0)
            {
                string discountText;

                if (_discountLevel == 1) // Item-level
                {
                    discountText = _discountType == 0
                        ? $"Discount ({_discountItemName} {_discountPercentage:P0}): -{discountAmount:C2}"
                        : $"Discount ({_discountItemName}): -{discountAmount:C2}";
                }
                else // Cart-level
                {
                    discountText = _discountType == 0
                        ? $"Discount ({_discountPercentage:P0} off cart): -{discountAmount:C2}"
                        : $"Discount (Cart): -{discountAmount:C2}";
                }

                lblDiscount.Text = discountText;
                lblDiscount.Visible = true;
            }
            else
            {
                lblDiscount.Visible = false;
            }

            // Tax and total
            lblTax.Text = $"Tax (8.25%): {tax:C2}";
            lblTotal.Text = $"Total (incl. tax): {finalTotal:C2}";
        }

        /// <summary>
        /// Clears the cart and closes the POS form, returning to the previous form.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            clsCart.ClearCart();
            this.Close();
        }

        /// <summary>
        /// Updates product details when a new product is selected,
        /// including stock quantity, image display, and availability.
        /// Also loads applicable promo codes for the selected product.
        /// </summary>
        private async void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            int inventoryID = (int)(long)dgvProducts.CurrentRow.Cells["InventoryID"].Value;
            DataRow row = await Task.Run(() =>
                clsSQL.GetProductDetailsByID(inventoryID));

            if (row != null)
            {
                // Get stock quantity
                int stockQty = (int)(long)row["Quantity"];
                lblQuantityOfFigure.Text = $"In Stock: {stockQty}";

                // Load image if available
                if (row["ItemImage"] != DBNull.Value)
                {
                    byte[] imgData = (byte[])row["ItemImage"];
                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        pbxFigureImage.Image = Image.FromStream(ms);
                        pbxFigureImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    pbxFigureImage.Image = null;
                }

                // Enable or disable controls based on stock
                if (stockQty <= 0)
                {
                    numQuantity.Enabled = false;
                    btnAddToCart.Enabled = false;
                    lblFigureOutOfStock.Text = "This figure is currently out of stock.";
                    lblFigureOutOfStock.Visible = true;
                }
                else
                {
                    numQuantity.Enabled = true;
                    numQuantity.Minimum = 1;
                    numQuantity.Maximum = stockQty;
                    numQuantity.Value = 1;

                    btnAddToCart.Enabled = true;
                    lblFigureOutOfStock.Visible = false;
                }

                // Load relevant promo codes for this selected product
                await LoadPromoCodesAsync(inventoryID);
            }
            else
            {
                MessageBox.Show("Product details not found.");
            }
        }

        /// <summary>
        /// Applies the selected promo code and updates discount details,
        /// including cart-level or item-level discounts, and recalculates totals.
        /// </summary>
        private async void cbxPromoCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPromoCode.SelectedIndex < 0)
                return;

            lblPromoCode.Visible = true;

            // Reset discount state
            _discountLevel = -1;
            _discountType = -1;
            _discountPercentage = 0;
            _discountItemName = "";

            // If "No Promo" selected
            if (cbxPromoCode.SelectedValue == DBNull.Value)
            {
                lblPromoCode.ForeColor = Color.Black;
                lblPromoCode.Text = "No promo applied.";
                UpdateTotals();
                return;
            }

            // Otherwise a real promo was selected
            int discountID = (int)(long)cbxPromoCode.SelectedValue;
            DataRow discountRow = await Task.Run(() =>
                clsSQL.GetDiscountByID(discountID));

            if (discountRow == null)
            {
                lblPromoCode.ForeColor = Color.Red;
                lblPromoCode.Text = "Invalid or expired promo code.";
                UpdateTotals();
                return;
            }

            lblPromoCode.ForeColor = Color.Green;

            _discountLevel = (int)(long)discountRow["DiscountLevel"];
            _discountType = (int)(long)discountRow["DiscountType"];
            string promoCode = discountRow["DiscountCode"].ToString();

            // CART LEVEL DISCOUNT
            if (_discountLevel == 0)
            {
                if (_discountType == 0)
                {
                    _discountPercentage = Convert.ToDecimal(discountRow["DiscountPercentage"]);
                    lblPromoCode.Text = $"Promo '{promoCode}' applied: {_discountPercentage:P0} off cart.";
                }
                else
                {
                    decimal amount = Convert.ToDecimal(discountRow["DiscountDollarAmount"]);
                    lblPromoCode.Text = $"Promo '{promoCode}' applied: {amount:C2} off cart.";
                }
            }
            else // ITEM LEVEL DISCOUNT
            {
                if (discountRow["InventoryID"] == DBNull.Value)
                {
                    lblPromoCode.ForeColor = Color.Red;
                    lblPromoCode.Text = "Invalid item-level promo (missing inventory ID).";
                    return;
                }

                int itemID = (int)(long)discountRow["InventoryID"];
                var item = clsCart.GetCartItems().FirstOrDefault(i => i.InventoryID == itemID);

                if (item != null)
                {
                    _discountItemName = item.ProductName;

                    if (_discountType == 0)  // Percentage
                    {
                        _discountPercentage = Convert.ToDecimal(discountRow["DiscountPercentage"]);
                        lblPromoCode.Text = $"Promo '{promoCode}' applied: {_discountPercentage:P0} off {_discountItemName}!";
                    }
                    else // Dollar amount
                    {
                        decimal amount = Convert.ToDecimal(discountRow["DiscountDollarAmount"]);
                        lblPromoCode.Text = $"Promo '{promoCode}' applied: {amount:C2} off {_discountItemName}!";
                    }
                }
                else
                {
                    lblPromoCode.ForeColor = Color.OrangeRed;
                    lblPromoCode.Text = "Promo applies to an item not in the cart.";
                    return;
                }
            }

            // Recalculate totals with the applied promo
            UpdateTotals();
        }

        /// <summary>
        /// Retrieves active promo codes for a specific inventory item and binds them
        /// to the promo code ComboBox, including a "No Promo" option.
        /// </summary>
        /// <param name="inventoryID">
        /// The ID of the inventory item used to filter applicable promo codes.
        /// </param>
        /// <returns>
        /// An asynchronous Task representing the operation.
        /// </returns>
        private async Task LoadPromoCodesAsync(int inventoryID)
        {
            DataTable dt = await Task.Run(() => clsSQL.GetActiveDiscountsSmart(inventoryID));

            DataRow noPromo = dt.NewRow();
            noPromo["DiscountID"] = DBNull.Value;
            noPromo["DiscountCode"] = "No Promo";
            dt.Rows.InsertAt(noPromo, 0);

            cbxPromoCode.DataSource = null;
            cbxPromoCode.DisplayMember = "DiscountCode";
            cbxPromoCode.ValueMember = "DiscountID";
            cbxPromoCode.DataSource = dt;

            cbxPromoCode.SelectedIndex = 0;
        }

        /// <summary>
        /// Retrieves and displays the selected customer's transaction history.
        /// </summary>
        private async void btnViewTransactions_Click(object sender, EventArgs e)
        {
            if (_customerID < 0)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            DataTable dtTransactions = await Task.Run(() =>
                clsSQL.GetCustomerTransactionHistory(_customerID));

            if (dtTransactions == null || dtTransactions.Rows.Count == 0)
            {
                MessageBox.Show("No past transactions found.");
                return;
            }

            clsHTML.GenerateCustomerTransactionsHTML(dtTransactions, _managerName);
        }

        /// <summary>
        /// Reloads product data when the category filter selection changes.
        /// </summary>
        private async void cbxCategoryFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string keyword = tbxSearchFigure.Text.Trim();
            int? categoryID = null;

            if (cbxCategoryFilter.SelectedItem != null)
            {
                DataRowView selected = cbxCategoryFilter.SelectedItem as DataRowView;

                if (selected["CategoryID"] != DBNull.Value)
                {
                    categoryID = (int)(long)selected["CategoryID"];
                }
            }

            await LoadProductDataAsync(keyword, categoryID);
        }

        /// <summary>
        /// Opens the help form for the POS system assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("pos");
            help.ShowDialog();
        }
    }
}
