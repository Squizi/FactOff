using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.DB
{
    public class UserFavoritesFacts
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid FactId { get; set; }
        public Fact Fact { get; set; }
    }
}
