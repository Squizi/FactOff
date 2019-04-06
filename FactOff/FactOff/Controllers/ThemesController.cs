using System;
using System.IO;
using FactOff.Attributes;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    /// <summary>
    /// Only logged in users can access it.
    /// Responsible for all views in the Themes folder.
    /// </summary>
    public class ThemesController : Controller
    {
        /// <summary>
        /// Allows communication wuth the ThemesService class.
        /// </summary>
        private readonly IThemesService service;

        /// <summary>
        /// Initializes a new instance of the ThemesController class.
        /// It's being called by the StartUp class.
        /// </summary>
        /// <param name="service">A required service for the class.</param>
        public ThemesController(IThemesService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Redirects to the Index page in the Themes folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [FactOffAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Opens a form for the creation of a new theme.
        /// Redirects to the Create page in the Themes folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [FactOffAuthorize]
        public IActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// Creates a new theme.
        /// </summary>
        /// <param name="request">The model for the new theme.</param>
        /// <returns></returns>
        [FactOffAuthorize]
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

        /// <summary>
        /// Return the image of the theme given the <paramref name="themeId"/>.
        /// </summary>
        /// <param name="themeId">The id of the theme.</param>
        /// <returns>The image of the theme.</returns>
        public FileStreamResult GetThemeImage(Guid themeId)
        {
            var theme = service.GetThemeById(themeId);
            Stream stream = new MemoryStream(theme.Image);
            return new FileStreamResult(stream, theme.ImageContentType);
        }
    }
}