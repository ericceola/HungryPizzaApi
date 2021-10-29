using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<int> InsertAsync(Product product);
        Task<IEnumerable<Product>> ListAsync();
    }
}
