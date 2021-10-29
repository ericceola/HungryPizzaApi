using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HungryPizza.Domain.Request
{
    public class CustomerAddressRequest
    {
        public long CustomerAddressId { get; set; }

        public int CustomerId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O nome da rua é obrigatório")]
        public string Street { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "O número é obrigatório")]
        public string Number { get; set; }

        [MaxLength(50)]
        public string Complement { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "O nome do bairro é obrigatório")]
        public string District { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "O nome da cidade é obrigatório")]
        public string City { get; set; }

        [MaxLength(2)]
        [Required(ErrorMessage = "O nome da UF é obrigatório")]
        public string RegionState { get; set; }

        [MaxLength(9)]
        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string ZipCode { get; set; }

        [MaxLength(15)]
        public string Surname { get; set; }
    }
}
