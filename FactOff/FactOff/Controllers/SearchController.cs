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
                Context = f.Context,
                Rating = f.Rating,
                CreatorName = f.Creator.Name,
                TagsNames = f.Tags.Select(t => t.Tag.Name)
            });

            return View(searchModel);
        }
    }
}