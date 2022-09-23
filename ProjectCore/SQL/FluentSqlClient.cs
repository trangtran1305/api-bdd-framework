using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.SQL
{
   public class FluentSqlClient<T> where T : class, new()
    {
        private readonly IDatabaseConnectionFactory _databaseConnection;

        public FluentSqlClient(IDatabaseConnectionFactory databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public async Task<List<T>> Get(Query query)
        {
            
            using (var conn = await _databaseConnection.CreateConnectionAsync())
            {
                conn.Open();
                var db = new QueryFactory(conn, new SqlServerCompiler());
                db.Query(query.ToString());
                var records = await db
                    .FromQuery(query)
                    .GetAsync<T>();

                return records
                    .ToList();
            }
        }

        public async Task<int> Delete(Query query)
        {
            using (var conn = await _databaseConnection.CreateConnectionAsync())
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());

                var count = await db
                    .FromQuery(query)
                    .DeleteAsync();

                return count;
            }
        }

    }
    public class FluentSqlClient
    {
        private readonly IDatabaseConnectionFactory _databaseConnection;

        public FluentSqlClient(IDatabaseConnectionFactory databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<List<dynamic>> Get(Query query)
        {
            using (var conn = await _databaseConnection.CreateConnectionAsync())
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());

                var records = await db
                    .FromQuery(query)
                    .GetAsync();

                return records
                    .ToList();
            }
        }

        public async Task<int> Update(Query query, object data)
        {
            using (var conn = await _databaseConnection.CreateConnectionAsync())
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());

                var updatedCount = await db
                    .FromQuery(query)
                    .UpdateAsync(data);

                return updatedCount;
            }
        }

        public async Task<int> Delete(Query query)
        {
            using (var conn = await _databaseConnection.CreateConnectionAsync())
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());

                var count = await db
                    .FromQuery(query)
                    .DeleteAsync();

                return count;
            }
        }
    }
}
