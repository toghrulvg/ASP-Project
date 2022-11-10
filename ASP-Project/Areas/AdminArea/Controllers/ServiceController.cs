using ASP_Project.Data;
using ASP_Project.Helpers;
using ASP_Project.Models;
using ASP_Project.ViewModels.ServiceViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ServiceController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.Where(m => !m.IsDeleted).ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceCreateVM service)
        {
            if (!ModelState.IsValid) return View();

            if (!service.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }

            if (!service.Photo.CheckFileSize(100))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + service.Photo.FileName;

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", fileName);

            await Helper.SaveFile(path, service.Photo);

            Service newService = new Service
            {
                Icon = fileName,
                Color = service.Color,
                Header = service.Header,
                Desc = service.Desc
            };

            await _context.Services.AddAsync(newService);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            Service service = await GetByIdAsync(id);

            if (service == null) return NotFound();

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", service.Icon);

            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            Helper.DeleteFile(path);

            _context.Services.Remove(service);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Service service = await GetByIdAsync((int)id);

            if (service == null) return NotFound();

            return View(service);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Service service)
        {
            if (id is null) return BadRequest();

            if (service.Icon == null) return RedirectToAction(nameof(Index));

            var dbService = await GetByIdAsync((int)id);

            if (dbService == null) return NotFound();

            if (!service.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View(dbService);
            }

            if (!service.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View(dbService);
            }

            string oldPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/icon", dbService.Icon);

            Helper.DeleteFile(oldPath);

            string fileName = Guid.NewGuid().ToString() + "_" + service.Photo.FileName;

            string newPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/slider", fileName);

            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await service.Photo.CopyToAsync(stream);
            }

            dbService.Icon = fileName;
            dbService.Header = service.Header;
            dbService.Desc = service.Desc;
            dbService.Color = service.Color;


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Blog blog = await _context.Blogs.FindAsync(id);

            if (blog == null) return NotFound();

            return View(blog);
        }







        private async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }






    }
}
