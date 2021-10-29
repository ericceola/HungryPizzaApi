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
    public class ProductServiceTest
    {
        IProductService _productService;
    

        [Fact]
        public async Task ProductRegisterAlreadyRegistered()
        {

            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();


            var product = new Product()
            {
                ProductId= 0,
                ProductName= "4 queijos",
                ProductDescription= "4 queijos com  massa Pan",
                Price= 60,
                ImageUrl= null
            };

            var productRequest = new ProductRequest()
            {
                ProductId = 0,
                ProductName = "4 queijos",
                ProductDescription = "4 queijos com  massa Pan",
                Price = 60,
                ImageUrl = null
            };


            var mocker = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });

            var mapper = mocker.CreateMapper();

            Task<int> productId = null;
            mockProductRepository.Setup(m => m.InsertAsync(product)).Returns(value: productId);

            _productService = new ProductService(mockProductRepository.Object, mapper);

            ProductResponse teste = await _productService.ProductRegister(productRequest);

            Assert.Equal("O produto não foi cadastrado.", teste.Message);

        }

        [Fact]
        public async Task ProductList()
        {

            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            IEnumerable<Product> productList = new List<Product>()
            {
                 new Product()
                {
                ProductId = 1,
                ProductName = "4 queijos",
                ProductDescription = "4 queijos com  massa Pan",
                Price = 60,
                ImageUrl = null
               },
                 new Product()
                {
                ProductId = 2,
                ProductName = "Muçarela",
                ProductDescription = "Muçarela com  massa Pan",
                Price = 60,
                ImageUrl = null
               },
            };
            IEnumerable<ProductRequest> productListRequest = new List<ProductRequest>()
            {
                     new ProductRequest()
                     {
                        ProductId = 1,
                        ProductName = "4 queijos",
                        ProductDescription = "4 queijos com  massa Pan",
                        Price = 60,
                        ImageUrl = null
                     },
                      new ProductRequest()
                     {
                        ProductId = 2,
                        ProductName = "Muçarela",
                        ProductDescription = "Muçarela com  massa Pan",
                        Price = 60,
                        ImageUrl = null
                     }
        };

           


            var mocker = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });

            var mapper = mocker.CreateMapper();

            mockProductRepository.Setup(m => m.ListAsync()).Returns(Task.FromResult(productList));

            _productService = new ProductService(mockProductRepository.Object, mapper);

            IEnumerable<ProductListResponse> teste = await _productService.ListAsync();

            Assert.NotNull(teste);

        }
    }
}
