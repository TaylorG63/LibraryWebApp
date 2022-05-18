namespace LibraryWebApp.Models
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Bio { get; set; }
        public int BirthLocation { get; set; }
    }
}
