using System;
using MySql.Data.MySqlClient;

namespace ApiNetCoreReact.Context
{
    public class AppDbContext 
    {
        public string ConnectionStrings { get; set; }

        public AppDbContext(string connectionString)
        {
            ConnectionStrings = connectionString;
        }

       
    }
}

