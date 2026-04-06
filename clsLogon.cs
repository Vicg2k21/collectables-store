using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2LogonView
{
    /// <summary>
    /// Provides logon validation and authentication functionality
    /// for the application.
    /// </summary>
    internal class clsLogon
    {
        /// <summary>
        /// Validates that the username and password fields
        /// contain valid input values.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns>
        /// A string containing the validation error message if input is invalid;
        /// otherwise returns null if validation succeeds.
        /// </returns>
        public string ValidateInput(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                return "Username is required.";

            if (string.IsNullOrWhiteSpace(password))
                return "Password is required.";

            return null; // No errors
        }

        /// <summary>
        /// Authenticates a user against the database
        /// using the provided username and password.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns>
        /// A string representing the user role if authentication succeeds;
        /// otherwise returns null if authentication fails.
        /// </returns>
        public string Authenticate(string username, string password)
        {
            return clsSQL.AuthenticateUser(username, password);
        }

        /// <summary>
        /// Retrieves the unique PersonID associated
        /// with the specified username.
        /// </summary>
        /// <param name="username">The username used to locate the person record.</param>
        /// <returns>
        /// The PersonID if the username exists in the system;
        /// otherwise returns null.
        /// </returns>
        public int? GetPersonID(string username)
        {
            return clsSQL.GetPersonIDByUsername(username);
        }

    }
}
