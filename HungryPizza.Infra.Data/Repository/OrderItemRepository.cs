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
    public class OrderItemRepository : IOrderItemRepository
    {
        

        public async Task<OrderItem> SelectAsync(int productId, int? halfProductId, int quantity)
        {  
            
          
            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

             
                string spInsert = "SP_PRODUCT_ORDER_ITEM";

                var parameters = new
                {
                    productId,
                    halfProductId,
                    quantity

                };

                var orderItem = await connection.QuerySingleOrDefaultAsync<OrderItem>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return orderItem;
            }
        }

        public async Task<IEnumerable<OrderItem>> SelectAllAsync(int orderId)
        {


            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();


                string spInsert = "SP_PRODUCT_ORDER_ITEM_LIST";

                var parameters = new
                {
                    orderId
                };

                var orderItemLinst = await connection.QueryAsync<OrderItem>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return orderItemLinst;
            }
        }

        public async Task<int> InsertAsync(OrderItem orderItem)
        {

            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                int id = 0;
                string spInsert = "SP_ORDER_ITEM_INSERT";

                DateTime dateCreate = DateTime.Now;

                var parameters = new { orderItem.OrderId, orderItem.ProductName, orderItem.UnitPrice, orderItem.Quantity, orderItem.Price };

                id = await connection.ExecuteScalarAsync<int>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return id;

            }

        }
    }
}
