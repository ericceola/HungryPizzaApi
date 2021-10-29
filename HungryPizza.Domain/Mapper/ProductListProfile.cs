using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using HungryPizza.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Mapper
{
    public class ProductListProfile : Profile
    {
        public ProductListProfile()
        {
            CreateMap<Product, ProductListResponse>()
            .ForMember(d => d.Price, convert => convert.ConvertUsing(new CurrencyFormatter()));
        }
    }
}
