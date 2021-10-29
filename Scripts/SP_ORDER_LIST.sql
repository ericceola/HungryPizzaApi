USE HungryPizzaDb;

GO

CREATE PROCEDURE SP_ORDER_LIST
(
	@customerId INT,
	@PageNumber INT,
	@PageSize INT
)    
AS    
BEGIN 
   SELECT OrderId, Amount, DateOrder FROM CustomerOrder WHERE CustomerId = @customerId ORDER BY OrderId DESC OFFSET @PageSize * (@PageNumber-1) ROWS FETCH NEXT @PageSize ROWS ONLY
END 




