using System;
using System.Collections.Generic;
using System.Linq;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    public class FactsController : Controller
    {
        /// <summary>
        /// The service allows the many-to-many connection between the facts and the tags.
        /// </summary>
        /// <summary>
        /// 
        /// </summary>
        private readonly IFactsService factsService;
        /// <summary>
        /// 
        /// </summary>
        private readonly ITagsService tagsService;

        public FactsController(IFactsService factsService, ITagsService tagsService)
        {
            this.factsService = factsService;
            this.tagsService = tagsService;
        }

        public IActionResult Index()
        {
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
            Guid factId = factsService.CreateFact(factContext);
            IEnumerable<Guid> tagsId = tagsService.CreateTags(tagsString);
            foreach (Guid tagId in tagsId)
            {
                factsService.AddTag(factsService.GetFactById(factId), tagsService.GetTagById(tagId));
            }

            return RedirectToAction("Index");
        }
    }
}