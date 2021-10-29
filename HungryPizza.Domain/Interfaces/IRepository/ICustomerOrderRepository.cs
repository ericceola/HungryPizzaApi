using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces.IRepository
{
    public interface ICustomerOrderRepository
    {
        Task<int> InsertAsync(CustomerOrder customerOrder);
        Task<IEnumerable<CustomerOrder>> SelectAllAsync(int customerId, int pageNumber, int pageSize);
    }
}
