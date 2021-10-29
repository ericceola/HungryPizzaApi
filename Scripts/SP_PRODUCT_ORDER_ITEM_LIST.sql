USE HungryPizzaDb;

GO

CREATE PROCEDURE SP_PRODUCT_ORDER_ITEM_LIST
(
	@OrderId INT
)    
AS    
BEGIN 
   SELECT ProductName, UnitPrice, Quantity, Price  FROM OrderItem P WHERE OrderId = @OrderId
END 

