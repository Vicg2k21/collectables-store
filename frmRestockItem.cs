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
    /// Provides a form that allows the user to adjust the quantity
    /// of an inventory item by adding or subtracting stock.
    /// </summary>
    public partial class frmRestockItem : Form
    {

        /// <summary>
        /// Gets the restock amount entered by the user.
        /// This value may be positive (restocking) or negative (removing stock).
        /// </summary>
        public int RestockAmount => (int)numAmount.Value;

        /// <summary>
        /// Stores the current quantity of the selected inventory item.
        /// </summary>
        private int currentQuantity;

        /// <summary>
        /// Initializes the Restock Item form and sets
        /// the item name and current quantity.
        /// </summary>
        /// <param name="itemName">
        /// The name of the inventory item being adjusted.
        /// </param>
        /// <param name="quantity">
        /// The current quantity of the inventory item.
        /// </param>
        public frmRestockItem(string itemName, int quantity)
        {
            InitializeComponent();

            // Set labels
            lblItemName.Text = $"Item: {itemName}";
            currentQuantity = quantity;
            lblCurrentQuantity.Text = $"Current Quantity: {currentQuantity}";

            // Set NumericUpDown limits
            numAmount.Minimum = -currentQuantity; // prevent negative final stock
            numAmount.Maximum = 9999;
            numAmount.Value = 1; // default value
        }

        private void frmRestockItem_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Confirms the restock operation and closes the form,
        /// returning an OK result to the calling form.
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Cancels the restock operation and closes the form
        /// without applying any changes.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Closes form without updating anything
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
