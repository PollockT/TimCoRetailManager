CREATE TABLE [dbo].[SalesItem]
(
	[Id] INT NOT NULL default NEWID(),
	[ItemName] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(MAX) NULL
	CONSTRAINT PK_SalesItemsId  PRIMARY KEY (Id) 
)
