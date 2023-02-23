using System;

namespace Pizza_Project.Pages
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            //Creates a new instance of the DataAccess class
            var dataAccess = new DataAccess();

            //Checks if this user already exists
            var userAlreadyExists = dataAccess.CheckUsernameExists(username);

            //If it does, show the error message, otherwise create the user and send them to the Order screen
            if (userAlreadyExists)
            {
                lblUserExists.Visible = true;
            }
            else
            {
                dataAccess.CreateUser(username, password);
                Response.Redirect("OrderScreen.aspx");
            }

        }
    }
}