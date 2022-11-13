using ASP_Project.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Project.Controllers
{
    
        public class BlogController : Controller
        {
            private readonly AppDbContext _context;
            public BlogController(AppDbContext context)
            {
                _context = context;
            }

            //public async Task<IActionResult> Index(int page = 1 , int take=4)
            //{

            //IEnumerable<Blog> blogs = await _context.Blogs
            //    .Skip((page * take) - take)
            //    .Take(take)
            //    .ToListAsync();
            //}

            //viewbag
        }
}
