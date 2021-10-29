using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Interfaces.IRepository;
using HungryPizza.Domain.Interfaces.IService;
using HungryPizza.Domain.Mapper;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using HungryPizza.Service.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaTest.Service
{
   
    public class CustomerOrderServiceTest
    {
       

        [Fact]
       public async Task CustomerOrderRegister()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            Mock<ICustomerOrderRepository> mockCustomerOrderRepository = new Mock<ICustomerOrderRepository>();
            Mock<IOrderItemRepository> mockCustomerItemRepository = new Mock<IOrderItemRepository>();
            Mock<ICustomerAddressRepository> mockCustomerAddressRepository = new Mock<ICustomerAddressRepository>();


            var customerOrder = new CustomerOrder()
            {
                OrderId = 1,
                CustomerId = 1
            };

            var customerOrderRequest = new CustomerOrderRequest()
            {
                OrderId = 1,
                CustomerId = 1
            };


            var orderItemRequest1 = new OrderItemRequest()
            {
                ProductId= 9,
				HalfProductId= 6,
				Quantity=2
            };

            var orderItemRequest2 = new OrderItemRequest()
            {
                ProductId = 1,
                HalfProductId = 0,
                Quantity = 1
            };

            customerOrderRequest.OrderItens = new List<OrderItemRequest>();
            customerOrderRequest.OrderItens.Add(orderItemRequest1);
            customerOrderRequest.OrderItens.Add(orderItemRequest2);

            int orderId = 1;

            mockCustomerOrderRepository.Setup(m => m.InsertAsync(customerOrder)).Returns(Task.FromResult(orderId));

            var mocker = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OrderCustomerProfile());
            });

            var mapper = mocker.CreateMapper();

            var _customerOrderService = new CustomerOrderService(mapper, mockCustomerRepository.Object, mockCustomerAddressRepository.Object, mockCustomerItemRepository.Object, mockCustomerOrderRepository.Object);

            CustomerOrderResponse test = await _customerOrderService.CustomerOrderRegister(customerOrderRequest);

            Assert.NotNull(test);
        }
    }
}
