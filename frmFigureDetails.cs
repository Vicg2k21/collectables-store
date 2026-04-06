using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2LogonView
{
    /// <summary>
    /// Displays detailed information about a selected figure,
    /// including description, price, image, and stock availability.
    /// Allows logged-in users to add the figure to their shopping cart.
    /// </summary>
    public partial class frmFigureDetails : Form
    {
        /// <summary>
        /// The ID of the currently logged-in user.
        /// A value of -1 indicates a guest user.
        /// </summary>
        private int _personID;

        /// <summary>
        /// The ID of the inventory item being displayed.
        /// </summary>
        private int _inventoryID;

        /// <summary>
        /// Stores the database row containing product information.
        /// </summary>
        private DataRow _productRow;

        /// <summary>
        /// Reference to the catalog form used to refresh inventory data.
        /// </summary>
        private frmFigureCatalog _catalogForm;

        /// <summary>
        /// Initializes the figure details form for a specific inventory item.
        /// </summary>
        /// <param name="inventoryId">The inventory item being viewed.</param>
        /// <param name="personId">The current user's ID.</param>
        /// <param name="catalogForm">Reference to the catalog form.</param>
        public frmFigureDetails(int inventoryID, int personID, frmFigureCatalog catalogForm)
        {
            InitializeComponent();
            _inventoryID = inventoryID;
            _personID = personID;
            _catalogForm = catalogForm;
        }

        /// <summary>
        /// Loads product information from the database when the form opens.
        /// Displays product details including name, description, price,
        /// stock availability, and image.
        /// </summary>
        private async void frmFigureDetails_Load(object sender, EventArgs e)
        {
            _productRow = await Task.Run(() =>
                clsSQL.GetProductDetailsByID(_inventoryID));

            DataRow row = _productRow;

            if (row != null)
            {
                lblNameOfFigure.Text = row["ItemName"].ToString();
                lblFigureDescription.Text = row["ItemDescription"].ToString();
                lblPriceOfFigure.Text = Convert.ToDecimal(row["RetailPrice"]).ToString("C");
                int stockQty = Convert.ToInt32(row["Quantity"]);
                lblQuantityOfFigure.Text = $"In Stock: {stockQty}";

                if (row["ItemImage"] != DBNull.Value)
                {
                    byte[] imgData = (byte[])row["ItemImage"];
                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        pbxFigure.Image = Image.FromStream(ms);
                        pbxFigure.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    pbxFigure.Image = null;
                }

                // Handle stock and login in correct order
                if (stockQty <= 0)
                {
                    // Out of stock
                    numQuantity.Enabled = false;
                    btnAddToCart.Enabled = false;
                    btnAddToCart.Visible = false;

                    btnLoginForGuests.Visible = false;
                    lblNeedToLoginToBuy.Text = "This figure is currently out of stock.";
                    lblNeedToLoginToBuy.Visible = true;
                }
                else if (_personID == -1)
                {
                    // Guest
                    numQuantity.Minimum = 1;
                    numQuantity.Maximum = stockQty;
                    numQuantity.Value = 1;

                    btnAddToCart.Enabled = false;
                    btnAddToCart.Visible = false;

                    btnLoginForGuests.Visible = true;
                    lblNeedToLoginToBuy.Text = "Login required to add items to cart.";
                    lblNeedToLoginToBuy.Visible = true;
                }
                else
                {
                    // Logged in and item in stock
                    numQuantity.Minimum = 1;
                    numQuantity.Maximum = stockQty;
                    numQuantity.Value = 1;

                    btnAddToCart.Enabled = true;
                    btnAddToCart.Visible = true;

                    btnLoginForGuests.Visible = false;
                    lblNeedToLoginToBuy.Visible = false;
                }

            }
            else
            {
                MessageBox.Show("Product details not found.");
                this.Close();
            }
        }

        /// <summary>
        /// Adds the selected figure to the user's shopping cart.
        /// Validates that the requested quantity does not exceed available inventory.
        /// </summary>
        private async void btnAddToCart_Click(object sender, EventArgs e)
        {

            if (_productRow != null)
            {
                int requestedQty = (int)numQuantity.Value;

                // Get current quantity from DB
                int availableQty = await Task.Run(() =>
                    clsSQL.GetAvailableInventoryQuantity(_inventoryID));

                if (requestedQty > availableQty)
                {
                    MessageBox.Show($"Only {availableQty} units are currently available. Please reduce your quantity.");
                    return;
                }

                var item = new CartItem
                {
                    InventoryID = _inventoryID,
                    ProductName = _productRow["ItemName"].ToString(),
                    Price = Convert.ToDecimal(_productRow["RetailPrice"]),
                    Quantity = requestedQty
                };

                clsCart.AddItem(item);
                MessageBox.Show("Item added to cart!");

                // Refresh the catalog after adding an item
                if (_catalogForm != null && !_catalogForm.IsDisposed)
                {
                    await _catalogForm.LoadInventoryDataAsync();
                }

                this.Close();
            }
        }

        /// <summary>
        /// Closes the figure details form and returns the user to the catalog.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes the current forms and opens the login form
        /// to allow guest users to sign in before purchasing.
        /// </summary>
        private void btnLoginForGuests_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the details form

            if (_catalogForm != null && !_catalogForm.IsDisposed)
            {
                _catalogForm.Close(); // Close the catalog form
            }

            using (frmMain loginForm = new frmMain())
            {
                // Just show the login dialog.
                // frmMain will open frmFigureCatalog after successful login.
                loginForm.ShowDialog();
            }
        }

        /// <summary>
        /// Opens the help form for figure details assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp helpForm = new frmHelp("details");
            helpForm.ShowDialog();
        }
    }
}
