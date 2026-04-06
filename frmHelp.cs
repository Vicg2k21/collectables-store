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
    public partial class frmHelp : Form
    {
        /// <summary>
        /// Stores the selected help topic used to determine which help content to display.
        /// </summary>
        private string _helpTopic;

        /// <summary>
        /// Initializes the help form with a specific help topic.
        /// </summary>
        /// <param name="helpTopic">The topic used to determine which help content to display.</param>
        public frmHelp(string helpTopic)
        {
            InitializeComponent();
            _helpTopic = helpTopic.ToLower();
        }

        /// <summary>
        /// Loads the appropriate help content based on the selected topic.
        /// </summary>
        private void frmHelp_Load(object sender, EventArgs e)
        {
            switch (_helpTopic)
            {
                case "login":
                    tbxHelp.Text = GetLoginHelp();
                    break;
                case "create":
                    tbxHelp.Text = GetCreateAccountHelp();
                    break;
                case "reset":
                    tbxHelp.Text = GetResetPasswordHelp();
                    break;
                case "catalog":
                    tbxHelp.Text = GetCatalogHelp();
                    break;
                case "details":
                    tbxHelp.Text = GetFigureDetailsHelp();
                    break;
                case "cart":
                    tbxHelp.Text = GetCartHelp();
                    break;
                case "checkout":
                    tbxHelp.Text = GetCheckoutHelp();
                    break;
                case "manager_main":
                    tbxHelp.Text = GetManagerMainHelp();
                    break;
                case "manage_accounts":
                    tbxHelp.Text = GetManageAccountsHelp();
                    break;
                case "manage_customers":
                    tbxHelp.Text = GetManageCustomersHelp();
                    break;
                case "manage_managers":
                    tbxHelp.Text = GetManageManagersHelp();
                    break;
                case "manage_employees":
                    tbxHelp.Text = GetManageEmployeesHelp();
                    break;
                case "reports":
                    tbxHelp.Text = GetReportsHelp();
                    break;
                case "discounts":
                    tbxHelp.Text = GetDiscountsHelp();
                    break;
                case "pos":
                    tbxHelp.Text = GetPosHelp();
                    break;
                case "inventory":
                    tbxHelp.Text = GetInventoryHelp();
                    break;
                default:
                    tbxHelp.Text = GetGeneralHelp();
                    break;
            }

            // Deselect highlighted text on load
            tbxHelp.SelectionStart = 0;
            tbxHelp.SelectionLength = 0;
        }

        private string GetLoginHelp() => @"
-----------------------------
LOGIN FORM HELP

- Enter your username and password.
- Click 'Login' to proceed.
- If you forgot your password, click 'Forgot Password'.
- If you need an account, click 'Create Account'.
- If you would like to browse the figure catalog without logging in, click 'Continue As Guest'.
";

        private string GetCreateAccountHelp() => @"
-----------------------------
CREATE ACCOUNT FORM HELP

Required Fields:
- First Name, Last Name, Address, City, ZipCode, State, Username, Password, Security Questions

Username:
- 8–20 characters, unique
- Starts with a letter
- No spaces or special characters

Password:
- 8–20 characters, no spaces
- Must include at least 3 of:
  * Uppercase, lowercase, number, special character

Phone:
- 10-digit numeric format (e.g., 5551234567)

ZIP Code:
- 12345 or 12345-6789

State:
- 2-letter abbreviation (TX, CA, etc.)

Security Questions:
- Provide short, unique answers (not case-sensitive)
";

        private string GetResetPasswordHelp() => @"
-----------------------------
RESET PASSWORD FORM HELP

Steps:
1. Enter your username, press tab to see your security questions
2. Answer your 3 security questions
3. Enter a new password that meets the criteria
4. Confirm the new password
5. Click 'Reset Password'

Password Rules:
- 8–20 characters
- Must meet 3 of 4 complexity types
- No spaces, case-sensitive
";

        private string GetGeneralHelp() => @"
-----------------------------
GENERAL TIPS

- Use Tab to move between fields
- Click the 'Need Help' button on any form to see instructions for each form.
- Required fields cannot be left blank
";

        private string GetCatalogHelp() => @"
-----------------------------
FIGURE CATALOG HELP

- Browse the available collectible figures.
- Use the search box to find figures by keyword.
- Use the category dropdown to filter by type such as Marvel and DC.
- Select a figure and click 'View Details' for more information.
- Logged-in users can also click 'View Cart' to see their current shopping cart.
- Guests can browse but cannot add items to the cart.
";

        private string GetFigureDetailsHelp() => @"
-----------------------------
FIGURE DETAILS HELP

- View full details about the selected figure.
- Includes name, price, description, stock quantity, and image.
- To purchase, select a quantity and click 'Add to Cart' as long as you are logged in.
- Guests must click 'Login' before they can add items to cart.
- Click 'Back' to return to the catalog.
";

        private string GetCartHelp() => @"
-----------------------------
CART HELP

- View and manage all items you've added to your cart.
- Change quantities in the Quantity column and click 'Update Quantities' to save changes.
- Apply a promo code in the provided box to receive a discount.
- Remove an item with 'Remove Item' or clear the cart entirely with 'Clear Cart'.
- When ready, click 'Checkout' to enter payment details.
- Use 'Continue Shopping' to go back to the catalog.
";

        private string GetCheckoutHelp() => @"
-----------------------------
CHECKOUT HELP

- Review your order summary, subtotal, discount, tax, and total.
- Enter valid payment information:
  * Card Number: 16 digits
  * Expiration: MM/YY (e.g., 07/26)
  * CVV: 3 digits
- Confirm your order to complete the purchase.
- After confirming, a receipt will be generated and the cart will be cleared.
";

        private string GetManagerMainHelp() => @"
-----------------------------
MANAGER MAIN MENU HELP

This screen allows managers to access:
- Inventory Management
- Discount/Promo Code Management
- Customer Management
- Manager Account Management
- Reports
- POS (Point of Sale)

Click any button to open the corresponding management screen.
";

        private string GetManageAccountsHelp() => @"
-----------------------------
MANAGE ACCOUNTS HELP

Use this screen to:
- View all users
- Enable or disable accounts
- Update user information
- Reset passwords
";

        private string GetManageCustomersHelp() => @"
-----------------------------
MANAGE CUSTOMERS HELP

Use this screen to:
- Add new customers
- Update existing customer information
- Disable or remove customer accounts
";

        private string GetManageManagersHelp() => @"
-----------------------------
MANAGE MANAGERS HELP

Use this screen to:
- Add new managers
- Update manager permissions and details
- Disable or remove manager accounts
";

        private string GetManageEmployeesHelp() => @"
-----------------------------
MANAGE EMPLOYEES HELP

Use this screen to:
- Add new employees
- Update employee permissions and details
- Disable or remove employee accounts
";

        private string GetReportsHelp() => @"
-----------------------------
REPORTS HELP

This screen allows you to generate printed HTML reports:

Sales Reports:
- Daily
- Weekly (7 consecutive days)
- Monthly

Inventory Reports:
- Items currently for sale
- Items needing restocked
- All items (including discontinued)

Choose the date using the calendar/date picker and click 'Generate'.
";

        private string GetDiscountsHelp() => @"
-----------------------------
DISCOUNTS / PROMO CODES HELP

Use this screen to:
- Create new promo codes
- Set expiration dates
- Choose item-specific or order-wide discounts
- Enable or disable existing discount codes
";

        private string GetPosHelp() => @"
-----------------------------
POINT OF SALE (POS) HELP

Use this POS system to:
- Look up customer (email, phone, invoice number, etc.)
- Search products and view details
- Add items to the cart
- Apply discounts/promo codes
- Complete a transaction on behalf of the customer
- Print the receipt with the manager name included
";

        private string GetInventoryHelp() => @"
-----------------------------
INVENTORY MANAGEMENT HELP

Use this screen to:
- Search inventory by keyword or category
- Add new products
- Edit product details
- Restock items
- Mark items as discontinued
- View items even if discontinued
- Identify items below restock threshold
";

    }
}
