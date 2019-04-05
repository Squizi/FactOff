using FactOff.Models.DB;
using FactOff.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace FactOff.Services.Contracts
{
    /// <summary>
    /// IFactsService is an interface for the FactsService.
    /// Contains all the CRUD operations to manipulate the facts in the database.
    /// <list type="bullet">
    /// <item>
    /// <term>Create</term>
    /// <description>CreateFact function creates a new fact by giving the context of the fact.</description>
    /// </item>
    /// <item>
    /// <term>Read</term>
    /// <description>GetFactById, GetAllFacts & GetRandomTen are all read methods that get the specified amount of facts.</description>
    /// </item>
    /// <item>
    /// <term>Update</term>
    /// <description>UpdateFact, AddTag & RemoveTag edit a specific fact.</description>
    /// </item>
    /// <item>
    /// <term>Delete</term>
    /// <description>DeleteFact function removes a specific fact from the database.</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>This class can communicate with the database and edit the information in the facts table.</para>
    /// </remarks>
    public interface IFactsService
    {
        /// <summary>
        /// Creates a new fact with the given <pa.
        /// </summary>
        /// <param name="factContext">The context of the fact that will be displyed.</param>
        /// <returns>The guid of the newly created fact.</returns>
        Guid CreateFact(string context);

        /// <summary>
        /// Return all needed fields for the Index page in the Facts folder
        /// </summary>
        /// <returns>View Model for the Index page in the Facts folder</returns>
        FactsIndexViewModel GetAllFacts();

        /// <summary>
        /// Finds a fact by a given <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Fact coresponding to the given id</returns>
        Fact GetFactById(Guid id);

        /// <summary>
        /// Get ten random facts in the form of a contiguous element.
        /// </summary>
        /// <returns>Returns ten contiguous element of type Fact</returns>
        IEnumerable<Fact> GetRandomTen();

        /// <summary>
        /// Deletes a given fact from the database.
        /// </summary>
        /// <param name="fact">The fact that will be deleted from the database.</param>
        /// <returns>How many rows were affected by this change.</returns>
        int DeleteFact(Fact fact);

        /// <summary>
        /// Changes the old context of a <paramref name="fact"/> with <paramref name="newContext"/>.
        /// </summary>
        /// <param name="fact">The fact to be updated.</param>
        /// <param name="newContext">The new context to the fact.</param>
        /// <returns>The id of the changed fact.</returns>
        Guid UpdateFact(Fact fact, string newContext);

        /// <summary>
        /// Removes a given <paramref name="tag"/> from a given <paramref name="fact"/>
        /// </summary>
        /// <param name="fact">The fact from which the tag must be removed from.</param>
        /// <param name="tag">The tag to be removed from the fact.</param>
        void RemoveTag(Fact fact, Tag tag);
        
        /// <summary>
        /// Adds a <paramref name="tag"/> to a given <paramref name="fact"/>.
        /// </summary>
        /// <param name="fact">The fact that the tag will be added to.</param>
        /// <param name="tag">The tag that will be added to the fact.</param>
        void AddTag(Fact fact, Tag tag);
    }
}
