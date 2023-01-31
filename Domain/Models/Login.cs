using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
	public class Login
	{
		[Required(ErrorMessage = "User name is REQUIRED!")]
		public string? UserName { get; set; }
        [Required(ErrorMessage = "Password name is REQUIRED!")]
        public string? Password { get; set; }
	}
}

