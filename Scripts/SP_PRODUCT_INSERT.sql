USE HungryPizzaDb;

GO

CREATE PROCEDURE [SP_PRODUCT_INSERT]
(
     @ProductName varchar(MAX),
     @ProductDescription VARCHAR(MAX),
     @Price decimal,
	 @ImageUrl VARCHAR(MAX)
)
AS    
BEGIN  
 BEGIN TRY
    BEGIN TRANSACTION;
            INSERT INTO HungryPizzaDb.dbo.Product(ProductName, ProductDescription,Price,ImageUrl) 
            VALUES (@ProductName, @ProductDescription, @Price, @imageUrl) 

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
