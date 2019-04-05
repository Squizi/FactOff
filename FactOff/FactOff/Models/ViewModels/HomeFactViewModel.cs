using FactOff.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    public class HomeFactViewModel
    {
        public Guid FactId { get; set; }
        public string Context { get; set; }
        public float Rating { get; set; }
        public User Creator { get; set; }
        public IEnumerable<HomeTagViewModel> Tags { get; set; }
    }
}
