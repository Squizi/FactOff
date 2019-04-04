using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.DB
{
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
