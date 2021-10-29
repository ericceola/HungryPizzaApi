USE HungryPizzaDb;

GO

CREATE PROCEDURE SP_CUSTOMER_CONSULT_ID
(
	@CustomerId int
)    
AS    
BEGIN   
   
    SELECT C.CustomerName, C.Cpf, C.ContactPhone  FROM Customer C WHERE C.CustomerId =@CustomerId 
   
END 