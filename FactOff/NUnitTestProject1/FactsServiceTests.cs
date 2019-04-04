using FactOff.Models.DB;
using FactOff.Services;
using FactOff.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class FactsServiceTests : DbContext
    {
        [Test]
        public void AddsTagToFact()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            Fact fact = new Fact();
            fact.Context = "This is a fact.";
            fact.FactId = Guid.NewGuid();
            Tag tag = new Tag();
            tag.TagId = Guid.NewGuid();
            Guid tagId = tag.TagId;
            
            factsService.AddTag(fact, tag);

            Assert.AreEqual(fact.Tags.First().TagId, tagId, "TagId of added tag is not the one it should be.");
        }

        [Test]
        public void CreateFactReturnsFactId()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            string factContext = "This is a fact.";

            factsService.CreateFact(factContext);

            Assert.AreEqual(mockContext.Facts.First().Context, factContext, "Fact not Created.");
        }

        [Test]
        public void DeleteFactFromDB()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            string factContext = "This is a fact.";

            factsService.CreateFact(factContext);
            factsService.DeleteFact.Remove(mockContext.Facts.First());

            Assert.IsNull(mockContext.Facts.First());
        }

        /*[Test]
        public void GetAllFactsReturnsModel()
        {

        }*/

        [Test]
        public void GetFactByIdReturnsFact()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            Fact fact = new Fact();
            fact.Context = "This is a fact.";
            Tag tag = new Tag();
            tag.TagId = Guid.NewGuid();
            Guid tagId = tag.TagId;

            factsService.CreateFact(fact.Context);
            factsService.AddTag(fact, tag);

            Assert.AreEqual(factsService.GetFactById(tagId), fact, "Fact is not the same as expected.");

        }

        [Test]
        public void RemoveTag()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            Fact fact = new Fact();
            fact.Context = "This is a fact.";
            Tag tag = new Tag();
            tag.TagId = Guid.NewGuid();
            Guid tagId = tag.TagId;

            factsService.AddTag(fact, tag);
            factsService.RemoveTag(fact, tag);

            Assert.IsNull(mockContext.Facts.First().Tags.First().Tag);

        }

        [Test]
        public void UpdateFact()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            var factContext = "This is a fact.";
            var updatedContext = "This is an updated fact.";

            factsService.CreateFact(factContext);
            factsService.UpdateFact(mockContext.Facts.First(), updatedContext);

            Assert.AreEqual(mockContext.Facts.First().Context, updatedContext, "Context is not updated.");

        }

    }
}