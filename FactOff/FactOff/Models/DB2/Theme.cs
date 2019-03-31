using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.DB2
{
    public class Theme
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ThemeId { get; set; }
        public string Name { get; set; }

        public ICollection<UserFavoriteThemes> Users { get; set; }
    }
}
