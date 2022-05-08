CREATE TABLE [dbo].[Books]
(
	[BookId] INT NOT NULL PRIMARY KEY,
	[Title] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(250) not null,
	[IsPaperBack] BIT NOT NULL,
	[PublishDate] DATE NOT NULL,
	[Author] INT NOT NULL FOREIGN KEY REFERENCES Author(AuthorID),
	[Genre]INT NOT NULL FOREIGN KEY REFERENCES Genre(GenreID),
	[Publisher] INT NOT NULL FOREIGN KEY REFERENCES Publisher(PublisherID)
)
