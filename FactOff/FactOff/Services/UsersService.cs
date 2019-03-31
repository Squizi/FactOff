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
        public Guid CreateUser(string name, string email)
        {
            User user = new User() {
                Name = name,
                Email = email
            };

            return user.UserId;
        }
    }
}
