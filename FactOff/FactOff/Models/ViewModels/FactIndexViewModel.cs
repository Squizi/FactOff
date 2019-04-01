using FactOff.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    public class FactIndexViewModel
    {
        public Fact Fact { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
