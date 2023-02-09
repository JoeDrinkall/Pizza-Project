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
        double total;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sTotal = (string)Session["Users"];
        }

        protected void btnCheesePizza_Click(object sender, EventArgs e)
        {
            string sTotal = (string)Session["UserTotal"];

            totalPrice.Text = sTotal;

            if(totalPrice.Text.Trim().Length == 0)
            {
                totalPrice.Text = "0";
                sTotal = "0";  
            }

            total = double.Parse(sTotal);
            total += 3.6;
            sTotal = total.ToString();
            //lblTotalPrice.Text = String.Format("Your total cost is {0:C}", total);
            totalPrice.Text = total.ToString();

            Session["UserTotal"] = sTotal;
            Response.Write(sTotal);
        }

        protected void btnPepperoniPizza_Click(object sender, EventArgs e)
        {
            string sTotal = (string)Session["UserTotal"];

            totalPrice.Text = sTotal;

            if (totalPrice.Text.Trim().Length == 0)
            {
                totalPrice.Text = "0";
                sTotal = "0";
            }

            total = double.Parse(sTotal);
            total += 3.8;
            sTotal = total.ToString();
            //lblTotalPrice.Text = String.Format("Your total cost is {0:C}", total);
            totalPrice.Text = total.ToString();

            Session["UserTotal"] = sTotal;
            Response.Write(sTotal);
        }
    }
}