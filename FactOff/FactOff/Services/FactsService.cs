using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactOff.Services
{
    public class FactsService : IFactsService
    {
        private FactOffContext context;
        public FactsService(FactOffContext context)
        {
            this.context = context;
        }
        public Guid CreateFact(string factContext)
        {
            Fact fact = new Fact()
            {
                Context = factContext,
            };
            context.Facts.Add(fact);
            context.SaveChanges();

            return fact.FactId;
        }

        public Fact GetFactById(Guid id)
        {
            return context.Facts.Where(f => f.FactId == id).FirstOrDefault();
        }
    }
}
