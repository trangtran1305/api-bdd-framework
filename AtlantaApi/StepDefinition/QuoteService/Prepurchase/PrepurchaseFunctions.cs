using AtlantaApi.StepDefinition.QuoteService;
using AtlantaApi.StepDefinition.QuoteService.Quotes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.ApiCore.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AtlantaApi.Utils
{
    public class PrepurchaseFunctions
    {
        public static double TotalAmountToPay(double totalPremiumInQuote, List<double> listPremium)
        {
            return totalPremiumInQuote + listPremium.Take(listPremium.Count).Sum();
        }

        public static double TotalAmountDeposit(double totalDepositInQuote, List<double> listDeposit)
        {
            return (totalDepositInQuote + listDeposit.Take(listDeposit.Count).Sum());
        }

        public static List<double> GetListPremium(string contextName, string jsonBody, List<ResultObject> lstResultObject)
        {
            List<double> lstPremium = new List<double>();
            if (contextName.Contains("ANCarClassic") || contextName.Contains("BeWiser") || contextName.Contains("AutonetVan"))
            {
                foreach (var optionalExtras in lstResultObject)
                {
                    if (jsonBody.Contains("KD") && optionalExtras.ProviderCode == "KD")
                    {
                        lstPremium.Add(optionalExtras.Premium);
                    }
                    if (jsonBody.Contains("KB") && optionalExtras.ProviderCode == "KB")
                    {
                        lstPremium.Add(optionalExtras.Premium);
                    }
                    if (jsonBody.Contains("T0") && optionalExtras.ProviderCode == "T0")
                    {
                        lstPremium.Add(optionalExtras.Premium);
                    }
                    if (jsonBody.Contains("T1") && optionalExtras.ProviderCode == "T1")
                    {
                        lstPremium.Add(optionalExtras.Premium);
                    }
                    if (jsonBody.Contains("T2") && optionalExtras.ProviderCode == "T2")
                    {
                        lstPremium.Add(optionalExtras.Premium);
                    }
                    if (jsonBody.Contains("T3") && optionalExtras.ProviderCode == "T3")
                    {
                        lstPremium.Add(optionalExtras.Premium);
                    }
                    if (jsonBody.Contains("YA") && optionalExtras.ProviderCode == "YA")
                    {
                        lstPremium.Add(optionalExtras.Premium);
                    }
                    if (jsonBody.Contains("YE") && optionalExtras.ProviderCode == "YE")
                    {
                        lstPremium.Add(optionalExtras.Premium);
                    }
                }
            }
            else
            {
                foreach (var optionalExtras in lstResultObject)
                {
                    if (jsonBody.Contains("RN") && optionalExtras.ProviderCode == "RN")
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
            }

            return lstPremium;
        }

        public static List<double> GetListDeposit(string contextName, string jsonBody, List<ResultObject> lstResultObject)
        {
            List<double> lstDeposit = new List<double>();
            if (contextName.Contains("ANCarClassic") || contextName.Contains("BeWiser") || contextName.Contains("AutonetVan"))
            {
                foreach (var optionalExtras in lstResultObject)
                {
                    if (jsonBody.Contains("KD") && optionalExtras.ProviderCode == "KD")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("KB") && optionalExtras.ProviderCode == "KB")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("T0") && optionalExtras.ProviderCode == "T0")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("T1") && optionalExtras.ProviderCode == "T1")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("T2") && optionalExtras.ProviderCode == "T2")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("T3") && optionalExtras.ProviderCode == "T3")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("YA") && optionalExtras.ProviderCode == "YA")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("YE") && optionalExtras.ProviderCode == "YE")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                }
            } else
            {
                foreach (var optionalExtras in lstResultObject)
                {
                    if (jsonBody.Contains("RN") && optionalExtras.ProviderCode == "RN")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("RS") && optionalExtras.ProviderCode == "RS")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("RX") && optionalExtras.ProviderCode == "RX")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("RW") && optionalExtras.ProviderCode == "RW")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                    if (jsonBody.Contains("RV") && optionalExtras.ProviderCode == "RV")
                    {
                        lstDeposit.Add(optionalExtras.Deposit);
                    }
                }
            }
            return lstDeposit;
        }

        public static string GetURL(string jsonBodyName, string apiVersion, string contextName)
        {
            string url = "";
            SpecflowHelper specflowHelper = new SpecflowHelper();

            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            if (jsonBodyName.ToLower().Contains("savedebit"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.SaveDebit);

            }
            else if (jsonBodyName.ToLower().Contains("savemarketing"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.SaveMarketing);

            }
            else if (jsonBodyName.ToLower().Contains("savepaymentinfo"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.SavePaymentInfo);

            }
            else if (jsonBodyName.ToLower().Contains("cacherequest"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Cache);

            }
            else if (jsonBodyName.ToLower().Contains("cachepull"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.PullCache);

            }
            else if (jsonBodyName.ToLower().Contains("vehiclesearch"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.VehicleSearch);

            }
            else if (jsonBodyName.ToLower().Contains("manufactures"))
            {
                url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Manufactures);

            }
            return url;
        }
        public static string ReturnPrepuchasePath(string requestBodyName, Tuple<ServiceEndpointName, ResourcePath, string> serviceInfoAndContext)
        {
            string prepurchasePath = "";
            if (requestBodyName.ToLower().Contains("savedebit"))
            {
                prepurchasePath = serviceInfoAndContext.Item2.SaveDebit;
            }
            else if (requestBodyName.ToLower().Contains("savemarketing"))
            {
                prepurchasePath = serviceInfoAndContext.Item2.SaveMarketing;
            }
            else if (requestBodyName.ToLower().Contains("savepaymentinfo"))
            {
                prepurchasePath = serviceInfoAndContext.Item2.SavePaymentInfo;
            }
            else if (requestBodyName.ToLower().Contains("cache"))
            {
                prepurchasePath = serviceInfoAndContext.Item2.Cache;
            }
            else if (requestBodyName.ToLower().Contains("vehicle"))
            {
                prepurchasePath = serviceInfoAndContext.Item2.VehicleService;
            }
            else if (requestBodyName.ToLower().Contains("cardconsent"))
            {
                prepurchasePath = serviceInfoAndContext.Item2.SaveCardConsent;
            }
            return prepurchasePath;
        }
        public static string CreateRequestBody(string requestBodyName,Table table, string sessionId, string apiVersion, string contextName)
        {
            if (sessionId.Equals("null"))
            {
                sessionId = null;
            }
            string jsonBody = ReadJsonFile(requestBodyName, apiVersion, contextName);
            var jObject = JObject.Parse(jsonBody);
            FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            var fieldNames = QuoteApiHelperPrepurchase.CreateKeyList(fieldMapping);
            string value = fieldMapping.Value;
            //if (fieldNames[0].ToLower().Contains("totalamounttopay") && value.ToLower().Contains("missing"))
            //    {
            //    value = "0";
            //}
            if (fieldNames[fieldNames.Count - 1].Equals("SessionId"))
            {
                if (value.Equals("null"))
                {
                    value = null;
                }
                jObject["SessionId"] = value;
            }
            else
            {
                if (value.Contains("File: "))
                {
                    jObject = QuoteApiHelperPrepurchase.AddJsonToBody(requestBodyName, jObject, value, apiVersion, contextName);
                }
                else
                {
                    JsonHelper.EditValue(jObject, fieldNames, value);
                }
                jObject["SessionId"] = sessionId;

            }
            // fix bug in case duplicate regNumber, read json file
            //checking with case sessionId in testcase
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }
        public static string CreateRequestBodyNormalCase(string sessionId, string filePath)
        {
            if (sessionId.Equals("null"))
            {
                sessionId = null;
            }
            string jsonBody = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonBody);
            jObject["SessionId"] = sessionId;
            var jobject = JObject.Parse(jsonBody);
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }
        public static string CreateRequestBodyWithDataChange(string filePath, Table table)
        {
            var jsonBody = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonBody);
            FieldMapping fieldMapping = table.CreateSet<FieldMapping>().ToList()[0];
            var fieldName = fieldMapping.Level1;
            string value = fieldMapping.Value;
            if (value == "null")
            {
                value = null;
            }
            jObject[fieldName] = value;
            jsonBody = JsonConvert.SerializeObject(jObject);
            return jsonBody;
        }
        public static string ReadJsonFile(string requestBodyName, string apiVersion,string contextName)
        {
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            string resourcePath = ReturnPrepuchasePath(requestBodyName, serviceInfoAndContext);
            string requestJsonFilePath = FileUtils.GetPayLoadSource(resourcePath + requestBodyName);
            string jsonBody = File.ReadAllText(requestJsonFilePath);
            return jsonBody;

        }

        public static int TotalAmountToPayInstalments(double totalPremiumInQuote, List<double> lstPremium, double depositRate, double interestRate)
        {
            double TotallstPremium = lstPremium.Take(lstPremium.Count).Sum();
            int deposit = (int)((TotallstPremium + totalPremiumInQuote)* depositRate);
            return deposit;
        }
        public static int TotalAmountToPayInstalmentsNoOpEx(double totalPremiumInQuote, double depositRate, double interestRate)
        {
            int deposit = (int) Math.Round(totalPremiumInQuote * depositRate);
            return deposit;
        }
    }
}
