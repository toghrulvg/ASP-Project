using Microsoft.AspNetCore.Mvc;

namespace ASP_Project.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
