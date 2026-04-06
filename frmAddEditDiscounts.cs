using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Module2LogonView
{
    /// <summary>
    /// Provides functionality for managers to add new discounts
    /// or edit existing discounts.
    /// </summary>
    public partial class frmAddEditDiscounts : Form
    {
        /// <summary>
        /// Stores the discount identifier. A null value indicates the form is in add mode.
        /// </summary>
        private int? discountID = null; // null = Add Mode

        /// <summary>
        /// Initializes the form in add mode for creating a new discount.
        /// </summary>
        public frmAddEditDiscounts()
        {
            InitializeComponent();
            this.Text = "Add Discount";
        }

        /// <summary>
        /// Initializes the form in edit mode for modifying an existing discount.
        /// </summary>
        /// <param name="discountID">Unique identifier of the discount to edit.</param>
        // Edit Mode
        public frmAddEditDiscounts(int discountID)
        {
            InitializeComponent();
            this.Text = "Edit Discount";
            this.discountID = discountID;
            LoadDiscountData();
        }

        /// <summary>
        /// Loads required data and initializes controls when the form opens.
        /// </summary>
        private void frmAddEditDiscounts_Load(object sender, EventArgs e)
        {
            SetupNumericControls();       // Setup numeric formatting
            LoadDiscountTypeCombo();      // Fill discount types
            LoadInventoryCombo();         // Fill inventory list

            if (discountID.HasValue)
                LoadDiscountData();       // Load existing discount

            numDiscountLevel_ValueChanged(this, EventArgs.Empty); // Enable/disable inventory combo
        }

        /// <summary>
        /// Configures numeric input controls used for discount values.
        /// </summary>
        private void SetupNumericControls()
        {
            // Discount Level (0 or 1 only)
            numDiscountLevel.Minimum = 0;
            numDiscountLevel.Maximum = 1;

            // Percentage discount
            numDiscountPercentage.DecimalPlaces = 2;
            numDiscountPercentage.Increment = 0.01m;
            numDiscountPercentage.Minimum = 0;
            numDiscountPercentage.Maximum = 1.00m; // 100%

            // Dollar discount
            numDiscountDollarAmount.DecimalPlaces = 2;
            numDiscountDollarAmount.Increment = 0.01m;
            numDiscountDollarAmount.Minimum = 0;
            numDiscountDollarAmount.Maximum = 10000m; 
        }

        /// <summary>
        /// Loads the discount type options (percentage or dollar amount)
        /// into the discount type dropdown.
        /// </summary>
        private void LoadDiscountTypeCombo()
        {
            DataTable dtTypes = new DataTable();
            dtTypes.Columns.Add("ID", typeof(int));
            dtTypes.Columns.Add("Name", typeof(string));

            dtTypes.Rows.Add(0, "Percentage");
            dtTypes.Rows.Add(1, "Dollar Amount");

            cbxDiscountType.DataSource = dtTypes;
            cbxDiscountType.ValueMember = "ID";
            cbxDiscountType.DisplayMember = "Name";

            cbxDiscountType.SelectedIndexChanged += cbxDiscountType_SelectedIndexChanged;
        }

        /// <summary>
        /// Loads available inventory items into the inventory selection dropdown.
        /// </summary>
        private void LoadInventoryCombo()
        {
            DataTable dtInventory = clsSQL.GetInventoryWithCategory();

            cbxInventoryID.DataSource = dtInventory;
            cbxInventoryID.ValueMember = "InventoryID";
            cbxInventoryID.DisplayMember = "ItemName";
        }

        /// <summary>
        /// Loads existing discount information into the form when editing a discount.
        /// </summary>
        private void LoadDiscountData()
        {
            DataRow row = clsSQL.GetDiscountByID(discountID.Value);

            if (row != null)
            {
                tbxDiscountCode.Text = row["DiscountCode"].ToString();
                tbxDescription.Text = row["Description"].ToString();

                numDiscountLevel.Value = (int)(long)row["DiscountLevel"];
                cbxDiscountType.SelectedValue = (int)(long)row["DiscountType"];

                numDiscountPercentage.Value =
                    row["DiscountPercentage"] != DBNull.Value
                    ? Convert.ToDecimal(row["DiscountPercentage"])
                    : 0;

                numDiscountDollarAmount.Value =
                    row["DiscountDollarAmount"] != DBNull.Value
                    ? Convert.ToDecimal(row["DiscountDollarAmount"])
                    : 0;

                dtpStartDate.Value =
                    row["StartDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["StartDate"])
                    : DateTime.Now;

                dtpExpirationDate.Value = Convert.ToDateTime(row["ExpirationDate"]);

                if (row["InventoryID"] != DBNull.Value)
                    cbxInventoryID.SelectedValue = (int)(long)row["InventoryID"];
                else
                    cbxInventoryID.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Validates the discount information and saves the discount
        /// by either creating a new record or updating an existing one.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Date validation to ensure discounts have valid date ranges
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime expirationDate = dtpExpirationDate.Value.Date;

            // Prevent expiration date in the past
            if (expirationDate < DateTime.Today)
            {
                MessageBox.Show(
                    "The expiration date cannot be in the past.",
                    "Invalid Expiration Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; // STOP SAVE
            }

            // Prevent expiration date earlier than start date
            if (expirationDate < startDate)
            {
                MessageBox.Show(
                    "The expiration date cannot be earlier than the start date.",
                    "Invalid Date Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; // STOP SAVE
            }

            // Validate item-level discounts require a selected inventory item
            if (numDiscountLevel.Value == 1 && cbxInventoryID.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "You selected Item-Level discount, but no Inventory Item is chosen.",
                    "Missing Inventory Item",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; // STOP SAVE
            }

            bool success;

            int? inventoryID = null;
            if (numDiscountLevel.Value == 1) // Item-Level discount
                inventoryID = cbxInventoryID.SelectedValue != null
                    ? (int?)(long)cbxInventoryID.SelectedValue
                    : null;

            if (discountID.HasValue)
            {
                success = clsSQL.UpdateDiscount(
                    discountID.Value,
                    tbxDiscountCode.Text.Trim(),
                    tbxDescription.Text.Trim(),
                    Convert.ToInt32(numDiscountLevel.Value),
                    inventoryID,
                    Convert.ToInt32(cbxDiscountType.SelectedValue),
                    numDiscountPercentage.Value,
                    numDiscountDollarAmount.Value,
                    dtpStartDate.Value,
                    dtpExpirationDate.Value
                );
            }
            else
            {
                int newID = clsSQL.AddDiscount(
                    tbxDiscountCode.Text.Trim(),
                    tbxDescription.Text.Trim(),
                    Convert.ToInt32(numDiscountLevel.Value),
                    inventoryID,
                    Convert.ToInt32(cbxDiscountType.SelectedValue),
                    numDiscountPercentage.Value,
                    numDiscountDollarAmount.Value,
                    dtpStartDate.Value,
                    dtpExpirationDate.Value
                );

                success = newID > 0;
            }

            if (success)
            {
                MessageBox.Show("Discount saved successfully.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save discount.");
            }

        }

        /// <summary>
        /// Enables or disables the inventory selection depending on the discount level.
        /// </summary>
        private void numDiscountLevel_ValueChanged(object sender, EventArgs e)
        {
            cbxInventoryID.Enabled = (numDiscountLevel.Value == 1); // only enabled for Item-Level discount
            if (!cbxInventoryID.Enabled)
                cbxInventoryID.SelectedIndex = -1;
        }

        /// <summary>
        /// Adjusts the input fields depending on whether the discount
        /// is percentage-based or dollar-based.
        /// </summary>
        private void cbxDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent crash when ComboBox not fully loaded yet
            if (cbxDiscountType.SelectedValue == null)
                return;

            if (int.TryParse(cbxDiscountType.SelectedValue.ToString(), out int selectedType))
            {
                if (selectedType == 0) // Percentage
                {
                    numDiscountDollarAmount.Value = 0;
                    numDiscountDollarAmount.Enabled = false;
                    numDiscountPercentage.Enabled = true;
                }
                else // Dollar Amount
                {
                    numDiscountPercentage.Value = 0;
                    numDiscountPercentage.Enabled = false;
                    numDiscountDollarAmount.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Closes the add/edit discount form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
