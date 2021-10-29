using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces
{
     public interface ICustomerRepository
    {
        Task<int> InsertAsync(Customer customer);
        Task<Customer> SelectedCustomerAsync(int customerId);
        Customer CustomerExists(string cpf);
    }
}
