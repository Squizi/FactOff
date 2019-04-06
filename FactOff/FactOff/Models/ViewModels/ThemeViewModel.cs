using Microsoft.AspNetCore.Http;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model for the Create page in the Themes folder.
    /// </summary>
    public class ThemeViewModel
    {
        /// <summary>
        /// The name of the theme.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The image sent with http request.
        /// </summary>
        public IFormFile ImageUploaded { get; set; }
        /// <summary>
        /// The image of the theme.
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// The type of the image.
        /// </summary>
        public string ImageContentType { get; set; }
    }
}
