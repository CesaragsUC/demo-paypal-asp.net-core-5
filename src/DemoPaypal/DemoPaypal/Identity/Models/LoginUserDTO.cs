using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Identity.Models
{
    public class LoginUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(100, ErrorMessage = "the {0} password should have between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
