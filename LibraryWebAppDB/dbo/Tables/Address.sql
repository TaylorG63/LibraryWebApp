CREATE TABLE [dbo].[Address]
(
	[AddressId] INT NOT NULL PRIMARY KEY,
	[Address] VARCHAR(50) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[Country] VARCHAR(50) NOT NULL,
	[State] VARCHAR(2),
	[Zip] VARCHAR(5)
)
