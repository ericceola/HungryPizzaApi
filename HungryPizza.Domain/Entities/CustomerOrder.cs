using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Domain.Entities
{
    public class CustomerOrder
    {
        
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        public string CustomerName {get;set;}

        public decimal Amount { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string RegionState { get; set; }

        public string ZipCode { get; set; }

        public string ContactPhone { get; set; }

        public DateTime DateOrder { get; set; }

    }
}
