using FactOff.Models.DB;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    /// <summary>
    /// The <c>ITagsService interface</c> for the <c>TagsService class</c>.
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
    public interface ITagsService
    {
        /// <summary>
        /// Creates a new tag with the given <paramref name="name"/>
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <returns>The id of the created tag.</returns>
        Guid CreateTag(string name);
        /// <summary>
        /// Creates many tags at once with the given <paramref name="tagsString"/>.
        /// </summary>
        /// <param name="tagsString">A string that separetes the names of the tags with a space</param>
        /// <returns>A collection of the ids of the new tags</returns>
        IEnumerable<Guid> CreateTags(string tagsString);
        /// <summary>
        /// Delete a specific <paramref name="tag"/>
        /// </summary>
        /// <param name="tag">Tag to be deleted.</param>
        /// <returns>Rows affected.</returns>
        int DeleteTag(Tag tag);
        /// <summary>
        /// Edits the name of a given <paramref name="tag"/> to a <paramref name="newName"/>
        /// </summary>
        /// <param name="tag">The tag to be updated.</param>
        /// <param name="newName">The new name of the tag.</param>
        /// <returns>The id of the edited tag</returns>
        Guid UpdateTag(Tag tag, string name);
        /// <summary>
        /// Returns a tag with a given <paramref name="id"/>
        /// </summary>
        /// <param name="id">The id of the tag to be serched.</param>
        /// <returns>The tag with the coresponding id.</returns>
        Tag GetTagById(Guid id);
    }
}
