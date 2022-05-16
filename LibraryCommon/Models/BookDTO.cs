namespace LibraryWebApp.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPaperBack { get; set; }
        public DateOnly PublishDate { get; set; }
        public int Author { get; set; }
        public int Genre { get; set; }
    }
}
