using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HungryPizza.Domain.Request
{
    public  class CustomerOrderRequest
    {

        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }
    
        public string Street { get; set; }
     
        public string Number { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string RegionState { get; set; }

        public string ZipCode { get; set; }

        public string ContactPhone { get; set; }

        public List<OrderItemRequest> OrderItens { get; set; }


    }
    public class OrderItemRequest
    {
       
        public int ProductId { get; set; }
        public int? HalfProductId { get; set; }
        public int Quantity { get; set; }
        

    }
}
