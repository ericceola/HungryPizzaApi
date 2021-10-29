using AutoMapper;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Interfaces.IService;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HungryPizza.Domain.Validator;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.IRepository;
using System.Transactions;
using System.Globalization;

namespace HungryPizza.Service.Service
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly IMapper _mapper;

        public CustomerOrderService(IMapper mapper, ICustomerRepository customerRepository, ICustomerAddressRepository customerAddressRepository, IOrderItemRepository orderItemRepository, ICustomerOrderRepository customerOrderRepository)
        {
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _orderItemRepository = orderItemRepository;
            _customerOrderRepository = customerOrderRepository;
            _mapper = mapper;
        }

        public async Task<CustomerOrderResponse> CustomerOrderRegister(CustomerOrderRequest customerOrderRequest)
        {
            
            CustomerOrderResponse customerOrderResponse = new CustomerOrderResponse();
            customerOrderResponse.OrderItens = new List<OrderItemResponse>();
            List<OrderItem> orderItemList = new List<OrderItem>();
            customerOrderResponse.Message = new List<string>();
            CustomerOrderRequestValidator validator = new CustomerOrderRequestValidator();
             

            var results = validator.Validate(customerOrderRequest);

            if (!results.IsValid)
            {
                
                foreach (var message in results.Errors)
                {
                    customerOrderResponse.Message.Add(message.ErrorMessage); 
                }

                return customerOrderResponse;
            }

            if (customerOrderRequest.CustomerId != null && customerOrderRequest.CustomerId != 0)
            {
               var cliente = await _customerRepository.SelectedCustomerAsync(customerOrderRequest.CustomerId.Value);

                if(cliente != null)
                {
                    customerOrderRequest.CustomerName = cliente.CustomerName;
                    customerOrderRequest.ContactPhone = cliente.ContactPhone;
                    var customerAddress = _customerAddressRepository.CustomerAddressExists(customerOrderRequest.CustomerId.Value);
                        
                    if(customerAddress != null)
                    {
                        customerOrderRequest.Street = customerAddress.Street;
                        customerOrderRequest.Number = customerAddress.Number;
                        customerOrderRequest.Complement = customerAddress.Complement;
                        customerOrderRequest.District = customerAddress.District;
                        customerOrderRequest.City = customerAddress.City;
                        customerOrderRequest.RegionState = customerAddress.RegionState;
                        customerOrderRequest.ZipCode = customerAddress.ZipCode;
                    }
                    else
                    {
                        customerOrderResponse.Message.Add("O endereço do cliente não encontrado.");
                        return customerOrderResponse;
                    }
                }
                else
                {
                    customerOrderResponse.Message.Add("O cliente não encontrado.");
                    return customerOrderResponse;
                }
            }
            
            foreach (var item in customerOrderRequest.OrderItens)
            {
                
                var orderItem = await _orderItemRepository.SelectAsync(item.ProductId, item.HalfProductId??0, item.Quantity);

                if (orderItem != null)
                {
                    orderItemList.Add(orderItem);

                    if (!orderItem.InStock)
                    {
                        customerOrderResponse.Message.Add(orderItem.ProductName);
                    }
                }
                else
                {
                     customerOrderResponse.Message.Add("Produto não encontrado.");
                    return customerOrderResponse;
                }

            }

            if(orderItemList.Where(p => p.InStock == false).Count() > 0)
            {
                return customerOrderResponse;
            }
           

            decimal amount  = orderItemList.Sum(p => p.Price);

            CustomerOrder customerOrder = _mapper.Map<CustomerOrder>(customerOrderRequest);

            customerOrder.Amount = amount;
            customerOrder.DateOrder = DateTime.Now;
            customerOrderResponse.Amount = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", customerOrder.Amount);
            customerOrderResponse.DateOrder = customerOrder.DateOrder.ToString("dd/MM/yyyy HH:mm");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                customerOrderResponse.OrderId = await _customerOrderRepository.InsertAsync(customerOrder);


                foreach (var orderItem in orderItemList)
                {
                    orderItem.OrderId = customerOrderResponse.OrderId;

                    await _orderItemRepository.InsertAsync(orderItem);

                }

                scope.Complete();
            }


            var ordemItemList = await _orderItemRepository.SelectAllAsync(customerOrderResponse.OrderId);

            customerOrderResponse.OrderItens = _mapper.Map<IEnumerable<OrderItem>,IEnumerable <OrderItemResponse>>(ordemItemList);

            customerOrderResponse.Message.Add("O seu pedido esta sendo preparado e logo sairá para entrega.");


            return customerOrderResponse;
        }

        public async Task<List<CustomerOrderResponse>> CustomerOrderList(int customerId, int pageNumber, int pageSize)
        {
            List<CustomerOrderResponse> customerOrderList = new List<CustomerOrderResponse>();
           
            var customerOrders = await _customerOrderRepository.SelectAllAsync(customerId, pageNumber, pageSize);

            foreach(var customerOrder in customerOrders)
            {
                var ordemItemList = await _orderItemRepository.SelectAllAsync(customerOrder.OrderId);
                var customerOrderResponse = _mapper.Map<CustomerOrderResponse>(customerOrder);

                customerOrderResponse.OrderItens = _mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemResponse>>(ordemItemList);
                customerOrderList.Add(customerOrderResponse);

            }
            return customerOrderList;
        }

    }
}
