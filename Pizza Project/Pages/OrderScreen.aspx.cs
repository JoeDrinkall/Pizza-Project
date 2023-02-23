using Pizza_Project.Models;
using System;
using System.Linq;
namespace Pizza_Project
{
    public partial class Order_Screen : System.Web.UI.Page
    {
        private Basket _basket;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check for an existing basket in the session. If not there, create a new basket
            var basket = (Basket)Session["Basket"];

            if (basket != null)
            {
                _basket = basket;                
            }
            else
            {
                _basket = new Basket();
                Session["Basket"] = _basket;
            }

            //Only show the staff screen link if the user is a staff member
            //It is hidden by default
            var isStaff = Convert.ToBoolean(Session["IsStaff"]);
            if (isStaff)
            {
                btnViewStaffScreen.Visible = true;
            }
        }

        protected void btnViewStaffScreen_Click(object sender, EventArgs e)
        {
            //Send the user to the Staff screen
            Response.Redirect("StaffScreen.aspx");
        }

        protected void btnViewBasket_Click(object sender, EventArgs e)
        {
            //send the user to the view basket screen
            Response.Redirect("ViewBasket.aspx");
        }

        protected void btnCheesePizza_Click(object sender, EventArgs e)
        {
            //This is the handler for a user clicking the add button for a Cheese pizza
            AddToBasket(1, "Cheese Pizza", 3.60m);
        }

        protected void btnPepperoniPizza_Click(object sender, EventArgs e)
        {
            //This is the handler for a user clicking the add button for a Pepperoni pizza
            AddToBasket(2, "Pepperoni Pizza", 3.800m);
        }

        protected void btnFanta_Click(object sender, EventArgs e)
        {
            //This is the handler for a user clicking the add button for a bottle of fanta
            AddToBasket(3, "Bottle of Fanta", 1.50m);
        }

        protected void btnWater_Click(object sender, EventArgs e)
        {
            //This is the handler for a user clicking the add button for a bottle of water
            AddToBasket(4, "Bottle of Water", 1.50m);
        }

        private void AddToBasket(int productId, string name, decimal price)
        {
            //This will add the new item to the basket
            //Then will update the total and save the basket in the session
            _basket.AddItem(productId, name, price);
            lblTotalPrice.Text = String.Format("{0:C}", _basket.GetTotal());
            Session["Basket"] = _basket;
        }
    }
}