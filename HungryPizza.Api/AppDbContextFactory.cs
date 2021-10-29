using HungryPizza.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Api
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<MySqlContext>
    {
        public MySqlContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            // Criando o DbContextOptionsBuilder manualmente
            var builder = new DbContextOptionsBuilder<MySqlContext>();
            // cria a connection string. 
            // requer a connectionstring no appsettings.json
            var connectionString = "Server=127.0.0.1;Port=3306;Database=hungrypizzadb;Uid=admin;Pwd=Hungy@01;charset=utf8;";
            builder.UseMySql(connectionString);

            // Cria o contexto
            return new MySqlContext(builder.Options);
        }
    }
}