using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.DB2
{
    public class UserFavoriteThemes
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ThemeId { get; set; }
        public Theme Theme { get; set; }
    }
}
