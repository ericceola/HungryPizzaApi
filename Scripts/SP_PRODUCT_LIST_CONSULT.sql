SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SP_PRODUCT_LIST_CONSULT]
AS    
BEGIN   
    SELECT P.ProductId, P.ProductName, P.ProductDescription,  P.Price, P.ImageUrl, P.inStock  FROM  Product P	
END 
GO


