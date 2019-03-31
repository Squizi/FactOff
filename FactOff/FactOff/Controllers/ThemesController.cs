using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FactOff.Controllers
{
    public class ThemesController : Controller
    {
        private IThemesService service;

        public ThemesController(IThemesService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}