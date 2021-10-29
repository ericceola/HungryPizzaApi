using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> ProductRegister(ProductRequest productRequest);

        Task<IEnumerable<ProductListResponse>> ListAsync();
    }
}
