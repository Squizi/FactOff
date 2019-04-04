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
        private readonly FactOffContext context;
        public FactsService(FactOffContext context)
        {
            this.context = context;
        }

        public void AddTag(Fact fact, Tag tag)
        {
            context.Facts.Where(f => f == fact).FirstOrDefault().Tags.Add(new FactsTags() { FactId = fact.FactId, TagId = tag.TagId });
            context.SaveChanges();
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

        public int DeleteFact(Fact fact)
        {
            context.Facts.Remove(fact);
            return context.SaveChanges();
        }

        public FactsIndexViewModel GetAllFacts()
        {
            Console.WriteLine(context.Facts);
            var facts = context.Facts.Select(f => new FactIndexViewModel()
            {
                Context = f.Context,
                CreatorName = f.Creator.Name,
                Rating = f.Rating,
                TagsNames = f.Tags.Select(t => t.Tag.Name)
            });

            FactsIndexViewModel model = new FactsIndexViewModel()
            {
                Facts = facts
            };

            return model;
        }

        public Fact GetFactById(Guid id)
        {
            return context.Facts.Where(f => f.FactId == id).FirstOrDefault();
        }

        public IEnumerable<Fact> GetRandomTen()
        {
            return context.Facts.Take(10);
        }

        public void RemoveTag(Fact fact, Tag tag)
        {
            context.Facts.Where(f => f == fact).FirstOrDefault().Tags.Remove(fact.Tags.Where(x => x.Tag == tag).FirstOrDefault());
            context.SaveChanges();
        }

        public Guid UpdateFact(Fact fact, string newContext)
        {
            context.Facts.Where(f => f == fact).FirstOrDefault().Context = newContext;
            context.SaveChanges();
            return fact.FactId;
        }
    }
}
