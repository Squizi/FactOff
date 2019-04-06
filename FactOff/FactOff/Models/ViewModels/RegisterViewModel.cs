using System.ComponentModel.DataAnnotations;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model for the Register page in the Account folder.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// The email of the new user.
        /// </summary>
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The name of the new user.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The password of the new user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
