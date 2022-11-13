using ASP_Project.Models;
using ASP_Project.Services.Interfaces;
using ASP_Project.ViewModels.AccountViewModels;

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ASP_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new AppUser
            {
                Fullname = registerVM.Fullname,
                Email = registerVM.Email,
                UserName = registerVM.Username
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            await _signInManager.SignInAsync(appUser, isPersistent: false);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }


            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            string link = Url.Action(nameof(ConfirmEmail), "Account",new {appUserId = appUser.Id,token},Request.Scheme,Request.Host.ToString());

            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("toghrulvg@code.edu.az"));
            email.To.Add(MailboxAddress.Parse(appUser.Email));
            email.Subject = "Test Email Subject";
            string body = string.Empty;
            string subject = "Verify email";

            using (StreamReader reader = new StreamReader("wwwroot/assets/Templates/Verify.html"))
            body = reader.ReadToEnd();



            body = body.Replace("{{link}}", link);

            _emailService.Send(appUser.Email, subject, body);
            //await _signInManager.SignInAsync(appUser, false);

            email.Body = new TextPart(TextFormat.Html) { Text = body };



            return RedirectToAction(nameof(VerifyEmail));

        }

        public async Task<IActionResult> ConfirmEmail(string appUserId, string token)
        {
            if (appUserId is null || token is null) return BadRequest();

            AppUser appUser = await _userManager.FindByIdAsync(appUserId);

            if (appUser == null) return NotFound();

            await _userManager.ConfirmEmailAsync(appUser, token);

            await _signInManager.SignInAsync(appUser, false);

            return RedirectToAction("Index", "Home");




        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.EmailOrUsername);
            if (appUser is null)
            {
                appUser = await _userManager.FindByNameAsync(loginVM.EmailOrUsername);
            }

            if (appUser is null)
            {
                ModelState.AddModelError("", "Email or password is wrong");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is wrong");
                return View(loginVM);
            }


            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public  IActionResult VerifyEmail()
        {
            return View();
        }


    }
}
