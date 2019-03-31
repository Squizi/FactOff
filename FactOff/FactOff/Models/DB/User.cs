using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.DB
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }

        public ICollection<Fact> CreatedFacts { get; set; }
        public ICollection<UserFavoritesFacts> FavoriteFacts { get; set; }
        public ICollection<UserFavoriteThemes> FavoriteThemes { get; set; }

        public User()
        {
            CreatedFacts = new List<Fact>();
            FavoriteFacts = new List<UserFavoritesFacts>();
            FavoriteThemes = new List<UserFavoriteThemes>();
        }
    }
}
