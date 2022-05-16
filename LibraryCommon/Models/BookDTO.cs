﻿namespace LibraryWebApp.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPaperBack { get; set; }
        public DateOnly PublishDate { get; set; }
        public AuthorDTO Author { get; set; }
        public GenreDTO Genre { get; set; }
    }
}
