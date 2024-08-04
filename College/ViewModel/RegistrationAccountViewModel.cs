using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace College.ViewModel
{
    public class RegistrationAccountViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
      
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "password and Confirmed not mated !! ")]
        public string PasswoedConfirmed { get; set; }
    }
}
