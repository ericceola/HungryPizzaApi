using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HungryPizza.Service.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> CustomerRegister(CustomerRequest customerRequest)
        {
            var customer = _mapper.Map<Customer>(customerRequest);
            CustomerResponse customerResponse = new CustomerResponse();

            var cpf = Regex.Replace(customer.Cpf, "[^0-9]", "");

            var exists = _customerRepository.CustomerExists(cpf);
            if (exists == null)
            {
                customer.DateCreate = DateTime.Now;
                int customerId = await _customerRepository.InsertAsync(customer);
               
                customerResponse.CustomerId = customerId;

                if (customerResponse.CustomerId == 0)
                {
                    customerResponse.Message = "O cliente não foi cadastrado.";
                }
                else
                {
                    customerResponse.Message = "Cliente cadastrado com sucesso.";
                }
            }
            else
            {
                customerResponse.CustomerId = exists.CustomerId;
                customerResponse.Message = "Cliente já cadastrado.";
            }

            return customerResponse;
        }
        public async Task<SelectedCustomerResponse> SelectedCustomer(int customerId)
        {
           
            var customer = await _customerRepository.SelectedCustomerAsync(customerId);
            CustomerResponse customerResponse = new CustomerResponse();
          

            var customerSelectResponse = _mapper.Map<SelectedCustomerResponse>(customer);

            if(customerSelectResponse != null)
            {
                customerSelectResponse.Message = "Cliente cadastrado na nossa base de dados.";
            }
            else
            {
                customerSelectResponse = new SelectedCustomerResponse();
                customerSelectResponse.Message = "Cliente não encontrado cadastrado na nossa base de dados.";
            }
             
            return customerSelectResponse;
        }


    }
}
