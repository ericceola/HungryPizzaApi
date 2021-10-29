using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Mapper;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using HungryPizza.Service.Service;

using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaTest.Service
{


    public class CustomerServiceTest
    {
        ICustomerService _customerService;
        [Fact]
        public async Task CustomerRegisterAlreadyRegistered()
        {
            

                var customer = new Customer()
                {
                    CustomerId = 0,
                    CustomerName = "Nome Teste",
                    Cpf = "75203416826",
                    ContactPhone = "(11)9833-3322"
                };

                var customerRequest = new CustomerRequest()
                {
                    CustomerId = 90,
                    CustomerName = "Nome Teste",
                    Cpf = "75203416826",
                    ContactPhone = "(11)9833-3322"
                };

                Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
               
                Task<int> customerId = null;

                mockCustomerRepository.Setup(m => m.InsertAsync(customer)).Returns(value: customerId);
                mockCustomerRepository.Setup(m => m.CustomerExists(customer.Cpf)).Returns(value: customer);
                var mocker = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new CustomerProfile());
                });


                var mapper = mocker.CreateMapper();

                _customerService = new CustomerService(mockCustomerRepository.Object, mapper);

                CustomerResponse teste = await _customerService.CustomerRegister(customerRequest);

                Assert.Equal("Cliente já cadastrado.",teste.Message);

          

        }

        [Fact]
        public async Task CustomerRegister_No_Register()
        {


            var customer = new Customer()
            {
                CustomerId = 0,
                CustomerName = "Nome Teste",
                Cpf = "75203416826",
                ContactPhone = "(11)9833-3322"
            };

            var customerRequest = new CustomerRequest()
            {
                CustomerId = 90,
                CustomerName = "Nome Teste",
                Cpf = "75203416826",
                ContactPhone = "(11)9833-3322"
            };

            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            Mock<ICustomerService> mockCustomerService = new Mock<ICustomerService>();
            Task<int> customerId = null;

            mockCustomerRepository.Setup(m => m.InsertAsync(customer)).Returns(value: customerId);
            mockCustomerRepository.Setup(m => m.CustomerExists(customer.Cpf)).Returns(value: null);
            var mocker = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerProfile());
            });


            var mapper = mocker.CreateMapper();

            _customerService = new CustomerService(mockCustomerRepository.Object, mapper);

            CustomerResponse test = await _customerService.CustomerRegister(customerRequest);
 
            Assert.Equal("O cliente não foi cadastrado.", test.Message);
        }

        [Fact]
        public async Task CustomerRegister_Success()
        {


            var customer = new Customer()
            {
                CustomerId = 1,
                CustomerName = "Nome Teste",
                Cpf = "75203416826",
                ContactPhone = "(11)9833-3322"
            };

            var customerRequest = new CustomerRequest()
            {
                CustomerId = 1,
                CustomerName = "Nome Teste",
                Cpf = "75203416826",
                ContactPhone = "(11)9833-3322"
            };

            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            Mock<ICustomerService> mockCustomerService = new Mock<ICustomerService>();
            int customerId = 1;
   

            mockCustomerRepository.Setup(m =>  m.InsertAsync(customer)).Returns(Task.FromResult(customerId));
            mockCustomerRepository.Setup(m => m.CustomerExists("000000000")).Returns(value: customer);
            var mocker = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerProfile());
            });


            var mapper = mocker.CreateMapper();

            _customerService = new CustomerService(mockCustomerRepository.Object, mapper);

            CustomerResponse test = await _customerService.CustomerRegister(customerRequest);

             
            Assert.NotNull(test);
        }
    }
}
