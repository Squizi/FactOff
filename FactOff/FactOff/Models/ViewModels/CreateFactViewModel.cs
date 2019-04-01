using FactOff.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    public class CreateFactViewModel
    {
        public string FactContext { get; set; }
        public string TagsString { get; set; }
    }
}
