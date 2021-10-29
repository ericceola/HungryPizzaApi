using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HungryPizza.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> ProductRegister(ProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            int productId =  await _productRepository.InsertAsync(product);
            ProductResponse productResponse = new ProductResponse();
            productResponse.ProductId = productId;


            if (productResponse.ProductId == 0)
            {
                productResponse.Message = "O produto não foi cadastrado.";
            }
            else
            {
                productResponse.Message = "Produto cadastrado com sucesso.";
            }

            return productResponse;
        }

        public async Task<IEnumerable<ProductListResponse>> ListAsync()
        {
          
            var products = await _productRepository.ListAsync();
            var productList =  _mapper.Map<IEnumerable<Product>, IEnumerable<ProductListResponse>>(products);

            return productList;
        }
    }
}
