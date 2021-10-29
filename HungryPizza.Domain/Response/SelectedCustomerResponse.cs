using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Response
{
    public class SelectedCustomerResponse
    {
        public string CustomerName { get; set; }
        public string Cpf { get; set; }
        public string ContactPhone { get; set; }

        public string Message { get; set; }
    }

}
