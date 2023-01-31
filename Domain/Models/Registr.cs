using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
	public class Registr
	{
        [Required(ErrorMessage = "User name is REQUIRED!")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password name is REQUIRED!")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email is REQUIRED!")]
        public string? Email { get; set; }
    }
}

