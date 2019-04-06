using System.ComponentModel.DataAnnotations;

namespace FactOff.Models.ViewModels
{
    /// <summary>
    /// View Model for the SignIn page in the Account folder.
    /// </summary>
    public class SignInViewModel
    {
        /// <summary>
        /// The email of the user.
        /// </summary>
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The password of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
