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
    /// <remarks>
    /// <para>This class can communicate with the database and edit the information in the tags table.</para>
    /// </remarks>
    public class TagsService : ITagsService
    {
        /// <summary>
        /// The required context for the connection to the database.
        /// </summary>
        private readonly FactOffContext context;

        /// <summary>
        /// The constructor for the <c>TagsService</c> that is being called by the <c>StartUp class</c>.
        /// </summary>
        /// <param name="context">The required context for the connection to the database.</param>
        public TagsService(FactOffContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates a new tag with the given <paramref name="name"/>
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <returns>The id of the created tag.</returns>
        /// <example>
        /// <code>
        /// Guid tagId = CreateTag("My tag");
        /// Tag tag = context.Tags.Where(t => t.Name == name).FirstOrDefault();
        /// Console.WriteLine(tag.Name);
        /// </code>
        /// </example>
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

        /// <summary>
        /// Creates many tags at once with the given <paramref name="tagsString"/>.
        /// </summary>
        /// <param name="tagsString">A string that separetes the names of the tags with a space</param>
        /// <returns>A collection of the ids of the new tags</returns>
        /// <example>
        /// <code>
        /// List<Guid> ids = CreatTags("tag1 tag2 tag3");
        /// List<Tag> tags = new List<Tag>();
        /// foreach(var id in ids){
        ///     tags.Add(context.Tags.Where(t => t.TagId == id).FirstOrDefault())
        /// }
        /// foreach(var tag in tags){
        ///     Console.WriteLine(tag.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<Guid> CreateTags(string tagsString)
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

        /// <summary>
        /// Delete a specific <paramref name="tag"/>
        /// </summary>
        /// <param name="tag">Tag to be deleted.</param>
        /// <returns>Rows affected.</returns>
        /// <example>
        /// <code>
        /// Tag tag = GetTagById(CreateTag)
        /// </code>
        /// </example>
        /// <see cref="GetTagById(Guid)"/>
        public int DeleteTag(Tag tag)
        {
            context.Tags.Remove(tag);
            return context.SaveChanges();
        }

        /// <summary>
        /// Returns a tag with a given <paramref name="id"/>
        /// </summary>
        /// <param name="id">The id of the tag to be serched.</param>
        /// <returns>The tag with the coresponding id.</returns>
        /// <example>
        /// <code>
        /// Guid tagId = CreateTag("My Tag");
        /// Tag tag = GetTagById(tagId);
        /// Console.WriteLine(tag.Name);
        /// </code>
        /// </example>
        /// <see cref="CreateTag(string)"/>
        public Tag GetTagById(Guid id)
        {
            return context.Tags.Where(t => t.TagId == id).FirstOrDefault();
        }

        /// <summary>
        /// Edits the name of a given <paramref name="tag"/> to a <paramref name="newName"/>
        /// </summary>
        /// <param name="tag">The tag to be updated.</param>
        /// <param name="newName">The new name of the tag.</param>
        /// <returns>The id of the edited tag</returns>
        /// <example>
        /// <code>
        /// Tag tag = GetTagById(CreateTag("My tag"));
        /// UpdateTag(tag, "New named tag");
        /// Console.WriteLine(tag.Name);
        /// </code>
        /// </example>
        public Guid UpdateTag(Tag tag, string newName)
        {
            tag.Name = newName;
            context.SaveChanges();

            return tag.TagId;
        }
    }
}
