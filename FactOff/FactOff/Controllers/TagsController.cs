using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    public class TagsController : Controller
    {
        private ITagsService service;

        public TagsController(ITagsService service)
        {
            this.service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            service.CreateTag(name);
            return View();
        }
    }
}