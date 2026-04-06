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
using System.Xml.Linq;

namespace Module2LogonView
{
    /// <summary>
    /// Provides functionality to add new inventory items or edit
    /// existing inventory items in the system.
    /// </summary>
    public partial class frmAddEditInventoryItem : Form
    {
        /// <summary>
        /// Stores the InventoryID of the item being edited.
        /// If null, the form operates in Add Mode.
        /// </summary>
        private int? _inventoryID = null;   // null = Add mode, value = Edit mode

        /// <summary>
        /// Stores the image data for the inventory item
        /// as a byte array for database storage.
        /// </summary>
        private byte[] _imageData = null;   // store image as byte array

        /// <summary>
        /// Initializes the form in Add Mode.
        /// </summary>
        public frmAddEditInventoryItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the form in Edit Mode for an existing item.
        /// </summary>
        /// <param name="inventoryID">
        /// The unique identifier of the inventory item to edit.
        /// </param>
        public frmAddEditInventoryItem(int inventoryID)
        {
            InitializeComponent();
            _inventoryID = inventoryID;
        }

        /// <summary>
        /// Handles the form load event and loads categories.
        /// If editing an item, existing item data is retrieved.
        /// </summary>
        private void frmAddEditInventoryItem_Load(object sender, EventArgs e)
        {
            LoadCategories();

            // If editing, load item from DB
            if (_inventoryID != null)
            {
                LoadItemData(_inventoryID.Value);
            }
        }

        /// <summary>
        /// Loads all inventory categories from the database
        /// and binds them to the category ComboBox.
        /// </summary>
        private void LoadCategories()
        {
            DataTable dt = clsSQL.GetAllCategories();
            cbxCategoryID.DataSource = dt;
            cbxCategoryID.DisplayMember = "CategoryName";
            cbxCategoryID.ValueMember = "CategoryID";
        }

        /// <summary>
        /// Retrieves inventory item data from the database
        /// and populates the form fields for editing.
        /// </summary>
        /// <param name="id">
        /// The InventoryID of the item to load.
        /// </param>
        private void LoadItemData(int id)
        {
            DataRow r = clsSQL.GetInventoryByID(id);

            if (r == null)
            {
                MessageBox.Show("Item not found.");
                return;
            }

            tbxItemName.Text = r["ItemName"].ToString();
            tbxItemDescription.Text = r["ItemDescription"].ToString();

            cbxCategoryID.SelectedValue = (int)(long)r["CategoryID"];
            numRetailPrice.Value = Convert.ToDecimal(r["RetailPrice"]);
            numCost.Value = Convert.ToDecimal(r["Cost"]);
            numQuantity.Value = (int)(long)r["Quantity"];
            numRestockThreshold.Value = (int)(long)r["RestockThreshold"];
            ckxDiscontinued.Checked = Convert.ToBoolean(r["Discontinued"]);

            if (r["ItemImage"] != DBNull.Value)
            {
                _imageData = (byte[])r["ItemImage"];
                pbxFigureImage.Image = Image.FromStream(new MemoryStream(_imageData));
                pbxFigureImage.SizeMode = PictureBoxSizeMode.Zoom;   
            }
            else
            {
                pbxFigureImage.Image = null;
            }
        }

        /// <summary>
        /// Validates the form inputs before saving.
        /// </summary>
        /// <returns>
        /// True if the form data is valid; otherwise false.
        /// </returns>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(tbxItemName.Text))
            {
                MessageBox.Show("Name required.");
                return false;
            }

            if (cbxCategoryID.SelectedIndex < 0)
            {
                MessageBox.Show("Select a category.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Saves the inventory item to the database.
        /// Updates an existing item in Edit Mode or
        /// creates a new item in Add Mode.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string name = tbxItemName.Text;
            string description = tbxItemDescription.Text;
            int categoryID = (int)(long)cbxCategoryID.SelectedValue;
            decimal cost = numCost.Value;
            decimal price = numRetailPrice.Value;
            int quantity = (int)numQuantity.Value;
            int restockThreshold = (int)numRestockThreshold.Value;

            // "Available" means NOT discontinued
            bool available = !ckxDiscontinued.Checked;

            // EDIT MODE
            if (_inventoryID != null)
            {
                bool success = clsSQL.UpdateInventoryItem(
                    _inventoryID.Value,
                    name,
                    description,
                    categoryID,
                    cost,
                    price,
                    quantity,
                    restockThreshold,
                    available,
                    _imageData  // may be null - keeps existing if SQL handles it
                );

                if (success)
                {
                    MessageBox.Show("Item updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error updating item.");
                }
            }
            else
            {
                // ADD MODE
                bool success = clsSQL.AddInventoryItem(
                    name,
                    description,
                    categoryID,
                    cost,
                    price,
                    quantity,
                    restockThreshold,
                    available,
                    _imageData
                );

                if (success)
                {
                    MessageBox.Show("Item added successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error adding item.");
                }
            }
        }

        /// <summary>
        /// Cancels the operation and closes the form
        /// without saving changes.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Closes form without updating anything
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Allows the user to upload an image for the inventory item.
        /// The selected image is converted to a byte array
        /// and displayed in the PictureBox.
        /// </summary>
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _imageData = File.ReadAllBytes(ofd.FileName);
                pbxFigureImage.Image = Image.FromStream(new MemoryStream(_imageData));
                pbxFigureImage.SizeMode = PictureBoxSizeMode.Zoom;   
            }
        }
    }
}
