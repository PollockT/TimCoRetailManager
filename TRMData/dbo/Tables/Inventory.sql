﻿CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL IDENTITY,
	[ProductId] INT NOT NULL,
	[Quantity] INT NOT NULL DEFAULT 1,
	[PurchasePrice] MONEY NOT NULL,
	[PurcahseDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),

	CONSTRAINT PK_InventoryId PRIMARY KEY (Id)
)