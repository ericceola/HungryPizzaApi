USE HungryPizzaDb;

GO

CREATE PROCEDURE [SP_CUSTOMER_ORDER_INSERT]
(
	 @CustomerId INT,
     @CustomerName varchar(MAX),
     @Amount DECIMAL,
     @Street VARCHAR(MAX),
	 @Number VARCHAR(MAX),
	 @Complement VARCHAR(MAX),
	 @District VARCHAR(MAX),
	 @City VARCHAR(MAX),
	 @RegionState VARCHAR(MAX),
	 @ZipCode VARCHAR(MAX),
	 @ContactPhone VARCHAR(MAX),
	 @DateOrder DATETIME
)
AS    
BEGIN  
 BEGIN TRY
    BEGIN TRANSACTION;
            INSERT INTO HungryPizzaDb.dbo.CustomerOrder(CustomerId, CustomerName, Amount, Street, Number, Complement, District, City, RegionState, ZipCode, ContactPhone, DateOrder) 
            VALUES (@CustomerId, @CustomerName, @Amount, @Street, @Number, @Complement, @District, @City, @RegionState, @ZipCode, @ContactPhone, @DateOrder) 

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
