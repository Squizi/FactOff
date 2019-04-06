using FactOff.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model of a single fact for the Index page in the Home folder.
    /// </summary>
    public class HomeFactViewModel
    {
        /// <summary>
        /// The context of the fact.
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// The rating of the fact.
        /// </summary>
        public float Rating { get; set; }
        /// <summary>
        /// The name of the user that created the fact.
        /// </summary>
        public string CreatorName { get; set; }
        /// <summary>
        /// The names of all the tags associated with the fact.
        /// </summary>
        public IEnumerable<string> TagsNames { get; set; }
    }
}
