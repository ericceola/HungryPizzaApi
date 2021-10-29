using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
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

   public  class  CustomerAddressServiceTest
    {
        ICustomerAddressService _customerAddressService;
       

        [Fact]
        public async Task CustomerAddressRegisterNotRegistered()
        {

            Mock<ICustomerAddressRepository> mockCustomerAddressRepository = new Mock<ICustomerAddressRepository>();


            var customerAddress = new CustomerAddress()
            {
                CustomerAddressId = 0,
                Surname = null,
                CustomerId = 1,
                Street = "Rua Figueiras",
                Number = "22",
                Complement = "Apartamento 40",
                District = "Bairro Jardim",
                City = "Santo André",
                RegionState = "SP",
                ZipCode = "09080-300"
            };

            var customerAddressRequest = new CustomerAddressRequest()
            {
                CustomerAddressId = 0,
                Surname = null,
                CustomerId = 1,
                Street = "Rua Figueiras",
                Number = "22",
                Complement = "Apartamento 40",
                District = "Bairro Jardim",
                City = "Santo André",
                RegionState = "SP",
                ZipCode = "09080-300"
            };


            var mocker = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerAddressProfile());
            });

            var mapper = mocker.CreateMapper();

            Task<int> customerId = null;
            mockCustomerAddressRepository.Setup(m => m.InsertAsync(customerAddress)).Returns(value: customerId);

            _customerAddressService = new CustomerAddressService(mockCustomerAddressRepository.Object, mapper);

            CustomerAddressResponse teste = await _customerAddressService.CustomerAddressRegister(customerAddressRequest);

            Assert.Equal("O endereço não foi cadastrado.", teste.Message);

        }




       
    }
}
