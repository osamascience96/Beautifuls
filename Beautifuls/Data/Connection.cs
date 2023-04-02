using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Beautifuls.Data
{
    public class Connection
    {
        private string _connectionString;
        private SqlConnection _connection;
        
        public Connection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["beautifulDbConnect"].ConnectionString;
            if(_connection != null)
                _connection= new SqlConnection(_connectionString);
        }

        public void Open()
        {
            if (_connection != null)
                _connection.Open();
        }

        public SqlConnection GetSqlInstance()
        {
            return _connection;
        }

        public void Close()
        {
            if (_connection != null)
                _connection.Close();
        }
    }
}