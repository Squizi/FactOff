using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<HomeThemeViewModel> Themes { get; set; }
    }
}
