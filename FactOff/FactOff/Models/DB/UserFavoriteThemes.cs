using System;

namespace FactOff.Models.DB
{
    /// <summary>
    /// Model of the many-to-many connection between the users table and the themes table.
    /// </summary>
    public class UserFavoriteThemes
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
        /// The id of the theme saved by the user.
        /// </summary>
        public Guid ThemeId { get; set; }
        /// <summary>
        /// Easier use of the Theme model for database manipulation.
        /// </summary>
        public Theme Theme { get; set; }
    }
}
