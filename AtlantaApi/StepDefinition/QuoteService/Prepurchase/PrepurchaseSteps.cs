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

namespace AtlantaApi.StepDefinition.QuoteService
{
    [Binding]
    public class PrepurchaseSteps : Steps
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
        private string _apiVersion;
        private string _contextName;

        SpecflowHelper _specflowHelper = new SpecflowHelper();


        public PrepurchaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException("scenarioContext");
        }

        [Given(@"User has prepurchase body")]
        public void GivenUserHasPrepurchaseRequest(Table prepurchaseTable)
        {
            var paramValues = SpecflowHelper.TableToDictionary(prepurchaseTable);
            _prepurchaseRequestBody = paramValues["PrepurchaseRequestBody"];
            _quoteRequestBody = paramValues["QuoteRequestBody"];
            _apiVersion = paramValues["ApiVersion"];
            _contextName = paramValues["ContextName"];
        }

        [When(@"user sends request using (.*) and (.*)")]
        public void WhenUserSendsRequestUsingRegnumberidAndRegnumbervnr(string regNumberId, string regNumberVNR)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(_apiVersion, _contextName);
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


        [When(@"User sends prepurchase requests")]
        public void WhenUserSendsPrepurchaseRequestusing()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _prepurchaseRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }

        //[When(@"User sends prepurchase requests invalid Regnumber")]
        //public void WhenUserSendsPrepurchaseRequestInvalidRegNumber()
        //{
        //    ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _prepurchaseRequestBody);
        //    string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
        //    var jsonBody = File.ReadAllText(lstPara.ResourcePath);
        //    var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
        //    _actualMessages = ResponseUtils.GetResponseMessage(response);
        //    _actualStatusCode = (int)response.Item2;
        //    var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
        //    _actualIsSuccess = responseBody.IsSuccess;
        //}

        [When(@"User sends save payment info request with PaymentMethod (.*) and OptionalExtras (.*) and (.*)")]
        public void WhenUserSendsSavePaymentInfoRequestWithPaymentMethodAndOptionalExtras(string paymentMethod, string optionalExtras, string totalAmountToPay)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _prepurchaseRequestBody);
            var lstResultObject = new List<ResultObject>();
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(lstPara.Token, _quoteRequestBody, _prepurchaseRequestBody, _apiVersion, _contextName);
            Thread.Sleep(1000);
            string sessionId = lstResultObject[0].SessionId.ToString();
            Thread.Sleep(1000);
            double totalPremiumInQuote = lstResultObject[0].TotalPremium;
            double totalDepositInQuote = lstResultObject[0].TotalDeposit;
            double depositRate = lstResultObject[0].DepositRate;
            double interestRate = lstResultObject[0].InterestRate;
            _jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            List<double> lstPremium = new List<double>();
            lstPremium = PrepurchaseFunctions.GetListPremium(_contextName, _jsonBody, lstResultObject);
            if (paymentMethod.Equals("payinfull"))
            {
                if (!totalAmountToPay.Equals("No"))
                {
                    if (optionalExtras.Equals("Yes"))
                    {
                        lstPremium = PrepurchaseFunctions.GetListPremium(_contextName, _jsonBody, lstResultObject);
                        _totalAmountToPay = PrepurchaseFunctions.TotalAmountToPay(totalPremiumInQuote, lstPremium).ToString();
                    }
                    if (optionalExtras.Equals("No"))
                    {
                        _totalAmountToPay = totalPremiumInQuote.ToString();
                        _jsonBody = _jsonBody
                            // for ANCarClassic
                            .Replace("\"KD\"", "").Replace("\"KB\"", "").Replace("\"T0\"", "").Replace("\"T1\"", "").Replace("\"T2\"", "")
                            .Replace("\"T3\"", "").Replace("\"YA\"", "").Replace("\"YE\"", "")
                            //for CNBike
                            .Replace("\"RO\"", "").Replace("\"RN\"", "").Replace("\"RP\"", "").Replace("\"RQ\"", "").Replace("\"EG\"", "");
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
                   //     lstPremium = PrepurchaseFunctions.GetListPremium(_contextName, _jsonBody, lstResultObject);
                        _totalAmountToPay = (PrepurchaseFunctions.TotalAmountToPayInstalments(totalPremiumInQuote, lstPremium, depositRate ,interestRate)).ToString();
                    }
                    if (optionalExtras.Equals("No"))
                    {
                       // _totalAmountToPay = totalDepositInQuote.ToString();
                        _totalAmountToPay = ((int)(PrepurchaseFunctions.TotalAmountToPayInstalmentsNoOpEx(totalPremiumInQuote, depositRate,interestRate))).ToString();
                        
                        _jsonBody = _jsonBody
                            // for ANCar lassic
                            .Replace("\"KD\"", "").Replace("\"KB\"", "").Replace("\"T0\"", "").Replace("\"T1\"", "").Replace("\"T2\"", "")
                            .Replace("\"T3\"", "").Replace("\"YA\"", "").Replace("\"YE\"", "")
                            //for CNBike
                            .Replace("\"RO\"", "").Replace("\"RN\"", "").Replace("\"RP\"", "").Replace("\"RQ\"", "").Replace("\"EG\"", "");

                    }
                }
                else
                {
                    _totalAmountToPay = "1234";
                }
            }
            _jsonBody = _jsonBody.Replace("<TotalAmount>", _totalAmountToPay);
            _jsonBody = _jsonBody.Replace("<PaymentMethodType>", paymentMethod);
            Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, _jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);
            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }


        [When(@"User send prepurchase request")]
        public void WhenUserSendValidPrepurchaseRequest(Table table)
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _prepurchaseRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBody(_prepurchaseRequestBody, table, sessionId, _apiVersion, _contextName);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _actualMessages = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
        }
        [Then(@"Prepurchase response returns (.*) and (.*) and (.*)")]
        public void ThenPrepurchaseResponseReturn(int expectedStatusCode, bool expectedIsSuccess, string expectedMessages)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedIsSuccess, _actualIsSuccess);
            Assert.Equal(expectedMessages.Replace(".", ""), _actualMessages.Replace("|", "").Replace(".", ""));
            Thread.Sleep(2000);
        }

        [Then(@"The prepurchase response returns ""(.*)"" and ""(.*)""")]
        public void ThenTheResponseReturnsAnd(int expectedStatusCode, string expectedMessage)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
            Assert.Equal(expectedMessage, _actualMessages);
        }

        [When(@"User send prepurchase service with")]
        public void WhenUserSendPrepurchaseRequest()
        {
            ParametersForRequest lstPara = Common.GetParametersForRequest(_apiVersion, _contextName, _prepurchaseRequestBody);
            string sessionId = Common.GetSessionId(lstPara.Token, _quoteRequestBody, _apiVersion, _contextName);
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            _message = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = responseBody.Messages[0];
        }
        [Then(@"Save Marketing response returns (.*)")]
        public void ThenSaveMarketingResponseReturn(int expectedStatusCode)
        {
            Assert.Equal(expectedStatusCode, _actualStatusCode);
        }


        [When(@"User send save payment info service with (.*) and (.*)")]
        public void WhenUserSendAValidSavePaymentInfoRequest(string version, string contextName, Table table)
        {
            string token = "";
            token = Common.GetToken();
            string sessionId = "";
            double totalPremiumInQuote = 0;
            double totalAmount = 0;
            var lstResultObject = new List<ResultObject>();
            contextName = Regex.Replace(contextName, @"\s+", "").Replace("\"", "");
            version = Regex.Replace(version, @"\s+", "").Replace("\"", "");
            lstResultObject = SavePaymentInfoFunctions.GetSessionIdAndTotalPremium(token, _quoteRequestBody, _prepurchaseRequestBody, version, contextName);
            sessionId = lstResultObject[0].SessionId.ToString();
            totalPremiumInQuote = lstResultObject[0].TotalPremium;
            var jsonBody = PrepurchaseFunctions.CreateRequestBody(_prepurchaseRequestBody, table, sessionId, version, contextName);
            List<double> lstPremium = new List<double>();
            foreach (var optionalExtras in lstResultObject)
            {
                if (jsonBody.Contains("RO") && optionalExtras.ProviderCode == "RO")
                {
                    lstPremium.Add(optionalExtras.Premium);
                }
                if (jsonBody.Contains("RS") && optionalExtras.ProviderCode == "RS")
                {
                    lstPremium.Add(optionalExtras.Premium);
                }
                if (jsonBody.Contains("RX") && optionalExtras.ProviderCode == "RX")
                {
                    lstPremium.Add(optionalExtras.Premium);
                }
                if (jsonBody.Contains("RW") && optionalExtras.ProviderCode == "RW")
                {
                    lstPremium.Add(optionalExtras.Premium);
                }
                if (jsonBody.Contains("RV") && optionalExtras.ProviderCode == "RV")
                {
                    lstPremium.Add(optionalExtras.Premium);
                }

            }
            totalAmount = totalPremiumInQuote + lstPremium.Take(lstResultObject.Count()).Sum();

            jsonBody = jsonBody.Replace("<TotalAmount>", totalAmount.ToString());
            var context = specflowHelper.GetContextFromConfig(contextName);
            var header = requestUtils.GetHeader(context, token);
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(version, contextName);
            _url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.SavePaymentInfo);

            var response = requestUtils.SendRequest(HttpMethod.Post, _url, jsonBody, header);
            _message = ResponseUtils.GetResponseMessage(response);

            _actualStatusCode = (int)response.Item2;
            var responseBody = JsonConvert.DeserializeObject<PrepurchaseResponse>(response.Item1);
            _actualIsSuccess = responseBody.IsSuccess;
            _actualMessages = responseBody.Messages[0];
            if (_actualStatusCode == 200)
            {
                _actualResultObj = responseBody.ResultObj;

            }
        }
    }
}
