using AtlantaApi.StepDefinition.QuoteService;
using AtlantaApi.Utils;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace AtlantaApi.StepDefinition.PaymentService
{
    [Binding]
    public class PaymentSteps : Steps
    {
        SpecflowHelper _specflowHelper = new SpecflowHelper();
        private RequestUtils _requestUtils = new RequestUtils();
        private int _actualStatusCode;
        private string _uri, _sessionId="",_webReference="",_url;
        private string _apiVersion, _contextName, _actualMessages;
        private string _quoteRequestBody, _registerPaymentRequestBody, _saveMarketingRequestBody, _saveDebitRequestBody,_savePaymentInfoRequestBody, _webHookBody;
        Tuple<string, System.Net.HttpStatusCode> _paymentResponse,_webHookResponse, _responseSaveMarketing, _responseSavePaymentInfo;
        [Given(@"User has payment body")]
        public void GivenUserHasRegisterPaymentRequest(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _registerPaymentRequestBody = paramValues["PaymentRequestBody"];
            _saveMarketingRequestBody = paramValues["SaveMarketingRequestBody"];
            _saveDebitRequestBody = paramValues["SaveDebitRequestBody"];
            _savePaymentInfoRequestBody = paramValues["SavePaymentInfoRequestBody"];

            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [Given(@"I have wrapUp table")]
        public void GivenUserHasPaymentOutcomeRequest(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _registerPaymentRequestBody = paramValues["PaymentRequestBody"];
            _saveMarketingRequestBody = paramValues["SaveMarketingRequestBody"];
            _saveDebitRequestBody = paramValues["SaveDebitRequestBody"];
            _savePaymentInfoRequestBody = paramValues["SavePaymentInfoRequestBody"];
            _webHookBody = paramValues["WebHookBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
            _uri = paramValues["Uri"].Replace("//", "|");
            //Thread.Sleep(3000);

        }
        

        [When(@"User send a Register PayInFull Payment service")]
        public void WhenUserSendARegisterPayInFullPaymentRequest()
        {
            // send  save payment infor request
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            var  lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1500);
            _sessionId = lstResultObject[0].SessionId.ToString();
            _webReference = lstResultObject[0].WebReference.ToString();
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            Thread.Sleep(3000);
            string jsonBodySavePaymentInfo = SavePaymentInfoFunctions.SetupRequestForSavePaymentInfoNormalCase(_contextName,lstPara, _sessionId, lstResultObject, totalPremiumInQuote);
            _responseSavePaymentInfo = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBodySavePaymentInfo, lstPara.Header);
            //send save marketing request
            ParametersForRequest lstPatameterSaveMarketing = Common.GetParametersForRequest(_apiVersion, _contextName, _saveMarketingRequestBody);
            string urlSaveMarketing = PrepurchaseFunctions.GetURL(_saveMarketingRequestBody, _apiVersion, _contextName);
            var jsonBodySaveMarketing = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterSaveMarketing.ResourcePath);
            Thread.Sleep(1500);
            _responseSaveMarketing = _requestUtils.SendRequest(HttpMethod.Post, urlSaveMarketing, jsonBodySaveMarketing, lstPatameterSaveMarketing.Header);
            //send register payment request
            ParametersForRequest lstPatameterRegisterPayment = Common.GetParametersForRequest(_apiVersion, _contextName, _registerPaymentRequestBody);
            string resourcePath = lstPatameterRegisterPayment.ResourcePath;
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterRegisterPayment.ResourcePath);
            Thread.Sleep(1500);
            _paymentResponse = _requestUtils.SendRequest(HttpMethod.Post, lstPatameterRegisterPayment.Url, jsonBody, lstPatameterRegisterPayment.Header);
            Thread.Sleep(1000);
             _actualStatusCode = (int)_paymentResponse.Item2;
            if (_actualStatusCode == 204)
            {
                _actualMessages = _paymentResponse.Item2.ToString();
            }
            else
                _actualMessages = ResponseUtils.GetResponseMessage(_paymentResponse);

        }

        [When(@"User send a Register Instalments Payment service")]
        public void WhenUserSendARegisterInstalmentsPaymtRequest()
        {
            // send  save payment infor request
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            var lstResultObject = new List<ResultObject>();
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1000);
            _sessionId = lstResultObject[0].SessionId.ToString();
            _webReference = lstResultObject[0].WebReference.ToString();
            double totalDepositInQuote = lstResultObject[0].TotalDeposit;
            Thread.Sleep(1000);
            string jsonBodySavePaymentInfo = SavePaymentInfoFunctions.SetupRequestForSavePaymentInfoInstalment(_contextName, lstPara, _sessionId, lstResultObject, totalDepositInQuote);
            _responseSavePaymentInfo = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBodySavePaymentInfo, lstPara.Header);
            //send save marketing request
            ParametersForRequest lstPatameterSaveMarketing = Common.GetParametersForRequest(_apiVersion, _contextName, _saveMarketingRequestBody);
            //string urlSaveMarketing = PrepurchaseFunctions.GetURL(_saveMarketingRequestBody, _apiVersion, _contextName);
            var jsonBodySaveMarketing = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterSaveMarketing.ResourcePath);
            _responseSaveMarketing = _requestUtils.SendRequest(HttpMethod.Post, lstPatameterSaveMarketing.Url, jsonBodySaveMarketing, lstPatameterSaveMarketing.Header);
            //send save direct debit request (for monthly payment method only)
            ParametersForRequest lstPatameterSaveDebit = Common.GetParametersForRequest(_apiVersion, _contextName, _saveDebitRequestBody);
            //string urlSaveDebit = PrepurchaseFunctions.GetURL(_saveDebitRequestBody, _apiVersion, _contextName);
            var jsonBodySaveDebit = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterSaveDebit.ResourcePath);
            var _responseSaveDebit = _requestUtils.SendRequest(HttpMethod.Post, lstPatameterSaveDebit.Url, jsonBodySaveDebit, lstPatameterSaveDebit.Header);


            //send register payment request
            ParametersForRequest lstPatameterRegisterPayment = Common.GetParametersForRequest(_apiVersion, _contextName, _registerPaymentRequestBody);
            string resourcePath = lstPatameterRegisterPayment.ResourcePath;
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterRegisterPayment.ResourcePath);
            Thread.Sleep(1000);
            _paymentResponse = _requestUtils.SendRequest(HttpMethod.Post, lstPatameterRegisterPayment.Url, jsonBody, lstPatameterRegisterPayment.Header);
            Thread.Sleep(2000);
            _actualStatusCode = (int)_paymentResponse.Item2;
            if (_actualStatusCode == 204)
            {
                _actualMessages = _paymentResponse.Item2.ToString();
            }
            else
                _actualMessages = ResponseUtils.GetResponseMessage(_paymentResponse);

        }

        [When(@"User send a Register Payment service request with data change")]
        public void WhenUserSendARegisterPaymentRequestValidation(Table table)
        {
            // send  save payment infor request
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _savePaymentInfoRequestBody);
            var lstResultObject = new List<ResultObject>();
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion, _contextName);
            Thread.Sleep(2000);
            _sessionId = lstResultObject[0].SessionId.ToString();
            _webReference = lstResultObject[0].WebReference.ToString();
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            Thread.Sleep(1000);
            string jsonBodySavePaymentInfo = SavePaymentInfoFunctions.SetupRequestForSavePaymentInfoNormalCase(_contextName, lstPara, _sessionId, lstResultObject, totalPremiumInQuote);
            _responseSavePaymentInfo = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBodySavePaymentInfo, lstPara.Header);
            //send save marketing request
            ParametersForRequest lstPatameterSaveMarketing = Common.GetParametersForRequest(_apiVersion, _contextName, _saveMarketingRequestBody);
            string urlSaveMarketing = PrepurchaseFunctions.GetURL(_saveMarketingRequestBody, _apiVersion, _contextName);
            var jsonBodySaveMarketing = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterSaveMarketing.ResourcePath);
            _responseSaveMarketing = _requestUtils.SendRequest(HttpMethod.Post, urlSaveMarketing, jsonBodySaveMarketing, lstPatameterSaveMarketing.Header);
            ParametersForRequest lstPatameterRegisterPayment = Common.GetParametersForRequest(_apiVersion, _contextName, _registerPaymentRequestBody);
            string resourcePath = lstPatameterRegisterPayment.ResourcePath;
            //var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterRegisterPayment.ResourcePath);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyWithDataChange(resourcePath, table);
            _paymentResponse = _requestUtils.SendRequest(HttpMethod.Post, lstPatameterRegisterPayment.Url, jsonBody, lstPatameterRegisterPayment.Header);
            _actualStatusCode = (int)_paymentResponse.Item2;
            if (_actualStatusCode == 204)
            {
                _actualMessages = _paymentResponse.Item2.ToString();
            }
            else
                _actualMessages = ResponseUtils.GetResponseMessage(_paymentResponse);

        }

        [When(@"User send a WebHook service")]
        public void WhenUserSendAWebHookRequest()
        {
            ParametersForRequest lstPatameterWebHook = Common.GetParametersForRequest(_apiVersion, _contextName, _webHookBody);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            _url = specflowHelper.GetUrlByString(_uri);
            var jsonBody = PaymentFunctions.CreateRequestBodyNormalCaseForWebHook(_sessionId, _webReference, lstPatameterWebHook.ResourcePath);
            Thread.Sleep(2000);
            _webHookResponse = _requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, lstPatameterWebHook.Header);
            _actualStatusCode = (int)_paymentResponse.Item2;
            _actualMessages = _webHookResponse.Item1.ToString();
            //Thread.Sleep(1000);

        }

        [When(@"User send a WebHook service with")]
        public void WhenUserSendAWebHookRequestValidation(Table table)
        {
            ParametersForRequest lstPatameterWebHook = Common.GetParametersForRequest(_apiVersion, _contextName, _webHookBody);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            _url = specflowHelper.GetUrlByString(_uri);
            var jsonBody = PaymentFunctions.CreateRequestBodyForWebHook(_webHookBody,table,_sessionId, _webReference, lstPatameterWebHook.ResourcePath);
            Thread.Sleep(1000);
            _webHookResponse = _requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, lstPatameterWebHook.Header);
            _actualStatusCode = (int)_webHookResponse.Item2;
            _actualMessages = _webHookResponse.Item1.ToString();
        }
        [Then(@"Payment response returns (.*) and (.*)")]
        public void ThenRecallResponseReturn(int expectedStatusCode, string expectedMessages)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Contains(expectedMessages, _actualMessages);
        }

        //[Then(@"Webhook response returns (.*)")]
        //public void ThenWebhookResponseReturn(int expectedStatusCode)
        //{
        //    Assert.Equal(expectedStatusCode, _actualStatusCode);
        //    Thread.Sleep(3000);
        //}
    }
}
