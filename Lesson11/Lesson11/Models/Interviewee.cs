using lesson11.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace lesson11.Models
{
    public class Interviewee {

        [Required(ErrorMessage = "You must enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter an address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter zip code")]
        [RegularExpression(@"\d\d\d\d", ErrorMessage = "You must enter a valid zip code")]
        public int Zip { get; set; }

        [Required(ErrorMessage = "You must enter city")]
        public string City { get; set; }

        [RegularExpression(@"\+{0,1}[\d\s]{8,14}", ErrorMessage = "You must give a valid phone number")]
        [Required(ErrorMessage = "You must enter phone")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "There is a problem with the email")]
        [Required(ErrorMessage = "You must enter email")]
        public string Email { get; set; }

        [Display(Name = "First interview")]
        [FutureDateAttribute (ErrorMessage = "Please enter a date in the future")]
        [Required(ErrorMessage = "You must enter the first data for the interview")]
        [DataType(DataType.Date)]
        public DateTime FirstInterview { get; set; }

        [Display(Name="Second interview")]
        [FutureDateAttribute(ErrorMessage = "Please enter a date in the future")]
        [Required(ErrorMessage = "You must enter the second data for the interview")]
        [DataType(DataType.Date)]
        public DateTime SecondInterview { get; set; }
    }
}