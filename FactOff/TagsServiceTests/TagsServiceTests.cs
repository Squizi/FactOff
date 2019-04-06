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
        [Obsolete]
        public void CreateTagTest()
        {
            var data = new List<Tag>().AsQueryable();
            var mockSet = new Mock<DbSet<Tag>>();
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var tagsService = new TagsService(mockContext);
            string tagName = "This is a tag.";

            tagsService.CreateTag(tagName);

            Assert.AreEqual(mockContext.Tags.First().Name, tagName, "Names are not equal.");
        }

        [Test]
        [Obsolete]
        public void CreateTagsTest()
        {
            var data = new List<Tag>().AsQueryable();
            var mockSet = new Mock<DbSet<Tag>>();
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var tagsService = new TagsService(mockContext);
            string tagsString = "FirstTag SecondTag ThirdTag";

            tagsService.CreateTags(tagsString);

            Assert.AreEqual(mockContext.Tags.Skip(2).First().Name, "Thirdtag", "Third tag doesnt have the expected name.");
        }

        [Test]
        [Obsolete]
        public void DeleteTagTest()
        {
            var data = new List<Tag>().AsQueryable();
            var mockSet = new Mock<DbSet<Tag>>();
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var tagsService = new TagsService(mockContext);
            string tagName = "This is a tag.";

            var tag = tagsService.CreateTag(tagName);
            var tagId = tagsService.GetTagById(tag);
            tagsService.DeleteTag(tagId);

            Assert.IsEmpty(mockContext.Tags);
        }

        [Test]
        [Obsolete]
        public void GetsTagByIdReturnsTag()
        {
            var data = new List<Tag>().AsQueryable();
            var mockSet = new Mock<DbSet<Tag>>();
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var tagsService = new TagsService(mockContext);
            Guid tagId = new Guid();
            var tagName = "Tag";
            Tag tag = new Tag();
            tag.TagId = tagId;
            tag.Name = tagName;

            tagsService.CreateTag(tagName);
            mockContext.Tags.First().TagId = tagId;
            var expectedTag = tagsService.GetTagById(tagId);

            Assert.AreEqual(expectedTag.Name, tag.Name, "Tag name is not the same.");
        }

        [Test]
        [Obsolete]
        public void UpdatesTagReturnsTagId()
        {
            var data = new List<Tag>().AsQueryable();
            var mockSet = new Mock<DbSet<Tag>>();
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tag>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var tagsService = new TagsService(mockContext);
            var tagName = "Tag";
            var tag = tagsService.GetTagById(tagsService.CreateTag(tagName));
            var newName = "NewTag";

            tagsService.UpdateTag(tag, newName);

            Assert.AreEqual(mockContext.Tags.First().Name, newName, "Name wasnt updated.");
        }
    }
}