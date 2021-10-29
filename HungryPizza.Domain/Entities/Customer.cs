using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Domain.Entities
{
    public class Customer 
    {
        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Cpf { get; set; }
        public string ContactPhone { get; set; }
    }
}
