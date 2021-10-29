using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HungryPizza.Domain.Request
{
    public class SelectedCustomerRequest
    {
       
        [Required(ErrorMessage = "O código do cliente é obrigatório")]
        public int CustomerId { get; set; }

    }
}
