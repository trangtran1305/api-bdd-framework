using Newtonsoft.Json.Linq;
using ProjectCore.SQL;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Linq;
using System.Data.SqlClient;
using Xunit;
using TechTalk.SpecFlow;
using SqlKata.Execution;
using System.Threading;

namespace AtlantaApi.StepDefinition.QuoteService
{
    public class CheckDataInDatabase
    {
        private static string quoteDataConnectionString;
        private static SqlKata.Execution.QueryFactory db;
        public static void ConnectDatabase(string tableName)
        {
            var sqlHelper = new SqlHelper();
            quoteDataConnectionString = sqlHelper.GetConnectionString(tableName);
            var compiler = new SqliteCompiler();
            var connection = new SqlConnection(quoteDataConnectionString);
            db = new QueryFactory(connection, compiler);
        }

        public static JObject GetInformationFromDb(string sessionId)
        {
            Thread.Sleep(5000);
            ConnectDatabase("QuoteDb");
            var recordQuote = db.Query("Quote").Where("SessionId", sessionId).Get();

            if (recordQuote.Count() == 0)
            {
                Console.WriteLine("No record found in database.");
                return null;
            }
            var record = recordQuote.FirstOrDefault();
            var quoteInformation = record.PurchaseDetails;
            var jsonObjectquoteInformation = JObject.Parse(quoteInformation);
            return jsonObjectquoteInformation;
        }

        public static string GetWebReferenceFromDb(string tableName,string dateCreated)
        {
            Thread.Sleep(5000);
            ConnectDatabase(tableName);
            var recordQuote = db.Query("Quote").WhereLike("QuoteRequest", "%EC2N 4AY%").WhereLike("QuoteRequest", "%1970-01-01%").Get();

            if (recordQuote.Count() == 0)
            {
                Console.WriteLine("No record found in database.");
                return null;
            }
            var record = recordQuote.First();
            return record.WebReference;
        }
        public static void VerifyPurchaseDetails(string path, string value,string sessionId)
        {
            var responseQuote = GetInformationFromDb(sessionId);

            var getDebitValue = responseQuote.SelectToken("$..Debit");
            var getPaymentInfoValue = responseQuote.SelectToken("$..PaymentInfo");
            var getMarketingInfoValue = responseQuote.SelectToken("$..MarketingInfo");

            if (String.IsNullOrEmpty(path) && value.Equals("null"))
            {
                Assert.True(getDebitValue!=null);
                Assert.True(getPaymentInfoValue != null);
                Assert.True(getMarketingInfoValue != null);
            }
            else if (path.Contains("MarketingInfo"))
            {
                var getSessionId = getMarketingInfoValue.SelectToken("$...SessionId");
                Assert.Equal(getSessionId, sessionId);
            }
            else if (path.Contains("PaymenInfo"))
            {
                var getSessionId = getPaymentInfoValue.SelectToken("$...SessionId");
                Assert.Equal(getSessionId, sessionId);
            }
            else if (path.Contains("Debit"))
            {
                var getSessionId = getDebitValue.SelectToken("$...SessionId");
                Assert.Equal(getSessionId, sessionId);
            }

      }

    }

}
