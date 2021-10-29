using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Entities
{
    public  class ProductItem
    {
        public int ProductId { get; set; }
        public int HalfProductId { get; set; }
        public int Quantity { get; set; }
    }
}
