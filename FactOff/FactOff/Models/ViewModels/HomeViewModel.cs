using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<HomeThemeViewModel> Themes { get; set; }
        public IEnumerable<HomeFactViewModel> Facts { get; set; }
    }
}
