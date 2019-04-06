using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model for the edit profile page
    /// </summary>
    public class AccountViewModel
    {
        /// <summary>
        /// The new name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The new email of the user.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The new password of the user.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// The new uploaded image.
        /// </summary>
        public IFormFile ImageUploaded { get; set; }
        /// <summary>
        /// The new image.
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// The type of the new image.
        /// </summary>
        public string ImageContentType { get; set; }
    }
}
