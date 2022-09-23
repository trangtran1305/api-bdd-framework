using AtlantaApi.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;
using ProjectCore.ApiCore.Common;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AtlantaApi.StepDefinition.QuoteService.Prepurchase
{
    [Binding]
    public class ValidateSavePaymentInfoSingleFieldInCaseCallToCDLUsingTotalAmountSteps
    {
        private readonly ScenarioContext _scenarioContext;
        RequestUtils requestUtils = new RequestUtils();
        SpecflowHelper specflowHelper = new SpecflowHelper();
        private string _url;
        private string _actualMessages = "";
        private int _actualStatusCode = 0;
        private bool _actualResultObj;
        private bool _actualIsSuccess;
        private string _prepurchaseRequestBody;
        private string _quoteRequestBody;
        private string _message;
        private string _totalAmountToPay;
        private string _jsonBody;
        private string _jsonFile;
        private string _apiVersionPrepurchase, _apiVersionQuote;
        private string _contextName;

        SpecflowHelper _specflowHelper = new SpecflowHelper();

        [Given(@"User has prepurchase body for SG")]
        public void GivenUserHasPrepurchaseBodyForSG(Table prepurchaseTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(prepurchaseTable);
            _prepurchaseRequestBody = paramValues["PrepurchaseRequestBody"];
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _apiVersionPrepurchase = paramValues["ApiVersionPrepurchase"];
            _apiVersionQuote = paramValues["ApiVersionQuote"];
            _contextName = paramValues["ContextName"];
        }
        
        [When(@"User sends SG save payment info request with PaymentMethod (.*) and OptionalExtras (.*) and (.*)")]
        public void WhenUserSendsSGSavePaymentInfoRequestWithPaymentMethodPayinfullAndOptionalExtrasYesAndYes(string paymentMethod, string optionalExtras, string totalAmountToPay)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersionPrepurchase, _contextName, _prepurchaseRequestBody);
            var lstResultObject = new List<ResultObject>();
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _prepurchaseRequestBody, _apiVersionQuote, _contextName);
            Thread.Sleep(1000);
            string sessionId = lstResultObject[0].SessionId.ToString();
            Thread.Sleep(2000);
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            double totalDepositInQuote = lstResultObject[0].TotalDeposit;
            double depositRate = lstResultObject[0].DepositRate;
            double interestRate = lstResultObject[0].InterestRate;
            _jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            List<double> lstPremium = new List<double>();
            lstPremium = PrepurchaseFunctions.GetListPremium(_contextName,_jsonBody, lstResultObject);

            if (paymentMethod.Equals("payinfull"))
            {
                if (!totalAmountToPay.Equals("No"))
                {
                    if (optionalExtras.Equals("Yes"))
                    {
                        lstPremium = PrepurchaseFunctions.GetListPremium(_contextName,_jsonBody, lstResultObject);
                        _totalAmountToPay = PrepurchaseFunctions.TotalAmountToPay(totalPremiumInQuote, lstPremium).ToString();
                    }
                    if (optionalExtras.Equals("No"))
                    {
                        _totalAmountToPay = totalPremiumInQuote.ToString();
                        _jsonBody = _jsonBody.Replace("\"RO\"", "").Replace("\"RN\"", "").Replace("\"RP\"", "").Replace("\"RQ\"", "").Replace("\"EG\"", "");

                    }
                }
                else
                {
                    _totalAmountToPay = "1234";
                }
            }
            if (paymentMethod.Equals("Instalmnts"))
            {
                if (!totalAmountToPay.Equals("No"))
                {
                    if (optionalExtras.Equals("Yes"))
                    {
                        List<double> lstDeposit = new List<double>();
                        lstDeposit = PrepurchaseFunctions.GetListDeposit(_contextName,_jsonBody, lstResultObject);
                        //_totalAmountToPay = PrepurchaseFunctions.TotalAmountDeposit(totalDepositInQuote, lstDeposit).ToString();
                        _totalAmountToPay = PrepurchaseFunctions.TotalAmountToPayInstalments(totalPremiumInQuote, lstPremium, depositRate, interestRate).ToString();
                    }
                    if (optionalExtras.Equals("No"))
                    {
                        // _totalAmountToPay = totalDepositInQuote.ToString();
                        _totalAmountToPay = PrepurchaseFunctions.TotalAmountToPayInstalmentsNoOpEx(totalPremiumInQuote, depositRate, interestRate).ToString();

                        _jsonBody = _jsonBody.Replace("\"RO\"", "").Replace("\"RN\"", "").Replace("\"RP\"", "").Replace("\"RQ\"", "").Replace("\"EG\"", "");

                    }
                }
                else
                {
                    _totalAmountToPay = "1234";
                }
            }
            _jsonBody = _jsonBody.Replace("<TotalAmount>", _totalAmountToPay);
            _jsonBody = _jsonBody.Replace("<PaymentMethodType>", paymentMethod);
            Thread.Sleep(2000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, _jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }

        [When(@"user sends SG request using (.*) and (.*)")]
        public void WhenUserSendsRequestUsingRegnumberidAndRegnumbervnr(string regNumberId, string regNumberVNR)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersionPrepurchase, _contextName);
            string fileName = _prepurchaseRequestBody.Replace("File: ", "");
            _jsonFile = serviceInfoAndContext.Item2.SaveMarketing + fileName;
            string resourcePath = PrepurchaseFunctions.ReturnPrepuchasePath(fileName, serviceInfoAndContext);
            string requestJsonFilePath = FileUtils.GetPayLoadSource(resourcePath + fileName);
            string json = File.ReadAllText(requestJsonFilePath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj["RegNumbers"][0]["id"] = regNumberId;
            jsonObj["RegNumbers"][0]["VRN"] = regNumberVNR;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(requestJsonFilePath, output);
        }

        [When(@"User sends SG prepurchase requests")]
        public void WhenUserSendsPrepurchaseRequestusing()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersionPrepurchase, _contextName, _prepurchaseRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersionQuote, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }

        [Then(@"Prepurchase SG response returns (.*) and (.*) and (.*)")]
        public void ThenPrepurchaseSGResponseReturnsAndTrueAndSaveDataSuccessfully(int expectedStatusCode, bool expectedIsSuccess, string expectedMessages)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedIsSuccess, _actualIsSuccess);
            Assert.Equal(expectedMessages, _actualMessages.Replace(" | ", ""));
        }

        [Then(@"The prepurchase response returns ""(.*)"" and ""(.*)""")]
        public void ThenTheResponseReturnsAnd(int expectedStatusCode, string expectedMessage)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedMessage, _actualMessages);
        }
    }
}
