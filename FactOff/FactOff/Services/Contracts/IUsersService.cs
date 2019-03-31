using System;

namespace FactOff.Services.Contracts
{
    interface IUsersService
    {
        Guid CreateUser(string name, string email);
    }
}
