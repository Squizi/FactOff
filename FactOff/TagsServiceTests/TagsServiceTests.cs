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
    public class Tests
    {  
        [Test]
        public void AddTag()
        {
            var data = new List<Fact>().AsQueryable();
            var mockSet = new Mock<DbSet<Fact>>();
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Fact>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
#pragma warning disable CS0618 // Type or member is obsolete
            optionsBuilder.UseInMemoryDatabase();
#pragma warning restore CS0618 // Type or member is obsolete
            var mockContext = new FactOffContext(optionsBuilder.Options);
            //mockContext.Setup(f => f.Facts).Returns(mockSet.Object);
            var factsService = new FactsService(mockContext);
        }
    }
}