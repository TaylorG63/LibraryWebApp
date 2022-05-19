using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    public class AuthorModel
    {
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must be combination of letters only.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must be combination of letters only.")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        [StringLength(5, ErrorMessage = "Zipcode cannot be more then 5 digits long")]
        public string ZipCode { get; set; }
    }
}
