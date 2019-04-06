using System;

namespace FactOff.Models.DB
{
    /// <summary>
    /// Model of the many-to-many connection between users table and facts table. 
    /// </summary>
    public class UserFavoritesFacts
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Easier use of the User model for database manipulation.
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// The id of the saved fact by the user.
        /// </summary>
        public Guid FactId { get; set; }
        /// <summary>
        /// Easier use of the Fact model for database manipulation.
        /// </summary>
        public Fact Fact { get; set; }
    }
}
