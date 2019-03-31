using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;

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
            Tag tag = new Tag() {
                Name = name
            };

            return tag.TagId;
        }
    }
}
