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
    /// Provides reporting features for managers, allowing them to
    /// generate sales reports and inventory reports.
    /// </summary>
    public partial class frmManagerReports : Form
    {
        /// <summary>
        /// Unique identifier of the logged-in manager.
        /// </summary>
        private int _managerID;

        /// <summary>
        /// Full name of the manager, retrieved from the database
        /// and displayed in reports. Defaults to "Unknown Manager" if not found.
        /// </summary>
        private string _managerName; // Store the manager's name

        /// <summary>
        /// Initializes the manager reports form for the selected manager.
        /// </summary>
        /// <param name="managerID">Unique identifier of the logged-in manager.</param>
        public frmManagerReports(int managerID)
        {
            InitializeComponent();
            _managerID = managerID;
        }

        /// <summary>
        /// Loads the manager information and sets the default report options
        /// when the form opens.
        private async void frmManagerReports_Load(object sender, EventArgs e)
        {
            var dtManager = await Task.Run(() =>
                clsSQL.GetManagerByID(_managerID));
            if (dtManager.Rows.Count > 0)
            {
                _managerName = dtManager.Rows[0]["NameFirst"].ToString() + " " + dtManager.Rows[0]["NameLast"].ToString();
            }
            else
            {
                _managerName = "Unknown Manager"; // fallback
            }

            // Default selections
            rbSalesTotals.Checked = true;
            cbxSalesView.Items.AddRange(new string[] { "Daily", "Weekly", "Monthly" });
            cbxSalesView.SelectedIndex = 0;
            UpdateFilterGroups();
        }

        /// <summary>
        /// Updates filter options when the Sales Totals report type is selected.
        /// </summary>
        private void rbSalesTotals_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilterGroups();
        }

        /// <summary>
        /// Updates filter options when the Inventory report type is selected.
        /// </summary>
        private void rbInventory_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilterGroups();
        }

        /// <summary>
        /// Enables or disables filter groups depending on the selected report type.
        /// </summary>
        private void UpdateFilterGroups()
        {
            gbxSalesFilters.Enabled = rbSalesTotals.Checked;
            gbxInventoryItems.Enabled = rbInventory.Checked;
        }

        /// <summary>
        /// Generates the selected report (sales totals or inventory)
        /// based on the chosen filters.
        /// </summary>
        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (rbSalesTotals.Checked)
            {
                // Get start date from DateTimePicker
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate;

                // Determine endDate based on sales view selection
                string view = cbxSalesView.SelectedItem.ToString();

                if (view == "Daily")
                {
                    endDate = startDate;
                }
                else if (view == "Weekly")
                {
                    endDate = startDate.AddDays(6); 
                }
                else // Monthly
                {
                    endDate = new DateTime(startDate.Year, startDate.Month,
                        DateTime.DaysInMonth(startDate.Year, startDate.Month));
                    startDate = new DateTime(startDate.Year, startDate.Month, 1);
                }

                // Call to SQL layer to get sales totals for date range
                var dtSales = await Task.Run(() =>
                    clsSQL.GetSalesReport(startDate, endDate));

                // Generate and open HTML report for sales
                await Task.Run(() =>
                    clsHTML.GenerateSalesReportHTML(
                        dtSales,
                        startDate,
                        endDate,
                        _managerName));
            }
            else if (rbInventory.Checked)
            {
                int reportType = 0; // default = Available items

                if (rbNeedRestock.Checked)
                    reportType = 1;
                else if (rbAllIncludingDiscontinued.Checked)
                    reportType = 2;

                // Call to SQL layer to get inventory data based on report type
                var dtInventory = await Task.Run(() =>
                    clsSQL.GetInventoryReport(reportType));

                // Generate and open HTML report for inventory
                await Task.Run(() =>
                    clsHTML.GenerateInventoryReportHTML(
                        dtInventory,
                        _managerName));
            }
        }

        /// <summary>
        /// Closes the reports form and returns to the manager screen.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();  // Return to Manager Screen
        }

        /// <summary>
        /// Opens the help form for reports assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp("reports");
            help.ShowDialog();
        }
    }
}
