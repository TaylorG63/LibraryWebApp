CREATE TABLE [dbo].[Publisher]
(
	[PublisherId] INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50),
	[BirthLocation] INT FOREIGN KEY REFERENCES Address(AddressId),
)
