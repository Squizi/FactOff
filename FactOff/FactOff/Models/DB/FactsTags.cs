using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;

namespace FactOff.Models.DB
{
    public class FactsTags
    {
        public Guid FactId { get; set; }
        public Fact Fact { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        public FactsTags(Guid factId, Guid tagId)
        {
            FactId = factId;
            TagId = tagId;
        }

        public FactsTags()
        {
        }
    }
}
