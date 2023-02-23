using Pizza_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza_Project
{
    public partial class ViewBasket : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //Get the basket out of the session
            var basket = (Basket)Session["Basket"];

            //IF there is a basket and it has items then show them on the grid
            if (basket != null && basket.Items != null)
            {
                gvBasket.DataSource = basket.Items;
                gvBasket.DataBind();
                gvBasket.FooterRow.Cells[2].Text = "TOTAL: ";
                gvBasket.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                gvBasket.FooterRow.Cells[3].Text = String.Format("{0:C}", basket.GetTotal());
                gvBasket.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                btnPlaceOrder.Visible = true;
            }
            else
            {
                //If there are no items in the basket then this will make it show the "No items" message
                gvBasket.DataBind();
            }
        }

        //This is called when the user clicks the Remove button
        protected void gvBasket_RowCommand(object sender, CommandEventArgs e)
        {
            //Get the basket from the session
            var basket = (Basket)Session["Basket"];

            if (e.CommandName == "Remove")
            {
                //The CommandArgument contains the ProductId. Need to convert it to an integer
                var productId = int.Parse(e.CommandArgument.ToString());
                basket.RemoveItem(productId);
            }

            //Update the basket in the session
            Session["Basket"] = basket;

            //Re-bind the basket items to the grid
            gvBasket.DataSource = basket.Items;
            gvBasket.DataBind();
            gvBasket.FooterRow.Cells[2].Text = "TOTAL: ";
            gvBasket.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            gvBasket.FooterRow.Cells[3].Text = String.Format("{0:C}", basket.GetTotal());
            gvBasket.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;

            //If the basket is now empty then hide the Place Order button
            if (basket.Items.Count == 0)
            {
                btnPlaceOrder.Visible = false;
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            var userId = (int)Session["UserId"];
            var basket = (Basket)Session["Basket"];

            var dataAccess = new DataAccess();
            var orderId = dataAccess.SaveOrder(basket, userId);

            Response.Redirect($"ThankYouForYourOrder.aspx?orderNumber={orderId}");
        }
    }
}