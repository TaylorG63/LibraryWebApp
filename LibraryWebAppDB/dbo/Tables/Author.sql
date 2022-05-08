CREATE TABLE [dbo].[Author]
(
	[AuthorId] INT NOT NULL PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50),
	[DateOfBirth] DATE NOT NULL,
	[BirthLocation] INT FOREIGN KEY REFERENCES Address(AddressId),
	[Bio] VARCHAR(MAX)
)
