using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Response
{
    public class ProductListResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        public string Price { get; set; }

        public string ImageUrl { get; set; }

        public bool InStock { get; set; }
    }
}
