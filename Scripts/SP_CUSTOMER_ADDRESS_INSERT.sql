USE HungryPizzaDb;

GO

CREATE PROCEDURE [SP_CUSTOMER_ADDRESS_INSERT]
(
     @CustomerId int,
     @Street VARCHAR(MAX),
     @Number VARCHAR(MAX),
	 @Complement VARCHAR(MAX),
     @District VARCHAR(MAX),
	 @City VARCHAR(MAX),
     @RegionState VARCHAR(MAX),
	 @ZipCode VARCHAR(MAX),
     @Surname VARCHAR(MAX)
)
AS    
BEGIN  
 BEGIN TRY
    BEGIN TRANSACTION;
            INSERT INTO HungryPizzaDb.dbo.CustomerAddress(CustomerId, Street,Number, Complement, District, City, RegionState, ZipCode, Surname) 
            VALUES (@CustomerId, @Street, @Number, @Complement, @District, @City, @RegionState, @ZipCode, @Surname) 

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
