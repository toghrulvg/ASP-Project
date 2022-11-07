using ASP_Project.Data;
using ASP_Project.Models;
using ASP_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Slider> slider = _context.Sliders.ToList();
            List<Service> services = _context.Services.ToList();
            List<Product> products = _context.Products.ToList();
            List<ProductImage> productImages = _context.ProductImages.ToList();
            List<TwinBlogs> twinBlogs = _context.TwinBlogs.ToList();
            List<Blog> blogs = _context.Blogs.Take(4).ToList();
            List<Brand> brands = _context.Brands.ToList();

            HomeVM home = new HomeVM
            {
                Sliders = slider,
                Services = services,
                Products = products,
                ProductImages = productImages,
                TwinBlogs = twinBlogs,
                Blogs = blogs,
                Brands = brands
            };
            return View(home);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
