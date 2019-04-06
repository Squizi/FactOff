using System;
using System.Collections.Generic;
using System.Linq;
using FactOff.Models.DB;
using FactOff.Attributes;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FactOff.Models.ViewModels;

namespace FactOff.Controllers
{
    /// <summary>
    /// Only logged in users can access it.
    /// Responsible for all views in the Facts folder.
    /// </summary>
    [FactOffAuthorize]
    public class FactsController : Controller
    {
        /// <summary>
        /// Allows communication with the <c>FactsService class</c>.
        /// </summary>
        private readonly IFactsService factsService;
        /// <summary>
        /// Allows communication with the <c>TagsService class</c>.
        /// </summary>
        private readonly ITagsService tagsService;
        /// <summary>
        /// Allows communication with the <c>UsersService class</c>.
        /// </summary>
        private readonly IUsersService usersService;
        /// <summary>
        /// Allows communication with the <c>themesService class</c>.
        /// </summary>
        private readonly IThemesService themesService;

        /// <summary>
        /// Initializes a new instance of the FactsController class.
        /// It's being called by the StartUp class.
        /// </summary>
        /// <param name="factsService">A required service for the class.</param>
        /// <param name="tagsService">A required service for the class.</param>
        /// <param name="usersService">A required service for the class.</param>
        public FactsController(IFactsService factsService, ITagsService tagsService, IUsersService usersService, IThemesService themesService)
        {
            this.factsService = factsService;
            this.tagsService = tagsService;
            this.usersService = usersService;
            this.themesService = themesService;
        }

        /// <summary>
        /// The main page with the facts.
        /// Redirects to the Index page in the Facts folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Index()
        {
            var model = factsService.GetAllFacts();
            return View(model);
        }
        /// <summary>
        /// Saves the fact to the logged user.
        /// </summary>
        /// <param name="factToSave">Fact that the user wants to save.</param>
        /// <returns>Rendered view to the response.</returns>
        [HttpPost]
        public IActionResult Index(Fact factToSave) {
            Guid userId = new Guid(HttpContext.Session.GetString("logeduser"));
            usersService.SaveFactToUser(usersService.GetUserById(userId), factToSave);
            var model = factsService.GetAllFacts();
            return View(model);
        }

        /// <summary>
        /// Opens the page for creating a new fact.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [FactOffAuthorize]
        public IActionResult Create()
        {
            var model = new CreateFactViewModel() {
                ThemesNames = themesService.GetAllThemes().Select(t => t.Name)
            };
            return View(model);
        }

        /// <summary>
        /// Creates the new fact.
        /// </summary>
        /// <param name="factContext">The context of the new fact.</param>
        /// <param name="tagsString">String with all the tags.</param>
        /// <returns>Rendered view to the response.</returns>
        [HttpPost]
        public IActionResult Create(string factContext, string tagsString, string selectedTheme)
        {
            User user = usersService.GetUserById(new Guid(HttpContext.Session.GetString("logeduser")));
            Guid factId = factsService.CreateFact(factContext, user, selectedTheme);
            IEnumerable<Guid> tagsId = tagsService.CreateTags(tagsString);
            foreach (Guid tagId in tagsId)
            {
                factsService.AddTag(factsService.GetFactById(factId), tagsService.GetTagById(tagId));
            }
            return RedirectToAction("Index");
        }
    }
}