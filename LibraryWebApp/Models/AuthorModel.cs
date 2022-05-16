namespace LibraryWebApp.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Bio { get; set; }
        public AddresModel Address { get; set; }
    }
}
