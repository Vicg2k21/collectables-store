using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2LogonView
{
    /// <summary>
    /// Represents a customer order within the system.
    /// Stores information about the person placing the order,
    /// payment details, and any applied discounts.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The ID of the discount applied to the order, if any.
        /// </summary>
        public int? DiscountID { get; set; }

        /// <summary>
        /// The ID of the person placing the order.
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// The ID of the manager associated with the order, if applicable.
        /// </summary>
        public int? ManagerID { get; set; }

        /// <summary>
        /// The date and time when the order was created.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// The credit card number used for payment.
        /// </summary>
        public string CC_Number { get; set; }

        /// <summary>
        /// The credit card expiration date.
        /// </summary>
        public string ExpDate { get; set; }

        /// <summary>
        /// The credit card verification value (CVV).
        /// </summary>
        public string CCV { get; set; }
    }

    /// <summary>
    /// Represents an individual item within an order.
    /// Each order may contain multiple order details.
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// The ID of the order this item belongs to.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// The inventory item being purchased.
        /// </summary>
        public int InventoryID { get; set; }

        /// <summary>
        /// The ID of any discount applied to this item.
        /// </summary>
        public int? DiscountID { get; set; }

        /// <summary>
        /// The quantity of the inventory item ordered.
        /// </summary>
        public int Quantity { get; set; }
    }
}
