using Pizza_Project.Models;
using System;
using System.Web.UI.WebControls;

namespace Pizza_Project.Pages
{
    public partial class StaffScreen : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //Show the orders that are not completed yet when the page loads
            ShowUncompletedOrders();
        }

        protected void gvOrders_RowCommand(object sender, CommandEventArgs e)
        {
            //Create a new instance of the DataAccess class
            var dataAccess = new DataAccess();

            //If the user has clicked on View then get the items for this order and show them in the grid
            if (e.CommandName == "View")
            {
                var orderId = int.Parse(e.CommandArgument.ToString());
                var orderItems = dataAccess.GetOrderItems(orderId);
                gvOrderDetails.DataSource = orderItems;
                gvOrderDetails.DataBind();
            }

            //If the user has clicked Making then set the order status to be Making
            if (e.CommandName == "Making")
            {
                var orderId = int.Parse(e.CommandArgument.ToString());
                dataAccess.SetOrderStatus(orderId, OrderStatus.Making);
                ShowUncompletedOrders();
            }

            //If the user has clicked Complete then set the order status to be Completed
            if (e.CommandName == "Complete")
            {
                var orderId = int.Parse(e.CommandArgument.ToString());
                dataAccess.SetOrderStatus(orderId, OrderStatus.Completed);
                ShowUncompletedOrders();
            }
        }

        private void ShowUncompletedOrders()
        {
            //Get the uncompleted orders from DataAccess and bind them to the grid
            var dataAccess = new DataAccess();
            var orderItems = dataAccess.GetUncompletedOrders();
            gvOrders.DataSource = orderItems;
            gvOrders.DataBind();
        }
    }
}