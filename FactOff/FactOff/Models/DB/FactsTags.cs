using System;

namespace FactOff.Models.DB
{
    /// <summary>
    /// Model of the many-to-many to connection between the facts table and the tags table.
    /// </summary>
    public class FactsTags
    {
        /// <summary>
        /// The id of the fact.
        /// </summary>
        public Guid FactId { get; set; }
        /// <summary>
        /// Easier use of the Fact model for database manipulation.
        /// </summary>
        public Fact Fact { get; set; }
        /// <summary>
        /// The id of the tag associated with the fact.
        /// </summary>
        public Guid TagId { get; set; }
        /// <summary>
        /// Easier use of the Tag model for the database manipulation.
        /// </summary>
        public Tag Tag { get; set; }
    }
}
