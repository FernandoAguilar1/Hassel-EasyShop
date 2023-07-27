using Microsoft.EntityFrameworkCore;

namespace EasyShop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int quantity { get; set; }

        [Precision(6, 2)]
        public decimal SingleValue { get; set; }

        [Precision(7,2)]
        public decimal TotalValue { get; set; }
    }
}
