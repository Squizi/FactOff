using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactOff.Services
{
    public class TagsService : ITagsService
    {
        private FactOffContext context;

        public TagsService(FactOffContext context)
        {
            this.context = context;
        }

        public Guid CreateTag(string name)
        {
            Tag tag = new Tag()
            {
                Name = name.First().ToString().ToUpper() + name.Substring(1)
            };

            context.Tags.Add(tag);
            context.SaveChanges();

            return tag.TagId;
        }

        public List<Guid> CreateTags(string tagsString)
        {
            List<string> tagsList = tagsString.Split().ToList();
            List<Guid> tagsId = new List<Guid>(); ;
            foreach (string tag in tagsList)
            {
                if (context.Tags.Where(t => t.Name == tag).Count() == 0)
                {
                    tagsId.Add(CreateTag(tag));
                }
                else
                {
                    tagsId.Add(context.Tags.Where(t => t.Name == tag).FirstOrDefault().TagId);
                }
            }

            return tagsId;
        }

        public Tag GetTagById(Guid id)
        {
            return context.Tags.Where(t => t.TagId == id).FirstOrDefault();
        }
    }
}
