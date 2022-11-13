using ASP_Project.Data;
using ASP_Project.Models;
using ASP_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;

namespace ASP_Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Contact> Contacts = _context.Contacts.ToList();
            Message message = _context.Messages.First();

            HomeVM home = new HomeVM
            {

                Contacts = Contacts,
                Message = message

            };




            return View(home);
        }
        //[HttpPost]
        //public async Task<IActionResult> SendMessage(MessageVM messageVM)
        //{
        //    //if (ModelState.isvalid)
        //    Message newMessage = new Message
        //    {
        //        Name = messageVM.Name,
        //        Number = messageVM.Number,
        //        Email = messageVM.Email,
        //        Subject = messageVM.Subject,
        //        YourMessage = messageVM.YourMessage

        //    };

        //    //await _context.Messages.AddAsync();


        //await _context.SaveChangesAsync();

        //return RedirectToAction(nameof(Index));

        //await _context.SaveChangesAsync();

        //return RedirectToAction(nameof(Index));
        //}

        //}
    }
}
