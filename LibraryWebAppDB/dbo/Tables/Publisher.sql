CREATE TABLE [dbo].[Publisher]
(
	[PublisherId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50),
	[BirthLocation] INT FOREIGN KEY REFERENCES Address(AddressId),
)
