using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2LogonView
{
    /// <summary>
    /// Provides the user interface for creating a new customer account,
    /// including personal information, login credentials, and security questions.
    /// </summary>
    public partial class frmCreateAccount : Form
    {
        /// <summary>
        /// Initializes the create account form.
        /// </summary>
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads security questions and other dropdown options when the form opens.
        /// </summary>
        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            // Load SetID = 1 questions for ComboBox 1
            cbxQ1.DataSource = clsSQL.GetSecurityQuestionsBySet(1);
            cbxQ1.DisplayMember = "QuestionPrompt";
            cbxQ1.ValueMember = "QuestionID";

            // Load SetID = 2 questions for ComboBox 2
            cbxQ2.DataSource = clsSQL.GetSecurityQuestionsBySet(2);
            cbxQ2.DisplayMember = "QuestionPrompt";
            cbxQ2.ValueMember = "QuestionID";

            // Load SetID = 3 questions for ComboBox 3
            cbxQ3.DataSource = clsSQL.GetSecurityQuestionsBySet(3);
            cbxQ3.DisplayMember = "QuestionPrompt";
            cbxQ3.ValueMember = "QuestionID";

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
        }

        /// <summary>
        /// Validates the user's input and attempts to create a new account
        /// in the database.
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = tbxFirstName.Text.Trim();
            string lastName = tbxLastName.Text.Trim();
            string address = tbxAddress.Text.Trim();
            string address2 = tbxAddress2.Text.Trim();
            string address3 = tbxAddress3.Text.Trim(); 
            string city = tbxCity.Text.Trim();
            string state = tbxState.Text.Trim();
            string zip = tbxZip.Text.Trim();
            string email = tbxEmail.Text.Trim();     
            string phone = tbxPhone.Text.Trim();
            string username = tbxUsername.Text; 
            string password = tbxPassword.Text;
            string answer1 = tbxAnswer1.Text.Trim();
            string answer2 = tbxAnswer2.Text.Trim();
            string answer3 = tbxAnswer3.Text.Trim();
            string title = cbxTitle.Text.Trim();
            string middleName = tbxMiddleName.Text.Trim();
            string suffix = cbxSuffix.Text.Trim();
            string phoneSecondary = tbxPhoneSecondary.Text.Trim();

            // Added these validation and required fields
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First Name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Last Name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Primary Address is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("City is required.");
                return;
            }

            // Username validation
            if (!clsValidation.IsValidUsername(username))
            {
                MessageBox.Show("Invalid username. It must be 8–20 characters, start with a letter, and contain only letters and digits.");
                return;
            }

            // Password validation
            if (!clsValidation.IsValidPassword(password))
            {
                MessageBox.Show("Invalid password. Must be 8–20 characters, contain no spaces, and meet at least 3 of 4 criteria:\n - Uppercase\n - Lowercase\n - Digit\n - Special character (!@#$%^&*())");
                return;
            }

            // Security answers validation
            if (!clsValidation.IsValidAnswer(answer1) ||
                !clsValidation.IsValidAnswer(answer2) ||
                !clsValidation.IsValidAnswer(answer3))
            {
                MessageBox.Show("Each security answer must be non-empty and no more than 20 characters.");
                return;
            }

            // Check unique questions
            if (cbxQ1.SelectedValue == null || cbxQ2.SelectedValue == null || cbxQ3.SelectedValue == null)
            {
                MessageBox.Show("Please select a security question for each question.");
                return;
            }

            int q1ID = (int)(long)cbxQ1.SelectedValue;
            int q2ID = (int)(long)cbxQ2.SelectedValue;
            int q3ID = (int)(long)cbxQ3.SelectedValue;

            if (q1ID == q2ID || q1ID == q3ID || q2ID == q3ID)
            {
                MessageBox.Show("Please select three different security questions.");
                return;
            }

            // Email validation
            if (!clsValidation.IsValidEmail(email))
            {
                MessageBox.Show("Invalid email address.");
                return;
            }

            // Phone validation
            if (!clsValidation.IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Phone number must be exactly 10 digits (numbers only).");
                return;
            }

            // ZIP code validation
            if (!clsValidation.IsValidZip(zip))
            {
                MessageBox.Show("Invalid ZIP code. Use 5-digit or 5+4 format (e.g., 12345 or 12345-6789).");
                return;
            }

            // State validation
            if (!clsValidation.IsValidState(state))
            {
                MessageBox.Show("Invalid state. Use a valid 2-letter U.S. abbreviation (e.g., TX, CA).");
                return;
            }

            int positionID = (int)clsSQL.GetPositions()
                            .Select("PositionTitle = 'Customer'")
                            .First()
                            .Field<long>("PositionID");

            bool success = clsSQL.CreateNewUser(
        title, firstName, middleName, lastName, suffix, address, address2, address3,
        city, state, zip, phone, phoneSecondary, username, password, positionID,
        q1ID, answer1, q2ID, answer2, q3ID, answer3,
        email);

            if (success)
            {
                MessageBox.Show("Account created successfully.");
                Close();
            }
            else
            {
                MessageBox.Show("Account creation failed. Please try again.");
            }
        }

        /// <summary>
        /// Opens the help form for account creation assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp helpForm = new frmHelp("create");
            helpForm.ShowDialog();
        }
    }
}
