USE [InventoryManagement_Test]
GO

/****** Object:  View [dbo].[vwProductInventory]    Script Date: 12/14/2021 9:07:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwProductInventory]
AS
SELECT        BL.BinNumber, BL.LotNumber, L.ProductSku, L.Quantity, L.ReceivedAt, L.ExpirationDate, BL.ID AS BinlotID
FROM            dbo.BinLots AS BL INNER JOIN
                         dbo.Lots AS L ON BL.LotNumber = L.Number
WHERE        (L.Quantity > 0)
GO
