using Newtonsoft.Json.Linq;
using ProjectCore.APICore.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectCore.ApiCore.Common
{
    public static class ResponseUtils
    {
        public static string GetResponseMessage(Tuple<string, HttpStatusCode> response)
        {
            string responseBody = response.Item1;
            var message = "";
            if (String.IsNullOrEmpty(responseBody))
            {
                Console.WriteLine("Response Body is null or empty! Response status: " + response.Item2);
                message = response.Item2.ToString();
            } else
            {
                var jResponseBody = JObject.Parse(responseBody);
                message = jResponseBody["Messages"].ToString();
                message = GetMessageContent(message);
            }
                        
            return message;
        }
        private static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ' || c == '-' || c == '/' || c == '~' || c == '\'' || c == '#' || c == '=' || c == ',' || c == '>')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Trim();
        }
        public static string GetMessageContent(string message)
        {
            var resultMessage = "";
            if (message.Contains(", line"))
            {
                var messageArr = message.Split(", line")[0];             
                resultMessage = messageArr.Replace("[\r\n  \"", "");
            }
            else
            {
               // var s = message.Split("\r\n");
                resultMessage = message.Replace("\"\r\n]", "").Replace("[\r\n  \"","");
                if(resultMessage.Contains("\",\r\n  \""))
                {
                   var s =  resultMessage.Replace("\",\r\n  \"", " ");
                    resultMessage = s;
                }
            }
            return resultMessage;
        }

        public static bool GetIsSuccess(Tuple<string, HttpStatusCode> response)
        {
            string respondBody = response.Item1;
            var jResponseBody = JObject.Parse(respondBody);
            return bool.Parse(jResponseBody["IsSuccess"].ToString());
        }

        public static VehicleLookUpVRN GetVehicleLookupVRN(Tuple<string, HttpStatusCode> response)
        {
            string responseBody = response.Item1;

            var jResponseBody = JObject.Parse(responseBody);
            var resultObj = jResponseBody["ResultObj"][0];
            return new VehicleLookUpVRN
            {
                Make = resultObj["Make"].ToString(),
                Model = resultObj["Model"].ToString(),
                Engine = resultObj["Engine"].ToString(),
                FromToYear = resultObj["FromToYear"].ToString(),
                ManufactureDate = resultObj["ManufactureDate"].ToString(),
                Fuel = resultObj["Fuel"].ToString(),
                Transmission = resultObj["Transmission"].ToString(),
                AbiCode = resultObj["AbiCode"].ToString(),
                CdlCode = resultObj["CdlCode"].ToString(),
                RegistrationDate = resultObj["RegistrationDate"].ToString()

            };
        }
        public static int GetResponseCode(Tuple<string, HttpStatusCode> response)
        {
            return (int)(response.Item2);
        }
    }
}
