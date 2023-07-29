using EasyShop.Data;
using EasyShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Controllers
{
    public class CustomerOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CustomerOrdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var customerId = _userManager.GetUserId(User); // Get user id:
            ViewData["UserId"] = customerId;

            Order? order = null;

            if (customerId != null && _context.Orders != null)
            {
                order = await _context.Orders.FirstOrDefaultAsync(m => m.CustomerId == customerId);
                if (order != null )
                {
                    order.Details = await _context.OrderDetails.Where(od => od.OrderId == order.Id).ToListAsync();

                    foreach (OrderDetail od in order.Details)
                    {
                        if (od.ProductId != 0)
                        {
                            od.product = await _context.Products.Where(p => p.Id == od.ProductId).FirstAsync();
                        }
                        else
                        {
                            od.product = null;
                        }
                    }
                }

                var completeOrder = _context.Orders.Include("OrderDetails").Where(o => o.CustomerId == customerId);
            }

            return View(order);
        }


        public async Task<IActionResult> Add(int productId, int quantity)
        {
            try
            {
                var customerId = _userManager.GetUserId(User); // Get user id:

                //check if product exists
                Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product != null)
                {
                    //get thisCustomer Order
                    Order? order = null;
                    order = await _context.Orders.FirstOrDefaultAsync(m => m.CustomerId == customerId);

                    if (order == null)
                    {
                        order = new Order(customerId);
                        _context.Orders.Add(order);
                    }

                    //load this order details
                    List<OrderDetail> details = await _context.OrderDetails.Where(od => od.OrderId == order.Id).ToListAsync();                
                    order.Details = details;

                    //add item to existing order  
                    if (details == null || details.Count == 0)
                    {
                        //if this order doesn't have details

                        //new order detail by product and quantity
                        OrderDetail orderDetail = new(product, quantity);
                        orderDetail.OrderId = order.Id;
                        order.Details = new List<OrderDetail> { orderDetail };                        
                    }
                    else
                    {
                        //this order already has details
                        order.updateDetail(product, quantity);
                    }

                    //recalculate total of the order
                    order.recalculateTotal();
                    _context.SaveChanges();
                }
                else
                {
                    //item doesn't exist, return error
                    throw new Exception("this Item doesn't exist in our catalog");
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
