using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Infra.Data.Configuration
{
    public static class DBConfiguration
    {
        public static string ConnectionString { get; set; }

        public static void PathDbMdf(bool active)
        {
            if (active)
            {
                string path = Environment.CurrentDirectory;
                string newPath = path.Replace("HungryPizza.Api", "HungryPizza.Infra.Data\\DB");
              
                AppDomain.CurrentDomain.SetData("DataDirectory", newPath);
            }
        }
    }
}
