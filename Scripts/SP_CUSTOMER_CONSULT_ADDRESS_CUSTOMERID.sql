USE HungryPizzaDb;

GO

CREATE PROCEDURE SP_CUSTOMER_CONSULT_ADDRESS_CUSTOMERID
(
	@CustomerId int
)    
AS    
BEGIN   
   
     SELECT CA.CustomerAddressId, CA.Surname, CA.Street, CA.Number, CA.Complement, CA.District, CA.City, CA.RegionState, CA.ZipCode FROM CustomerAddress CA WHERE CA.CustomerId =@CustomerId 
   
END 