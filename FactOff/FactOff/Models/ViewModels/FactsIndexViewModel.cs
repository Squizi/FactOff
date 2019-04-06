using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model of all the facts for the Index page in the Facts folder.
    /// </summary>
    public class FactsIndexViewModel
    {
        /// <summary>
        /// Collection of all the facts with the needed fields.
        /// </summary>
        public IEnumerable<FactIndexViewModel> Facts { get; set; }
    }
}
