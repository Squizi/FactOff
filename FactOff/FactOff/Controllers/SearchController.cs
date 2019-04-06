using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService service;

        public SearchController(ISearchService service)
        {
            this.service = service;
        }

        public IActionResult Index(SearchViewModel searchModel)
        {
            searchModel.Facts = service.Search(searchModel.Search, new List<Guid>()).Select(f => new HomeFactViewModel
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
            });

            return View(searchModel);
        }
    }
}