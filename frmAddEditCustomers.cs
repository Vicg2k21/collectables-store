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
    /// Form used to add a new customer or edit an existing customer.
    /// Handles customer personal information, login credentials,
    /// and security questions.
    /// </summary>
    public partial class frmAddEditCustomers : Form
    {
        /// <summary>
        /// Unique identifier of the customer being edited.
        /// If null, the form operates in Add Mode.
        /// </summary>
        private int? personID = null;   // null = Add Mode

        /// <summary>
        /// Unique identifier of the customer's login account.
        /// Used when updating an existing customer.
        /// </summary>
        private int? logonID = null;

        /// <summary>
        /// Stores the customer's existing password when editing.
        /// Used if the password field is left blank.
        /// </summary>
        private string existingPassword = null;

        /// <summary>
        /// Initializes the form in Add Customer mode.
        /// </summary>
        public frmAddEditCustomers()
        {
            InitializeComponent();
            this.Text = "Add Customer";
        }

        /// <summary>
        /// Initializes the form in Edit Customer mode.
        /// </summary>
        /// <param name="personID">Unique identifier of the customer being edited.</param>
        /// <param name="logonID">Unique identifier of the customer's login account.</param>
        // Edit mode
        public frmAddEditCustomers(int personID, int logonID)
        {
            InitializeComponent();
            this.Text = "Edit Customer";

            this.personID = personID;
            this.logonID = logonID;
        }

        /// <summary>
        /// Retrieves customer information from the database
        /// and populates the form fields when editing a customer.
        /// </summary>
        private void LoadCustomerData()
        {
            if (!personID.HasValue) return;

            DataTable dt = clsSQL.GetCustomerByID(personID.Value);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                tbxFirstName.Text = row["NameFirst"].ToString();
                tbxLastName.Text = row["NameLast"].ToString();
                tbxEmail.Text = row["Email"]?.ToString();
                tbxPhone.Text = row["PhonePrimary"]?.ToString();
                tbxUsername.Text = row["LogonName"].ToString();
                tbxAddress.Text = row["Address1"].ToString();
                tbxAddress2.Text = row["Address2"] == DBNull.Value ? "" : row["Address2"].ToString();
                tbxAddress3.Text = row["Address3"] == DBNull.Value ? "" : row["Address3"].ToString();
                tbxCity.Text = row["City"].ToString();
                tbxState.Text = row["State"].ToString();
                tbxZip.Text = row["Zipcode"].ToString();

                // Keep existing password if unchanged
                existingPassword = row["Password"].ToString();
                tbxPassword.Text = "";

                ckxDisabled.Checked =
                    row["AccountDisabled"] != DBNull.Value &&
                    Convert.ToInt32(row["AccountDisabled"]) == 1;

                cbxPosition.SelectedValue = Convert.ToInt32(row["PositionID"]);
            }
        }

        /// <summary>
        /// Validates all customer input and saves the customer record.
        /// Updates an existing customer or creates a new customer
        /// depending on the form mode.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string first = tbxFirstName.Text.Trim();
            string last = tbxLastName.Text.Trim();
            string addr1 = tbxAddress.Text.Trim();
            string addr2 = tbxAddress2.Text.Trim();
            string addr3 = tbxAddress3.Text.Trim();
            string city = tbxCity.Text.Trim();
            string state = tbxState.Text.Trim();
            string zip = tbxZip.Text.Trim();
            string email = tbxEmail.Text.Trim();
            string phone = tbxPhone.Text.Trim();
            string username = tbxUsername.Text.Trim();
            string password = tbxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(first))
            {
                MessageBox.Show("First name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(last))
            {
                MessageBox.Show("Last name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(addr1))
            {
                MessageBox.Show("Address is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("City is required.");
                return;
            }
            if (!clsValidation.IsValidState(state))
            {
                MessageBox.Show("Invalid state format. Example: TX");
                return;
            }
            if (!clsValidation.IsValidZip(zip))
            {
                MessageBox.Show("Invalid ZIP code.");
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is required.");
                return;
            }

            // EDIT MODE – password blank - keep existing
            if (personID.HasValue && string.IsNullOrWhiteSpace(password))
            {
                password = existingPassword;
            }

            // ADD MODE – password required
            if (!personID.HasValue && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password is required.");
                return;
            }

            if (!clsValidation.IsValidUsername(username))
            {
                MessageBox.Show("Invalid username. It must be 8–20 characters, start with a letter, and contain only letters and digits.");
                return;
            }

            if (!clsValidation.IsValidPassword(password))
            {
                MessageBox.Show("Invalid password. Must be 8–20 characters, contain no spaces, and meet at least 3 of 4 criteria:\n - Uppercase\n - Lowercase\n - Digit\n - Special character (!@#$%^&*())");
                return;
            }

            bool success = false;

            // Role Selection
            if (cbxPosition.SelectedValue == null)
            {
                MessageBox.Show("Position is required.");
                return;
            }

            int positionID = Convert.ToInt32(cbxPosition.SelectedValue);
            string positionTitle = cbxPosition.Text;

            if (personID.HasValue && logonID.HasValue)
            {
                success = clsSQL.UpdateAccount(
                    personID.Value,
                    logonID.Value,
                    first,
                    last,
                    email,
                    phone,
                    addr1,
                    addr2,
                    addr3,
                    city,
                    state,
                    zip,
                    username,
                    password,
                    ckxDisabled.Checked,
                    positionID,
                    positionTitle
                );
            }
            else
            {
                // Trimmed security question answers
                string a1 = tbxA1.Text.Trim();
                string a2 = tbxA2.Text.Trim();
                string a3 = tbxA3.Text.Trim();

                // Validate that all security question answers are filled
                if (string.IsNullOrWhiteSpace(a1) || string.IsNullOrWhiteSpace(a2) || string.IsNullOrWhiteSpace(a3))
                {
                    MessageBox.Show("All security question answers are required.");
                    return;
                }

                success = clsSQL.AddCustomer(
                    first,
                    last,
                    email,
                    phone,
                    addr1,
                    addr2,
                    addr3,
                    city,
                    state,
                    zip,
                    username,
                    password,
                    (int)cbxQ1.SelectedValue, a1,
                    (int)cbxQ2.SelectedValue, a2,
                    (int)cbxQ3.SelectedValue, a3
                );
            }

            if (success)
            {
                MessageBox.Show("Customer saved successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save customer.");
            }
        }

        /// <summary>
        /// Loads available position roles into the position dropdown list.
        /// </summary>
        private void LoadPositions()
        {
            cbxPosition.DataSource = clsSQL.GetPositions();
            cbxPosition.DisplayMember = "PositionTitle";
            cbxPosition.ValueMember = "PositionID";
        }

        /// <summary>
        /// Initializes form controls and loads required data
        /// when the Add/Edit Customer form is displayed.
        /// </summary>
        private void frmAddEditCustomers_Load(object sender, EventArgs e)
        {
            LoadPositions();

            // Load Title options
            cbxTitle.Items.Clear();
            cbxTitle.Items.AddRange(new string[] {
            "", "Mr.", "Mrs.", "Ms.", "Dr."
            });
            cbxTitle.SelectedIndex = 0; // Optional: set blank as default

            // Load Suffix options
            cbxSuffix.Items.Clear();
            cbxSuffix.Items.AddRange(new string[] {
            "", "Jr.", "Sr.", "II", "III"
            });
            cbxSuffix.SelectedIndex = 0;
            // Checking above

            if (!personID.HasValue)  // ADD MODE
            {
                ckxDisabled.Visible = false;

                cbxPosition.Enabled = false;        // Manager cannot change position for new customers
                cbxPosition.SelectedValue = 1;   // Customer default

                // Load security questions
                cbxQ1.DataSource = clsSQL.GetSecurityQuestionsBySet(1);
                cbxQ1.DisplayMember = "QuestionPrompt";
                cbxQ1.ValueMember = "QuestionID";

                cbxQ2.DataSource = clsSQL.GetSecurityQuestionsBySet(2);
                cbxQ2.DisplayMember = "QuestionPrompt";
                cbxQ2.ValueMember = "QuestionID";

                cbxQ3.DataSource = clsSQL.GetSecurityQuestionsBySet(3);
                cbxQ3.DisplayMember = "QuestionPrompt";
                cbxQ3.ValueMember = "QuestionID";
            }
            else  // EDIT MODE
            {
                ckxDisabled.Visible = true;

                // Hide ALL security question controls in edit mode
                cbxQ1.Visible = false;
                cbxQ2.Visible = false;
                cbxQ3.Visible = false;

                tbxA1.Visible = false;
                tbxA2.Visible = false;
                tbxA3.Visible = false;

                lblQ1.Visible = false;
                lblQ2.Visible = false;
                lblQ3.Visible = false;

                LoadCustomerData();

                cbxPosition.Enabled = true;   // <-- Enable manager to change position
            }

        }

        /// <summary>
        /// Closes the form without saving changes.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
