using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EasyShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } = "";
        [Precision(6, 2)]
        [DisplayName("Total Value")]
        public decimal TotalValue { get; set; }
        public List<OrderDetail>? Details { get; set; }

        public Order(string customerId)
        {
            CustomerId = customerId;
        }

        internal void recalculateTotal()
        {
            decimal total = 0;
            if (this.Details != null)
            {
                foreach (OrderDetail od in this.Details)
                {
                    total += od.TotalValue;
                }
            }
            this.TotalValue = total;
        }

        internal void updateDetail(Product product, int quantity)
        {
            if (this.Details == null)  throw new Exception("can't update an item on a null detail list"); 

            bool existe = false;
            //add item to order details by product and quantity
            foreach (OrderDetail od in this.Details)
            {
                if (od.ProductId == product.Id)
                {
                    existe = true;
                    od.Quantity += quantity;
                    od.TotalValue = od.Quantity * od.SingleValue;
                    od.OrderId = this.Id;
                    break;
                }
            }

            if (!existe)
            {
                OrderDetail orderDetail = new OrderDetail(product, quantity);
                orderDetail.OrderId= this.Id;
                this.Details.Add(orderDetail);
            }
        }
    }
}
