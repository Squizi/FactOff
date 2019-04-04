using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactOff.Services
{
    public class FactsTagsService : IFactsTagsService
    {
        private readonly FactOffContext context;
        //private ITagsService tagService;
        //private IFactsService factService;

        public FactsTagsService(FactOffContext context)
        {
            this.context = context;
            //this.tagService = tagService;
            //this.factService = factService;
        }

        public int AddTagsToFact(Guid factId, List<Guid> tagsId)
        {
            int rowsAffected = 0;
            Fact fact = context.Facts.Where(x => x.FactId == factId).FirstOrDefault();
            foreach (Guid tagId in tagsId)
            {
                FactsTags factTag = new FactsTags()
                {
                    FactId = factId,
                    TagId = tagId
                };
                context.Facts.Where(f => f.FactId == factId).FirstOrDefault().Tags.Add(factTag);
            }
            rowsAffected = context.SaveChanges();

            return rowsAffected;
        }
    }
}
