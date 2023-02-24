using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace Pizza_Project.Models
{
    //The Basket holds the items being ordered from the order screen
    public class Basket
    {
        public List<BasketItem> Items {get; set;}

        public Basket()
        {
            Items = new List<BasketItem>();
        }

        //This returns the total price of all items in the basket
        public decimal GetTotal()
        {
            var total = 0m;

            foreach (var item in Items)
            {
                total += item.TotalPrice;
            }

            return total;
        }

        //This will remove an item from the list of items in the basket
        public void RemoveItem(int productId)
        {
            var itemToRemove = Items.First(i => i.ProductId == productId);
            Items.Remove(itemToRemove);
        }

        //This will add an item to the list of items in the basket        
        public void AddItem(int productId, string name, decimal price)
        {
            var basketItem = new BasketItem
            {
                ProductId = productId,
                ProductName = name,
                ProductPrice = price,
                Quantity = 1
            };

            AddItemOrIncreaseQuantity(basketItem);
        }

        private void AddItemOrIncreaseQuantity(BasketItem newItem)
        {
            //First check if this product is already in the basket
            //If it is then increase the quantity
            //Otherwise add it to the basket
            if (Items.Any(i => i.ProductId == newItem.ProductId))
            {
                var existingBasketItem = Items.First(i => i.ProductId == newItem.ProductId);
                existingBasketItem.Quantity++;
            }
            else
            {
                Items.Add(newItem);
            }
        }
    }
}
