CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY,
	[Role] INT NOT NULL FOREIGN KEY REFERENCES Role(RoleID),
	[FirstName] CHAR(25) not null,
	[LastName] CHAR(25) not null,
	[UserName] CHAR(25) not null,
	[Email] Char(50) not null,
	[Password] VarChar(MAX) not null,
	[Salt] VARChar(MAX)
)
