using Pizza_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza_Project
{
    public partial class Order_Screen : System.Web.UI.Page
    {
        private Basket _basket;

        protected void Page_Load(object sender, EventArgs e)
        {
            var basket = (Basket)Session["Basket"];

            if (basket != null)
            {
                _basket = basket;                
            }
            else
            {
                _basket = new Basket();
            }
        }

        protected void btnCheesePizza_Click(object sender, EventArgs e)
        {
            if (_basket.Items.Any(i => i.ProductId == 1))
            {
                var existingCheesePizzaItem = _basket.Items.First(i => i.ProductId == 1);
                existingCheesePizzaItem.Quantity++;
            }
            else
            {                
                _basket.Items.Add(new BasketItem { ProductId = 1, ProductName = "Cheese Pizza", ProductPrice =3.6m, Quantity = 1 });
            }

            totalPrice.Text = String.Format("{0:C}", _basket.GetTotal());

            Session["Basket"] = _basket;
        }

        protected void btnPepperoniPizza_Click(object sender, EventArgs e)
        {
            if (_basket.Items.Any(i => i.ProductId == 2))
            {
                var existingPepperoniPizzaItem = _basket.Items.First(i => i.ProductId == 2);
                existingPepperoniPizzaItem.Quantity++;
            }
            else
            {                
                _basket.Items.Add(new BasketItem { ProductId = 2, ProductName = "Pepperoni Pizza", ProductPrice = 3.8m, Quantity = 1 });
            }

            totalPrice.Text = String.Format("{0:C}", _basket.GetTotal());

            Session["Basket"] = _basket;
        }

        protected void btnViewBasket_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBasket.aspx");
        }
    }
}