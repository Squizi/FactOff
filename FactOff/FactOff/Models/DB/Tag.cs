using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactOff.Models.DB
{
    /// <summary>
    /// Model of the tags table from the database.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Unique id of the tag.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TagId { get; set; }
        /// <summary>
        /// The name of the tag.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All facts with that tag.
        /// </summary>
        public ICollection<FactsTags> Facts { get; set; }

        /// <summary>
        /// The constructor sets the default values.
        /// </summary>
        public Tag()
        {
            Facts = new List<FactsTags>();
        }
    }
}
