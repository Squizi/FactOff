using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Services.Contracts
{
    interface IUsersService
    {
        Guid CreateUser(string name, string email);
    }
}
