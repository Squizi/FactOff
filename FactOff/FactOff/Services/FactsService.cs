using FactOff.Models.DB;
using FactOff.Models.ViewModels;
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

        public FactsIndexViewModel GetAllFacts()
        {
            Console.WriteLine(context.Facts);
            var facts = context.Facts.Select(f => new FactIndexViewModel(){
                Fact = f,
                Tags = f.Tags.Select(t => t.Tag).ToList()
            });

            FactsIndexViewModel model = new FactsIndexViewModel() {
                Facts = facts
            };

            return model;
        }

        public Fact GetFactById(Guid id)
        {
            return context.Facts.Where(f => f.FactId == id).FirstOrDefault();
        }
    }
}
