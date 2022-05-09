﻿CREATE TABLE [dbo].[Genre]
(
	[GenreId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(250),
	[IsFiction] BIT NOT NULL
)
