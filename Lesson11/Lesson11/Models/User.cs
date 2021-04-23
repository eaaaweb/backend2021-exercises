using lesson11.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lesson11.Models
{
    public class User {
        [Display(Name = "Name")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "You name must be more that 4 characters")]
        [Required(ErrorMessage = "You forgot to enter you name")]
        public string Fullname { get; set; }

        [Remote("UniqueUserName", "RemoteValidation")]
        [UniqueUsername(ErrorMessage = "Username is already taken")]
        [Required(ErrorMessage = "You forgot to enter a username")]
        public string Username { get; set; }

        [StringLength(30, MinimumLength = 6, ErrorMessage = "Your password must be at least 6 characters")]
        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match")]
        [Required(ErrorMessage = "You must confirm the password")]
        [DataType(DataType.Password)]
        
        public string ConfirmPassword { get; set; }

        [Range(typeof(int), "1", "120", ErrorMessage = "Value for age must be between {1} and {2}")]
        [Required(ErrorMessage = "You must enter your age")]
        public int Age { get; set; }
    }
}