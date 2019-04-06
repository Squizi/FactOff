using System.Collections.Generic;

namespace FactOff.Models.ViewModels
{

    /// <summary>
    /// View Model for the Create page in the Fact folder.
    /// </summary>
    public class CreateFactViewModel
    {
        /// <summary>
        /// The context of the new fact.
        /// </summary>
        public string FactContext { get; set; }
        /// <summary>
        /// The tags of the new fact.
        /// </summary>
        public string TagsString { get; set; }
        /// <summary>
        /// All available themes.
        /// </summary>
        public IEnumerable<string> ThemesNames { get; set; }
        /// <summary>
        /// The selected theme by the user.
        /// </summary>
        public string SelectedTheme { get; set; }
    }
}
