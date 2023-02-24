using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Pizza_Project.Models;
using System.Collections.Generic;

namespace Pizza_Project
{
    public class DataAccess
    {
        //This will ;return the details of a user
        public User GetUserDetails(string username, string password)
        {
            var connection = GetConnection(); //Get a connection to the database
            connection.Open();

            //Create the sql command and add parameters
            var command = new SqlCommand("SELECT * FROM Users WHERE Name = @username AND Password = @password", connection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value =  username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            //read in the data
            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //If there are Rows, then it has found a matching user.
            //Create a User object with the data from the database and return it
            if (dataTable.Rows.Count > 0)
            {
                var userId = int.Parse(dataTable.Rows[0]["Id"].ToString());
                var name = dataTable.Rows[0]["Name"].ToString();
                var isStaff = Convert.ToBoolean(dataTable.Rows[0]["IsStaff"]);
                var user = new User()
                {
                    Id = userId,
                    Name = name,
                    IsStaff = isStaff,
                };
                return user;
            }
            //If it cannot find a user, throw an exception.
            throw new Exception("User Not Found");
        }

        //This will check if a user already exists
        public bool CheckUsernameExists(string username)
        {
            //Get a connection to the database
            var connection = GetConnection();
            connection.Open();

            //Create the sql query
            var command = new SqlCommand("SELECT * FROM Users WHERE Name = @username", connection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;

            //Read the data
            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //If it has found a row for this username then there will be more than zero rows.
            //So if there are more than zero rows then we know the user exists
            var userAlreadyExists = dataTable.Rows.Count > 0;

            return userAlreadyExists;
        }


        //This will create a new user in the database
        public int CreateUser(string username, string password)
        {
            //Get the connection to the database
            var connection = GetConnection();
            connection.Open();

            //create the sql query and pass in the parameters.
            //also read out the ID of the new user with SELECT SCOPE_IDENTITY() which will return the new id.
            var command = new SqlCommand("INSERT INTO Users (Name, Password) VALUES (@name, @password); SELECT SCOPE_IDENTITY()", connection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            
            //This will read the new ID
            var orderId = Convert.ToInt32(command.ExecuteScalar());

            return orderId;
        }

        //Saves an order to the database
        public int SaveOrder(Basket basket, int userId)
        {
            //Get a connection to the database
            var connection = GetConnection();
            connection.Open();

            //create a sql command to add the Order and add the parameters and get the new OrderId
            var command = new SqlCommand("INSERT INTO Orders (StudentId, OrderDate) VALUES (@studentId, @orderdate); SELECT SCOPE_IDENTITY()", connection);
            command.Parameters.Add("@studentId", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@orderdate", SqlDbType.DateTime).Value = DateTime.Now;

            //This will read the new OrderId
            var orderId = Convert.ToInt32(command.ExecuteScalar());

            //Add all of the OrderItems from the basket and save them in the OrderItems table
            foreach (var item in basket.Items)
            {
                command = new SqlCommand("INSERT INTO OrderItems (OrderId, ProductName, Quantity, ProductPrice) VALUES (@orderId, @productname, @quantity, @productprice)", connection);
                command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
                command.Parameters.Add("@productname", SqlDbType.VarChar).Value = item.ProductName;
                command.Parameters.Add("@quantity", SqlDbType.Int).Value = item.Quantity;
                command.Parameters.Add("@productprice", SqlDbType.Decimal).Value = item.ProductPrice;
                command.ExecuteNonQuery(); //This will execute the sql command without returning any data
            }

            return orderId;
        }
        
        //This will get all uncompleted orders
        public List<Order> GetUncompletedOrders()
        {
            //Get a connection to the database
            var connection = GetConnection();
            connection.Open();

            //Create the sql command to look for orders that do not have Status 2 (Status 2 is Completed)
            var command = new SqlCommand("SELECT Id, OrderDate, Status FROM Orders WHERE Status <> 2", connection);

            //read in the data
            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //create a new list of Orders
            var orders = new List<Order>();

            //go through each row of data (each row is an order) and add it to the list of orders
            foreach (DataRow row in dataTable.Rows)
            {
                var id = Convert.ToInt32(row["Id"]);
                var date = Convert.ToDateTime(row["OrderDate"]);
                var status = (OrderStatus)Convert.ToInt32(row["Status"]);
                
                orders.Add(new Order
                {
                    Id = id,
                    OrderDate = date,
                    Status = status
                });
            }
            return orders;
        }

        //This will get the items for each order
        public List<OrderItem> GetOrderItems(int orderId)
        {
            //get a connection to the database
            var connection = GetConnection();
            connection.Open();

            //Create a sql command to read orderitems for this order, passing in the orderid.
            var command = new SqlCommand("SELECT Id, ProductName, Quantity FROM OrderItems WHERE OrderId = @orderId", connection);
            command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;

            //read the data
            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            //create a new list of orderitems
            var orderItems = new List<OrderItem>();

            //go through the rows of data (which are orderitems) and create a new OrderItem for each one and add it to the list
            foreach (DataRow itemsRow in dataTable.Rows)
            {
                var id = Convert.ToInt32(itemsRow["Id"]);
                var name = Convert.ToString(itemsRow["ProductName"]);
                var quantity = Convert.ToInt32(itemsRow["Quantity"]);
                orderItems.Add(new OrderItem
                {
                    Id = id,
                    Name = name,
                    Quantity = quantity,
                });
            }
            return orderItems;
        }

        //This will set the status of an order, i.e. Complete or In Progress
        public void SetOrderStatus(int orderId, OrderStatus status)
        {
            //get a connection to the database
            var connection = GetConnection();
            connection.Open();

            //create a sql command to update the order
            var command = new SqlCommand("UPDATE Orders SET Status = @status WHERE Id = @orderId", connection);
            command.Parameters.Add("@status", SqlDbType.Int).Value = status;
            command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;

            command.ExecuteNonQuery();
        }

        //This returns the SQL Connection to the sql database
        private SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["pizzadb"].ConnectionString);
            return connection;
        }
    }
}