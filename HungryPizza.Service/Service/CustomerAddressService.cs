using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using System.Threading.Tasks;

namespace HungryPizza.Service.Service
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly ICustomerAddressRepository _CustomerAddressRepository;
        private readonly IMapper _mapper;

        public CustomerAddressService(ICustomerAddressRepository CustomerAddressRepository, IMapper mapper)
        {
            _CustomerAddressRepository = CustomerAddressRepository;
            _mapper = mapper;
        }

        public async Task<CustomerAddressResponse> CustomerAddressRegister(CustomerAddressRequest customerAddressRequest)
        {
            var customerAddress = _mapper.Map<CustomerAddress>(customerAddressRequest);
            CustomerAddressResponse customerAddressResponse = new CustomerAddressResponse();
            
            var exists = _CustomerAddressRepository.CustomerAddressExists(customerAddress.CustomerId);
            if (exists == null)
            {

                int customerAddressId = await _CustomerAddressRepository.InsertAsync(customerAddress);

                customerAddressResponse.CustomerAddressId = customerAddressId;

                if (customerAddressResponse.CustomerAddressId == 0)
                {
                    customerAddressResponse.Message = "O endereço não foi cadastrado.";
                }
                else
                {
                    customerAddressResponse.Message = "Endereço cadastrado com sucesso.";
                }
            }
            else
            {
                customerAddressResponse.CustomerAddressId = exists.CustomerAddressId;
                customerAddressResponse.Message = "Endereço já cadastrado pelo usuário.";
            }

            return customerAddressResponse;
        }
    }
}
