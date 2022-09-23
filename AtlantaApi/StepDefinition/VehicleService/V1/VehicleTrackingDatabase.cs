using AtlantaApi.Utils;
using ProjectCore.SQL;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SqlClient;
using System.Threading;
using System.Linq;
using System;

namespace AtlantaApi.StepDefinition.VehicleService.V1
{
    class VehicleTrackingDatabase
    {

        private static FluentSqlClient<TrackingDB> _trackingDataSqlClient;
        private static string quoteDataConnectionString;
        private static QueryFactory db;

        public static void ConnectDatabase()
        {
            var sqlHelper = new SqlHelper();
            quoteDataConnectionString = sqlHelper.GetConnectionString("TrackingDb");
            var compiler = new SqliteCompiler();
            var connection = new SqlConnection(quoteDataConnectionString);
            db = new QueryFactory(connection, compiler);

            _trackingDataSqlClient = new FluentSqlClient<TrackingDB>(new DatabaseConnectionFactory(quoteDataConnectionString));

        }

        public static Tuple<TrackingDB> GetTrackingInformation(string requestType)
        {
            Thread.Sleep(5000);
            ConnectDatabase();
            var trackingRecord = db.Query("Tracking").Where("RequestType", requestType).OrderByDesc("DateCreated").Get();
            if (trackingRecord.Count() == 0)
            {
                return null;
            }
            var record = trackingRecord.FirstOrDefault();
            return new Tuple<TrackingDB>(record);
        }
    }
}
