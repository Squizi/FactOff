using FactOff.Models.DB;
using FactOff.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace FactOff.Services
{
    public class UsersService : IUsersService
    {
        private FactOffContext context;

        public UsersService(FactOffContext context)
        {
            this.context = context;
        }
        public Guid CreateUser(string email, string name, string password)
        {
            //TODO
            //password = HashPassword(password);
            User user = new User() {
                Name = name,
                Email = email,
                Password = password
            };

            return user.UserId;
        }

        public string SignIn(string email, string password)
        {
            //TODO
            //password = HashPassword(password);
            var user = context.Users.Where(u => u.Email == email && u.Password == password).SingleOrDefault();
            if(user != null)
            {
                
                return user.UserId.ToString();
            }

            return null;
        }

        private string HashPassword(string password) {
            throw new NotImplementedException();
        }
    }
}
