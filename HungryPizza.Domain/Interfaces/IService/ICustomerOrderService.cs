using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces.IService
{
    public interface ICustomerOrderService
    {
        Task<CustomerOrderResponse> CustomerOrderRegister(CustomerOrderRequest customerOrderRequest);

        Task<List<CustomerOrderResponse>> CustomerOrderList(int customerId, int pageNumber = 1, int pageSize = 5);
    }
}
