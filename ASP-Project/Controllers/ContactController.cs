using Microsoft.AspNetCore.Mvc;

namespace ASP_Project.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
