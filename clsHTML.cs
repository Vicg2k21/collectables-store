using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2LogonView
{
    /// <summary>
    /// Provides methods to generate HTML reports and receipts for orders,
    /// sales, inventory, and customer transactions.
    /// </summary>
    public static class clsHTML
    {
        /// <summary>
        /// Generates an HTML receipt for a completed order and opens it in the default browser.
        /// </summary>
        /// <param name="items">List of items in the cart.</param>
        /// <param name="subtotal">Subtotal before discounts and taxes.</param>
        /// <param name="discountAmount">Total discount applied.</param>
        /// <param name="taxRate">Applicable tax rate as a decimal (e.g., 0.0825 for 8.25%).</param>
        /// <param name="finalTotal">Final total after discounts and taxes.</param>
        /// <param name="orderID">Unique identifier for the order.</param>
        /// <param name="promoCode">Applied promo code, if any.</param>
        /// <param name="customerName">Customer's full name.</param>
        /// <param name="customerPhone">Customer's phone number.</param>
        /// <param name="discountType">Discount type: 0 = percentage, 1 = flat amount.</param>
        /// <param name="discountRate">Discount rate applied (percentage or dollar amount).</param>
        /// <param name="managerName">Optional manager or employee name associated with the order.</param>
        public static void GenerateReceipt(
            List<CartItem> items,
            decimal subtotal,
            decimal discountAmount,
            decimal taxRate,
            decimal finalTotal,
            int orderID,
            string promoCode,
            string customerName,
            string customerPhone,
            int discountType,       
            decimal discountRate,
            string managerName = null  
            )
        {
            // Create the output folder
            string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YourApplication");
            Directory.CreateDirectory(docPath); // Create if not exists

            string fileName = $"Receipt_{orderID}_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            string filePath = Path.Combine(docPath, fileName);

            // Generate the HTML content
            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html><head>");
            html.AppendLine("<meta charset='UTF-8'>");
            html.AppendLine("<title>Order Receipt</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: Arial, sans-serif; margin: 40px; }");
            html.AppendLine("table { border-collapse: collapse; width: 100%; }");
            html.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; }");
            html.AppendLine("th { background-color: #f2f2f2; }");
            html.AppendLine(".right { text-align: right; }");
            html.AppendLine("</style>");
            html.AppendLine("</head><body>");

            html.AppendLine($"<h2>Order Receipt - #{orderID}</h2>");
            html.AppendLine($"<p>Date: {DateTime.Now:MMMM dd, yyyy hh:mm tt}</p>");

            if (!string.IsNullOrWhiteSpace(customerName))
                html.AppendLine($"<p><strong>Customer:</strong> {customerName}</p>");

            if (!string.IsNullOrWhiteSpace(customerPhone))
                html.AppendLine($"<p><strong>Phone:</strong> {customerPhone}</p>");

            if (!string.IsNullOrWhiteSpace(promoCode))
            {
                html.AppendLine($"<p>Promo Code: <strong>{promoCode}</strong></p>");
            }
            if (!string.IsNullOrWhiteSpace(managerName))
            {
                html.AppendLine($"<p><strong>Employee:</strong> {managerName}</p>");
            }

            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Product</th><th>Price</th><th>Quantity</th><th>Total</th></tr>");

            foreach (var item in items)
            {
                decimal total = item.Price * item.Quantity;
                html.AppendLine("<tr>");
                html.AppendLine($"<td>{item.ProductName}</td>");
                html.AppendLine($"<td class='right'>{item.Price:C2}</td>");
                html.AppendLine($"<td class='right'>{item.Quantity}</td>");
                html.AppendLine($"<td class='right'>{total:C2}</td>");
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table><br/>");

            decimal discountedTotal = Math.Round(subtotal - discountAmount, 2);
            decimal tax = Math.Round(discountedTotal * taxRate, 2);

            html.AppendLine("<h3>Summary</h3>");
            html.AppendLine("<table>");

            html.AppendLine($"<tr><td>Subtotal</td><td class='right'>{subtotal:C2}</td></tr>");
            if (discountAmount > 0)
            {
                string discountLine = discountType == 0 // 0 = Percentage, 1 = Flat (Dollar)
                    ? $"<tr><td>Discount ({discountRate:P0})</td><td class='right'>-{discountAmount:C2}</td></tr>"
                    : $"<tr><td>Discount</td><td class='right'>-{discountAmount:C2}</td></tr>";

                html.AppendLine(discountLine);
                html.AppendLine($"<tr><td><strong>Discounted Subtotal</strong></td><td class='right'>{subtotal - discountAmount:C2}</td></tr>");
            }

            html.AppendLine($"<tr><td>Tax ({taxRate:P2})</td><td class='right'>{tax:C2}</td></tr>");
            
            html.AppendLine($"<tr><th>Total</th><th class='right'>{finalTotal:C2}</th></tr>");

            html.AppendLine("</table>");

            html.AppendLine("<p>Thank you!</p>");

            html.AppendLine("</body></html>");

            // Write HTML to file
            File.WriteAllText(filePath, html.ToString());

            // Open in browser
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        /// <summary>
        /// Generates an HTML page showing all customer transactions and opens it in the browser.
        /// </summary>
        /// <param name="transactions">DataTable containing transaction information.</param>
        /// <param name="managerName">Optional manager name to include in the report header.</param>
        public static void GenerateCustomerTransactionsHTML(DataTable transactions, string managerName = null)
        {
            string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YourApplication");
            Directory.CreateDirectory(docPath);

            string fileName = $"CustomerTransactions_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            string filePath = Path.Combine(docPath, fileName);

            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html><head>");
            html.AppendLine("<meta charset='UTF-8'>");
            html.AppendLine("<title>Customer Transactions</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: Arial, sans-serif; margin: 40px; }");
            html.AppendLine("table { border-collapse: collapse; width: 100%; }");
            html.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; }");
            html.AppendLine("th { background-color: #f2f2f2; }");
            html.AppendLine(".right { text-align: right; }");
            html.AppendLine("</style>");
            html.AppendLine("</head><body>");

            html.AppendLine("<h2>Customer Transaction History</h2>");

            if (!string.IsNullOrWhiteSpace(managerName))
                html.AppendLine($"<p><strong>Manager:</strong> {managerName}</p>");

            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Order ID</th><th>Date</th><th>Customer</th><th>Total</th></tr>");

            foreach (DataRow row in transactions.Rows)
            {
                int orderID = Convert.ToInt32(row["OrderID"]);
                DateTime orderDate = Convert.ToDateTime(row["OrderDate"]);
                string customerName = row["CustomerName"].ToString();
                decimal total = Convert.ToDecimal(row["Total"]);

                html.AppendLine("<tr>");
                html.AppendLine($"<td>{orderID}</td>");
                html.AppendLine($"<td>{orderDate:MMMM dd, yyyy}</td>");
                html.AppendLine($"<td>{customerName}</td>");
                html.AppendLine($"<td class='right'>{total:C2}</td>");
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</body></html>");

            File.WriteAllText(filePath, html.ToString());
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        /// <summary>
        /// Generates an HTML sales report for the specified date range and opens it in the browser.
        /// </summary>
        /// <param name="sales">DataTable containing sales information.</param>
        /// <param name="startDate">Start date for the report.</param>
        /// <param name="endDate">End date for the report.</param>
        /// <param name="managerName">Optional manager name to include in the report header.</param>
        public static void GenerateSalesReportHTML(DataTable sales, DateTime startDate, DateTime endDate, string managerName = null)
        {
            string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YourApplication");
            Directory.CreateDirectory(docPath);

            string fileName = $"SalesReport_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            string filePath = Path.Combine(docPath, fileName);

            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html><head>");
            html.AppendLine("<meta charset='UTF-8'>");
            html.AppendLine("<title>Sales Report</title>");
            html.AppendLine("<style>body { font-family: Arial; margin: 40px; } table { border-collapse: collapse; width: 100%; } th, td { border: 1px solid #ddd; padding: 8px; } th { background-color: #f2f2f2; } .right { text-align: right; }</style>");
            html.AppendLine("</head><body>");
            html.AppendLine($"<h2>Sales Report ({startDate:MMMM dd, yyyy} - {endDate:MMMM dd, yyyy})</h2>");

            if (!string.IsNullOrWhiteSpace(managerName))
                html.AppendLine($"<p><strong>Manager:</strong> {managerName}</p>");

            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Order ID</th><th>Date</th><th>Total Sale</th></tr>");

            foreach (DataRow row in sales.Rows)
            {
                int orderID = Convert.ToInt32(row["OrderID"]);
                DateTime orderDate = Convert.ToDateTime(row["OrderDate"]);
                decimal totalSale = Convert.ToDecimal(row["TotalSale"]);

                html.AppendLine("<tr>");
                html.AppendLine($"<td>{orderID}</td>");
                html.AppendLine($"<td>{orderDate:MMMM dd, yyyy}</td>");
                html.AppendLine($"<td class='right'>{totalSale:C2}</td>");
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</body></html>");

            File.WriteAllText(filePath, html.ToString());
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        /// <summary>
        /// Generates an HTML inventory report, highlighting items that need restocking,
        /// and opens it in the default browser.
        /// </summary>
        /// <param name="inventory">DataTable containing inventory information.</param>
        /// <param name="managerName">Optional manager name to include in the report header.</param>
        public static void GenerateInventoryReportHTML(DataTable inventory, string managerName = null)
        {
            string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YourApplication");
            Directory.CreateDirectory(docPath);

            string fileName = $"InventoryReport_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            string filePath = Path.Combine(docPath, fileName);

            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html><head>");
            html.AppendLine("<meta charset='UTF-8'>");
            html.AppendLine("<title>Inventory Report</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: Arial; margin: 40px; }");
            html.AppendLine("table { border-collapse: collapse; width: 100%; }");
            html.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; }");
            html.AppendLine("th { background-color: #f2f2f2; }");
            html.AppendLine(".right { text-align: right; }");
            html.AppendLine(".restock { background-color: #ff0000; }");  
            html.AppendLine("</style>");
            html.AppendLine("</head><body>");
            html.AppendLine("<h2>Inventory Report</h2>");

            if (!string.IsNullOrWhiteSpace(managerName))
                html.AppendLine($"<p><strong>Manager:</strong> {managerName}</p>");

            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Inventory ID</th><th>Item Name</th><th>Cost</th><th>Price</th><th>Quantity</th><th>Restock Threshold</th><th>Discontinued</th></tr>");

            foreach (DataRow row in inventory.Rows)
            {
                int qty = Convert.ToInt32(row["Quantity"]);
                int threshold = Convert.ToInt32(row["RestockThreshold"]);
                bool needsRestock = qty <= threshold;

     
                string rowClass = needsRestock ? " class='restock'" : "";

                html.AppendLine($"<tr{rowClass}>");
                html.AppendLine($"<td>{row["InventoryID"]}</td>");
                html.AppendLine($"<td>{row["ItemName"]}</td>");
                html.AppendLine($"<td class='right'>{Convert.ToDecimal(row["Cost"]):C2}</td>");
                html.AppendLine($"<td class='right'>{Convert.ToDecimal(row["RetailPrice"]):C2}</td>");
                html.AppendLine($"<td class='right'>{qty}</td>");
                html.AppendLine($"<td class='right'>{threshold}</td>");
                html.AppendLine($"<td>{(Convert.ToBoolean(row["Discontinued"]) ? "Yes" : "No")}</td>");
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</body></html>");

            File.WriteAllText(filePath, html.ToString());
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}
