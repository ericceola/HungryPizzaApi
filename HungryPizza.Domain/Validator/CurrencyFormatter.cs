using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Validator
{
    public class CurrencyFormatter : IValueConverter<decimal, string>
    {
        public string Convert(decimal source, ResolutionContext context)
            => source.ToString("c");
    }
}
