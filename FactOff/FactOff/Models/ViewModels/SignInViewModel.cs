using System.ComponentModel.DataAnnotations;

namespace FactOff.Models.ViewModels
{
    public class SignInViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
