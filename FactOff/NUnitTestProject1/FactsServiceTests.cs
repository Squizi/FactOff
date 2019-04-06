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
        [Obsolete]
        public void AddsTagToFact()
        {
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var factsService = new FactsService(mockContext);
            Fact fact = new Fact();
            fact.Context = "This is a fact.";
            var factContext = "This is a fact.";
            fact.FactId = Guid.NewGuid();
            Tag tag = new Tag();
            tag.TagId = Guid.NewGuid();
            Guid tagId = tag.TagId;
            User Creator = new User();

            factsService.CreateFact(factContext, Creator);
            factsService.AddTag(fact, tag);

            Assert.AreEqual(fact.Tags.First().TagId, tagId, "TagId of added tag is not the one it should be.");
        }

        [Test]
        [Obsolete]
        public void CreateFactReturnsFactId()
        {
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var factsService = new FactsService(mockContext);
            string factContext = "This is a fact.";
            User Creator = new User();

            factsService.CreateFact(factContext, Creator);

            Assert.AreEqual(mockContext.Facts.First().Context, factContext, "Fact not Created.");
        }

        [Test]
        [Obsolete]
        public void DeleteFactFromDB()
        {
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var factsService = new FactsService(mockContext);
            string factContext = "This is a fact.";
            User Creator = new User();

            factsService.CreateFact(factContext, Creator);
            factsService.DeleteFact(mockContext.Facts.First());

            Assert.IsEmpty(mockContext.Facts);
        }

        [Test]
        [Obsolete]
        public void GetAllFactsReturnsModel()
        {
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var factsService = new FactsService(mockContext);
            string factContext1 = "First fact.";
            string factContext2 = "Second fact.";
            string factContext3 = "Third fact.";
            User Creator = new User();

            factsService.CreateFact(factContext1, Creator);
            factsService.CreateFact(factContext2, Creator);
            factsService.CreateFact(factContext3, Creator);
            var model = factsService.GetAllFacts();

            Assert.AreEqual(model.Facts.Skip(2).First().Context, factContext3, "Context of third fact is not what it should be.");
        }

        [Test]
        [Obsolete]
        public void GetFactByIdReturnsFact()
        {
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var factsService = new FactsService(mockContext);
            Fact fact = new Fact();
            fact.Context = "This is a fact.";
            Tag tag = new Tag();
            tag.TagId = Guid.NewGuid();
            Guid tagId = tag.TagId;
            User Creator = new User();

            factsService.CreateFact(fact.Context, Creator);
            factsService.AddTag(fact, tag);

            Assert.IsNull(factsService.GetFactById(tagId));

        }

        [Test]
        [Obsolete]
        public void RemoveTagFromDB()
        {
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var factsService = new FactsService(mockContext);
            Fact fact = new Fact();
            fact.Context = "This is a fact.";
            Tag tag = new Tag();
            tag.Name = "Test";
            tag.TagId = Guid.NewGuid();
            User Creator = new User();

            factsService.CreateFact(fact.Context, Creator);
            factsService.AddTag(fact, tag);
            if (mockContext.Facts.First() == fact)
            {
                factsService.RemoveTag(fact, tag);
            }

            Assert.AreEqual(mockContext.Facts.First().Tags.Count, 0, "The fact wasn't removed.");

        }

        [Test]
        [Obsolete]
        public void UpdateFactInDB()
        {
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var factsService = new FactsService(mockContext);
            var factContext = "This is a fact.";
            var updatedContext = "This is an updated fact.";
            User Creator = new User();

            factsService.CreateFact(factContext, Creator);
            factsService.UpdateFact(mockContext.Facts.First(), updatedContext);

            Assert.AreEqual(mockContext.Facts.First().Context, updatedContext, "Context is not updated.");
        }

    }
}