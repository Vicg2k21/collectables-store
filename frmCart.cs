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
    /// Represents the shopping cart form where users can view items,
    /// apply promo codes, update quantities, remove items, and proceed
    /// to checkout.
    /// </summary>
    public partial class frmCart : Form
    {
        /// <summary>
        /// The ID of the person associated with the current cart session.
        /// </summary>
        private int _personID;

        /// <summary>
        /// Determines the level of discount applied.
        /// 0 = cart-level discount, 1 = item-level discount.
        /// </summary>
        private int _discountLevel = -1;         // 0 = cart-level, 1 = item-level

        /// <summary>
        /// Determines the type of discount applied.
        /// 0 = percentage discount, 1 = fixed dollar amount discount.
        /// </summary>
        private int _discountType = -1;          // 0 = percentage, 1 = dollar

        /// <summary>
        /// Stores the percentage discount value when applicable.
        /// </summary>
        private decimal _discountPercentage = 0; // Store as decimal (e.g. 0.20)

        /// <summary>
        /// Stores the item name for item-level promotions.
        /// </summary>
        private string _discountItemName = "";   // For item-level promos

        /// <summary>
        /// Reference to the catalog form used to refresh inventory after checkout.
        /// </summary>
        private frmFigureCatalog _catalogForm;

        /// <summary>
        /// Initializes the cart form with the current user and catalog reference.
        /// </summary>
        /// <param name="personID">The ID of the customer or employee using the cart.</param>
        /// <param name="catalogForm">Reference to the catalog form.</param>
        public frmCart(int personID, frmFigureCatalog catalogForm)
        {
            InitializeComponent();
            _personID = personID;
            _catalogForm = catalogForm;
        }

        /// <summary>
        /// Executes when the cart form loads.
        /// Initializes the cart display and hides the promo message.
        /// </summary>
        private void frmCart_Load(object sender, EventArgs e)
        {
            lblPromoCodeMessage.Visible = false;
            LoadCart();
        }

        /// <summary>
        /// Loads all cart items into the DataGridView and updates totals.
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
        /// Calculates subtotal, discounts, tax, and final total for the cart.
        /// Updates the UI labels with the calculated values.
        /// </summary>
        private void UpdateTotals()
        {
            int discountType;
            decimal discountAmount;

            decimal subtotal = clsCart.GetSubtotal();
            decimal discountedTotal = clsCart.GetDiscountedTotal(tbxPromoCode.Text.Trim(), out discountAmount, out discountType);

            decimal tax = Math.Round(discountedTotal * 0.0825m, 2, MidpointRounding.AwayFromZero);
            decimal finalTotal = discountedTotal + tax;

            lblSubtotal.Text = $"Subtotal: {subtotal:C2}";

            lblTax.Text = $"Tax (8.25%): {tax:C2}";
            lblTax.Visible = true;
            lblTotal.Text = $"Total (incl. tax): {finalTotal:C2}";

            if (discountAmount > 0)
            {
                string discountLabel = "";

                if (_discountLevel == 1 && _discountType == 0)
                {
                    // Item level percentage
                    discountLabel = $"Discount: ({_discountPercentage:P0}) -{discountAmount:C2}";
                }
                else if (_discountLevel == 1 && _discountType == 1)
                {
                    // Item level dollar
                    discountLabel = $"Discount: -{discountAmount:C2}";
                }
                else if (_discountLevel == 0 && _discountType == 0)
                {
                    // Cart level percentage
                    discountLabel = $"Discount: ({_discountPercentage:P0}) -{discountAmount:C2}";
                }
                else if (_discountLevel == 0 && _discountType == 1)
                {
                    // Cart level dollar
                    discountLabel = $"Discount: -{discountAmount:C2}";
                }

                lblDiscount.Text = discountLabel;
                lblDiscount.Visible = true;
            }
            else
            {
                lblDiscount.Visible = false;
            }

            lblTotal.Text = $"Total (incl. tax): {finalTotal:C2}";
        }

        /// <summary>
        /// Applies a promotional discount code to the current cart.
        /// Determines whether the discount is cart-level or item-level
        /// and updates totals accordingly.
        /// </summary>
        private void btnApplyPromo_Click(object sender, EventArgs e)
        {
            string promoCode = tbxPromoCode.Text.Trim();
            var discountRow = clsSQL.GetDiscountByCode(promoCode);

            lblPromoCodeMessage.Visible = true;

            // Reset discount state
            _discountLevel = -1;
            _discountType = -1;
            _discountPercentage = 0;
            _discountItemName = "";

            if (!string.IsNullOrWhiteSpace(promoCode))
            {
                if (discountRow != null)
                {
                    lblPromoCodeMessage.ForeColor = Color.Green;

                    _discountLevel = Convert.ToInt32(discountRow["DiscountLevel"]);
                    _discountType = Convert.ToInt32(discountRow["DiscountType"]);

                    if (_discountLevel == 0) // Cart level
                    {
                        if (_discountType == 0) // Percentage
                        {
                            _discountPercentage = Convert.ToDecimal(discountRow["DiscountPercentage"]);
                            lblPromoCodeMessage.Text = $"Promo '{promoCode}' applied: {_discountPercentage:P0} off your cart!";
                        }
                        else
                        {
                            decimal amount = Convert.ToDecimal(discountRow["DiscountDollarAmount"]);
                            lblPromoCodeMessage.Text = $"Promo '{promoCode}' applied: {amount:C2} off your cart!";
                        }
                    }
                    else if (_discountLevel == 1) // Item level
                    {
                        if (discountRow["InventoryID"] == DBNull.Value)
                        {
                            lblPromoCodeMessage.ForeColor = Color.Red;
                            lblPromoCodeMessage.Text = "Invalid item-level promo code (missing InventoryID).";
                            return;
                        }

                        int itemID = Convert.ToInt32(discountRow["InventoryID"]);
                        var item = clsCart.GetCartItems().FirstOrDefault(i => i.InventoryID == itemID);

                        if (item != null)
                        {
                            _discountItemName = item.ProductName;

                            if (_discountType == 0) // Percentage
                            {
                                _discountPercentage = Convert.ToDecimal(discountRow["DiscountPercentage"]);
                                lblPromoCodeMessage.Text = $"Promo '{promoCode}' applied: {_discountPercentage:P0} off {_discountItemName}!";
                            }
                            else // Dollar amount
                            {
                                decimal amount = Convert.ToDecimal(discountRow["DiscountDollarAmount"]);
                                lblPromoCodeMessage.Text = $"Promo '{promoCode}' applied: {amount:C2} off {_discountItemName}!";
                            }
                        }
                        else
                        {
                            lblPromoCodeMessage.ForeColor = Color.OrangeRed;
                            lblPromoCodeMessage.Text = "Promo applies to an item not currently in your cart.";
                            return;
                        }
                    }
                }
                else
                {
                    lblPromoCodeMessage.ForeColor = Color.Red;
                    lblPromoCodeMessage.Text = "Invalid or expired promo code.";
                }
            }
            else
            {
                lblPromoCodeMessage.ForeColor = Color.Red;
                lblPromoCodeMessage.Text = "Enter a promo code.";
            }

            UpdateTotals(); // Recalculate totals after applying promo
        }

        /// <summary>
        /// Removes the selected item from the shopping cart.
        /// </summary>
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                int inventoryID = (int)dgvCart.CurrentRow.Cells["InventoryID"].Value;
                clsCart.RemoveItem(inventoryID);
                LoadCart();
            }
        }

        /// <summary>
        /// Clears all items from the shopping cart after confirmation.
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
        /// Updates the quantities of items in the cart based on user input.
        /// Validates quantities against available inventory.
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
        /// Opens the checkout form and processes the cart for purchase.
        /// Refreshes the catalog inventory after checkout completes.
        /// </summary>
        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            // Check if the cart is empty before continueing
            var cartItems = clsCart.GetCartItems();
            if (cartItems == null || cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add items before checking out.");
                return;
            }

            var personRow = clsSQL.GetPersonInfo(_personID);

            if (personRow == null)
            {
                MessageBox.Show("Could not retrieve customer info.");
                return;
            }

            string customerName = $"{personRow["NameFirst"]} {personRow["NameLast"]}";
            string customerPhone = personRow["PhonePrimary"]?.ToString() ?? "N/A";

            frmCheckout checkout = new frmCheckout(tbxPromoCode.Text.Trim(), _personID, customerName, customerPhone);
            checkout.ShowDialog();

            // After checkout closes, refresh catalog
            if (_catalogForm != null && !_catalogForm.IsDisposed)
            {
                await _catalogForm.LoadInventoryDataAsync();
            }

            if (clsCart.GetCartItems().Count == 0)
            {
                this.Close(); // Close cart if checkout successful
            }
        }

        /// <summary>
        /// Closes the cart form and returns the user to the catalog.
        /// </summary>
        private void btnContinueShopping_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens the help form for assistance with using the shopping cart.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp helpForm = new frmHelp("cart");
            helpForm.ShowDialog();
        }
    }
}
