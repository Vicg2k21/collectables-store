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
    /// Form used to add a new employee or edit an existing employee.
    /// Handles employee personal information, account credentials,
    /// and position assignment.
    /// </summary>
    public partial class frmAddEditEmployee : Form
    {
        /// <summary>
        /// Unique identifier of the employee being edited.
        /// If null, the form operates in Add Mode.
        /// </summary>
        private int? personID = null;   // null = Add mode

        /// <summary>
        /// Unique identifier of the employee's login account.
        /// Used when updating an existing employee.
        /// </summary>
        private int? logonID = null;

        /// <summary>
        /// Stores the employee's existing password when editing an account.
        /// Used if the user leaves the password field empty during update.
        /// </summary>
        private string existingPassword = null;

        /// <summary>
        /// Initializes the form in Add Employee mode.
        /// </summary>
        public frmAddEditEmployee()
        {
            InitializeComponent();
            this.Text = "Add Employee";
        }

        /// <summary>
        /// Initializes the form in Edit Employee mode.
        /// </summary>
        /// <param name="personID">The unique identifier of the employee being edited.</param>
        /// <param name="logonID">The unique identifier of the employee's login account.</param>
        // Edit mode
        public frmAddEditEmployee(int personID, int logonID)
        {
            InitializeComponent();
            this.Text = "Edit Employee";

            this.personID = personID;
            this.logonID = logonID;
        }

        /// <summary>
        /// Initializes form controls and loads required data
        /// when the Add/Edit Employee form is displayed.
        /// </summary>
        private void frmAddEditEmployee_Load(object sender, EventArgs e)
        {
            // Load positions
            cbxPosition.DataSource = clsSQL.GetPositions();
            cbxPosition.DisplayMember = "PositionTitle";
            cbxPosition.ValueMember = "PositionID";

            ckxDisabled.Visible = personID.HasValue; // only show in edit mode

            // Load Title options
            cbxTitle.Items.Clear();
            cbxTitle.Items.AddRange(new string[] { "", "Mr.", "Mrs.", "Ms.", "Dr." });
            cbxTitle.SelectedIndex = 0;

            // Load Suffix options
            cbxSuffix.Items.Clear();
            cbxSuffix.Items.AddRange(new string[] { "", "Jr.", "Sr.", "II", "III" });
            cbxSuffix.SelectedIndex = 0;

            if (!personID.HasValue)  // ADD MODE
            {
                cbxPosition.Enabled = false;
                // Set default position to Employee
                cbxPosition.SelectedValue = 3; // Employee PositionID

                tbxPassword.Text = ""; // require password

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

                // Make sure answer textboxes and labels are visible
                tbxA1.Visible = tbxA2.Visible = tbxA3.Visible = true;
                lblQ1.Visible = lblQ2.Visible = lblQ3.Visible = true;
            }
            else // EDIT MODE
            {
                cbxPosition.Enabled = true; // manager can change position
                LoadEmployeeData();

                // Hide security questions entirely in edit mode
                cbxQ1.Visible = cbxQ2.Visible = cbxQ3.Visible = false;
                tbxA1.Visible = tbxA2.Visible = tbxA3.Visible = false;
                lblQ1.Visible = lblQ2.Visible = lblQ3.Visible = false;
            }
        }

        /// <summary>
        /// Retrieves employee information from the database
        /// and populates the form fields when editing an employee.
        /// </summary>
        private void LoadEmployeeData()
        {
            if (!personID.HasValue) return;

            DataTable dt = clsSQL.GetEmployeeByID(personID.Value);

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

                existingPassword = row["Password"].ToString();
                tbxPassword.Text = "";

                ckxDisabled.Checked = Convert.ToBoolean(row["AccountDisabled"]);
                cbxPosition.SelectedValue = Convert.ToInt32(row["PositionID"]);
            }
        }

        /// <summary>
        /// Validates all user input and saves the employee record.
        /// Updates an existing employee or creates a new employee
        /// depending on the form mode.
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
                success = clsSQL.AddEmployee(
                    firstName, lastName, email, phone,
                    address1, address2, address3, city, state, zip,
                    username, password,
                    q1ID, a1, q2ID, a2, q3ID, a3
                );
            }

            if (success)
            {
                MessageBox.Show(personID.HasValue ? "Employee updated successfully." : "Employee saved successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save employee.");
            }
        }

        /// <summary>
        /// /// <summary>
        /// Closes the form without saving any changes.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
