namespace LibraryWebApp.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPaperBack { get; set; }
        public DateTime PublishDate { get; set; }
        public AuthorModel Author { get; set; }
        public GenreModel Genre { get; set; }
    }
}
