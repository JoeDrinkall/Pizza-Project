using System;

namespace Pizza_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Create a new instance of the DataAccess class
            var dataAccess = new DataAccess();

            //Try and get the user details. If there isn't a user it will throw an exception. 
            //If the exception is caught it will show the error message
            //Otherwise it will set the UserId and whether they are Staff in the Session and redirect to the order screen
            try
            {
                var user = dataAccess.GetUserDetails(txtUsername.Text, txtPassword.Text);
                Session["UserId"] = user.Id;
                Session["IsStaff"] = user.IsStaff;
                Response.Redirect("OrderScreen.aspx");
            }
            catch (Exception ex)
            {
                error.Visible = true;
            }              
        }
    }
}