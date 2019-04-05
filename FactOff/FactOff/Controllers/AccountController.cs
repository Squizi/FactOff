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
        /// <summary>
        /// The service lets the AccountController communicate with the UsersService
        /// which communicates with the database.
        /// </summary>
        private readonly IUsersService service;

        /// <summary>
        /// Initializes a new instance of the AccountController class.
        /// It's being called by the StartUp class.
        /// </summary>
        /// <param name="service">The required service for the class.</param>
        public AccountController(IUsersService service)
        {
            this.service = service;
        }

        /// <summary>
        /// The action redirects to the Index page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The action redirects to the Profile page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Profile()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// The action redirects to the SavedPosted page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult SavedPosted()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// The action redirects to the SignIn page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult SignIn()
        {
            if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("logeduser")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// Gets the reqired fields to sign in.
        /// </summary>
        /// <param name="requestModel">Model of the required fields to sign in.</param>
        /// <returns>Rendered view to the response.</returns>
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

        /// <summary>
        /// The action redirects to the Index page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("logeduser");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The action redirects to the Registration page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Registration()
        {
            return View();
        }

        /// <summary>
        /// Gets the required fields to register.
        /// </summary>
        /// <param name="requestModel">Model of the required fields to register.</param>
        /// <returns>Rendered view to the response.</returns>
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


        /// <summary>
        /// The action redirects to the 404 PageNotFound in the Shared folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult PageNotFound()
        {
            return RedirectToAction("PageNotFound", "Shared");
        }

        /// <summary>
        /// In case of an error redirects to the Error page in the Shared folder
        /// </summary>
        /// <returns>Rendered error view to the response.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
