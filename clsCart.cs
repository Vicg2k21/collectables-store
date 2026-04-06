using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module2LogonView
{
    /// <summary>
    /// Represents a single item stored in the shopping cart.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Unique identifier for the inventory item.
        /// </summary>
        public int InventoryID { get; set; }

        /// <summary>
        /// Name of the figure being purchased.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Retail price of the figure.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity of the figure added to the cart.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Optional discount identifier applied to the item.
        /// </summary>
        public int? DiscountID { get; set; }

        /// <summary>
        /// Calculates the total price for this cart item.
        /// </summary>
        /// <returns>Total price.</returns>
        public decimal Total => Price * Quantity;
    }

    /// <summary>
    /// Manages shopping cart operations such as adding items,
    /// removing items, calculating totals, and applying discounts.
    /// </summary>
    internal class clsCart
    {
        /// <summary>
        /// Stores all items currently in the shopping cart.
        /// </summary>
        private static List<CartItem> _items = new List<CartItem>();

        /// <summary>
        /// Adds an item to the shopping cart while checking available inventory.
        /// </summary>
        /// <param name="item">The cart item to add.</param>
        public static void AddItem(CartItem item)
        {
            var existing = _items.FirstOrDefault(i => i.InventoryID == item.InventoryID);
            int availableQty = clsSQL.GetAvailableInventoryQuantity(item.InventoryID);

            if (existing != null)
            {
                if (existing.Quantity + item.Quantity > availableQty)
                {
                    MessageBox.Show($"Cannot add more than {availableQty} units of '{item.ProductName}'.");
                    return;
                }

                existing.Quantity += item.Quantity;
            }
            else
            {
                if (item.Quantity > availableQty)
                {
                    MessageBox.Show($"Only {availableQty} units available for '{item.ProductName}'.");
                    return;
                }

                _items.Add(item);
            }
        }

        /// <summary>
        /// Removes an item from the cart using its inventory ID.
        /// </summary>
        /// <param name="inventoryID">Inventory identifier of the item to remove.</param>
        public static void RemoveItem(int inventoryID)
        {
            _items.RemoveAll(i => i.InventoryID == inventoryID);
        }

        /// <summary>
        /// Removes all items from the shopping cart.
        /// </summary>
        public static void ClearCart()
        {
            _items.Clear();
        }

        /// <summary>
        /// Retrieves a copy of the current cart items.
        /// </summary>
        /// <returns>A list containing all items currently in the cart.</returns>
        public static List<CartItem> GetCartItems()
        {
            return new List<CartItem>(_items);
        }

        /// <summary>
        /// Calculates the subtotal for all items in the cart.
        /// </summary>
        /// <returns>The subtotal amount before discounts and taxes.</returns>
        public static decimal GetSubtotal()
        {
            return _items.Sum(i => i.Total);
        }

        /// <summary>
        /// Calculates the total after applying a promotional discount.
        /// </summary>
        /// <param name="promoCode">Promo code entered by the user.</param>
        /// <param name="discountAmount">Outputs the calculated discount value.</param>
        /// <param name="discountType">Outputs the type of discount (percentage or dollar).</param>
        /// <returns>The cart total after the discount is applied.</returns>
        public static decimal GetDiscountedTotal(string promoCode, out decimal discountAmount, out int discountType)
        {
            discountAmount = 0;
            discountType = -1;
            decimal subtotal = GetSubtotal();

            if (string.IsNullOrWhiteSpace(promoCode))
                return subtotal;

            DataRow discountRow = clsSQL.GetDiscountByCode(promoCode);

            if (discountRow == null)
                return subtotal;

            int discountLevel = Convert.ToInt32(discountRow["DiscountLevel"]);
            discountType = Convert.ToInt32(discountRow["DiscountType"]);

            decimal discountedTotal = subtotal;

            if (discountLevel == 0)
            {
                // Cart Level
                if (discountType == 0) // Percentage
                {
                    decimal percent = Convert.ToDecimal(discountRow["DiscountPercentage"]);
                    discountAmount = subtotal * percent;
                }
                else if (discountType == 1) // Dollar
                {
                    decimal dollarAmount = Convert.ToDecimal(discountRow["DiscountDollarAmount"]);
                    discountAmount = Math.Min(dollarAmount, subtotal);
                }

                discountedTotal = subtotal - discountAmount;
            }
            else if (discountLevel == 1)
            {
                // Item Level
                if (discountRow["InventoryID"] == DBNull.Value)
                    return subtotal; // invalid item-level discount with missing InventoryID

                int itemInventoryID = Convert.ToInt32(discountRow["InventoryID"]);
                var targetItem = _items.FirstOrDefault(i => i.InventoryID == itemInventoryID);

                if (targetItem == null)
                    return subtotal; // item not in cart; no discount applies

                targetItem.DiscountID = Convert.ToInt32(discountRow["DiscountID"]);

                decimal itemTotal = targetItem.Total;

                if (discountType == 0) // Percentage
                {
                    decimal percent = Convert.ToDecimal(discountRow["DiscountPercentage"]);
                    discountAmount = itemTotal * percent;
                }
                else if (discountType == 1) // Dollar
                {
                    decimal dollarAmount = Convert.ToDecimal(discountRow["DiscountDollarAmount"]);
                    discountAmount = Math.Min(dollarAmount, itemTotal);
                }

                discountedTotal = subtotal - discountAmount;
            }
            return discountedTotal;
        }
    }
}
