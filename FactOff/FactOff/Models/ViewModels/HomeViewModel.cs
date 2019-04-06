using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model for the Index page in the Home folder.
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// A collection of the themes.
        /// </summary>
        public IEnumerable<HomeThemeViewModel> Themes { get; set; }
        /// <summary>
        /// A collection of the facts.
        /// </summary>
        public IEnumerable<HomeFactViewModel> Facts { get; set; }
    }
}
