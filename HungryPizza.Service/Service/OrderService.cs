using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _oderRepository;
        public OrderService(IOrderRepository oderRepository)
        {
            _oderRepository = oderRepository;
        }

        public async Task<bool> OrderRegister(CustomerOrder order)
        {
            await _oderRepository.InsertAsync(order);
            return true;
        }

    }
}
