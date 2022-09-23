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
    class VehicleDVLADatabase
    {
        private static FluentSqlClient<DVLADatabase> _quoteDataSqlClient;
        private static string quoteDataConnectionString;
        private static QueryFactory db;

        public static void ConnectDatabase()
        {
            var sqlHelper = new SqlHelper();
            quoteDataConnectionString = sqlHelper.GetConnectionString("UIDVLADb");
            var compiler = new SqliteCompiler();
            var connection = new SqlConnection(quoteDataConnectionString);
            db = new QueryFactory(connection, compiler);

            _quoteDataSqlClient = new FluentSqlClient<DVLADatabase>(new DatabaseConnectionFactory(quoteDataConnectionString));

        }

        public static Tuple<string, string, string, string, string> GetDVLAInfoFromDatabase(string registrationNumber)
        {
            Thread.Sleep(5000);
            ConnectDatabase();
            registrationNumber = registrationNumber.Replace(" ", "");
            var dvlaRecord = db.Query("Vehicle").Where("RegistrationNumber", registrationNumber).Get();
            if (dvlaRecord.Count() == 0) { 
                return null;
            }
            var record = dvlaRecord.FirstOrDefault();
            return new Tuple<string, string, string, string, string>(record.Make, record.Model, record.Engine, record.FromToYear, record.Type);
        }

        public static void UpdateExpiresDateTime(string registrationNumber)
        {
            Thread.Sleep(5000);
            ConnectDatabase();
            var updateDVLA = db.Query("Vehicle").Where("RegistrationNumber", registrationNumber).Update(new
            {
                ExpiresDateTime = DateTime.Today.AddDays(2)
            });

        }

        public static void DecreaseExpiresDateTime(string registrationNumber)
        {
            Thread.Sleep(5000);
            ConnectDatabase();
            var updateDVLA = db.Query("Vehicle").Where("RegistrationNumber", registrationNumber).Update(new
            {
                ExpiresDateTime = DateTime.Today.AddDays(-1)
            });

        }

        public static void DeleteRecordOnRequestLog(string ipAddress)
        {
            Thread.Sleep(5000);
            ConnectDatabase();
            var deleteRequestLog = db.Query("RequestLog").Where("IpAddress", ipAddress).Delete();
        }

        public static dynamic GetRequestLogRecord(string registrationNumber)
        {
            Thread.Sleep(5000);
            ConnectDatabase();
            var dvlaRecord = db.Query("RequestLog").Where("RegNumber", registrationNumber).Get();
            if (dvlaRecord.Count() == 0)
            {
                return null;
            }
            return dvlaRecord;
        }


    }
}
