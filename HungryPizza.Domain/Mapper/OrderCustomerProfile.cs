using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Request;
using HungryPizza.Domain.Response;
using HungryPizza.Domain.Validator;

namespace HungryPizza.Domain.Mapper
{
    public class OrderCustomerProfile : Profile
    {
        public OrderCustomerProfile()
        {
            CreateMap<CustomerOrderRequest, CustomerOrder>();
            CreateMap<CustomerOrder, CustomerOrderResponse>()
            .ForMember(d => d.Amount, convert => convert.ConvertUsing(new CurrencyFormatter()))
            .ForMember(d => d.DateOrder, convert => convert.ConvertUsing(new DateFormatter()));

        }
    }
}
