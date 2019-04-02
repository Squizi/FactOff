using System;
using System.Collections.Generic;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    public class FactsController : Controller
    {
        private readonly IFactsTagsService factsTagsService;
        private readonly IFactsService factsService;
        private readonly ITagsService tagsService;
        
        public FactsController(IFactsTagsService factsTagsService, IFactsService factsService, ITagsService tagsService)
        {
            this.factsTagsService = factsTagsService;
            this.factsService = factsService;
            this.tagsService = tagsService;
        }

        public IActionResult Index()
        {
            var model = factsService.GetAllFacts();
            return View(model);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string factContext, string tagsString) {
            Guid factId = factsService.CreateFact(factContext);
            List<Guid> tagsId = tagsService.CreateTags(tagsString);
            factsTagsService.AddTagsToFact(factId, tagsId);

            return RedirectToAction("Index");
        }
    }
}