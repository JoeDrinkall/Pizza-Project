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
            var basket = (Basket)Session["Basket"];
            gvBasket.DataSource = basket.Items;
            gvBasket.DataBind();
            gvBasket.FooterRow.Cells[2].Text = "TOTAL: ";
            gvBasket.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            gvBasket.FooterRow.Cells[3].Text = String.Format("{0:C}", basket.GetTotal());
            gvBasket.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;

        }

        protected void gvBasket_RowCommand(object sender, CommandEventArgs e)
        {
            var basket = (Basket)Session["Basket"];

            if (e.CommandName == "Remove")
            {
                basket.RemoveItem(int.Parse(e.CommandArgument.ToString()));
            }
            
            gvBasket.DataSource = basket.Items;
            gvBasket.DataBind();
            gvBasket.FooterRow.Cells[2].Text = "TOTAL: ";
            gvBasket.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            gvBasket.FooterRow.Cells[3].Text = String.Format("{0:C}", basket.GetTotal());
            gvBasket.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            var userId = (int)Session["UserId"];
            var basket = (Basket)Session["Basket"];

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["pizzadb"].ConnectionString);
            connection.Open();
            var command = new SqlCommand("INSERT INTO Orders (StudentId, OrderDate) VALUES (@studentId, @orderdate); SELECT SCOPE_IDENTITY()", connection);
            command.Parameters.AddWithValue("@studentId", userId);
            command.Parameters.AddWithValue("@orderdate", DateTime.Now);            
            var orderId = (int)command.ExecuteNonQuery();

            foreach (var item in basket.Items)
            {
                command = new SqlCommand("INSERT INTO OrderItems (OrderId, ProductName, Quantity, ProductPrice) VALUES (@orderId, @productname, @quantity, @productprice)", connection);
                command.Parameters.AddWithValue("@orderId", orderId);
                command.Parameters.AddWithValue("@productname", item.ProductName);
                command.Parameters.AddWithValue("@quantity", item.Quantity);
                command.Parameters.AddWithValue("@productprice", item.ProductPrice);
                command.ExecuteNonQuery();
            }

            Response.Redirect("ThankYouForYourOrder.aspx");
        }
    }
}