using AtlantaApi.Utils;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace AtlantaApi.StepDefinition.QuoteService
{
    public class SavePaymentInfoFunctions
    {
        //public static List<ResultObject> GetSessionIdAndTotalPremium(string token, string quoteRequestBodyName, string prepurchaseRequestBodyName, string apiVersion, string contextName)
        //{
        //    SpecflowHelper specflowHelper = new SpecflowHelper();
        //    List<ResultObject> lstResultObject = new List<ResultObject>();
        //    int totalPremium = 0;
        //    int totalDeposit = 0;
        //    double depositRate = 0.0;
        //    double interestRate = 0.0;
        //    string jsonBody = QuoteApiHelperPrepurchase.CreateRequestBodyWithDateChange(quoteRequestBodyName, apiVersion, contextName);

        //    //Thread.Sleep(2000);
        //    var requestUtils = new RequestUtils();
        //    ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, quoteRequestBodyName);
        //    var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
        //    string url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Quotes);
        //    string context = serviceInfoAndContext.Item3;

        //    var header = requestUtils.GetHeader(context, token);
        //    var response = requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
        //    //Thread.Sleep(2000);
        //    int actualStatusCode = (int)response.Item2;
        //    var jResponseQuoteBody = JObject.Parse(response.Item1);
        //    if (actualStatusCode == 200)
        //    {
        //        string sessionId = jResponseQuoteBody["ResultObj"]["SessionId"].ToString();
        //        string webReference = jResponseQuoteBody["ResultObj"]["WebReference"].ToString();
        //        if ((prepurchaseRequestBodyName.ToLower().Contains("forregister")))
        //        {
        //            lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, "", 0, 0, 0));
        //        }

        //        else if (prepurchaseRequestBodyName.ToLower().Contains("savepaymentinfo"))
        //        {
        //            try { 
                    
        //                if (contextName.Contains("ANCarClassic") || contextName.Contains("BeWiser"))
        //                {
        //                    totalPremium = Int32.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Premium"]["TotalPremium"].ToString());
        //                    totalDeposit = Int32.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["Deposit"].ToString());
        //                    var sbcn = jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString();
        //                    depositRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString());
        //                    interestRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["InterestRate"].ToString());
        //                    string providerCodeKD = jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["ProviderCode"].ToString();
        //                    int premiumKD = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["Premium"].ToString());
        //                    int depositKD = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeKD, premiumKD, totalDeposit, depositKD, depositRate, interestRate));
        //                    string providerCodeKB = jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["ProviderCode"].ToString();
        //                    int premiumKB = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["Premium"].ToString());
        //                    int depositKB = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeKB, premiumKB, totalDeposit, depositKB, depositRate, interestRate));
        //                    string providerCodeT0 = jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["ProviderCode"].ToString();
        //                    int premiumT0 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["Premium"].ToString());
        //                    int depositT0 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeT0, premiumT0, totalDeposit, depositT0, depositRate, interestRate));
        //                    string providerCodeT1 = jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["ProviderCode"].ToString();
        //                    int premiumT1 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["Premium"].ToString());
        //                    int depositT1 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeT1, premiumT1, totalDeposit, depositT1, depositRate, interestRate));
        //                    string providerCodeT2 = jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["ProviderCode"].ToString();
        //                    int premiumT2 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["Premium"].ToString());
        //                    int depositT2 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeT2, premiumT2, totalDeposit, depositT2, depositRate, interestRate));
        //                    string providerCodeT3 = jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["ProviderCode"].ToString();
        //                    int premiumT3 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["Premium"].ToString());
        //                    int depositT3 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeT3, premiumT3, totalDeposit, depositT3, depositRate, interestRate));
        //                    string providerCodeYA = jResponseQuoteBody["ResultObj"]["OptionalExtras"][6]["ProviderCode"].ToString();
        //                    int premiumYA = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][6]["Premium"].ToString());
        //                    int depositYA = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][6]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeYA, premiumYA, totalDeposit, depositYA, depositRate, interestRate));
        //                    string providerCodeYE = jResponseQuoteBody["ResultObj"]["OptionalExtras"][7]["ProviderCode"].ToString();
        //                    int premiumYE = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][7]["Premium"].ToString());
        //                    int depositYE = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][7]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeYE, premiumYE, totalDeposit, depositYE, depositRate, interestRate));
        //                }
        //                    else
        //                {
        //                    totalPremium = Int32.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Premium"]["TotalPremium"].ToString());
        //                    totalDeposit = Int32.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["Deposit"].ToString());
        //                    var sbcn = jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString();
        //                    depositRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString());
        //                    interestRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["InterestRate"].ToString());
        //                    string providerCodeRO = jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["ProviderCode"].ToString();
        //                    int premiumRO = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["Premium"].ToString());
        //                    int depositRO = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeRO, premiumRO, totalDeposit, depositRO, depositRate, interestRate));
        //                    string providerCodeRS = jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["ProviderCode"].ToString();
        //                    int premiumRS = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["Premium"].ToString());
        //                    int depositRS = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeRS, premiumRS, totalDeposit, depositRS, depositRate, interestRate));
        //                    string providerCodeRN = jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["ProviderCode"].ToString();
        //                    int premiumRN = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["Premium"].ToString());
        //                    int depositRN = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeRN, premiumRN, totalDeposit, depositRN, depositRate, interestRate));
        //                    string providerCodeRP = jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["ProviderCode"].ToString();
        //                    int premiumRP = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["Premium"].ToString());
        //                    int depositRP = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeRP, premiumRP, totalDeposit, depositRP, depositRate, interestRate));
        //                    string providerCodeRW = jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["ProviderCode"].ToString();
        //                    int premiumRW = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["Premium"].ToString());
        //                    int depositRW = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeRW, premiumRW, totalDeposit, depositRW, depositRate, interestRate));
        //                    string providerCodeRV = jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["ProviderCode"].ToString();
        //                    int premiumRV = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["Premium"].ToString());
        //                    int depositRV = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["Deposit"].ToString());
        //                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, providerCodeRV, premiumRV, totalDeposit, depositRV, depositRate, interestRate));

        //                }
        //            //Thread.Sleep(1000);
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Get quote unsuccessfull");
        //    }

        //    return lstResultObject;
        //}

        public static List<ResultObject> GetSessionIdAndTotalPremium(string token, string quoteRequestBodyName, string prepurchaseRequestBodyName, string apiVersion, string contextName)
        {
            SpecflowHelper specflowHelper = new SpecflowHelper();
            List<ResultObject> lstResultObject = new List<ResultObject>();
            double totalPremium = 0.0;
            double totalDeposit = 0.0;
            double depositRate = 0.0;
            double interestRate = 0.0;
            string jsonBody = QuoteApiHelperPrepurchase.CreateRequestBodyWithDateChange(quoteRequestBodyName, apiVersion, contextName);

            //Thread.Sleep(2000);
            var requestUtils = new RequestUtils();
            ParametersForRequest lstPara = Common.GetParametersForRequest(apiVersion, contextName, quoteRequestBodyName);
            var serviceInfoAndContext = Common.GetServiceInfoByVersionAndContext(apiVersion, contextName);
            string url = specflowHelper.GetUrlByString(serviceInfoAndContext.Item1.Quotes);
            string context = serviceInfoAndContext.Item3;

            var header = requestUtils.GetHeader(context, token);
            var response = requestUtils.SendRequest(HttpMethod.Post, url, jsonBody, header);
            //Thread.Sleep(2000);
            int actualStatusCode = (int)response.Item2;
            var jResponseQuoteBody = JObject.Parse(response.Item1);
            if (actualStatusCode == 200)
            {
                string sessionId = jResponseQuoteBody["ResultObj"]["SessionId"].ToString();
                string webReference = jResponseQuoteBody["ResultObj"]["WebReference"].ToString();
                string schemeCode = jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["Insurer"]["Scheme"]["Code"].ToString();
                if ((prepurchaseRequestBodyName.ToLower().Contains("forregister")))
                {
                    lstResultObject.Add(new ResultObject(sessionId, webReference, totalPremium, "", 0, 0, 0));
                }

                else if (prepurchaseRequestBodyName.ToLower().Contains("savepaymentinfo"))
                {
                    try
                    {

                        if (apiVersion == "V3")
                        {
                            totalPremium = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Premium"]["TotalPremium"].ToString());
                            totalDeposit = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["Deposit"].ToString());
                            var sbcn = jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString();
                            depositRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString());
                            interestRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["InterestRate"].ToString());
                            string providerCodeKD = jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][0]["OpexProducts"][0]["Code"].ToString();
                            double premiumKD = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][0]["OpexProducts"][0]["Premium"].ToString());
                            double depositKD = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][0]["OpexProducts"][0]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeKD, premiumKD, totalDeposit, depositKD, depositRate, interestRate));
                            string providerCodeKB = jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][1]["OpexProducts"][0]["Code"].ToString();
                            double premiumKB = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][1]["OpexProducts"][0]["Premium"].ToString());
                            double depositKB = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][1]["OpexProducts"][0]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeKB, premiumKB, totalDeposit, depositKB, depositRate, interestRate));
                            string providerCodeT0 = jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][2]["OpexProducts"][0]["Code"].ToString();
                            double premiumT0 = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][2]["OpexProducts"][0]["Premium"].ToString());
                            double depositT0 = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][2]["OpexProducts"][0]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeT0, premiumT0, totalDeposit, depositT0, depositRate, interestRate));
                            string providerCodeT1 = jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][3]["OpexProducts"][0]["Code"].ToString();
                            double premiumT1 = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][3]["OpexProducts"][0]["Premium"].ToString());
                            double depositT1 = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][3]["OpexProducts"][0]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeT1, premiumT1, totalDeposit, depositT1, depositRate, interestRate));
                            //string providerCodeT2 = jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][4]["OpexProducts"][0]["Code"].ToString();
                            //int premiumT2 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][4]["OpexProducts"][0]["Premium"].ToString());
                            //int depositT2 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][4]["OpexProducts"][0]["Deposit"].ToString());
                            //lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeT2, premiumT2, totalDeposit, depositT2, depositRate, interestRate));
                            //string providerCodeT3 = jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][5]["OpexProducts"][0]["Code"].ToString();
                            //int premiumT3 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][5]["OpexProducts"][0]["Premium"].ToString());
                            //int depositT3 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][5]["OpexProducts"][0]["Deposit"].ToString());
                            //lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeT3, premiumT3, totalDeposit, depositT3, depositRate, interestRate));
                            //string providerCodeYA = jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][6]["OpexProducts"][0]["Code"].ToString();
                            //int premiumYA = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][6]["OpexProducts"][0]["Premium"].ToString());
                            //int depositYA = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][6]["OpexProducts"][0]["Deposit"].ToString());
                            //lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeYA, premiumYA, totalDeposit, depositYA, depositRate, interestRate));
                            //string providerCodeYE = jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][7]["OpexProducts"][0]["Code"].ToString();
                            //int premiumYE = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][7]["OpexProducts"][0]["Premium"].ToString());
                            //int depositYE = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtraCategories"][7]["OpexProducts"][0]["Deposit"].ToString());
                            //lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeYE, premiumYE, totalDeposit, depositYE, depositRate, interestRate));
                            /*} else if (contextName.Contains("BeWiser") || contextName.Contains("ANCarClassic"))
                            {
                                totalPremium = Int32.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Premium"]["TotalPremium"].ToString());
                                totalDeposit = Int32.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["Deposit"].ToString());
                                var sbcn = jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString();
                                depositRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString());
                                interestRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["InterestRate"].ToString());
                                string providerCodeKD = jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["ProviderCode"].ToString();
                                int premiumKD = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["Premium"].ToString());
                                int depositKD = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["Deposit"].ToString());
                                lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeKD, premiumKD, totalDeposit, depositKD, depositRate, interestRate));
                                string providerCodeKB = jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["ProviderCode"].ToString();
                                int premiumKB = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["Premium"].ToString());
                                int depositKB = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["Deposit"].ToString());
                                lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeKB, premiumKB, totalDeposit, depositKB, depositRate, interestRate));
                                string providerCodeT0 = jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["ProviderCode"].ToString();
                                int premiumT0 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["Premium"].ToString());
                                int depositT0 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["Deposit"].ToString());
                                lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeT0, premiumT0, totalDeposit, depositT0, depositRate, interestRate));
                                string providerCodeT1 = jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["ProviderCode"].ToString();
                                int premiumT1 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["Premium"].ToString());
                                int depositT1 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["Deposit"].ToString());
                                lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeT1, premiumT1, totalDeposit, depositT1, depositRate, interestRate));
                                string providerCodeT2 = jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["ProviderCode"].ToString();
                                int premiumT2 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["Premium"].ToString());
                                int depositT2 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["Deposit"].ToString());
                                lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeT2, premiumT2, totalDeposit, depositT2, depositRate, interestRate));
                                string providerCodeT3 = jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["ProviderCode"].ToString();
                                int premiumT3 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["Premium"].ToString());
                                int depositT3 = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["Deposit"].ToString());
                                lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeT3, premiumT3, totalDeposit, depositT3, depositRate, interestRate));
                                string providerCodeYA = jResponseQuoteBody["ResultObj"]["OptionalExtras"][6]["ProviderCode"].ToString();
                                int premiumYA = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][6]["Premium"].ToString());
                                int depositYA = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][6]["Deposit"].ToString());
                                lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeYA, premiumYA, totalDeposit, depositYA, depositRate, interestRate));
                                string providerCodeYE = jResponseQuoteBody["ResultObj"]["OptionalExtras"][7]["ProviderCode"].ToString();
                                int premiumYE = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][7]["Premium"].ToString());
                                int depositYE = Int32.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][7]["Deposit"].ToString());
                                lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeYE, premiumYE, totalDeposit, depositYE, depositRate, interestRate));
                            */
                        }
                        else
                        {
                            totalPremium = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Premium"]["TotalPremium"].ToString());
                            totalDeposit = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["Deposit"].ToString());
                            var sbcn = jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString();
                            depositRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["DepositRate"].ToString());
                            interestRate = double.Parse(jResponseQuoteBody["ResultObj"]["PolicyProduct"][0]["PaymentOptions"]["Instalments"][0]["InterestRate"].ToString());
                            string providerCodeRO = jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["ProviderCode"].ToString();
                            double premiumRO = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["Premium"].ToString());
                            double depositRO = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][0]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeRO, premiumRO, totalDeposit, depositRO, depositRate, interestRate));
                            string providerCodeRS = jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["ProviderCode"].ToString();
                            double premiumRS = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["Premium"].ToString());
                            double depositRS = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][1]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeRS, premiumRS, totalDeposit, depositRS, depositRate, interestRate));
                            string providerCodeRN = jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["ProviderCode"].ToString();
                            double premiumRN = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["Premium"].ToString());
                            double depositRN = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][2]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeRN, premiumRN, totalDeposit, depositRN, depositRate, interestRate));
                            string providerCodeRP = jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["ProviderCode"].ToString();
                            double premiumRP = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["Premium"].ToString());
                            double depositRP = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][3]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeRP, premiumRP, totalDeposit, depositRP, depositRate, interestRate));
                            string providerCodeRW = jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["ProviderCode"].ToString();
                            double premiumRW = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["Premium"].ToString());
                            double depositRW = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][4]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeRW, premiumRW, totalDeposit, depositRW, depositRate, interestRate));
                            string providerCodeRV = jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["ProviderCode"].ToString();
                            double premiumRV = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["Premium"].ToString());
                            double depositRV = double.Parse(jResponseQuoteBody["ResultObj"]["OptionalExtras"][5]["Deposit"].ToString());
                            lstResultObject.Add(new ResultObject(sessionId, webReference, schemeCode, totalPremium, providerCodeRV, premiumRV, totalDeposit, depositRV, depositRate, interestRate));

                        }
                        //Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                Debug.WriteLine("Get quote unsuccessfull");
            }

            return lstResultObject;
        }

        public static string GetProviderCode(string prepurchaseRequestBodyName)
        {
            string providerCode = "";
            return providerCode;
        }

        public static string SetupRequestForSavePaymentInfoNormalCase(string _contextName, ParametersForRequest lstPara, string sessionId, List<ResultObject> lstResultObject, double totalPremiumInQuote)
        {
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);

            List<double> lstPremium = new List<double>();
            lstPremium = PrepurchaseFunctions.GetListPremium(_contextName, jsonBody, lstResultObject);
            int totalAmount = (int)PrepurchaseFunctions.TotalAmountToPay(totalPremiumInQuote, lstPremium);
            jsonBody = jsonBody.Replace("<TotalAmount>", totalAmount.ToString());
            return jsonBody;
        }
        public static string SetupRequestForSavePaymentInfoInstalment(string _contextName, ParametersForRequest lstPara, string sessionId, List<ResultObject> lstResultObject, double totalDepositInQuote)
        {
            var jsonBody = PrepurchaseFunctions.CreateRequestBodyNormalCase(sessionId, lstPara.ResourcePath);

            List<double> lstDeposit = new List<double>();
            lstDeposit = PrepurchaseFunctions.GetListDeposit(_contextName, jsonBody, lstResultObject);
            int totalAmount = (int)PrepurchaseFunctions.TotalAmountDeposit(totalDepositInQuote, lstDeposit);
            jsonBody = jsonBody.Replace("<TotalAmount>", totalAmount.ToString());
            return jsonBody;
        }
    }
}
