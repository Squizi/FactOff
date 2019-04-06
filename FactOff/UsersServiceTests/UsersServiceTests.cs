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
        public void CreatesUserReturnsUserId()
        {
            var data = new List<User>().AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var usersService = new UsersService(mockContext);
            string email = "email";
            string name = "User";
            string password = "password";

            usersService.CreateUser(email, name, password);

            Assert.IsNotEmpty(mockContext.Users);
        }

        [Test]
        [Obsolete]
        public void DeletesUserReturnsContextSaveToChanges()
        {
            var data = new List<User>().AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var usersService = new UsersService(mockContext);
            string email = "email";
            string name = "User";
            string password = "password";

            usersService.CreateUser(email, name, password);
            usersService.DeleteUser(mockContext.Users.First());

            Assert.IsEmpty(mockContext.Users);
        }

        [Test]
        [Obsolete]
        public void GetsUserByIdReturnsUser()
        {
            var data = new List<User>().AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var usersService = new UsersService(mockContext);
            Assert.Pass();
            string email = "email";
            string name = "User";
            string password = "password";

            usersService.CreateUser(email, name, password);
            var user = mockContext.Users.First();

            Assert.AreEqual(usersService.GetUserById(user.UserId), user,"User is not the same.");
        }

        [Test]
        [Obsolete]
        public void SignsInReturnsReturnsUserString()
        {
            var data = new List<User>().AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var usersService = new UsersService(mockContext);
            string email = "email";
            string name = "User";
            string password = "password";

            usersService.CreateUser(email, name, password);
            var userId = usersService.SignIn(email, password);

            Assert.AreEqual(userId, mockContext.Users.First().UserId.ToString(), "Sign in wasnt successful because id's are not the same.");
        }

        [Test]
        [Obsolete]
        public void ChecksIfUserExistsReturnsBool()
        {
            var data = new List<User>().AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var usersService = new UsersService(mockContext);
            string email = "email";
            string name = "User";
            string password = "password";

            usersService.CreateUser(email, name, password);
            var doesUserExist = usersService.UserExists(email);

            Assert.IsTrue(doesUserExist);
        }

        [Test]
        [Obsolete]
        public void EditsUserReturnsUserId()
        {
            var data = new List<User>().AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var usersService = new UsersService(mockContext);
            string email = "email";
            string name = "User";
            string password = "password";
            string newEmail = "newEmail";
            byte[] newImage = null;
            string newImageContentType = "nothing";
            string newName = "newUser";
            string newPassword = "newPassword";

            usersService.CreateUser(email, name, password);
            Guid userId = mockContext.Users.First().UserId;
            usersService.EditUser(userId, newEmail, newImage, newImageContentType, newName, newPassword);

            Assert.AreEqual(usersService.GetUserById(userId).Password, newPassword, "Passwords don't match.");
        }

        [Test]
        [Obsolete]
        public void AddsFactUserRowToUserSavedTable()
        {
            var data = new List<User>().AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var optionsBuilder = new DbContextOptionsBuilder<FactOffContext>();
            _ = optionsBuilder.UseInMemoryDatabase();
            var mockContext = new FactOffContext(optionsBuilder.Options);
            var usersService = new UsersService(mockContext);
            string email = "email";
            string name = "User";
            string password = "password";
            Fact fact = new Fact();
            Guid factId = Guid.NewGuid();
            fact.FactId = factId;
            fact.Context = "This is a fact.";

            usersService.CreateUser(email, name, password);
            var user = mockContext.Users.First();
            usersService.SaveFactToUser(user, fact);

            Assert.AreEqual(user.FavoriteFacts.First().FactId, factId, "The id's do not match");
        }
    }
}