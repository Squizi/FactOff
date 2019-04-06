using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// Single Fact View Model for the Index page in the Facts folder.
    /// </summary>
    public class FactIndexViewModel
    {
        /// <summary>
        /// The context of the fact.
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// The name of the user that created the fact.
        /// </summary>
        public string CreatorName { get; set; }
        /// <summary>
        /// The name of the theme of the fact.
        /// </summary>
        public string ThemeName { get; set; }
        /// <summary>
        /// The id of the user that created the fact.
        /// </summary>
        public string CreatorId { get; set; }
        /// <summary>
        /// The rating of the fact.
        /// </summary>
        public float Rating { get; set; }
        /// <summary>
        /// The names of all the tags connected to the fact.
        /// </summary>
        public IEnumerable<string> TagsNames { get; set; }
    }
}
