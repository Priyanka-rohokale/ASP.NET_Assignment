using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Assignment.Controllers
{
    public class Order
    {
        public int Id { get; set; }
        public decimal OrderAmount { get; set; }
        public string CustomerType { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class OrderProcessingContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderProcessingContext() : base("name=DefaultConnection") { }
    }

    public class OrderController : Controller
    {
       
            private readonly OrderProcessingContext _context;

            public OrderController()
            {
                _context = new OrderProcessingContext();
            }

            // GET: Order/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Order/Create
            [HttpPost]
            public ActionResult Create(Order order)
            {
                if (ModelState.IsValid)
                {
                    // Apply discount logic
                    if (order.CustomerType == "Loyal" && order.OrderAmount >= 100)
                    {
                        order.Discount = 0.10m * order.OrderAmount;
                    }
                    else
                    {
                        order.Discount = 0;
                    }
                    order.TotalAmount = order.OrderAmount - order.Discount;

                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    return RedirectToAction("Results", new { id = order.Id });
                }
                return View(order);
            }

            // GET: Order/Results/5
            public ActionResult Results(int id)
            {
                var order = _context.Orders.Find(id);
                return View(order);
            }
        }

    
}