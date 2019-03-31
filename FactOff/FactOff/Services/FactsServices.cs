using FactOff.Models.DB2;
using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Services
{
    public class FactsService : IFactsService
    {
        private FactOffContext context;
        public FactsService(FactOffContext context)
        {
            this.context = context;
        }
        public Guid CreateFact(string factContext, ICollection<FactsTags> tags)
        {
            Fact fact = new Fact()
            {
                Context = factContext,
                Tags = tags
            };

            return fact.FactId;
        }
    }
}
