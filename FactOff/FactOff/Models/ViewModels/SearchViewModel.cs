using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{
    public class SearchViewModel
    {
        public string Search { get; set; }
        public IEnumerable<HomeTagViewModel> Tags { get; set; }
        public IEnumerable<HomeFactViewModel> Facts { get; set; }
    }
}
