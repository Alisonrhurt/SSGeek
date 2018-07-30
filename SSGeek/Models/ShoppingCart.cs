using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
    public class ShoppingCart
    {

        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        public void AddToCart(Product p, int quantity)
        {
            // Find the current item in the cart (if it exists)
            var shoppingCartItem = Items.FirstOrDefault(i => i.Product.ProductId == p.ProductId);

            // If it doesn't exist add it as a "Shopping Cart Item"
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem() { Product = p, Quantity = 0 };
                Items.Add(shoppingCartItem);
            }

            // Update the Quantity            
            shoppingCartItem.Quantity += quantity;

        }

        public decimal GrandTotal
        {
            get
            {
                decimal total = 0.0M;

                foreach (var item in Items)
                {
                    total += (decimal)(item.Product.Price) * item.Quantity;
                }

                return total;
            }
        }

        public void RemoveOne(Product product)
        {
            // Find the cart item
            var item = Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);

            // If it doesnt exist, I don't care, return
            if (item == null)
            {
                return;
            }

            // If it exists and qty is 1, remove from the list
            if (item.Quantity == 1)
            {
                Items.Remove(item);
                return;
            }

            // Otherwise, deduct 1 from quantity
            item.Quantity -= 1;
        }
    }
}