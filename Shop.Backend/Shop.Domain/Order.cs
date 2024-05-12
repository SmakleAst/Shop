namespace Shop.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string  CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public Statuses Status { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set;}

        public List<OrderItem> OrderItems { get; set; }
    }
}
