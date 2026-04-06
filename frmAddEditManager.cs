using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Module2LogonView
{
    /// <summary>
    /// Provides functionality for adding and editing manager accounts.
    /// Handles manager information, account credentials, security questions,
    /// and position assignment.
    /// </summary>
    public partial class frmAddEditManager : Form
    {
        /// <summary>
        /// Stores the PersonID when editing an existing manager.
        /// Null indicates the form is in Add mode.
        /// </summary>
        private int? personID = null; // null = Add mode

        /// <summary>
        /// Stores the LogonID when editing an existing manager account.
        /// </summary>
        private int? logonID = null;

        /// <summary>
        /// Stores the existing password when editing a manager.
        /// Used when the user leaves the password field empty to retain the original password.
        /// </summary>
        private string existingPassword = null; // stores password for edit mode

        /// <summary>
        /// Initializes the form in Add Manager mode.
        /// </summary>
        // Add mode
        public frmAddEditManager()
        {
            InitializeComponent();
            this.Text = "Add Manager";
        }

        /// <summary>
        /// Initializes the form in Edit Manager mode and loads the
        /// selected manager's information.
        /// </summary>
        /// <param name="personID">The ID of the person record.</param>
        /// <param name="logonID">The ID of the logon account.</param>
        // Edit mode
        public frmAddEditManager(int personID, int logonID)
        {
            InitializeComponent();
            this.Text = "Edit Manager";
            this.personID = personID;
            this.logonID = logonID;
        }

        /// <summary>
        /// Loads manager information from the database and populates
        /// the form fields when editing an existing manager.
        /// </summary>
        private void LoadManagerData()
        {
            if (!personID.HasValue) return;

            DataTable dt = clsSQL.GetManagerByID(personID.Value);

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

                // Store existing password for use if user doesn't change it
                existingPassword = row["Password"].ToString(); 
                // Password textbox stays empty for security
                tbxPassword.Text = "";

                ckxDisabled.Checked = Convert.ToBoolean(row["AccountDisabled"]);

                cbxPosition.SelectedValue = Convert.ToInt32(row["PositionID"]);
            }
        }

        /// <summary>
        /// Loads available position titles from the database and
        /// binds them to the position dropdown list.
        /// </summary>
        private void LoadPositions()
        {
            cbxPosition.DataSource = clsSQL.GetPositions();
            cbxPosition.DisplayMember = "PositionTitle";   // shows "Customer", "Employee", "Manager"
            cbxPosition.ValueMember = "PositionID";       // actual ID in database
        }

        /// <summary>
        /// Initializes form controls when the form loads.
        /// Configures dropdown lists, security questions,
        /// and adjusts UI elements based on Add or Edit mode.
        /// </summary>
        private void frmAddEditManager_Load(object sender, EventArgs e)
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

            if (!personID.HasValue) // Add mode
            {
                // Hide disabled checkbox in Add mode
                ckxDisabled.Visible = false;

                cbxPosition.Enabled = false;        // Disable selection for new managers
                cbxPosition.SelectedValue = 2;  // Default PositionID for Manager

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
            else  // Edit Mode
            {
                ckxDisabled.Visible = true;

                // Hide security questions entirely in edit mode
                cbxQ1.Visible = false;
                cbxQ2.Visible = false;
                cbxQ3.Visible = false;

                tbxA1.Visible = false;
                tbxA2.Visible = false;
                tbxA3.Visible = false;

                lblQ1.Visible = false;
                lblQ2.Visible = false;
                lblQ3.Visible = false;

                LoadManagerData();

                cbxPosition.Enabled = true;     // Enable manager to change position
            }
        }

        /// <summary>
        /// Validates user input and saves the manager record.
        /// In Add mode, a new manager account is created.
        /// In Edit mode, the existing manager information is updated.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Trimmed values for validation
            string firstName = tbxFirstName.Text.Trim();
            string lastName = tbxLastName.Text.Trim();
            string address1 = tbxAddress.Text.Trim();
            string address2 = tbxAddress2.Text.Trim();
            string address3 = tbxAddress3.Text.Trim();
            string city = tbxCity.Text.Trim();
            string state = tbxState.Text.Trim();
            string zip = tbxZip.Text.Trim();
            string email = tbxEmail.Text.Trim();
            string phone = tbxPhone.Text.Trim();
            string username = tbxUsername.Text.Trim();
            string password = tbxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Last name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(address1))
            {
                MessageBox.Show("Primary Address is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("City is required.");
                return;
            }
            if (!clsValidation.IsValidZip(zip))
            {
                MessageBox.Show("Invalid ZIP code.");
                return;
            }
            if (!clsValidation.IsValidState(state))
            {
                MessageBox.Show("Invalid state. Use a 2-letter abbreviation (e.g., TX).");
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is required.");
                return;
            }

            // In Edit Mode, allow empty password to mean "keep existing"
            if (personID.HasValue && logonID.HasValue && string.IsNullOrEmpty(password))
            {
                password = existingPassword;
            }

            // In Add Mode, password is required
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
                    firstName,
                    lastName,
                    email,
                    phone,
                    address1,
                    address2,
                    address3,
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
                // Get selected security questions and answers
                int q1ID = (int)cbxQ1.SelectedValue;
                string a1 = tbxA1.Text.Trim();
                int q2ID = (int)cbxQ2.SelectedValue;
                string a2 = tbxA2.Text.Trim();
                int q3ID = (int)cbxQ3.SelectedValue;
                string a3 = tbxA3.Text.Trim();

                // Validate that all security question answers are filled
                if (string.IsNullOrWhiteSpace(a1) || string.IsNullOrWhiteSpace(a2) || string.IsNullOrWhiteSpace(a3))
                {
                    MessageBox.Show("All security question answers are required.");
                    return;
                }

                // Call AddManager 
                success = clsSQL.AddManager(
                    firstName, lastName, email, phone,
                    address1, address2, address3, city, state, zip,
                    username, password,
                    q1ID, a1, q2ID, a2, q3ID, a3
                );
            }

            if (success)
            {
                MessageBox.Show(personID.HasValue ? "Manager updated successfully." : "Manager saved successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save manager.");
            }
        }

        /// <summary>
        /// Cancels the current operation and closes the form
        /// without saving changes.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
