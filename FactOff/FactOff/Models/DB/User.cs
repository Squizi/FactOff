using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactOff.Models.DB
{
    /// <summary>
    /// Model of the users table from the database.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique id of the user.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        /// <summary>
        /// The name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The email of the user.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The password of the user.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// The profile picture of the user.
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// The type of the profice picture.
        /// </summary>
        public string ImageContentType { get; set; }

        /// <summary>
        /// All facts created by the user.
        /// </summary>
        public ICollection<Fact> CreatedFacts { get; set; }
        /// <summary>
        /// All facts that the user has favoured.
        /// </summary>
        public ICollection<UserFavoritesFacts> FavoriteFacts { get; set; }
        /// <summary>
        /// All themes the user has favoured.
        /// </summary>
        public ICollection<UserFavoriteThemes> FavoriteThemes { get; set; }

        /// <summary>
        /// The constructor sets the default values.
        /// </summary>
        public User()
        {
            CreatedFacts = new List<Fact>();
            FavoriteFacts = new List<UserFavoritesFacts>();
            FavoriteThemes = new List<UserFavoriteThemes>();
        }
    }
}
