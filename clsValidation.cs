using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Module2LogonView
{
    /// <summary>
    /// Provides validation methods for user input throughout the application.
    /// This includes validation for usernames, passwords, addresses, contact
    /// information, and payment details.
    /// </summary>
    internal class clsValidation
    {
        /// <summary>
        /// Validates a username.
        /// The username must:
        /// - Be 8–20 characters long
        /// - Start with a letter
        /// - Contain only letters and digits
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <returns>True if the username meets all requirements; otherwise false.</returns>
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;

            // Reject if it starts or ends with whitespace
            if (username != username.Trim())
                return false;

            // Length and character check
            return Regex.IsMatch(username, @"^[A-Za-z][A-Za-z0-9]{7,19}$");
        }

        /// <summary>
        /// Validates a password.
        /// The password must:
        /// - Be 8–20 characters long
        /// - Contain no spaces
        /// - Meet at least three of the following criteria:
        ///   * Uppercase letter
        ///   * Lowercase letter
        ///   * Digit
        ///   * Special character (!@#$%^&*())
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>True if the password meets the requirements; otherwise false.</returns>
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            if (password.Length < 8 || password.Length > 20) return false;
            if (password.Contains(" ")) return false;

            // Only allow specific characters
            if (!Regex.IsMatch(password, @"^[A-Za-z0-9!@#$%^&*()]+$"))
                return false;

            int criteriaMet = 0;
            if (Regex.IsMatch(password, "[A-Z]")) criteriaMet++;
            if (Regex.IsMatch(password, "[a-z]")) criteriaMet++;
            if (Regex.IsMatch(password, "[0-9]")) criteriaMet++;
            if (Regex.IsMatch(password, @"[!@#$%^&*()]")) criteriaMet++;

            return criteriaMet >= 3;
        }

        /// <summary>
        /// Validates a security question answer.
        /// The answer must not be empty and cannot exceed 20 characters.
        /// </summary>
        /// <param name="answer">The answer to validate.</param>
        /// <returns>True if the answer is valid; otherwise false.</returns>
        public static bool IsValidAnswer(string answer)
        {
            return !string.IsNullOrWhiteSpace(answer) && answer.Length <= 20;
        }

        /// <summary>
        /// Validates a U.S. ZIP code.
        /// Accepts either a 5-digit ZIP code or ZIP+4 format.
        /// </summary>
        /// <param name="zip">The ZIP code to validate.</param>
        /// <returns>True if the ZIP code is valid; otherwise false.</returns>
        public static bool IsValidZip(string zip)
        {
            if (string.IsNullOrWhiteSpace(zip)) return false;
            return Regex.IsMatch(zip.Trim(), @"^\d{5}(-\d{4})?$");
        }

        /// <summary>
        /// Validates a phone number.
        /// The phone number must contain exactly 10 digits after removing formatting.
        /// </summary>
        /// <param name="phone">The phone number to validate.</param>
        /// <returns>True if valid or empty; otherwise false.</returns>
        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true; // Allow NULL or empty
            phone = Regex.Replace(phone, @"[\s\-\(\)]", ""); // Remove formatting
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        /// <summary>
        /// Validates an email address format.
        /// Prevents invalid patterns such as consecutive dots and improper domain formats.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if valid or empty; otherwise false.</returns>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true; // Allow optional
            email = email.Trim();
            // prevents:
            // - consecutive dots
            // - dot at the start or end of local part
            // - invalid domain formats
            return Regex.IsMatch(email,
                @"^(?!.*\.\.)[a-zA-Z0-9](\.?[a-zA-Z0-9_\-+%])*@[a-zA-Z0-9-]+(\.[a-zA-Z]{2,})+$");
        }

        /// <summary>
        /// Validates a U.S. state abbreviation.
        /// </summary>
        /// <param name="state">The state abbreviation to validate.</param>
        /// <returns>True if the abbreviation exists in the list of valid U.S. states.</returns>
        public static bool IsValidState(string state)
        {
            if (string.IsNullOrWhiteSpace(state)) return false;
            return ValidStates.Contains(state.Trim().ToUpper());
        }

        /// <summary>
        /// A collection of valid U.S. state abbreviations.
        /// </summary>
        private static readonly HashSet<string> ValidStates = new HashSet<string>
        {
            "AL","AK","AZ","AR","CA","CO","CT","DE","FL","GA","HI","ID","IL","IN","IA",
            "KS","KY","LA","ME","MD","MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ",
            "NM","NY","NC","ND","OH","OK","OR","PA","RI","SC","SD","TN","TX","UT","VT",
            "VA","WA","WV","WI","WY"
        };

        /// <summary>
        /// Validates a credit card number.
        /// The card number must contain exactly 16 digits.
        /// </summary>
        /// <param name="number">The credit card number.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidCreditCard(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return false;
            string digitsOnly = Regex.Replace(number, @"[^\d]", "");
            return Regex.IsMatch(digitsOnly, @"^\d{16}$");
        }

        /// <summary>
        /// Validates a credit card expiration date.
        /// The date must be in the future but no more than 5 years ahead.
        /// Accepts formats MM/yy or MM/yyyy.
        /// </summary>
        /// <param name="expDate">Expiration date string.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidExpDate(string expDate)
        {
            if (!DateTime.TryParseExact(expDate, new[] { "MM/yy", "MM/yyyy" }, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                return false;

            DateTime now = DateTime.Now;
            DateTime maxValid = now.AddYears(5);
            parsedDate = parsedDate.AddMonths(1).AddDays(-1); // Last day of exp month

            return parsedDate >= now && parsedDate <= maxValid;
        }

        /// <summary>
        /// Validates a credit card CVV code.
        /// The CVV must be exactly 3 digits.
        /// </summary>
        /// <param name="cvv">The CVV code.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidCVV(string cvv)
        {
            return Regex.IsMatch(cvv ?? "", @"^\d{3}$");
        }

    }
}