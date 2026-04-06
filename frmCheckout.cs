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
    /// Checkout form responsible for displaying cart totals,
    /// validating payment information, processing the order,
    /// and generating the customer receipt.
    /// </summary>
    public partial class frmCheckout : Form
    {
        /// <summary>
        /// Promotion code entered by the user that may apply a discount.
        /// </summary>
        private string _promoCode;

        /// <summary>
        /// Discount record retrieved from the database.
        /// </summary>
        private DataRow _discountRow;

        /// <summary>
        /// Unique identifier of the logged-in user.
        /// </summary>
        private int _personID;

        /// <summary>
        /// Full name of the customer placing the order.
        /// </summary>
        private string _customerName;

        /// <summary>
        /// Customer phone number displayed on the receipt.
        /// </summary>
        private string _customerPhone;

        /// <summary>
        /// Initializes the checkout form with customer and promotion information.
        /// </summary>
        /// <param name="promoCode">Promotion code applied to the order.</param>
        /// <param name="personID">Unique identifier of the logged-in user.</param>
        /// <param name="customerName">Customer full name.</param>
        /// <param name="customerPhone">Customer phone number.</param>
        public frmCheckout(string promoCode, int personID, string customerName, string customerPhone)
        {
            InitializeComponent();
            _promoCode = promoCode;
            _personID = personID;
            _customerName = customerName;
            _customerPhone = customerPhone;
        }

        /// <summary>
        /// Loads the checkout form and retrieves discount information
        /// if a promotion code was applied.
        /// </summary>
        private void frmCheckout_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_promoCode))
            {
                _discountRow = clsSQL.GetDiscountByCode(_promoCode);
            }

            DisplayTotals();
        }

        /// <summary>
        /// Calculates and displays the subtotal, discount, tax,
        /// and final total for the current shopping cart.
        /// </summary>
        private void DisplayTotals()
        {
            decimal discountAmt;
            decimal discountedTotal = clsCart.GetDiscountedTotal(_promoCode, out discountAmt, out int discountType);
            decimal subtotal = clsCart.GetSubtotal();
            decimal tax = Math.Round(discountedTotal * 0.0825m, 2);
            decimal finalTotal = Math.Round(discountedTotal + tax, 2);

            lblSubtotal.Text = $"Subtotal: {subtotal:C2}";

            lblTax.Text = $"Tax (8.25%): {tax:C2}";
            lblTax.Visible = true;

            if (discountAmt > 0)
            {
                lblDiscount.Text = $"Discount: -{discountAmt:C2}";
                lblDiscount.Visible = true;
            }
            else
            {
                lblDiscount.Visible = false;
            }

            lblTotal.Text = $"Total (incl. tax): {finalTotal:C2}";
        }

        /// <summary>
        /// Validates payment information and processes the order
        /// when the confirm button is clicked.
        /// </summary>
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validate credit card fields
            if (string.IsNullOrWhiteSpace(mtbCardNumber.Text) ||
                string.IsNullOrWhiteSpace(mtbExpirationDate.Text) ||
                string.IsNullOrWhiteSpace(mtbCVV.Text))
            {
                MessageBox.Show("Please fill in all credit card fields.");
                return;
            }

            // Validate credit card format
            string cardNumber = mtbCardNumber.Text.Trim();
            string expDate = mtbExpirationDate.Text.Trim();

            if (!clsValidation.IsValidCreditCard(cardNumber))
            {
                MessageBox.Show("Invalid credit card number. Must be 16 digits.");
                return;
            }

            if (!clsValidation.IsValidExpDate(expDate))
            {
                MessageBox.Show("Invalid or expired expiration date.");
                return;
            }

            if (!clsValidation.IsValidCVV(mtbCVV.Text.Trim()))
            {
                MessageBox.Show("Invalid CVV. Must be exactly 3 digits.");
                return;
            }

            // Determine discount
            int? discountID = null;
            if (_discountRow != null)
                discountID = Convert.ToInt32(_discountRow["DiscountID"]);

            // Get cart items before inserting the order
            var cartItems = clsCart.GetCartItems();
            if (cartItems == null || cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add items before confirming the order.");
                return;
            }

            // Create and insert order
            Order newOrder = new Order
            {
                PersonID = _personID,
                OrderDate = DateTime.Now,
                DiscountID = discountID,
                CC_Number = cardNumber,
                ExpDate = expDate,
                CCV = mtbCVV.Text.Trim()
            };

            int orderID = 0;

            try
            {
                await Task.Run(() =>
                {
                    // Convert cart items into OrderDetail list
                    List<OrderDetail> detailList = cartItems.Select(item => new OrderDetail
                    {
                        InventoryID = item.InventoryID,
                        Quantity = item.Quantity,
                        DiscountID = item.DiscountID
                    }).ToList();

                    orderID = clsSQL.ProcessOrder(newOrder, detailList);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Checkout failed: " + ex.Message);
                return;
            }

            if (orderID <= 0)
            {
                MessageBox.Show("Order failed. Please try again.");
                return;
            }

            // Generate receipt
            decimal subtotal = clsCart.GetSubtotal();
            decimal discountedTotal = clsCart.GetDiscountedTotal(_promoCode, out decimal discountAmt, out int discountType);
            decimal tax = Math.Round(discountedTotal * 0.0825m, 2);
            decimal finalTotal = Math.Round(discountedTotal + tax, 2);

            clsHTML.GenerateReceipt(cartItems, subtotal, discountAmt, 0.0825m, finalTotal, orderID, _promoCode, _customerName, _customerPhone,
            discountType, _discountRow != null
            ? (Convert.ToInt32(_discountRow["DiscountType"]) == 0
            ? Convert.ToDecimal(_discountRow["DiscountPercentage"])
            : Convert.ToDecimal(_discountRow["DiscountDollarAmount"]))
            : 0m);

            // Clear cart after
            clsCart.ClearCart();

            // Notify and close
            MessageBox.Show("Thank you! Your order has been placed.");
            this.Close();
        }

        /// <summary>
        /// Opens the help form for checkout assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp helpForm = new frmHelp("checkout");
            helpForm.ShowDialog();
        }
    }
}
