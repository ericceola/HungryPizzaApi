using Dapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Infra.Data.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Infra.Data.Repository
{
    public class CustomerRepository :  ICustomerRepository
    {
        public async Task<int> InsertAsync(Customer customer)
        {

            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                int id = 0;
                string spInsert = "SP_CUSTOMER_INSERT";

                DateTime dateCreate = DateTime.Now;

                var parameters = new { customer.CustomerName, customer.Cpf, customer.ContactPhone };

                id = await connection.ExecuteScalarAsync<int>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return id;

            }
            
        }

        public async Task<Customer> SelectedCustomerAsync(int customerId)
        {

            Customer customer = new Customer();
            
            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                string spConsult = "SP_CUSTOMER_CONSULT_ID";

                var parameters = new { CustomerId = customerId };

                customer = await connection.QuerySingleOrDefaultAsync<Customer>(spConsult, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == ConnectionState.Open) connection.Close();
            }
           
            return customer;
        }

        public Customer CustomerExists(string cpf)
        {

            Customer customer = new Customer();

            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                string spConsult = "SP_CUSTOMER_CONSULT_CPF";

                var parameters = new { Cpf = cpf };

                customer = connection.QuerySingleOrDefault<Customer>(spConsult, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return customer;
        }
    }
}
