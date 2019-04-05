using System;
using System.Collections.Generic;
using System.Linq;
using FactOff.Models.DB;
using FactOff.Attributes;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    [FactOffAuthorize]
    public class FactsController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IFactsService factsService;
        /// <summary>
        /// 
        /// </summary>
        private readonly ITagsService tagsService;
        private readonly IUsersService usersService;

        public FactsController(IFactsService factsService, ITagsService tagsService, IUsersService usersService)
        {
            this.factsService = factsService;
            this.tagsService = tagsService;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            var model = factsService.GetAllFacts();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Fact factToSave) {
            Guid userId = new Guid(HttpContext.Session.GetString("logeduser"));
            usersService.SaveFactToUser(usersService.GetUserById(userId), factToSave);
            var model = factsService.GetAllFacts();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string factContext, string tagsString)
        {
            User user = usersService.GetUserById(new Guid(HttpContext.Session.GetString("logeduser")));
            Guid factId = factsService.CreateFact(factContext, user);
            IEnumerable<Guid> tagsId = tagsService.CreateTags(tagsString);
            foreach (Guid tagId in tagsId)
            {
                factsService.AddTag(factsService.GetFactById(factId), tagsService.GetTagById(tagId));
            }

            return RedirectToAction("Index");
        }
    }
}