using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> InsertAsync(CustomerOrder order);
        



    }
}
