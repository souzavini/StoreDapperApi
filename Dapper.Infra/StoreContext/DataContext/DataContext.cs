using System;
using System.Data;
using Dapper;
using MySqlConnector;

namespace Dapper.Infra.StoreContext.DataContext
{
    public class DataContext : IDisposable
    {
        public MySqlConnection Connection { get; set; }

        public DataContext()
        {
            Connection = new MySqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}