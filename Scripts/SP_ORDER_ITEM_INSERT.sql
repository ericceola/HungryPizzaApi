USE HungryPizzaDb;

GO

CREATE PROCEDURE [SP_ORDER_ITEM_INSERT]
(
     @OrderId INT,
     @ProductName VARCHAR(MAX),
	 @UnitPrice DECIMAL,
     @Quantity INT,
	 @Price DECIMAL
)
AS    
BEGIN  
 BEGIN TRY
    BEGIN TRANSACTION;
            INSERT INTO HungryPizzaDb.dbo.OrderItem(OrderId, ProductName,UnitPrice,Quantity,Price) 
            VALUES (@OrderId, @ProductName, @UnitPrice, @Quantity,@Price) 

         SELECT SCOPE_IDENTITY();
          
        
  IF (XACT_STATE() = 1)
      COMMIT TRANSACTION;

 END TRY
 BEGIN CATCH
    IF (XACT_STATE() = -1)
    ROLLBACK TRANSACTION;
    THROW;
 END CATCH
END 
GO
