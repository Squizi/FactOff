using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactOff.Models.DB;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    public class FactsController : Controller
    {
        private IFactsTagsService factsTagsService;
        private IFactsService factsService;
        private ITagsService tagsService;

        public FactsController(IFactsTagsService factsTagsService, IFactsService factsService, ITagsService tagsService)
        {
            this.factsTagsService = factsTagsService;
            this.factsService = factsService;
            this.tagsService = tagsService;
        }

        public IActionResult Index()
        {
            return View();
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