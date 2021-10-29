using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Domain.Entities
{
    public class Product
    {
       
        public int ProductId { get; set; }
    
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
      
        public string ImageUrl { get; set; }

        public bool InStock { get; set; }

        
    }
}
