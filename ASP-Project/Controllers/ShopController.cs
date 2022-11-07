using ASP_Project.Data;
using ASP_Project.Models;
using ASP_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            
            List<Product> products = _context.Products.ToList();
            List<ProductImage> productImages = _context.ProductImages.ToList();
            HomeVM home = new HomeVM
            {
                Products = products,
                ProductImages = productImages
            };
            return View(home);



        }
    }
}
