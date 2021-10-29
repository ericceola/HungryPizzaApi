using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> SelectAsync(int productId, int? halfProductId, int quantity);
        Task<IEnumerable<OrderItem>> SelectAllAsync(int orderId);
        Task<int> InsertAsync(OrderItem orderItem);
    }
}
