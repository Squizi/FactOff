using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;

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

        private string HashPassword(string password) {
            throw new NotImplementedException();
        }
    }
}
