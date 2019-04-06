using FactOff.Models.DB;
using System;

namespace FactOff.Services.Contracts
{
    /// <summary>
    /// <c>IUsersService interface</c> for the <c>UsersService class</c>.
    /// Contains all the CRUD operations to manipulate the themes in the database.
    /// <list type="bullet">
    /// <item>
    /// <term>Create</term>
    /// <description>CreateUser creates a new factoff with his email, name & password.</description>
    /// </item>
    /// <item>
    /// <term>Read</term>
    /// <description>GetUserById, UserExists & SignIn look in the database for users and return indicator if the factoff exists.</description>
    /// </item>
    /// <item>
    /// <term>Update</term>
    /// <description>EditUser & SaveFactToUser edit the information about a given user.</description>
    /// </item>
    /// <item>Delete</item>
    /// <description>DeleteUser removes a given user from the database.</description>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>This class can communicate with the database and edit the information in the users table.</para>
    /// </remarks>
    public interface IUsersService
    {
        /// <summary>
        /// Creates a new user with a <paramref name="name"/>, <paramref name="email"/> & <paramref name="password"/> and adds it to the database.
        /// </summary>
        /// <param name="email">The email of the new user.</param>
        /// <param name="name">The name of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        /// <returns>The id of the created user.</returns>
        Guid CreateUser(string email, string name, string password);
        /// <summary>
        /// Lets a user to sign in if he gives the right <paramref name="email"/> & <paramref name="password"/>.
        /// </summary>
        /// <param name="email">The email of the user requesting to sign in.</param>
        /// <param name="password">The password of the user requesting to sign in.</param>
        /// <returns>The id of the user if a user exists with the given <paramref name="email"/> & <paramref name="password"/>.</returns>
        string SignIn(string email, string password);
        /// <summary>
        /// Check if there is a user with a coresponding <paramref name="email"/>.
        /// </summary>
        /// <param name="email">The email of the user that will be searched.</param>
        /// <returns>A boolean value that represents if the email is in the database.</returns>
        bool UserExists(string email);
        /// <summary>
        /// Edits all the information about a user by a given <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The id of the user to be edited.</param>
        /// <param name="newEmail">The new email of the user.</param>
        /// <param name="newImage">The new profile picture of the user.</param>
        /// <param name="newImageContentType">The type of the new profile picture.</param>
        /// <param name="newName">The new name of the user.</param>
        /// <param name="newPassword">The new password of the user.</param>
        /// <returns>The id of the edited user.</returns>
        Guid EditUser(Guid userId, string newEmail, byte[] newImage, string newImageContentType, string newName, string newPassword);
        /// <summary>
        /// Removes a given <paramref name="user"/> from the database.
        /// </summary>
        /// <param name="user">The user to be deleted.</param>
        /// <returns>Affected rows.</returns>
        int DeleteUser(User user);
        /// <summary>
        /// Finds a user with coresponding <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the user to be searched for.</param>
        /// <returns>The user with the coresponding <paramref name="id"/>.</returns>
        User GetUserById(Guid id);
        /// <summary>
        /// Adds <paramref name="fact"/>-<paramref name="user"/> row to the UserSaved table.
        /// </summary>
        /// <param name="user">The user to whom the fact will be saved.</param>
        /// <param name="fact">The fact that will be saved to the user.</param>
        /// <returns>Affected rows.</returns>
        int SaveFactToUser(User user, Fact fact);
    }
}
