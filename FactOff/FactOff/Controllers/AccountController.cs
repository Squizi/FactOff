using Microsoft.AspNetCore.Mvc;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using FactOff.Attributes;
using FactOff.Models.DB;
using System.Collections.Generic;

namespace FactOff.Controllers
{
    /// <summary>
    /// Responsible for all views in the Account folder.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Allows communication with the <c>UsersService class</c>.
        /// </summary>
        private readonly IUsersService userService;
        /// <summary>
        /// Allows communication with the <c>FactsService class</c>.
        /// </summary>
        private readonly IFactsService factsService;

        /// <summary>
        /// Initializes a new instance of the AccountController class.
        /// It's being called by the StartUp class.
        /// </summary>
        /// <param name="userService">A required service for the class.</param>
        /// <param name="factsService">A required service for the class.</param>
        public AccountController(IUsersService userService, IFactsService factsService)
        {
            this.userService = userService;
            this.factsService = factsService;
        }

        /// <summary>
        /// The users profile page.
        /// If the user is logged in an action redirects to the Profile page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [FactOffAuthorize]
        public IActionResult Profile()
        {
            User user = userService.GetUserById(new Guid(HttpContext.Session.GetString("logeduser")));
            ProfileViewModel model = factsService.GetAllFactByUser(user);
            return View(model);
        }

        /// <summary>
        /// The page where the user can edit his info.
        /// If the user is logged in an action redirects to the EditProfile page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [FactOffAuthorize]
        public IActionResult EditProfile()
        {
            User user = userService.GetUserById(new Guid(HttpContext.Session.GetString("logeduser")));
            AccountViewModel model = new AccountViewModel
            {
                Name = user.Name,
                Email = user.Email
            };
            return View(model);
        }


        /// <summary>
        /// Lets the user made changes happen.
        /// If the user is logged in an action redirects to the EditProfile page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [FactOffAuthorize]
        [HttpPost]
        public IActionResult EditProfile(AccountViewModel request)
        {
            if (ModelState.IsValid)
            {
                byte[] image;
                using (MemoryStream ms = new MemoryStream())
                {
                    request.ImageUploaded.CopyTo(ms);
                    image = ms.ToArray();
                }
                userService.EditUser(new Guid(HttpContext.Session.GetString("logeduser")), request.Email, image, request.ImageUploaded.ContentType, request.Name, request.Password);
                return RedirectToAction("Index", "Home");
            }
            request.Password = null;
            return View(request);
        }

        /// <summary>
        /// Lets the user change his profile picture with one of his choice.
        /// </summary>
        /// <returns>Filetream with image info.</returns>
        [FactOffAuthorize]
        public FileStreamResult GetUserImage()
        {
            User user = userService.GetUserById(new Guid(HttpContext.Session.GetString("logeduser")));
            Stream stream = new MemoryStream(user.Image);
            return new FileStreamResult(stream, user.ImageContentType);
        }

        /// <summary>
        /// Shows all saved posts by the user.
        /// If logged in the action redirects to the SavedPosted page in the Account folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [FactOffAuthorize]
        public IActionResult SavedPosted()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// The sign in page.
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
                string userId = userService.SignIn(requestModel.Email, requestModel.Password);
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
        /// Signs out of the account.
        /// The action redirects to the Index page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [FactOffAuthorize]
        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("logeduser");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Allows for new users to register.
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
            if (userService.UserExists(requestModel.Email))
            {
                ModelState.AddModelError("", "There is already an account with this email.");
            }
            else
            {
                userService.CreateUser(requestModel.Email, requestModel.Name, requestModel.Password);
                return RedirectToAction("SignIn", "Account");
            }
            return View();
        }
    }
}
