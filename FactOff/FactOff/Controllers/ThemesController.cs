using System;
using System.IO;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    public class ThemesController : Controller
    {
        private readonly IThemesService service;

        public ThemesController(IThemesService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ThemeViewModel request)
        {
            if (ModelState.IsValid)
            {
                byte[] image;
                using (var ms = new MemoryStream())
                {
                    request.ImageUploaded.CopyTo(ms);
                    image = ms.ToArray();
                }
                service.CreateTheme(request.Name, image, request.ImageUploaded.ContentType);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public FileStreamResult GetThemeImage(Guid themeId)
        {
            var theme = service.GetThemeById(themeId);
            Stream stream = new MemoryStream(theme.Image);
            return new FileStreamResult(stream, theme.ImageContentType);
        }
    }
}