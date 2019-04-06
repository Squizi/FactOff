using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactOff.Models.DB
{
    /// <summary>
    /// Model of the facts table from the database.
    /// </summary>
    public class Fact
    {
        /// <summary>
        /// Unique id for every fact.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FactId { get; set; }
        /// <summary>
        /// The content of the fact. 
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// How good is the average rating of the fact.
        /// </summary>
        public float Rating { get; set; }
        /// <summary>
        /// How many ratings have been given out to the fact.
        /// </summary>
        public int RateCount { get; set; }

        /// <summary>
        /// Who wrote the fact to the site.
        /// </summary>
        public User Creator { get; set; }
        /// <summary>
        /// What is the primary category (theme) of the fact.
        /// </summary>
        public Theme Theme { get; set; }

        /// <summary>
        /// All users that have favoured the fact.
        /// </summary>
        public ICollection<UserFavoritesFacts> Users { get; set; }
        /// <summary>
        /// All tags that categorize the fact.
        /// </summary>
        public ICollection<FactsTags> Tags { get; set; }

        /// <summary>
        /// The constructor sets the default values for the fields.
        /// </summary>
        public Fact()
        {
            Rating = 0;
            RateCount = 0;
            Users = new List<UserFavoritesFacts>();
            Tags = new List<FactsTags>();
        }
    }
}
