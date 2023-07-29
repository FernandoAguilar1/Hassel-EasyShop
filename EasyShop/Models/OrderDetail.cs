using Microsoft.EntityFrameworkCore;

namespace EasyShop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Precision(6, 2)]
        public decimal SingleValue { get; set; }
        [Precision(7, 2)]
        public decimal TotalValue { get; set; }

        public OrderDetail() { }

        public OrderDetail(Product product, int quantity)
        {
            this.ProductId = product.Id;
            this.Quantity = quantity;
            this.SingleValue = product.Price;
            this.TotalValue = product.Price * this.Quantity;
        }
    }
}
