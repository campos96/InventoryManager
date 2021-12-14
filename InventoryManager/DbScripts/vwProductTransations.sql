USE [InventoryManagement_Test]
GO

/****** Object:  View [dbo].[vwProductTransations]    Script Date: 12/14/2021 9:54:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwProductTransations]
AS
SELECT        TOP (100) PERCENT P.Sku, IT.TransactionType, BL.BinNumber, BL.LotNumber, IT.Quantity, IT.Username, IT.Date, IT.ID AS InventoryTransactionID
FROM            dbo.InventoryTransactions AS IT INNER JOIN
                         dbo.BinLots AS BL ON IT.BinLotID = BL.ID INNER JOIN
                         dbo.Bins AS B ON B.Number = BL.BinNumber INNER JOIN
                         dbo.Lots AS L ON L.Number = BL.LotNumber INNER JOIN
                         dbo.Products AS P ON L.ProductSku = P.Sku
GO
