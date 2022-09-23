using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjectCore.SQL
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;

        public DatabaseConnectionFactory(
            string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                return null;
            }

            var sqlConnection =  new SqlConnection(_connectionString);
            return sqlConnection;
        }
    }
}