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

        //Update User
        /*public Guid UpdateUser(User user, string newEmail, byte[] newImage, string newName, string newPassword)
        {
            context.Users.Where(u => u == user).FirstOrDefault().Email = newEmail;
            context.Users.Where(u => u == user).FirstOrDefault().Image = newImage;
            context.Users.Where(u => u == user).FirstOrDefault().Name = newName;
            context.Users.Where(u => u == user).FirstOrDefault().Password = newPassword;
            context.SaveChanges();
            return user.UserId;
        }*/

        public Guid UpdateEmail(User user, string newEmail)
        {
            context.Users.Where(u => u == user).FirstOrDefault().Email = newEmail;
            context.SaveChanges();
            return user.UserId;
        }

        public Guid UpdateImage(User user, byte[] newImage)
        {
            context.Users.Where(u => u == user).FirstOrDefault().Image = newImage;
            context.SaveChanges();
            return user.UserId;
        }

        public Guid UpdateName(User user, string newName)
        {
            context.Users.Where(u => u == user).FirstOrDefault().Name = newName;
            context.SaveChanges();
            return user.UserId;
        }

        public Guid UpdatePassword(User user, string newPassword)
        {
            context.Users.Where(u => u == user).FirstOrDefault().Password = newPassword;
            context.SaveChanges();
            return user.UserId;
        }
    }
}
