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
    /// Provides functionality for users to reset their password by
    /// verifying answers to their security questions.
    /// </summary>
    public partial class frmResetPassword : Form
    {
        private int q1ID, q2ID, q3ID;

        /// <summary>
        /// Initializes the reset password form.
        /// </summary>
        public frmResetPassword()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the initial focus to the username textbox when the form loads.
        /// </summary>
        private void frmResetPassword_Load(object sender, EventArgs e)
        {
            tbxUsername.Focus(); // initial focus
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        /// <summary>
        /// Retrieves and displays the security questions for the entered username
        /// when the user leaves the username textbox.
        /// </summary>
        private void tbxUsername_Leave(object sender, EventArgs e)
        {
            var questions = clsSQL.GetSecurityQuestionsForUser(tbxUsername.Text);
            if (questions == null)
            {
                MessageBox.Show("Username not found or no security questions available.");
                return;
            }

            // Set the label text
            lblQ1.Text = questions["Q1Prompt"].ToString();
            lblQ2.Text = questions["Q2Prompt"].ToString();
            lblQ3.Text = questions["Q3Prompt"].ToString();

            // Store the question IDs
            q1ID = Convert.ToInt32(questions["Q1ID"]);
            q2ID = Convert.ToInt32(questions["Q2ID"]);
            q3ID = Convert.ToInt32(questions["Q3ID"]);
        }

        /// <summary>
        /// Validates the user's security answers and updates the password
        /// if the verification is successful.
        /// </summary>
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text.Trim();
            string a1 = tbxA1.Text.Trim();
            string a2 = tbxA2.Text.Trim();
            string a3 = tbxA3.Text.Trim();
            string newPwd = tbxNewPassword.Text;
            string confirmPwd = tbxConfirmPassword.Text;

            // Validate answers
            if (!clsValidation.IsValidAnswer(a1) ||
                !clsValidation.IsValidAnswer(a2) ||
                !clsValidation.IsValidAnswer(a3))
            {
                MessageBox.Show("All answers are required, ≤20 chars, and not whitespace.");
                return;
            }

            // Validate new password
            if (!clsValidation.IsValidPassword(newPwd))
            {
                MessageBox.Show("New password doesn't meet complexity requirements.");
                return;
            }

            if (newPwd != confirmPwd)
            {
                MessageBox.Show("New password and confirmation do not match.");
                return;
            }

            // Verify on DB
            if (!clsSQL.VerifySecurityAnswers(username, q1ID, a1, q2ID, a2, q3ID, a3))
            {
                MessageBox.Show("Security answers are incorrect.");
                return;
            }

            // Finally update
            if (clsSQL.UpdatePassword(username, newPwd))
            {
                MessageBox.Show("Password reset successful.");
                Close();
            }
            else
            {
                MessageBox.Show("Failed to reset password. Please try again.");
            }
        }

        /// <summary>
        /// Opens the help form for password reset assistance.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp helpForm = new frmHelp("reset");
            helpForm.ShowDialog();
        }
    }
}
