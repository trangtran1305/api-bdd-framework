using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNRenewalPortal.Pages.ApiCall
{
    public class ApiCallPreparation
    {
        private static RequestUtils _testUtils = new RequestUtils();
        private static SpecflowHelper _specflowHelper = new SpecflowHelper();
        private static string token = null;
        public static string GetToken()
        {
            
            if (token != null) return token;
            string uri = "/api/token/authorize";
            string url = _specflowHelper.GetUrlByString(uri);
            var response = _testUtils.SendRequest(HttpMethod.Get, url);
            var jObjectResponse = JObject.Parse(response.Item1);
            token = jObjectResponse["token_type"].ToString() + " " + jObjectResponse["access_token"].ToString();

            return token;
        }
        public ResultObj LookUpDvla(string regNumber)
        {
            var authorization = GetToken();         
            var context = _specflowHelper.GetContextFromConfig("ScenicMotorHome");
            var header = _testUtils.GetHeader(context, authorization);
            var dvlaUrl = _specflowHelper.GetUrlByString(ServicesEndpoints.DvlaApi) + regNumber;
            var response = _testUtils.SendRequest(HttpMethod.Get, dvlaUrl,null,header);            
            var jObjectResponse = JObject.Parse(response.Item1);            
            var resultObj = JsonConvert.DeserializeObject<ResultObj>(jObjectResponse["ResultObj"][0].ToString());

            return resultObj;
        }
    }
    public class ServicesEndpoints
    {
        public static readonly string DvlaApi = "/api/V1/vehicle/lookup?RegistrationNumber=";
    }
    }
