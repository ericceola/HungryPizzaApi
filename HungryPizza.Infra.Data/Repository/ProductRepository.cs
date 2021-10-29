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
    public class ProductRepository : IProductRepository
    {
        public async Task<int> InsertAsync(Product product)
        {
           
            using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
            {
                connection.Open();

                int id = 0;
                string spInsert = "SP_PRODUCT_INSERT";

                DateTime dateCreate = DateTime.Now;

                var parameters = new { product.ProductName, product.ProductDescription, product.Price, product.ImageUrl };

                id = await connection.ExecuteScalarAsync<int>(spInsert, parameters, commandType: CommandType.StoredProcedure);
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                return id;

            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {

            IEnumerable<Product> productList = new List<Product>();
            try
            {
                using (var connection = new SqlConnection(DBConfiguration.ConnectionString))
                {
                    connection.Open();

                    string spConsult = "SP_PRODUCT_LIST_CONSULT";

                    productList = await connection.QueryAsync<Product>(spConsult, commandType: CommandType.StoredProcedure);
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return productList;
        }
    }
}
