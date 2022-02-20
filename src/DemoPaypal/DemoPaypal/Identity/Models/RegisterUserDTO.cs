using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Identity.Models
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "the field {0} is required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "the field {0} is required")]
        [EmailAddress(ErrorMessage = "the field {0} is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [StringLength(100, ErrorMessage = "the field {0} should be between  {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "the passwords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}
