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
    /// Provides functionality for managers to view, search, add,
    /// edit, and delete discounts.
    /// </summary>
    public partial class frmManagerDiscounts : Form
    {
        /// <summary>
        /// Initializes the Manager Discounts form.
        /// </summary>
        public frmManagerDiscounts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads all discount records when the form is opened.
        /// </summary>
        private async void frmManagerDiscounts_Load(object sender, EventArgs e)
        {
            await LoadDiscountsAsync();
        }

        /// <summary>
        /// Retrieves all discounts from the database asynchronously
        /// and populates the DataGridView.
        /// </summary>
        private async Task LoadDiscountsAsync()
        {
            var dt = await Task.Run(() =>
                clsSQL.GetAllDiscounts());

            dgvDiscounts.DataSource = dt;
            FormatGrid();
        }

        /// <summary>
        /// Applies formatting to the DataGridView columns including
        /// date, percentage, and currency display.
        /// </summary>
        private void FormatGrid()
        {
            if (dgvDiscounts.Columns.Count == 0)
                return;

            // Date formatting
            dgvDiscounts.Columns["StartDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvDiscounts.Columns["ExpirationDate"].DefaultCellStyle.Format = "MM/dd/yyyy";

            // Percentage formatting
            dgvDiscounts.Columns["DiscountPercentage"].DefaultCellStyle.Format = "P0";

            // Dollar formatting
            dgvDiscounts.Columns["DiscountDollarAmount"].DefaultCellStyle.Format = "C2";

            dgvDiscounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Searches for discounts using the keyword entered
        /// in the search textbox.
        /// </summary>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = tbxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                await LoadDiscountsAsync();
                return;
            }

            await SearchDiscountsAsync(keyword);

        }

        /// <summary>
        /// Retrieves discounts matching the provided keyword
        /// and displays them in the grid.
        /// </summary>
        /// <param name="keyword">Search keyword used to filter discounts.</param>
        private async Task SearchDiscountsAsync(string keyword)
        {
            string sqlKeyword = $"%{keyword}%";

            var dt = await Task.Run(() =>
                clsSQL.SearchDiscounts(sqlKeyword));

            dgvDiscounts.DataSource = dt;
            FormatGrid();
        }

        /// <summary>
        /// Clears the search field and reloads all discounts.
        /// </summary>
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            tbxSearch.Clear();
            await LoadDiscountsAsync();

        }

        /// <summary>
        /// Opens the Add Discount form to create a new discount record.
        /// </summary>
        private async void btnAddDiscount_Click(object sender, EventArgs e)
        {
            frmAddEditDiscounts frm = new frmAddEditDiscounts(); // ADD MODE

            if (frm.ShowDialog() == DialogResult.OK)
                await LoadDiscountsAsync();

        }

        /// <summary>
        /// Opens the Edit Discount form for the selected discount.
        /// </summary>
        private async void btnEditDiscount_Click(object sender, EventArgs e)
        {
            if (dgvDiscounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a discount to edit.");
                return;
            }

            int discountID = (int)(long)
                dgvDiscounts.SelectedRows[0].Cells["DiscountID"].Value;

            frmAddEditDiscounts frm = new frmAddEditDiscounts(discountID); // EDIT MODE

            if (frm.ShowDialog() == DialogResult.OK)
                await LoadDiscountsAsync();
        }

        /// <summary>
        /// Deletes the selected discount after confirmation.
        /// </summary>
        private async void btnDeleteDiscount_Click(object sender, EventArgs e)
        {
            if (dgvDiscounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a discount to delete.");
                return;
            }

            int discountID = (int)(long)
                dgvDiscounts.SelectedRows[0].Cells["DiscountID"].Value;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this discount?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            bool success = await Task.Run(() =>
                clsSQL.DeleteDiscount(discountID));

            if (success)
            {
                MessageBox.Show("Discount deleted successfully.");
                await LoadDiscountsAsync();
            }
            else
            {
                MessageBox.Show("Failed to delete discount.");
            }
        }

        /// <summary>
        /// Closes the Manager Discounts form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens the help form for discount management assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("discounts");
            help.ShowDialog();
        }
    }
}
