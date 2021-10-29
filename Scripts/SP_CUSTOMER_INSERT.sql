USE HungryPizzaDb;

GO

CREATE PROCEDURE [SP_CUSTOMER_INSERT]
(
     @CustomerName varchar(MAX),
     @Cpf VARCHAR(MAX),
     @ContactPhone VARCHAR(MAX),
     @DateCreate DAteTime
)
AS    
BEGIN  
 BEGIN TRY
    BEGIN TRANSACTION;
            INSERT INTO HungryPizzaDb.dbo.Customer(CustomerName, Cpf,ContactPhone, DateCreate) 
            VALUES (@CustomerName, @Cpf, @ContactPhone, @DateCreate) 

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
