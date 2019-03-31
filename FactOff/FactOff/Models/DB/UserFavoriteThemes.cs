using System;

namespace FactOff.Models.DB
{
    public class UserFavoriteThemes
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ThemeId { get; set; }
        public Theme Theme { get; set; }
    }
}
