using AtlantaApi.Utils;
using ProjectCore.ApiCore.Common;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace AtlantaApi.StepDefinition.QuoteService
{
    [Binding]
    public class CheckQuoteDataAfterGetANewQuoteSteps : Steps
    {
        private string _quoteRequestBody;
        SpecflowHelper _specflowHelper = new SpecflowHelper();
        private string _prepurchaseRequestBody;
        string _sessionId,_apiVersion,_contextName;
        string _webReference = "";
        [Given(@"User has quote body")]
        public void GivenUerHasQuoteBody(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _quoteRequestBody = paramValues["QuoteRequestBody"];
        }
        
        [When(@"User send a quote request (.*) and (.*)")]
        public void WhenQueryDataInQuoteTable(string apiVersion, string contextName)
        {
            string token = Common.GetToken();
           _sessionId = Common.GetSessionId(token,_quoteRequestBody,apiVersion,contextName);
        }

        [When(@"User update a quote request (.*) and (.*)")]
        public void WhenUserUpdateAQuote(string apiVersion, string contextName)
        {
            string token = Common.GetToken();
            Dictionary<string, string> lstSessionIsWebReference = Common.GetSessionIdAndWebReference(token, _quoteRequestBody, apiVersion, contextName);
             lstSessionIsWebReference.TryGetValue("SessionId",out _sessionId);
             lstSessionIsWebReference.TryGetValue("WebReference",out _webReference);
            var jsonBody = QuoteApiHelperPrepurchase.CreateRequestBodyWithQuoteChange(_quoteRequestBody, _sessionId, _webReference, apiVersion, contextName);
            var requestUtils = new RequestUtils();
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            string url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Quotes);
            string context = serviceInfoAndContext.Item3;

            var header = requestUtils.GetHeader(context, token);
            var response = requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
        }

        [Given(@"User has prepurchase json body")]
        public void GivenUserHasPrepurchaseRequest(Table prepurchaseTable)
        {
            SpecflowHelper specflowHelper = new SpecflowHelper();
            var paramValues = SpecflowHelper.TableToDictionary(prepurchaseTable);
            _prepurchaseRequestBody = paramValues["PrepurchaseRequestBody"];
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User send purchase service")]
        public void WhenUserSendValidPurchaseRequest()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _prepurchaseRequestBody);
            _sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1000);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPara.ResourcePath);
            RequestUtils requestUtils = new RequestUtils();
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
        }
        [Then(@"The PerchaseDetails should have the following values with (.*) and (.*)")]
        public void ThenDataShowedAsync(string path, string value)
        {
             CheckDataInDatabase.VerifyPurchaseDetails(path, value, _sessionId);
        }

        [When(@"User send save payment info service to database")]
        public void WhenUserSendASavePaymentInfoRequest()
        {
            var lstResultObject = new List<ResultObject>();
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _prepurchaseRequestBody);
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _prepurchaseRequestBody, _apiVersion, _contextName);
            _sessionId = lstResultObject[0].SessionId.ToString();
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase( _sessionId, lstPara.ResourcePath);
            List<double> lstPremium = new List<double>();
            lstPremium = PrepurchaseFunctions.GetListPremium(_contextName, jsonBody, lstResultObject);
            double totalAmount = PrepurchaseFunctions.TotalAmountToPay(totalPremiumInQuote, lstPremium);

            jsonBody = jsonBody.Replace("<TotalAmount>", totalAmount.ToString());
            RequestUtils requestUtils = new RequestUtils();
            SpecflowHelper specflowHelper = new SpecflowHelper();

            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
        }
    }
}
