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
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            
            var mockContext = new Mock<FactOffContext>();
            mockContext.Setup(f => f.Facts).Returns(mockSet.Object);

            var factsService = new FactsService(mockContext.Object);

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

            factsService.Object.CreateFact(factContext);

            Assert.AreEqual(mockContext.Object.Facts.First().Context, factContext, "Fact not Created.");
        }

        [Test]
        public void DeleteFactFromDB()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            string factContext = "This is a fact.";
            
            factsService.Object.CreateFact(factContext);
            factsService.Object.DeleteFact(mockContext.Object.Facts.First());

            Assert.IsNull(mockContext.Object.Facts.First());
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

            factsService.Object.CreateFact(fact.Context);
            factsService.Object.AddTag(fact, tag);

            Assert.AreEqual(factsService.Object.GetFactById(tagId), fact, "Fact is not the same as expected.");

        }

        [Test]
        public void RemoveTagFromDB()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            Fact fact = new Fact();
            fact.Context = "This is a fact.";
            Tag tag = new Tag();
            tag.TagId = Guid.NewGuid();
            Guid tagId = tag.TagId;

            factsService.Object.AddTag(fact, tag);
            factsService.Object.RemoveTag(fact, tag);

            Assert.IsNull(mockContext.Object.Facts.First().Tags.First().Tag);

        }

        [Test]
        public void UpdateFactInDB()
        {
            var mockContext = new Mock<FactOffContext>();
            var factsService = new Mock<FactsService>(mockContext);
            var factContext = "This is a fact.";
            var updatedContext = "This is an updated fact.";

            factsService.Object.CreateFact(factContext);
            factsService.Object.UpdateFact(mockContext.Object.Facts.First(), updatedContext);

            Assert.AreEqual(mockContext.Object.Facts.First().Context, updatedContext, "Context is not updated.");

        }

    }
}