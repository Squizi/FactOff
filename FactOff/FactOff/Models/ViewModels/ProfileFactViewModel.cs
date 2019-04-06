using FactOff.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model of a single fact for the Profile page in the Account folder.
    /// </summary>
    public class ProfileFactViewModel
    {
        /// <summary>
        /// The context of the fact.
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// The names of the tags for the fact.
        /// </summary>
        public IEnumerable<string> TagsNames { get; set; }
        /// <summary>
        /// The name of the theme of the fact.
        /// </summary>
        public string ThemeName { get; set; }
        /// <summary>
        /// The rating of the fact.
        /// </summary>
        public double Rating { get; set; }
    }
}
