using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FactOff.Models;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace FactOff.Controllers
{
    public class AccountController : Controller
    {
        private IUsersService service;

        public AccountController(IUsersService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult SavedPosted()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult SignIn()
        {
            if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("logeduser")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var userId = service.SignIn(requestModel.Email, requestModel.Password);
                if (userId != null)
                {
                    HttpContext.Session.SetString("logeduser", userId);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }
            return View();
        }

        public IActionResult SignOut(string email, string password)
        {
            HttpContext.Session.Remove("logeduser");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegisterViewModel requestModel)
        {
            if (service.UserExists(requestModel.Email))
            {
                ModelState.AddModelError("", "There is already an account with this email.");
            }
            else
            {
                service.CreateUser(requestModel.Email, requestModel.Name, requestModel.Password);
                return RedirectToAction("SignIn", "Account");
            }
            return View();
        }

        public IActionResult PageNotFound()
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
