using System;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model for a single theme for the Index page in the Home folder.
    /// </summary>
    public class HomeThemeViewModel
    {
        /// <summary>
        /// The id of the theme.
        /// </summary>
        public Guid ThemeId { get; set; }
        /// <summary>
        /// The name of the theme.
        /// </summary>
        public string Name { get; set; }
    }
}
