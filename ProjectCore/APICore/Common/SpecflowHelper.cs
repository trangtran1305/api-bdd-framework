using ProjectCore.Configurations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ProjectCore.ApiCore.Common
{
   public class SpecflowHelper
    {
        public TestConfigs _configs = new TestConfigs();
        public static Dictionary<string, string> TableToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static string[] toArray(Table table)
        {
            string[] array = new string[table.RowCount + 1];
            int i = 0;
            foreach (var row in table.Rows)
            {
                array[i] = row[1];
                i++;
            }
            return array;
        }

        public static string QuickFormatString(String source, Table table)
        {
            string[] parameters = toArray(table);
            return String.Format(source, parameters);
        }
        public string GetUrl(Table table)
        {
            Dictionary<string, string> paramValues = SpecflowHelper.TableToDictionary(table);
            return  _configs.GlobalConfig.APISetting.APIBaseUrl+ paramValues["Uri"];
        }
        public string GetUrlByString(string uri)
        {
            var baseUrl  = _configs.GlobalConfig.APISetting.APIBaseUrl;
            var url = _configs.GlobalConfig.APISetting.APIBaseUrl + uri;
            if (!baseUrl.Contains("qa") && !baseUrl.Contains("stg"))
            {
                url = _configs.GlobalConfig.APISetting.APIBaseUrl + uri.Replace("|", "-");
            }
            return url;
        }
        public string GetContextFromConfig(string inputContextName)
        {
            Context contextResult = new Context();
            contextResult = _configs.GlobalConfig.APISetting.ContextList.Where(context => context.ContextName.Equals(inputContextName)).FirstOrDefault<Context>();
            return contextResult.Value;
        }
        public string GetBaseUrlFromConfig(string inputContextName)
        {
            Context contextResult = new Context();
            contextResult = _configs.GlobalConfig.APISetting.ContextList.Where(context => context.ContextName.Equals(inputContextName)).FirstOrDefault<Context>();
            return contextResult.BaseUrl;
        }
        public static DataTable ToDataTable(Table table)
        {
            var dataTable = new DataTable();
            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {
                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }
    }
}
