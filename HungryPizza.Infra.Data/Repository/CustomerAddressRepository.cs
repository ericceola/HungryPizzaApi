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
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        public async Task<int> InsertAsync(CustomerAddress CustomerAddress)
        {
            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                int id = 0;
                string spInsert = "SP_CUSTOMER_ADDRESS_INSERT";

                var parameters = new { CustomerAddress.CustomerId, CustomerAddress.Street, CustomerAddress.Number, CustomerAddress.Complement, CustomerAddress.District, CustomerAddress.City, CustomerAddress.RegionState, CustomerAddress.ZipCode, CustomerAddress.Surname  };

                id = await connection.ExecuteScalarAsync<int>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return id;
            }
        }

        public CustomerAddress CustomerAddressExists(int customerId)
        {

            CustomerAddress customerAddress = new CustomerAddress();

            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                string spConsult = "SP_CUSTOMER_CONSULT_ADDRESS_CUSTOMERID";

                var parameters = new { CustomerId = customerId };

                customerAddress = connection.QuerySingleOrDefault<CustomerAddress>(spConsult, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return customerAddress;
        }
    }
}
