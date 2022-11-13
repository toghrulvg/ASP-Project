using Microsoft.AspNetCore.Mvc;

namespace ASP_Project.Areas.AdminArea.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
