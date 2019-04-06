using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FactOff.Models;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using System.Linq;

namespace FactOff.Controllers
{
    /// <summary>
    /// Responsible for all views in the Home folder.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Allows communication with the <c>ThemesService class</c>.
        /// </summary>
        private readonly IThemesService themesService;
        /// <summary>
        /// Allows communication with the <c>FactsService class</c>.
        /// </summary>
        private readonly IFactsService factsService;

        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// It's being called by the StartUp class.
        /// </summary>
        /// <param name="themesService">A required service for the class.</param>
        /// <param name="factsService">A required service for the class.</param>
        public HomeController(IThemesService themesService, IFactsService factsService)
        {
            this.themesService = themesService;
            this.factsService = factsService;
        }

        /// <summary>
        /// The main page. Displays ten rendom facts and some themes.
        /// Redirects to the Index page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Themes = themesService.GetAllThemes().Select(t => new HomeThemeViewModel
                {
                    ThemeId = t.ThemeId,
                    Name = t.Name
                }),
                Facts = factsService.GetRandomTen().Select(f => new HomeFactViewModel
                {
                    FactId = f.FactId,
                    Context = f.Context,
                    Rating = f.Rating,
                    Creator = f.Creator,
                    Tags = f.Tags.Select(t => new HomeTagViewModel
                    {
                        TagId = t.TagId,
                        Name = t.Tag.Name
                    })
                })
            };
            return View(model);
        }

        /// <summary>
        /// Lets the user contact the developers if he encounters a problem.
        /// Redirect to the Contact page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Shows the user the privacy policy.
        /// Redirects to the Privacy page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// If the user tries to reach a page that doesn't exist he is redirected to 404 Page Not Found.
        /// Redirects to the PageNotFound file in the Shared folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult PageNotFound()
        {
            return RedirectToAction("PageNotFount", "Shared");
        }


        /// <summary>
        /// In case of an error tells the user.
        /// Redirects to the Error page in the Shared folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
