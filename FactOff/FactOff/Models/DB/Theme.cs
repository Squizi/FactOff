using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactOff.Models.DB
{
    /// <summary>
    /// Model of the themes table from the database.
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// Unique id of the theme.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ThemeId { get; set; }
        /// <summary>
        /// The name of the theme.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The picture of the theme.
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// The type of the image.
        /// </summary>
        public string ImageContentType { get; set; }

        /// <summary>
        /// All users that have favoured the theme.
        /// </summary>
        public ICollection<UserFavoriteThemes> Users { get; set; }
        /// <summary>
        /// All facts associated with the theme.
        /// </summary>
        public ICollection<Fact> Facts { get; set; }

        /// <summary>
        /// The contructor sets the default values.
        /// </summary>
        public Theme()
        {
            Users = new List<UserFavoriteThemes>();
        }
    }
}
