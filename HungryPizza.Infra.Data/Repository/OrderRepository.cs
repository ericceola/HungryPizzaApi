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
    public class OrderRepository : IOrderRepository
    {
        public async Task<int> InsertAsync(CustomerOrder order)
        {
            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                int id = 0;
                string spInsert = "SP_CUSTOMER_INSERT";

                var parameters = new { order.CustomerId, order.CustomerName, order.Street, order.Number, 
                                       order.Complement, order.District, order.City, order.RegionState, order.ZipCode,
                                       order.ContactPhone, order.DateOrder};

                id = await connection.ExecuteScalarAsync<int>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return id;
            }
        }

      

    }
}
