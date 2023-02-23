
namespace Pizza_Project.Models
{
    //This holds the items in an order
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}