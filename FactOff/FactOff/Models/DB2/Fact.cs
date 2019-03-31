using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.DB2
{
    public class Fact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FactId { get; set; }
        public string Context { get; set; }
        public float Rating { get; set; }
        public int RateCount { get; set; }

        public User Creator { get; set; }

        public ICollection<UserFavoritesFacts> Users { get; set; }
        public ICollection<FactsTags> Tags { get; set; }
    }
}
