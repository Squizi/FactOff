using FactOff.Models.DB;
using System;

namespace FactOff.Services.Contracts
{
    public interface IUsersService
    {
        Guid CreateUser(string email, string name, string password);
        string SignIn(string email, string password);
        bool UserExists(string email);
        Guid EditUser(Guid userId, string newEmail, byte[] newImage, string newImageContentType, string newName, string newPassword);
        int DeleteUser(User user);
        User GetUserById(Guid id);
    }
}
