using FactOff.Models.DB;
using System;

namespace FactOff.Services.Contracts
{
    public interface IUsersService
    {
        Guid CreateUser(string email, string name, string password);
        string SignIn(string email, string password);
        bool UserExists(string email);
        Guid UpdateName(User user, string newName);
        Guid UpdateEmail(User user, string newEmail);
        Guid UpdateImage(User user, byte[] newImage);
        Guid UpdatePassword(User user, string newPassword);
        int DeleteUser(User user);
        User GetUserById(Guid id);
    }
}
