using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{
    public class FactIndexViewModel
    {
        public string Context { get; set; }
        public string CreatorName { get; set; }
        public float Rating { get; set; }
        public IEnumerable<string> TagsNames { get; set; }
    }
}
