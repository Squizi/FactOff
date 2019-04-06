using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model for the Profile page in the Account folder.
    /// </summary>
    public class ProfileViewModel
    {
        /// <summary>
        /// Collection of all the facts created by this user.
        /// </summary>
        public IEnumerable<ProfileFactViewModel> Facts { get; set; }
        /// <summary>
        /// The names of all of the saved themes.
        /// </summary>
        public IEnumerable<string> SavedThemes { get; set; }
    }
}
