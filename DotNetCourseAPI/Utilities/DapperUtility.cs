using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetCourseAPI.Utilities
{
    public class DapperUtility
    {

        private static string _connectionString = "";
        private IDbConnection _connection;
        private IConfiguration _configuration;
        public DapperUtility(IConfiguration config) 
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection( _connectionString );
           
            
        }

        public IEnumerable<T> GetData<T>(string query) 
        {
            IEnumerable<T> data = null;
            
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("Invalid Query data provided");
            }
            try
            {
               data =  _connection.Query<T>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return data;

        }


        public T GetSingleData<T>(string query)
        {
            T data;
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("Invalid Query data provided");
            }
            try
            {
                data = _connection.QuerySingle<T>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return data;
        }

        public bool ExecuteQuery(string query)
        {
            bool isExecuted = false;
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("Invalid Query data provided");
            }
            try
            {
                isExecuted = _connection.Execute(query) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return isExecuted;
        }

        public int RowsUpdatedFromQueryExecution(string query)
        {
            int rowsUpdated = 0;
           
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("Invalid Query data provided");
            }
            try
            {
                rowsUpdated = _connection.Execute(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return rowsUpdated;
        }
    }
}
