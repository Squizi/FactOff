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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ThemeId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string ImageContentType { get; set; }

        public ICollection<UserFavoriteThemes> Users { get; set; }
        public ICollection<Fact> Facts { get; set; }

        public Theme()
        {
            Users = new List<UserFavoriteThemes>();
        }
    }
}
