using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Linq;

namespace FactOff.Services
{
    public class UsersService : IUsersService
    {
        private readonly FactOffContext context;

        public UsersService(FactOffContext context)
        {
            this.context = context;
        }

        public Guid CreateUser(string email, string name, string password)
        {
            User user = new User()
            {
                Name = name,
                Email = email,
                Password = password
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user.UserId;
        }

        public int DeleteUser(User user)
        {
            context.Users.Remove(user);
            return context.SaveChanges();
        }

        public User GetUserById(Guid id)
        {
            return context.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        public string SignIn(string email, string password)
        {
            //TODO
            //password = HashPassword(password);
            var user = context.Users.Where(u => u.Email == email && u.Password == password).SingleOrDefault();
            if (user != null)
            {
                return user.UserId.ToString();
            }

            return null;
        }

        public bool UserExists(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }

        public Guid EditUser(Guid userId, string newEmail, byte[] newImage, string newImageContentType,string newName, string newPassword)
        {
            var user = GetUserById(userId);
            user.Email = newEmail;
            user.Image = newImage;
            user.ImageContentType = newImageContentType;
            user.Name = newName;
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                user.Password = newPassword;
            }
            context.SaveChanges();
            return user.UserId;
        }

        public int SaveFactToUser(User user, Fact fact)
        {
            if(!user.FavoriteFacts.Contains(new UserFavoritesFacts(){ UserId = user.UserId, FactId = fact.FactId })) { 
                user.FavoriteFacts.Add(new UserFavoritesFacts(){ UserId = user.UserId, FactId = fact.FactId });
            }
            return context.SaveChanges();
        }
    }
}
