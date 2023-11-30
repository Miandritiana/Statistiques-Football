using System;
using System.Data;
using System.Data.SqlClient;

namespace StatistiqueFoot.Models
{
    public class Connexion 
    {
        public SqlConnection connection;

        public Connexion()
        {
            string connectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=foot;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection connexion
        {
            get { return connection; }
            set { connection = value; }
        }
    }
}
