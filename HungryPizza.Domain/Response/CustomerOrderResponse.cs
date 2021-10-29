using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Response
{
    public class CustomerOrderResponse
    {
        public int OrderId { get; set; }

        public IEnumerable<OrderItemResponse> OrderItens { get; set; }

        public string Amount { get; set; }

        public string DateOrder { get; set; }
     
        public List<string> Message { get; set; }
    }

    public class OrderItemResponse
    {
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }
}
