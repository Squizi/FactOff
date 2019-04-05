using FactOff.Models.DB;
using FactOff.Models.ViewModels;
using FactOff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactOff.Services
{
    /// <summary>
    /// The FactsService class that inherits from IFactsService.
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
    public class FactsService : IFactsService
    {
        /// <summary>
        /// The required context for the connection to the database.
        /// </summary>
        private readonly FactOffContext context;

        /// <summary>
        /// The constructor for the FactsService that is being called by the StartUp class.
        /// </summary>
        /// <param name="context">The required context for the connection to the database.</param>
        public FactsService(FactOffContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a <paramref name="tag"/> to a given <paramref name="fact"/>.
        /// </summary>
        /// <param name="fact">The fact that the tag will be added to.</param>
        /// <param name="tag">The tag that will be added to the fact.</param>
        /// <example>
        /// <code>
        /// Fact newFact = new Fact(){
        ///     Context = "This is a fact."
        /// };
        /// Tag newTag = new Tag(){
        ///     Name = "Tag name"
        /// };
        /// AddTag(newFact, newTag);
        /// foreach(var tag in newFact.Tags.Select(t => t.Tag).ToList()){
        ///     if(tag == newTag){
        ///         Console.WriteLine($"The new fact has the tag {tag.Name}");
        ///     }
        /// }
        /// </code>
        /// </example>
        public void AddTag(Fact fact, Tag tag)
        {

            fact.Tags.Add(new FactsTags() { FactId = fact.FactId, TagId = tag.TagId });
            context.SaveChanges();
        }

        /// <summary>
        /// Creates a new fact with the given <pa.
        /// </summary>
        /// <param name="factContext">The context of the fact that will be displyed.</param>
        /// <returns>The guid of the newly created fact.</returns>
        /// <example>
        /// <code>
        /// Guid factId = CreateFact("This is the context of the new fact.");
        /// if(context.Facts.Where(x => x.FactId == factId).Count() == 1){
        ///     Console.WriteLine($"The database has a fact with context: {context.Facts.Where(x => x.FactId == new Guid()).FirstOrDefault().Context}");
        /// }
        /// </code>
        /// </example>
        public Guid CreateFact(string factContext)
        {
            Fact fact = new Fact()
            {
                Context = factContext
            };
            context.Facts.Add(fact);
            context.SaveChanges();

            return fact.FactId;
        }

        /// <summary>
        /// Finds a fact by a given <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Fact coresponding to the given id</returns>
        /// <example>
        /// <code>
        /// Guid factId = CreateFact("Context of new fact");
        /// Console.WriteLine($"{GetFactById(factIf).Context}")
        /// </code>
        /// </example>
        public Fact GetFactById(Guid id)
        {
            return context.Facts.Where(f => f.FactId == id).FirstOrDefault();
        }

        /// <summary>
        /// Deletes a given fact from the database.
        /// </summary>
        /// <param name="fact">The fact that will be deleted from the database.</param>
        /// <returns>How many rows were affected by this change.</returns>
        /// <example>
        /// <code>
        /// var factId = CreateFact("This is a new fact");
        /// var fact = GetFactById(factId);
        /// DeleteFact(fact);
        /// if(GetFactById(factId) == null){
        ///     Console.WriteLine("No fact found with that id");
        /// }
        /// else{
        ///     Console.WriteLine($"The content of the fact is: {GetFactById(fact).Context}");
        /// }
        /// </code>
        /// </example>
        public int DeleteFact(Fact fact)
        {
            context.Facts.Remove(fact);
            return context.SaveChanges();
        }

        /// <summary>
        /// Return all needed fields for the Index page in the Facts folder
        /// </summary>
        /// <returns>View Model for the Index page in the Facts folder</returns>
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

        /// <summary>
        /// Get ten random facts in the form of a contiguous element.
        /// </summary>
        /// <returns>Returns ten contiguous element of type Fact</returns>
        /// <example>
        /// <code>
        /// List<Fact> facts = GetRandomTen();
        /// foreach(Fact fact in facts){
        ///     Console.WriteLine(fact.Context);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<Fact> GetRandomTen()
        {
            return context.Facts.Take(10);
        }

        /// <summary>
        /// Removes a given <paramref name="tag"/> from a given <paramref name="fact"/>
        /// </summary>
        /// <param name="fact">The fact from which the tag must be removed from.</param>
        /// <param name="tag">The tag to be removed from the fact.</param>
        /// <example>
        /// <code>
        /// Guid factId = CreateFact("Context of fact");
        /// Fact fact = GetFactById(factId);
        /// Tag tag = new Tag(){
        ///     Name = "Tag name"
        /// };
        /// AddTag(fact, tag);
        /// Remove(fact, tag);
        /// if(fact.Tags.Where(t => t.Tag == tag).Count() == 0){
        ///     Console.WriteLine("There is no such tag in this fact");
        /// }
        /// else{
        ///     Console.WriteLine($"fact.Tags.Where(t => t.Tag == tag).First().Tag.Name");
        /// }
        /// </code>
        /// </example>
        public void RemoveTag(Fact fact, Tag tag)
        {
            fact.Tags.Remove(fact.Tags.Where(x => x.Tag == tag).FirstOrDefault());
            context.SaveChanges();
        }

        /// <summary>
        /// Changes the old context of a <paramref name="fact"/> with <paramref name="newContext"/>.
        /// </summary>
        /// <param name="fact">The fact to be updated.</param>
        /// <param name="newContext">The new context to the fact.</param>
        /// <returns>The id of the changed fact.</returns>
        public Guid UpdateFact(Fact fact, string newContext)
        {
            context.Facts.Where(f => f == fact).FirstOrDefault().Context = newContext;
            context.SaveChanges();
            return fact.FactId;
        }
    }
}
