using System;

namespace Pizza_Project.Models
{
    //This holds an Order
    //It it used when reading an existing order from the database
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }        
        public OrderStatus Status { get; set; }
    }
}