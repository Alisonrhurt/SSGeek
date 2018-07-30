using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;

namespace SSGeek.Models
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return (decimal)Product.Price * (decimal)this.Quantity;
            }
        }
    }
}