namespace CustomerAPI.DTO
{
    public class CustomerOrderDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }

        public int Count { get; set; }

        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductCost { get; set; }
    }
}
