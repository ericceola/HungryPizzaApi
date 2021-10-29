using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Validator
{
    public class DateFormatter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime source, ResolutionContext context)
           => source.ToString("dd/MM/yyyy HH:mm");
    }
}
