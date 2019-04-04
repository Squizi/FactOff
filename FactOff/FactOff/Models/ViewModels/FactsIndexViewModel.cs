using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{
    public class FactsIndexViewModel
    {
        public IEnumerable<FactIndexViewModel> Facts { get; set; }
    }
}
