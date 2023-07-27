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
            }

            return View(order);
        }


        public async Task<IActionResult> Add(int productId, int quantity)
        {
            try
            {
                var customerId = _userManager.GetUserId(User); // Get user id:

                //get thisCustomerOrder
                Order? order = null;
                order = await _context.Orders.FirstOrDefaultAsync(m => m.CustomerId == customerId);

                Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product != null)
                {
                    if (order == null)
                    {
                        order = new Order(customerId);

                        OrderDetail orderDetail = new()
                        {
                            ProductId = product.Id,
                            quantity = quantity,
                            SingleValue = product.Price,
                            TotalValue = product.Price * quantity
                        };
                        order.Details = new List<OrderDetail> { orderDetail };

                        decimal total = 0;
                        foreach (OrderDetail od in order.Details)
                        {
                            total += od.TotalValue;
                        }
                        order.Price = total;

                        _context.Orders.Add(order);
                        _context.SaveChanges();
                    }
                    else
                    {
                        //add item to existing order
                    }
                }
                else
                {
                    //item doesn't exsit, return error 
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
