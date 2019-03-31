using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.DB
{
    public class FactsTags
    {
        public Guid FactId { get; set; }
        public Fact Fact { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
