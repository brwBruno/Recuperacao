CREATE TABLE [dbo].[TBBook]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Theme] VARCHAR(50) NOT NULL, 
    [Author] VARCHAR(50) NOT NULL, 
    [Volume] INT NOT NULL, 
    [Publication] DATETIME NOT NULL, 
    [Availability] INT NOT NULL
)
