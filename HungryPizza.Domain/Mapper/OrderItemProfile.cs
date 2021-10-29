using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Response;
using HungryPizza.Domain.Validator;
using System.Collections.Generic;

namespace HungryPizza.Domain.Mapper
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemResponse>()
                .ForMember(d => d.Price, convert => convert.ConvertUsing(new CurrencyFormatter()))
                .ForMember(d => d.UnitPrice, convert => convert.ConvertUsing(new CurrencyFormatter())); 



        }

        
    }
}
