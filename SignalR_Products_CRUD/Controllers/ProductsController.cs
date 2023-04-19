using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Products_CRUD.Data;
using SignalR_Products_CRUD.Hubs;
using SignalR_Products_CRUD.Models;

namespace SignalR_Products_CRUD.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppSettingsDbContext _context;
        private readonly IHubContext<ProductHub> _productHub;

        public ProductsController (AppSettingsDbContext context, IHubContext<ProductHub> productHub)
        {
            _context = context;
            _productHub = productHub;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }



        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }



        public IActionResult AddProduct ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct (Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                _productHub.Clients.All.SendAsync("refreshProducts");
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
