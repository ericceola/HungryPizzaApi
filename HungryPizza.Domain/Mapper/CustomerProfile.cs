using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
          
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer, SelectedCustomerResponse>();

        }
    }
}
