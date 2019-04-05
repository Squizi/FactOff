using FactOff.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    public class ProfileFactViewModel
    {
        public string Context { get; set; }
        public IEnumerable<string> TagsNames { get; set; }
        public string ThemeName { get; set; }
        public double Rating { get; set; }
    }
}
