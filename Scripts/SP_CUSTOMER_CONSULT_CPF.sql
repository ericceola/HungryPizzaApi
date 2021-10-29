USE HungryPizzaDb;

GO

CREATE PROCEDURE SP_CUSTOMER_CONSULT_CPF
(
	@Cpf VARCHAR(14)
)    
AS    
BEGIN   
   
    SELECT TOP 1 C.CustomerId FROM Customer C WHERE C.Cpf =@Cpf 
   
END 