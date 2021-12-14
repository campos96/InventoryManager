USE [InventoryManagement_Test]
GO

/****** Object:  View [dbo].[vwUserSales]    Script Date: 12/14/2021 9:55:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwUserSales]
AS
SELECT        IT.Username, P.Sku, P.Price AS 'UnitPrice', SUM(IT.Quantity) AS 'TotalQuantity', SUM(IT.Quantity) * P.Price AS 'TotalPrice'
FROM            dbo.InventoryTransactions AS IT INNER JOIN
                         dbo.BinLots AS BL ON BL.ID = IT.BinLotID INNER JOIN
                         dbo.Lots AS L ON BL.LotNumber = L.Number INNER JOIN
                         dbo.Products AS P ON P.Sku = L.ProductSku
WHERE        (IT.TransactionType = 1)
GROUP BY IT.Username, P.Sku, P.Price
GO
