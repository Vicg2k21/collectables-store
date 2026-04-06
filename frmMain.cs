using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Module2LogonView
{
    /// <summary>
    /// Main login form that allows users to authenticate,
    /// create accounts, reset passwords, or continue as a guest.
    /// Redirects users to the appropriate form based on their role.
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// Gets the unique identifier of the logged-in user.
        /// Null if the user has not logged in.
        /// </summary>
        // For guests when logging in through FigureDetails form
        public int? LoggedInPersonID { get; private set; }

        /// <summary>
        /// Initializes the main login form and prepares the application for use.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            tbxPassword.UseSystemPasswordChar = true;

            // Ensure database indexes exist for Module 4 Threading/Optimization
            clsSQL.EnsureIndexes();

            this.Activated += frmMain_Activated;
        }

        /// <summary>
        /// Handles the login process by validating input,
        /// authenticating the user, and redirecting them
        /// to the appropriate form based on their role.
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            clsLogon logon = new clsLogon();

            // Validate input (UI only receives the result)
            string validationMessage = logon.ValidateInput(username, password);
            if (validationMessage != null)
            {
                MessageBox.Show(validationMessage);
                return;
            }

            // Authenticate user
            string positionTitle = await Task.Run(() =>
                logon.Authenticate(username, password));
            if (positionTitle == null)
            {
                MessageBox.Show("Login failed. Invalid username or password.");
                return;
            }

            // Fetch PersonID
            LoggedInPersonID = await Task.Run(() =>
                logon.GetPersonID(username));

            if (LoggedInPersonID == null)
            {
                MessageBox.Show("Login succeeded but PersonID could not be retrieved.");
                return;
            }

            MessageBox.Show("Login successful! Debug: User is a " + positionTitle);

            this.DialogResult = DialogResult.OK;

            // Redirect based on role
            if (positionTitle.ToLower().Contains("manager"))
            {
                var managerForm = new frmManager(LoggedInPersonID.Value);
                managerForm.FormClosed += (s, args) => this.Show();
                managerForm.Show();
                this.Hide();
            }
            else
            {
                var catalogForm = new frmFigureCatalog(LoggedInPersonID.Value);
                catalogForm.FormClosed += (s, args) => this.Show();
                catalogForm.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Toggles the visibility of the password field.
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        /// <summary>
        /// Opens the form to create an account.
        /// </summary>
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            frmCreateAccount createForm = new frmCreateAccount();
            createForm.ShowDialog();
        }

        /// <summary>
        /// Opens the form to reset password.
        /// </summary>
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            frmResetPassword resetForm = new frmResetPassword();
            resetForm.ShowDialog();
        }

        /// <summary>
        /// Opens the help form for login assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp helpForm = new frmHelp("login");
            helpForm.ShowDialog();
        }

        /// <summary>
        /// Allows the user to continue browsing the catalog as a guest.
        /// Guest users cannot access cart or order history features.
        /// </summary>
        private void btnContinueAsGuest_Click(object sender, EventArgs e)
        {
            frmFigureCatalog guestCatalog = new frmFigureCatalog(-1); // -1 for guest

            // Return to login when catalog closes
            guestCatalog.FormClosed += (s, args) => this.Show();

            guestCatalog.Show();
            this.Hide();

        }

        /// <summary>
        /// Clears login fields when the form regains focus.
        /// </summary>
        private void frmMain_Activated(object sender, EventArgs e)
        {
            tbxUsername.Text = "";
            tbxPassword.Text = "";
            chkShowPassword.Checked = false;
        }
    }
}
