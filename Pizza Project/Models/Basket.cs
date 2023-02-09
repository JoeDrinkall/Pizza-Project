using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Pizza_Project.Models
{
    internal class Basket
    {
        public List<BasketItem> Items {get; set;}

        public Basket()
        {
            Items = new List<BasketItem>();
        }

        public decimal GetTotal()
        {
            var total = 0m;

            foreach (var item in Items)
            {
                total += item.TotalPrice;
            }

            return total;
        }

        public void RemoveItem(int productId)
        {
            var itemToRemove = Items.First(i => i.ProductId == productId);
            Items.Remove(itemToRemove);
        }
    }
}
