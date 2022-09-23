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
    public class SendARegisterPaymentRequestNormalCaseInstalmentSteps
    {
        SpecflowHelper _specflowHelper = new SpecflowHelper();
        private RequestUtils _requestUtils = new RequestUtils();
        private int _actualStatusCode;
        private string _uri, _url, _sessionId = "", _webReference = "";
        private string _apiVersion0, _apiVersion1, _apiVersion2, _contextName, _actualMessages;
        private string _quoteRequestBody, _registerPaymentRequestBody, _saveMarketingRequestBody, _savePaymentInfoRequestBody, _webHookBody, _saveCardConsentBody = "", _saveDirectDebitBody = "";
        Tuple<string, System.Net.HttpStatusCode> _paymentResponse, _webHookResponse, _responseSaveMarketing, _responseSavePaymentInfo, _responseSaveCardConsent, _responseSaveDirectDebit;
        
        [Given(@"User has payment body for SG")]
        public void GivenUserHasPaymentBodyForSG(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _registerPaymentRequestBody = paramValues["PaymentRequestBody"];
            _saveMarketingRequestBody = paramValues["SaveMarketingRequestBody"];
            _savePaymentInfoRequestBody = paramValues["SavePaymentInfoRequestBody"];

            _apiVersion0 = paramValues["ApiVersion0"];
            _apiVersion1 = paramValues["ApiVersion1"];
            _apiVersion2 = paramValues["ApiVersion2"];
            _contextName = paramValues["ContextName"];
            try
            {
                if (!String.IsNullOrEmpty(paramValues["SaveCardConsentBody"]))
                {
                    _saveCardConsentBody = paramValues["SaveCardConsentBody"];
                }
                if (!String.IsNullOrEmpty(paramValues["SaveDirectDebitBody"]))
                {
                    _saveDirectDebitBody = paramValues["SaveDirectDebitBody"];
                }
            }
            catch (Exception) { }
        }

        [Given(@"I have wrapUp table for SG")]
        public void GivenUserHasPaymentOutcomeRequest(Table table)
        {
            var paramValues = SpecflowHelper.TableToDictionary(table);
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _registerPaymentRequestBody = paramValues["PaymentRequestBody"];
            _saveMarketingRequestBody = paramValues["SaveMarketingRequestBody"];
            _savePaymentInfoRequestBody = paramValues["SavePaymentInfoRequestBody"];
            _webHookBody = paramValues["WebHookBody"];
            _apiVersion0 = paramValues["ApiVersion0"];
            _apiVersion1 = paramValues["ApiVersion1"];
            _apiVersion2 = paramValues["ApiVersion2"];
            _contextName = paramValues["ContextName"];
            _uri = paramValues["Uri"];
            try
            {
                if (!String.IsNullOrEmpty(paramValues["SaveCardConsentBody"]))
                {
                    _saveCardConsentBody = paramValues["SaveCardConsentBody"];
                }
                if (!String.IsNullOrEmpty(paramValues["SaveDirectDebitBody"]))
                {
                    _saveDirectDebitBody = paramValues["SaveDirectDebitBody"];
                }
            }
            catch (Exception) { }
            Thread.Sleep(3000);

        }

        [When(@"User send a SG Resister Payment service")]
        public void WhenUserSendASGResisterPaymentService()
        {
            // send  save payment infor request
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion1, _contextName, _savePaymentInfoRequestBody);
            var lstResultObject = new List<ResultObject>();
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _savePaymentInfoRequestBody, _apiVersion2, _contextName);
            Thread.Sleep(2000);
            _sessionId = lstResultObject[0].SessionId.ToString();
            _webReference = lstResultObject[0].WebReference.ToString();
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            Thread.Sleep(5000);
            string jsonBodySavePaymentInfo = SavePaymentInfoFunctions.SetupRequestForSavePaymentInfoNormalCase(_apiVersion1,lstPara, _sessionId, lstResultObject, totalPremiumInQuote);
            _responseSavePaymentInfo = _requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBodySavePaymentInfo, lstPara.Header);
            //send save marketing request
            ParametersForRequest lstPatameterSaveMarketing = Common.GetParametersForRequest(_apiVersion1, _contextName, _saveMarketingRequestBody);
            string urlSaveMarketing = PrepurchaseFunctions.GetURL(_saveMarketingRequestBody, _apiVersion1, _contextName);
            var jsonBodySaveMarketing = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterSaveMarketing.ResourcePath);
            _responseSaveMarketing = _requestUtils.SendRequest(HttpMethod.Post, urlSaveMarketing, jsonBodySaveMarketing, lstPatameterSaveMarketing.Header);
            Thread.Sleep(2000);
            if (!String.IsNullOrEmpty(_saveDirectDebitBody))
            {
                //send save Direct Debit request
                ParametersForRequest lstPatameterSaveDirectDebit = Common.GetParametersForRequest(_apiVersion2, _contextName, _saveDirectDebitBody);
                var jsonBodySaveDirectDebit = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterSaveDirectDebit.ResourcePath);
                _responseSaveDirectDebit = _requestUtils.SendRequest(HttpMethod.Post, lstPatameterSaveDirectDebit.Url, jsonBodySaveDirectDebit, lstPatameterSaveDirectDebit.Header);
                Thread.Sleep(2000);
            }
            if (!String.IsNullOrEmpty(_saveCardConsentBody))
            {
                //send save card consent request
                ParametersForRequest lstPatameterSaveCardConsent = Common.GetParametersForRequest(_apiVersion0, _contextName, _saveCardConsentBody);
                var jsonBodySaveCardConsent = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterSaveCardConsent.ResourcePath);
                _responseSaveCardConsent = _requestUtils.SendRequest(HttpMethod.Post, lstPatameterSaveCardConsent.Url, jsonBodySaveCardConsent, lstPatameterSaveCardConsent.Header);
                Thread.Sleep(2000);
            }


            //send register payment request
            ParametersForRequest lstPatameterRegisterPayment = Common.GetParametersForRequest(_apiVersion1, _contextName, _registerPaymentRequestBody);
            string resourcePath = lstPatameterRegisterPayment.ResourcePath;
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(_sessionId, lstPatameterRegisterPayment.ResourcePath);
            Thread.Sleep(2000);
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

        [When(@"User send a SG WebHook service with")]
        public void WhenUserSendAWebHookRequestValidation(Table table)
        {
            ParametersForRequest lstPatameterWebHook = Common.GetParametersForRequest(_apiVersion2, _contextName, _webHookBody);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            _url = specflowHelper.GetUrlByString(_uri);
            var jsonBody = PaymentFunctions.CreateRequestBodyForWebHook(_webHookBody, table, _sessionId, _webReference, lstPatameterWebHook.ResourcePath);
            Thread.Sleep(2000);
            _webHookResponse = _requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, lstPatameterWebHook.Header);
            _actualStatusCode = (int)_paymentResponse.Item2;
            _actualMessages = _webHookResponse.Item1.ToString();
        }

        [When(@"User send a SG WebHook service")]
        public void WhenUserSendAWebHookRequest()
        {

            ParametersForRequest lstPatameterWebHook = Common.GetParametersForRequest(_apiVersion2, _contextName, _webHookBody);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            _url = specflowHelper.GetUrlByString(_uri);
            var jsonBody = PaymentFunctions.CreateRequestBodyNormalCaseForWebHook(_sessionId, _webReference, lstPatameterWebHook.ResourcePath);
            Thread.Sleep(2000);
            _webHookResponse = _requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, lstPatameterWebHook.Header);

            _actualStatusCode = (int)_paymentResponse.Item2;
            _actualMessages = _webHookResponse.Item1.ToString();
            Thread.Sleep(2000);

        }

        [Then(@"SG Payment response returns (.*) and (.*)")]
        public void ThenSGPaymentResponseReturnsAndRegisterPaymentSuccessfully(int expectedStatusCode, string expectedMessages)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Contains(expectedMessages, _actualMessages);
        }
    }
}
