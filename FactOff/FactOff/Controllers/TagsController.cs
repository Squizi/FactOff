using FactOff.Attributes;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    /// <summary>
    /// Only logged users can access it.
    /// Responsible for all views in the Tags folder.
    /// </summary>
    [FactOffAuthorize]
    public class TagsController : Controller
    {
        /// <summary>
        /// Allows communication with the <c>TagsService class</c>.
        /// </summary>
        private readonly ITagsService service;

        /// <summary>
        /// Initializes a new instance of the TagsController class.
        /// It's being called by the StartUp class.
        /// </summary>
        /// <param name="service">A required service for the class.</param>
        public TagsController(ITagsService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Opens a form page for the creation of new tags.
        /// Redirects to the Create page in the Tags folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Actually creates the new tag.
        /// Redirects to the Index page in the Home folder.
        /// </summary>
        /// <param name="name">The name of the new tag.</param>
        /// <returns>Rendered view to the response.</returns>
        [HttpPost]
        public IActionResult Create(string name)
        {
            service.CreateTag(name);
            return RedirectToAction("Index", "Home");
        }
    }
}