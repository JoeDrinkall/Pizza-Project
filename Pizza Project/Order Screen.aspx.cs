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
        double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheesePizza_Click(object sender, EventArgs e)
        {
            total += 3.6;
            totalPrice.Text = String.Format("Your total cost is {0:C}", total);
        }

        protected void btnPepperoniPizza_Click(object sender, EventArgs e)
        {
            total += 3.8;
            totalPrice.Text = String.Format("Your total cost is {0:C}", total);
        }
    }
}