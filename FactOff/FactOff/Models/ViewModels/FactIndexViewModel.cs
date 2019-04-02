using FactOff.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
