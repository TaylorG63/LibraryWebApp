using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    public class RegisterModel
    {
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "First name must be combination of letters and numbers only.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Last name must be combination of letters and numbers only.")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "User Name")]
        //[Remote(action: "DoesUserNameExist", controller: "HomeController", ErrorMessage ="User name already exists. Please enter a different user name.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "user name must be combination of letters and numbers only.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }
    }
}
