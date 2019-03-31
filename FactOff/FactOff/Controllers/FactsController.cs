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
        private IFactsService service;

        public FactsController(IFactsService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string factContext) {
            service.CreateFact(factContext, null);

            return RedirectToAction("Index");
        }
    }
}