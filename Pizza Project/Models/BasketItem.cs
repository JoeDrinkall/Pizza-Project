using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pizza_Project.Models
{
    internal class BasketItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get { return ProductPrice * Quantity; }
        }
    }
}