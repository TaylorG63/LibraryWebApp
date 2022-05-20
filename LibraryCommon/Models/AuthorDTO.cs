namespace LibraryWebApp.Models
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public int BirthLocation { get; set; }
        public string GetName { get => FirstName + " " + LastName; }
    }
}
