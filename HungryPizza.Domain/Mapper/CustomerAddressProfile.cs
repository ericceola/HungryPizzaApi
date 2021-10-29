using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Mapper
{
    public class CustomerAddressProfile : Profile
    {
        public CustomerAddressProfile()
        {

            CreateMap<CustomerAddressRequest, CustomerAddress>();
           

        }
    }
}
