using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FactOff.Models;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using System.Linq;

namespace FactOff.Controllers
{
    public class HomeController : Controller
    {
        private IThemesService serviceTheme;
        private IFactsService serviceFacts;

        public HomeController(IThemesService serviceTheme, IFactsService serviceFacts)
        {
            this.serviceTheme = serviceTheme;
            this.serviceFacts = serviceFacts;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Themes = serviceTheme.GetAll().Select(t => new HomeThemeViewModel
                {
                    ThemeId = t.ThemeId,
                    Name = t.Name
                }),
                Facts = serviceFacts.GetRandomTen().Select(t => new HomeFactViewModel
                {
                    FactId = t.FactId,
                    Context = t.Context,
                    Rating = t.Rating,
                    Creator = t.Creator
                })
            };
            return View(model);
        }

        public IActionResult Facts()
        {
            ViewData["Message"] = "Your application page full of facts.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
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
