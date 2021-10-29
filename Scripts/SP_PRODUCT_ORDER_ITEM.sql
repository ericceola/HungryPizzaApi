USE HungryPizzaDb;

GO

CREATE PROCEDURE SP_PRODUCT_ORDER_ITEM
(
	@ProductId INT,
	@HalfProductId INT,
	@Quantity INT
)    
AS    
BEGIN   

	IF(@HalfProductId = 0)
		BEGIN
			SELECT 
			 CASE
				WHEN P.InStock = 1 THEN P.ProductName
				ELSE CONCAT(P.ProductName, ' ', '(EM FALTA)')
				END AS 
				ProductName, (P.Price) AS UnitPrice, @Quantity as Quantity, (P.Price * @Quantity) as Price, P.InStock  FROM Product P WHERE P.ProductId = @ProductId
		END
	ELSE
		BEGIN
	  	    SELECT
			  CASE
				WHEN PA.InStock = 1 AND PB.InStock = 1 THEN CONCAT(PA.ProductName,' / ', PB.ProductName)
				WHEN PA.InStock = 0 THEN CONCAT(PA.ProductName, ' ', '(EM FALTA)')
				ELSE CONCAT(PB.ProductName, ' ', '(EM FALTA)')
				END AS 
			  ProductName, 
			 ((PA.Price + PB.Price) /2) AS UnitPrice, @Quantity as Quantity, (((PA.Price + PB.Price) /2) * @Quantity) as Price, (PA.InStock & PB.InStock) as InStock FROM Product PA
				INNER JOIN   Product PB  ON  PA.ProductId =  @ProductId AND PB.ProductId = @HalfProductId
		END

  END 




 