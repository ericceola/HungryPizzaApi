using Dapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Interfaces.IRepository;
using HungryPizza.Infra.Data.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;


namespace HungryPizza.Infra.Data.Repository
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        public async Task<int> InsertAsync(CustomerOrder customerOrder)
        {
            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                int id = 0;
                string spInsert = "SP_CUSTOMER_ORDER_INSERT";

                var parameters = new {
                    CustomerId = customerOrder.CustomerId,
                    CustomerName =  customerOrder.CustomerName,
                    Amount = customerOrder.Amount,
                    Street = customerOrder.Street,
                    Number = customerOrder.Number,
                    Complement = customerOrder.Complement,
                    District = customerOrder.District,
                    City = customerOrder.City,
                    RegionState = customerOrder.RegionState,
                    ZipCode = customerOrder.ZipCode,
                    ContactPhone = customerOrder.ContactPhone,
                    DateOrder = customerOrder.DateOrder
                };

                id = await connection.ExecuteScalarAsync<int>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return id;
            }
        }

        public async Task<IEnumerable<CustomerOrder>> SelectAllAsync(int customerId, int pageNumber, int pageSize)
        {


            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();


                string spInsert = "SP_ORDER_LIST";

                var parameters = new
                {
                    customerId,
                    pageNumber,
                    pageSize,
                };

                var orderItemLinst = await connection.QueryAsync<CustomerOrder>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return orderItemLinst;
            }
        }
    }


}
