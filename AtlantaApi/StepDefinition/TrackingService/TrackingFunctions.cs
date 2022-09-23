using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using TechTalk.SpecFlow;

namespace AtlantaApi.StepDefinition.TrackingService
{
    public class TrackingFunctions
    {
        public string CreateURL(string url, List<string> lsParamName, List<string> lsParamValue)
        {
            var uriBuilder = new UriBuilder(url);
            var paramsValues = HttpUtility.ParseQueryString(uriBuilder.Query);
            for (int i = 0; i < lsParamName.Count; i++)
            {
                if (lsParamName[i] == "brd")
                {
                    DateTime date = Convert.ToDateTime(lsParamValue[i]);
                    lsParamValue[i] = date.ToString("dd/MM/yyyy");
                }
                paramsValues.Add(lsParamName[i], lsParamValue[i]);
            }
            uriBuilder.Query = paramsValues.ToString();
            return uriBuilder.Uri.ToString();
        }

        public void CreateQuoteBodyWithExternalParams(Table table)
        {
            var lsParams = SpecflowHelper.ToDataTable(table);

        }
    }
}
