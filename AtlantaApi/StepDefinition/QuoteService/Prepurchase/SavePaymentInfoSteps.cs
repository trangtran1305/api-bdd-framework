using AtlantaApi.Utils;
using Newtonsoft.Json;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.QuoteService.Prepurchase
{
    [Binding]
    public class SavePaymentInfoSteps : Steps
    {
        RequestUtils requestUtils = new RequestUtils();
        private int _actualStatusCode = 0;
        private bool _actualIsSuccess;
        private string _actualMessages, _savePaymentInfoRequestBody, _quoteRequestBody;
        private string _apiVersion, _contextName;

        [Given(@"User has Save Payment Info body")]
        public void GivenUserHasSavePaymentInfoRequest(Table saveDebitTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(saveDebitTable);
            _savePaymentInfoRequestBody = paramValues["SavePaymentInfoRequestBody"];
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"User send Save Payment Info Normal Case")]
        public void WhenUserSendSavePaymentInfoRequest()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            var lstResultObject = new List<ResultObject>();
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1000);
            string sessionId = lstResultObject[0].SessionId.ToString();
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;

            string jsonBody = SavePaymentInfoFunctions.SetupRequestForSavePaymentInfoNormalCase(_contextName, lstPara, sessionId, lstResultObject,totalPremiumInQuote);
            Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }

        [When(@"User send Save Payment Info with old sessionId")]
        public void WhenUserSendSavePaymentInfoRequestWithOldSessionId()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            var lstResultObjectOld = new List<ResultObject>();
            lstResultObjectOld = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            var lstResultObjectNew = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            //Thread.Sleep(2000);
            string sessionId = lstResultObjectOld[0].SessionId.ToString();
            double totalPremiumInQuote = lstResultObjectNew[0].TotalPremium;

            string jsonBody = SavePaymentInfoFunctions.SetupRequestForSavePaymentInfoNormalCase(_contextName, lstPara, sessionId, lstResultObjectNew, totalPremiumInQuote);
            //Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }
        [When(@"User send Save Payment Info request")]
        public void WhenUserSendSavePaymentInfoRequest(Table table)
        {
            var lstResultObject = new List<ResultObject>();
            List<double> lstPremium = new List<double>();

            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            string sessionId = lstResultObject[0].SessionId.ToString();
            Thread.Sleep(1000);
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            var jsonBody = PrepurchaseFunctions.CreateRequestBody(_savePaymentInfoRequestBody, table, sessionId, _apiVersion, _contextName);
            lstPremium = PrepurchaseFunctions.GetListPremium(_contextName, jsonBody, lstResultObject);
            double totalAmount = PrepurchaseFunctions.TotalAmountToPay(totalPremiumInQuote, lstPremium);

            jsonBody = jsonBody.Replace("<TotalAmount>", totalAmount.ToString());
            Thread.Sleep(1000);

            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }
        
        [Then(@"Save Payment Info response returns (.*) and (.*) and (.*)")]
        public void ThenTheResponseReturnsAnd(int expectedStatusCode, bool expectedIsSuccess, string expectedMessage)
        {
            expectedMessage = expectedMessage.Replace(".", "").Replace(",", "").ToLower();
            _actualMessages = _actualMessages.Replace(".", "").Replace(",", "").ToLower();

            Assert.Equal(expectedMessage, _actualMessages);
            Assert.Equal(expectedStatusCode, _actualStatusCode);
        }
        [When(@"User send Save Payment Info request with (.*)")]
        public void WhenUserSendSavePaymentInfoRequestWith(string input)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            var lstResultObject = new List<ResultObject>();
            string sessionId = "";
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            Thread.Sleep(2000);
            if (input.ToLower().Equals("valid"))
            {
                sessionId = lstResultObject[0].SessionId.ToString();
            }
            else if (input.ToLower().Equals("old"))
            {
                var lstResultObjectNew = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
                sessionId = lstResultObject[0].SessionId.ToString();
            }
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;

            string jsonBody = SavePaymentInfoFunctions.SetupRequestForSavePaymentInfoNormalCase(_contextName,  lstPara, sessionId, lstResultObject, totalPremiumInQuote);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }

    }
}
