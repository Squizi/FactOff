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
        public void CreateThemeReturnsThemeId()
        {
            var data = new List<Theme>().AsQueryable();
            var mockSet = new Mock<DbSet<Theme>>();
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var themesService = new ThemesService(mockContext);
            string name = "Theme";
            byte[] image = null;
            string imageContentType = "Nothing";

            var themeId = themesService.CreateTheme(name, image, imageContentType);


            Assert.AreEqual(mockContext.Themes.First().Name, name, "Name is not the same.");
        }

        [Test]
        [Obsolete]
        public void DeletesThemeFromContext()
        {
            var data = new List<Theme>().AsQueryable();
            var mockSet = new Mock<DbSet<Theme>>();
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var themesService = new ThemesService(mockContext);
            string name = "Theme";
            byte[] image = null;
            string imageContentType = "Nothing";

            var themeId = themesService.CreateTheme(name, image, imageContentType);
            themesService.DeleteTheme(mockContext.Themes.First());

            Assert.IsEmpty(mockContext.Themes);
        }

        [Test]
        [Obsolete]
        public void GetsThemeByIdReturnsTheme()
        {
            var data = new List<Theme>().AsQueryable();
            var mockSet = new Mock<DbSet<Theme>>();
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var themesService = new ThemesService(mockContext);
            string name = "Theme";
            byte[] image = null;
            string imageContentType = "Nothing";

            var themeId = themesService.CreateTheme(name, image, imageContentType);

            Assert.AreEqual(themesService.GetThemeById(themeId).ThemeId, themeId, "Theme id is not the same.");
        }

        [Test]
        [Obsolete]
        public void GetsAllThemesReturnsIEnumerableOfTheme()
        {
            var data = new List<Theme>().AsQueryable();
            var mockSet = new Mock<DbSet<Theme>>();
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var themesService = new ThemesService(mockContext);
            string name1 = "Theme1";
            byte[] image1 = null;
            string imageContentType1 = "Nothing";
            string name2 = "Theme2";
            byte[] image2 = null;
            string imageContentType2 = "Nothing";
            string name3 = "Theme3";
            byte[] image3 = null;
            string imageContentType3 = "Nothing";

            var themeId1 = themesService.CreateTheme(name1, image1, imageContentType1);
            var themeId2 = themesService.CreateTheme(name2, image2, imageContentType2);
            var themeId3 = themesService.CreateTheme(name3, image3, imageContentType3);
            var themes = themesService.GetAllThemes();

            Assert.AreEqual(themes.Skip(2).First().ThemeId, themeId3, "Theme id of last theme is on the expected one.");
        }

        [Test]
        [Obsolete]
        public void UpdatesThemeReturnsUpdatedThemeId()
        {
            var data = new List<Theme>().AsQueryable();
            var mockSet = new Mock<DbSet<Theme>>();
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Theme>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var themesService = new ThemesService(mockContext);
            string name = "Theme";
            byte[] image = null;
            string imageContentType = "Nothing";
            string newName = "NewTheme";
            byte[] newImage = null;
            string newImageContentType = "Something";

            var themeId = themesService.CreateTheme(name, image, imageContentType);
            var theme = themesService.GetThemeById(themeId);
            themesService.UpdateTheme(theme, newName, newImage, newImageContentType);

            Assert.AreEqual(themesService.GetThemeById(themeId).Name, newName, "Name didnt update.");
        }

    }
}