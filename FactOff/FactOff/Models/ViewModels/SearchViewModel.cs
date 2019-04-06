using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model for the Index page in the Search folder.
    /// </summary>
    public class SearchViewModel
    {
        /// <summary>
        /// String to be searched.
        /// </summary>
        public string Search { get; set; }
        /// <summary>
        /// Facts that satisfy the search.
        /// </summary>
        public IEnumerable<HomeFactViewModel> Facts { get; set; }
    }
}
