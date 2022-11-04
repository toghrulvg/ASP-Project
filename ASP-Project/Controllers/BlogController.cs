using Microsoft.AspNetCore.Mvc;

namespace ASP_Project.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
