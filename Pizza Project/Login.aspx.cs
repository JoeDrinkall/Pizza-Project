using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["pizzadb"].ConnectionString);
            connection.Open();
            var command = new SqlCommand("SELECT * FROM Users WHERE Name = @username AND Password = @password", connection);
            command.Parameters.AddWithValue("@username", txtUsername.Text);
            command.Parameters.AddWithValue("@password", txtPassword.Text);
            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                var userId = int.Parse(dataTable.Rows[0]["Id"].ToString());
                Session["UserId"] = userId;
                Response.Redirect("OrderScreen.aspx");
            }                
        }
    }
}