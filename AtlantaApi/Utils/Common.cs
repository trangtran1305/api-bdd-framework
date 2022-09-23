using AtlantaApi.StepDefinition.QuoteService;
using AtlantaApi.Utils.ServiceVersionsManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace AtlantaApi.Utils
{
    public class Common
    {
        private static string token = null;
        private static SpecflowHelper _specflowHelper = new SpecflowHelper();
        static RequestUtils _requestUtils = new RequestUtils();
        public static string GetToken()
        {
            if (token != null) return token;
            RequestUtils testUtils = new RequestUtils();
            string uri = "/api/token/authorize";
            string url = _specflowHelper.GetUrlByString(uri);
            var response = testUtils.SendRequest(HttpMethod.Get, url);
            var jObjectResponse = JObject.Parse(response.Item1);
            token = jObjectResponse["token_type"].ToString() + " " + jObjectResponse["access_token"].ToString();

            return token;
        }
        public static string GetSessionId(string token, string quoteRequestBodyName, string apiVersion, string contextName)
        {
            int actualStatusCode = 0;
            var response = GetQuoteResponse(token, quoteRequestBodyName, apiVersion, contextName);
            actualStatusCode = (int)response.Item2;
            var jResponseQuoteBody = JObject.Parse(response.Item1);
            string sessionId = jResponseQuoteBody["ResultObj"]["SessionId"].ToString();
            Thread.Sleep(1000);
            return sessionId;
        }

        public static Dictionary<string, string> GetSessionIdAndWebReference(string token, string quoteRequestBodyName, string apiVersion, string contextName)
        {
            var lstSessionIdWebReference = new Dictionary<string, string>();
            Tuple<string, System.Net.HttpStatusCode> response;
            JObject jResponseQuoteBody;
            if (quoteRequestBodyName.ToLower().Contains("partialquote"))
            {
                response = GetPartialQuoteResponse(token, quoteRequestBodyName, apiVersion, contextName);
                jResponseQuoteBody = JObject.Parse(response.Item1);
                lstSessionIdWebReference.Add("WebReference", jResponseQuoteBody["ResultObj"]["WebReference"].ToString());
            }
            else
            {
                response = GetQuoteResponse(token, quoteRequestBodyName, apiVersion, contextName);
                jResponseQuoteBody = JObject.Parse(response.Item1);
                if ((int)response.Item2 == 200)
                {
                    lstSessionIdWebReference.Add("SessionId", jResponseQuoteBody["ResultObj"]["SessionId"].ToString());
                    lstSessionIdWebReference.Add("WebReference", jResponseQuoteBody["ResultObj"]["WebReference"].ToString());
                }
                else
                {
                    //lstSessionIdWebReference.Add("SessionId", jResponseQuoteBody["ResultObj"]["SessionId"].ToString());
                    lstSessionIdWebReference.Add("WebReference", "NULL");
                }

            }

            return lstSessionIdWebReference;
        }


        public static Tuple<string, System.Net.HttpStatusCode> GetQuoteResponse(string token, string quoteRequestBodyName, string apiVersion, string contextName)
        {
            string jsonBody = QuoteApiHelperPrepurchase.CreateRequestBodyWithDateChange(quoteRequestBodyName, apiVersion, contextName);

            Thread.Sleep(1000);
            var requestUtils = new RequestUtils();
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            string url = _specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Quotes);
            string context = serviceInfoAndContext.Item3;

            var header = requestUtils.GetHeader(context, token);
            var response = requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
            //Thread.Sleep(1000);
            return response;

        }

        public static Tuple<string, System.Net.HttpStatusCode> GetPartialQuoteResponse(string token, string partialQuoteRequestBodyName, string apiVersion, string contextName)
        {
            ParametersForRequest lstPara = GetParametersForRequest(apiVersion, contextName, partialQuoteRequestBodyName);
            string jsonBody = QuoteApiHelperPrepurchase.CreateRequestBodyWithDateChange(partialQuoteRequestBodyName, apiVersion, contextName);
            var requestUtils = new RequestUtils();
            Thread.Sleep(1000);
            var response = requestUtils.SendRequest(HttpMethod.Post, lstPara.Url, jsonBody, lstPara.Header);
            return response;

        }
        public static Tuple<ServiceEndpointName, ResourcePath, string> GetServiceInfoByVersionAndContext(string inputVersion, string inputContext = null)
        {
            ServiceVersion version;
            string context = null;
            Enum.TryParse(inputVersion, out version);
            var serviceVersionsFactory = new ServiceVersionsFactory();
            var serviceVersionBase = serviceVersionsFactory.GetServiceByVersion(version);
            var serviceEndpoint = serviceVersionBase.SetEndpoint();
            var resourcePath = serviceVersionBase.SetResource();
            if (!String.IsNullOrEmpty(inputContext))
            {
                context = _specflowHelper.GetContextFromConfig(inputContext);
            }
            return new Tuple<ServiceEndpointName, ResourcePath, string>(serviceEndpoint, resourcePath, context);
        }

        public static string ReadFileJson(string fileName, string version, string contextName)
        {
            //var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(version, contextName);
            var requestJsonFilePath = GetPathFile(fileName, version, contextName);
            string body = File.ReadAllText(requestJsonFilePath);
            return body;
        }
        public static string GetPathFile(string fileName, string version, string contextName)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(version, contextName);
            SpecflowHelper specflowHelper = new SpecflowHelper();
            string resourcePath = "";
            if (fileName.Contains("Quotes"))
            {
                resourcePath = serviceInfoAndContext.Item2.Quotes;

            }
            else if (fileName.Contains("VehicleSearch"))
            {
                resourcePath = serviceInfoAndContext.Item2.VehicleService; ;

            }
            else if (fileName.Contains("Metadata"))
            {
                resourcePath = serviceInfoAndContext.Item2.ReferenceDataMetadata;
            }
            else if (fileName.Contains("KeyWord"))
            {
                resourcePath = serviceInfoAndContext.Item2.ReferenceDataByKeyword;
            }
            else if (fileName.Contains("VehicleType"))
            {
                resourcePath = serviceInfoAndContext.Item2.VehicleService;
            }
            else if (fileName.ToLower().Contains("savecardconsent"))
            {
                resourcePath = serviceInfoAndContext.Item2.SaveCardConsent;
            }
            else
                resourcePath = serviceInfoAndContext.Item2.ReferenceDataMetadata;

            string requestJsonFilePath = FileUtils.GetPayLoadSource(resourcePath + fileName);

            return requestJsonFilePath;
        }
        public static string FormatString(string value)
        {
            try
            {
                value = string.Format(value);
                value = Regex.Replace(value, @"\s+", "").Replace("\"", "");
            }
            catch (Exception )
            {
                value = Regex.Replace(value, @"\s+", "").Replace("\"", "");

            }
            return value;
        }

        public static ParametersForRequest GetParametersForRequest(string apiVersion, string contextName, string requestBodyName)
        {
            string url, resourcePath;
            string token = GetToken();
            ParametersForRequest parameters = new ParametersForRequest();
            string context = _specflowHelper.GetContextFromConfig(contextName);
            var header = _requestUtils.GetHeader(context, token);
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);

            SpecflowHelper specflowHelper = new SpecflowHelper();

            if (requestBodyName.ToLower().Contains("recall"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ReCall);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.ReCall + requestBodyName);
            }
            else if (requestBodyName.ToLower().Contains("registerpayment"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Register);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.Register + requestBodyName);
            }
            else if (requestBodyName.ToLower().Contains("savedebit"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.SaveDebit);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.SaveDebit + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("savemarketing"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.SaveMarketing);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.SaveMarketing + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("savepaymentinfo"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.SavePaymentInfo);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.SavePaymentInfo + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("cacherequest"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Cache);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.Cache + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("cachepull"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.PullCache);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.PullCache + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("vehiclesearch"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleSearch);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.VehicleSearch + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("manufactures"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Manufactures);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.Manufactures + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("vehicletype"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleTypes);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.VehicleService + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("vehiclegetmodel"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ModelList);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.VehicleService + requestBodyName);

            }

            else if (requestBodyName.ToLower().Contains("keyword"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ReferenceDataByKeyword);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.ReferenceDataByKeyword + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("byvalue"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ReferenceDataByValue);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.ReferenceDataByValue + requestBodyName);

            }

            else if (requestBodyName.ToLower().Contains("metadata"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.ReferenceDataMetadata);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.ReferenceDataMetadata + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("partialquote"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.StorePartialQuote);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.StorePartialQuote + requestBodyName);

            }
            else if (requestBodyName.ToLower().Contains("savecardconsent"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.SaveCardConsent);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.SaveCardConsent + requestBodyName);

            }

            else if (requestBodyName.ToLower().Contains("webhook"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Outcome);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.Outcome + requestBodyName);
                header = GetHeader(context, token);
            }
            else if(requestBodyName.ToLower().Contains("quote"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Quotes);
                resourcePath = FileUtils.GetPayLoadSource(serviceInfoAndContext.Item2.Quotes + requestBodyName);
                header = GetHeader(context, token);
            }
            else
            {
                url = "";
                resourcePath = "";
            }
            parameters.Header = header;
            parameters.Url = url;
            parameters.Token = token;
            parameters.ResourcePath = resourcePath;
            return parameters;
        }
        public static Dictionary<string, string> GetHeader(string context, string authorization = null)
        {
            var headerDict = new Dictionary<string, string>();
            headerDict.Add("Context", context);
            headerDict.Add("Content-Type", "application/x-www-form-urlencoded");
            if (authorization != null)
            {
                headerDict.Add("Authorization", authorization);
            }

            return headerDict;
        }

    }
    public class TokenAuthorize
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }

    public enum ServiceVersion
    {
        V0,
        V1,
        V2,
        V3
    }
    public class ServiceEndpointName
    {
        public string IdentityServer { get; set; }
        public string Address { get; set; }
        public string Branding { get; set; }
        public string Cache { get; set; }
        public string PullCache { get; set; }
        //Start for Quote service
        public string Quotes { get; set; }
        public string StorePartialQuote { get; set; }
        public string ReCall { get; set; }
        public string SaveMarketing { get; set; }
        public string SaveDebit { get; set; }
        public string SavePaymentInfo { get; set; }
        public string ValidateBankDetails { get; set; }
        //End for Quote service
        //Start for Vehicle service
        public string Lookup { get; set; }
        public string VehicleTypes { get; set; }
        public string VehicleSearch { get; set; }

        public string Manufactures { get; set; }
        public string ModelList { get; set; }
        public string Models { get; set; }
        public string EngineCapacities { get; set; }
        public string VehicleMakeList { get; internal set; }

        //End for Vehicle service
        //Start for Payment service
        public string Register { get; set; }
        public string Outcome { get; set; }
        //End for Payment service
        public string ReferenceDataMetadata { get; set; }
        public string ReferenceDataByKeyword { get; set; }
        public string ReferenceDataByValue { get; set; }
        public string SaveCardConsent { get; set; }
        public string ManufacturesList { get; set; }
        public string ModelListScenicMH { get; internal set; }
        public string ModelListSG { get; internal set; }
        public string OutcomeSG { get; internal set; }
        public string BrandingPhone { get; internal set; }
    }
    public class ResourcePath
    {
        public string IdentityServer { get; set; }
        public string Address { get; set; }
        public string Cache { get; set; }
        public string PullCache { get; set; }
        //Start for Quote service
        public string Quotes { get; set; }
        public string StorePartialQuote { get; set; }
        public string ReCall { get; set; }
        public string SaveMarketing { get; set; }
        public string SaveDebit { get; set; }
        public string SavePaymentInfo { get; set; }
        public string ValidateBankDetails { get; set; }
        //End for Quote service
        //Start for Vehicle service
        public string Lookup { get; set; }
        public string VehicleTypes { get; set; }
        public string VehicleSearch { get; set; }
        public string Manufactures { get; set; }
        public string VehicleService { get; set; }
        public string Models { get; set; }
        public string EngineCapacities { get; set; }
        //End for Vehicle service
        //Start for Payment service
        public string Register { get; set; }
        public string Outcome { get; set; }
        //End for Payment service
        public string ReferenceDataMetadata { get; set; }
        public string ReferenceDataByKeyword { get; set; }
        public string ReferenceDataByValue { get; set; }
        public string SaveCardConsent { get; set; }

    }

    public class ResultObject
    {
        private string v1;
        private int v2;
        private int v3;
        private int v4;

        public ResultObject(string sessionId, string webReference, double totalPremium, string v1, int v2, int v3, int v4)
        {
            SessionId = sessionId;
            WebReference = webReference;
            TotalPremium = totalPremium;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public ResultObject(string sessionId, string webReference, string schemeCode, double totalPremium, string providerCode, double premium, double totalDeposit, double deposit, double depositRate = 0.0, double interestRate = 0.0)
        {
            SessionId = sessionId;
            WebReference = webReference;
            SchemeCode = schemeCode;
            TotalPremium = totalPremium;
            ProviderCode = providerCode;
            Premium = premium;
            TotalDeposit = totalDeposit;
            Deposit = deposit;
            DepositRate = depositRate;
            InterestRate = interestRate;
        }
        public string SessionId { get; set; }
        public string WebReference { get; set; }
        public double TotalPremium { get; set; }
        public string ProviderCode { get; set; }
        public double Premium { get; set; }
        public double TotalDeposit { get; set; }
        public double Deposit { get; set; }
        public double DepositRate { get; set; }
        public double InterestRate { get; set; }
        public string SchemeCode { get; set; }
    }

    public class RequestBody
    {
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
    }

    public class CacheDb
    {
        public int Id { get; set; }
        public string CodeReference { get; set; }
        public string StoredInfomation { get; set; }
        public int ExpiryOffset { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateExpiry { get; set; }
    }

    public class DVLADatabase
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public string Engine { get; set; }
        public string FromToYear { get; set; }
        public string Type { get; set; }
        public string Doors { get; set; }
        public string Seets { get; set; }
        public string CO2 { get; set; }
        public string ManufactureDate { get; set; }
        public string Imported { get; set; }
        public string ImportedNi { get; set; }
        public string PriorUse { get; set; }
        public string GrossVehicleWeight { get; set; }
        public string Drive { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string AbiCode { get; set; }
        public string RegistrationDate { get; set; }
    }

    public class TrackingDB
    {
        public int Id { get; set; }
        public string InternalId { get; set; }
        public string WebReference { get; set; }
        public string CompanyCode { get; set; }
        public string PolicyType { get; set; }
        public string AffinityCode { get; set; }
        public string RequestType { get; set; }
        public string RequestXML { get; set; }
        public string ResponseXML { get; set; }
        public long ElapsedTime { get; set; }
        public DateTime DateCreated { get; set; }
        public bool EmailSent { get; set; }
        public string RowVers { get; set; }
        public long TrackingOrder { get; set; }
        public bool IsError { get; set; }
    }
    public class Vehicle
    {
        public int Year { get; set; }
        public string Types { get; set; }
    }

    public class ParametersForRequest
    {
        public Dictionary<string, string> Header { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
        public string ResourcePath { get; set; }

    }

    public class VehicleData
    {
        public VehicleData(string type, string manufacturer,string model,string dugNumber)
        {
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
            DuqNumber = dugNumber;
        }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string DuqNumber { get; set; }
    }

}

