using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HungryPizza.Domain.Request
{
    public class CustomerRequest
    {
        public int CustomerId { get; set; }

        [MinLength(1, ErrorMessage = "O nome do cliente tem que conter no mínimo 1 caracter.")]
        [MaxLength(30, ErrorMessage = "O nome do cliente tem que conter  no máximo 30 caracter.")]
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        public string CustomerName { get; set; }

        [MaxLength(14)]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }

        [MinLength(13, ErrorMessage = "Informe o telefone corretamente.(11)99999-9999")]
        [MaxLength(14, ErrorMessage = "Informe o telefone corretamente. (11)99999-9999")]
        [Required(ErrorMessage = "O Telefone é obrigatório")]
        public string ContactPhone { get; set; }
    }
}
