using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please again write your password.")]        
        [Compare(nameof(Password))]
        public string Repassword { get; set; }
    }
}
