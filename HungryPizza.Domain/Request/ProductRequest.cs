using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HungryPizza.Domain.Request
{
    public class ProductRequest
    {
        public int ProductId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "O nome do Produto é obrigatório")]
        public string ProductName { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "O nome da descrição é obrigatório")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Valor do produto é obrigatório")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string ImageUrl{ get; set; }
    }
}
