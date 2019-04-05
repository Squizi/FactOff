using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactOff.Services
{
    /// <summary>
    /// The <c>TagsService class</c> that inherits from <c>ITagsService interface</c>.
    /// Contains all the CRUD operations to manipulate the tags in the database.
    /// <list type="bullet">
    /// <item>
    /// <term>Create</term>
    /// <description>CreateTag & CreateTags both create tags by giving tha name of the tag.</description>
    /// </item>
    /// <item>
    /// <term>Read</term>
    /// <description>GetTagById returns a specific tag by a given id.</description>
    /// </item>
    /// <item>
    /// <term>Update</term>
    /// <description>UpdateTag edit the name of a specific tag.</description>
    /// </item>
    /// <item>
    /// <term>Delete</term>
    /// <description>DeleteTag removes a tag from the database.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class TagsService : ITagsService
    {
        private readonly FactOffContext context;

        public TagsService(FactOffContext context)
        {
            this.context = context;
        }

        public Guid CreateTag(string name)
        {
            Tag tag = new Tag()
            {
                Name = name.First().ToString().ToUpper() + name.Substring(1).ToLower()
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

        public int DeleteTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Tag GetTagById(Guid id)
        {
            return context.Tags.Where(t => t.TagId == id).FirstOrDefault();
        }

        public Guid UpdateTag(Tag tag, string newName)
        {
            context.Tags.Where(t => t == tag).FirstOrDefault().Name = newName;
            context.SaveChanges();

            return tag.TagId;
        }
    }
}
