using System;

namespace Pizza_Project
{
    public partial class ThankYouForYourOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This will read the order number from the querystring to display it on the page
            var orderId = Request.QueryString["orderNumber"];
            lblOrderNumber.Text = orderId;
        }
    }
}