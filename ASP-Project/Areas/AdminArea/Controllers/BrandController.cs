using ASP_Project.Data;
using ASP_Project.Helpers;
using ASP_Project.Models;
using ASP_Project.ViewModels.BrandViewModels;
using ASP_Project.ViewModels.SliderViewModels;
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
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.Where(m => !m.IsDeleted).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandCreateVM brand)
        {
            if (!ModelState.IsValid)
                
                return View();

            if (!brand.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View();
            }


            if (!brand.Photo.CheckFileSize(500))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + brand.Photo.FileName;

            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img/brand", fileName);

            await Helper.SaveFile(path, brand.Photo);

            Brand newBrand = new Brand
            {
                Image = fileName
            };

            await _context.Brands.AddAsync(newBrand);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Brand brand = await _context.Brands.FirstOrDefaultAsync(m => m.Id == id);

            brand.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Brand brand = await GetByIdAsync((int)id);

            if (brand == null) return NotFound();

            return View(brand);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Brand brand)
        {
            if (id is null) return BadRequest();

            if (brand.Photo == null) return RedirectToAction(nameof(Index));

            var dbBrand = await GetByIdAsync((int)id);

            if (dbBrand == null) return NotFound();

            if (!brand.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Please choose correct image type");
                return View(dbBrand);
            }

            if (!brand.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Please choose correct image size");
                return View(dbBrand);
            }

            string oldPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/brand", dbBrand.Image);

            Helper.DeleteFile(oldPath);

            string fileName = Guid.NewGuid().ToString() + "_" + brand.Photo.FileName;

            string newPath = Helper.GetFilePath(_env.WebRootPath, "assets/img/brand", fileName);


            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await brand.Photo.CopyToAsync(stream);
            }

            dbBrand.Image = fileName;


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Brand brand = await _context.Brands.FindAsync(id);

            if (brand == null) return NotFound();

            return View(brand);
        }








        private async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }












    }
}
