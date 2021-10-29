using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using System.Threading.Tasks;

namespace HungryPizza.Service.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<bool> OrderItemRegister(OrderItem orderItem)
        {
            //await _orderItemRepository.InsertAsync(orderItem);
            return true;
        }
    }
}
