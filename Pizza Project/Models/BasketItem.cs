namespace Pizza_Project.Models
{
    //This holds the details of a product being ordered in the basket.
    //There might be several of these in one basket.
    public class BasketItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }

        //This will return the total price of this item by multiplying the price by the quantity
        public decimal TotalPrice
        {
            get { return ProductPrice * Quantity; }
        }
    }
}