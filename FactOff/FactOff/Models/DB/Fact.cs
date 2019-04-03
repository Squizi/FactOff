using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactOff.Models.DB
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

        public Fact()
        {
            Rating = 0;
            RateCount = 0;
            Users = new List<UserFavoritesFacts>();
            Tags = new List<FactsTags>();
        }
    }
}
