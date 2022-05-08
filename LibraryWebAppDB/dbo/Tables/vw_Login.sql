CREATE VIEW [dbo].[vw_Login]
	AS SELECT UserID, UserName, Password, Salt FROM [User]
