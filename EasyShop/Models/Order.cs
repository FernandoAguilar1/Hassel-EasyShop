using Microsoft.EntityFrameworkCore;


namespace EasyShop.Models
{
    public class Order
    {
        public Order(string customerId)
        {
            CustomerId = customerId;
        }

        public int Id { get; set; }
        public string CustomerId { get; set; } = "";
        [Precision(6, 2)]
        public decimal Price { get; set; }
        public List<OrderDetail>? Details { get; set; }
    }
}
