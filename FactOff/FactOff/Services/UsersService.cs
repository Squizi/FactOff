using FactOff.Models.DB;
using FactOff.Services.Contracts;
using System;
using System.Linq;

namespace FactOff.Services
{
    /// <summary>
    /// The <c>UsersService class</c> that inherits from <c>IUsersService interface</c>.
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
    public class UsersService : IUsersService
    {
        /// <summary>
        /// The required context for the connection to the database.
        /// </summary>
        private readonly FactOffContext context;

        /// <summary>
        /// The constructor for the <c>UsersService</c> that is being called by the <c>StartUp class</c>.
        /// </summary>
        /// <param name="context">The required context for the connection to the database.</param>
        public UsersService(FactOffContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates a new user with a <paramref name="name"/>, <paramref name="email"/> & <paramref name="password"/> and adds it to the database.
        /// </summary>
        /// <param name="email">The email of the new user.</param>
        /// <param name="name">The name of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        /// <returns>The id of the created user.</returns>
        /// <example>
        /// <code>
        /// User user = GetUserById(CreateUser("myEmail@example.com", "My name", "My password"));
        /// Console.WriteLine($"Name: {user.Name}; Email: {user.Email}; Password: {user.Password}");
        /// </code>
        /// </example>
        /// <see cref="GetUserById(Guid)"/>
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

        /// <summary>
        /// Removes a given <paramref name="user"/> from the database.
        /// </summary>
        /// <param name="user">The user to be deleted.</param>
        /// <returns>Affected rows.</returns>
        /// <example>
        /// <code>
        /// User user = GetUserById(CreateUser("myEmail@example.com", "My name", "My password"));
        /// DeleteUser(user);
        /// if(GetUserById(user.UserId) == null){
        ///     Console.WriteLine("No such user.");
        /// }
        /// </code>
        /// </example>
        /// <see cref="CreateUser(string, string, string)"/>
        /// <seealso cref="GetUserById(Guid)"/>
        public int DeleteUser(User user)
        {
            context.Users.Remove(user);
            return context.SaveChanges();
        }

        /// <summary>
        /// Finds a user with coresponding <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the user to be searched for.</param>
        /// <returns>The user with the coresponding <paramref name="id"/>.</returns>
        /// <example>
        /// <code>
        /// User user = GetUserById(CreateUser("myEmail@example.com", "My name", "My password"));
        /// Console.WriteLine(user.Name);
        /// </code>
        /// </example>
        /// <see cref="CreateUser(string, string, string)"/>
        public User GetUserById(Guid id)
        {
            return context.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        /// <summary>
        /// Lets a user to sign in if he gives the right <paramref name="email"/> & <paramref name="password"/>.
        /// </summary>
        /// <param name="email">The email of the user requesting to sign in.</param>
        /// <param name="password">The password of the user requesting to sign in.</param>
        /// <returns>The id of the user if a user exists with the given <paramref name="email"/> & <paramref name="password"/>.</returns>
        ///<example>
        ///<code>
        /// User user = GetUserById(CreateUser("myEmail@example.com", "My name", "My password"));
        /// string userId = SignIn(user.Email, user.Password);
        /// Console.WriteLine(userId == null ? "Wrong username or password" : "userId");
        /// </code>
        /// </example>
        /// <see cref="CreateUser(string, string, string)"/>
        /// <seealso cref="GetUserById(Guid)"/>
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

        /// <summary>
        /// Check if there is a user with a coresponding <paramref name="email"/>.
        /// </summary>
        /// <param name="email">The email of the user that will be searched.</param>
        /// <returns>A boolean value that represents if the email is in the database.</returns>
        /// <example>
        /// <code>
        /// User user = GetUserById(CreateUser("myEmail@example.com", "My name", "My password"));
        /// if(UserExists(user.Email)){
        ///     Console.WriteLine(user.Name);
        /// }
        /// else{
        ///     Console.WriteLine("No such user in the database");
        /// }
        /// </code>
        /// </example>
        /// <see cref="CreateUser(string, string, string)"/>
        /// <seealso cref="GetUserById(Guid)"/>
        public bool UserExists(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }

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
        /// <example>
        /// <code>
        /// User user = GetUserById(CreateUser("myEmail@example.com", "My name", "My password"));
        /// byte[] image;
        /// using (var ms = new MemoryStream())
        /// {
        ///     request.ImageUploaded.CopyTo(ms);
        ///     image = ms.ToArray();
        /// }
        /// EditUser(user.UserId, "newEmail@example.com", image, request.ImageUploaded.ContentType, "My new name", "My new password");
        /// Console.WriteLine(user.Name);
        /// </code>
        /// </example>
        public Guid EditUser(Guid userId, string newEmail, byte[] newImage, string newImageContentType, string newName, string newPassword)
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

        /// <summary>
        /// Adds <paramref name="fact"/>-<paramref name="user"/> row to the UserSaved table.
        /// </summary>
        /// <param name="user">The user to whom the fact will be saved.</param>
        /// <param name="fact">The fact that will be saved to the user.</param>
        /// <returns>Affected rows.</returns>
        /// <example>
        /// <code>
        /// User user = GetUserById(CreateUser("myEmail@example.com", "My name", "My password"));
        /// Fact fact = new Fact(){
        ///     Context = "Fact context"
        /// };
        /// SavefactToUser(user, fact);
        /// Console.WriteLine(user.FavoriteFacts.Where(f => f.Fact == fact).First().Fact.Context);
        /// </code>
        /// </example>
        public int SaveFactToUser(User user, Fact fact)
        {
            if (!user.FavoriteFacts.Contains(new UserFavoritesFacts() { UserId = user.UserId, FactId = fact.FactId }))
            {
                user.FavoriteFacts.Add(new UserFavoritesFacts() { UserId = user.UserId, FactId = fact.FactId });
            }
            return context.SaveChanges();
        }
    }
}
