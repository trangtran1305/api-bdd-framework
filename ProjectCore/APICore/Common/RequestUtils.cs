using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectCore.ApiCore.Common
{
   public class RequestUtils
    {
        public Request myRequest { get; set; }

        //public IConfiguration Configuration { get; set; }

        public Tuple<string, HttpStatusCode> SendRequest(string method, string url, Dictionary<string, string> headerDict = null, string requestResource = null, string contentType = "application/json;charset=\"utf-8\"")
        {
            Console.WriteLine("SendRequest URL: " + url);

            Request request = new Request();

            Console.WriteLine("SendRequest: " + url);

            switch (method)
            {
                case HttpMethod.Post:
                    request = SendPostRequest(url, headerDict, requestResource, contentType);
                    break;

                case HttpMethod.Get:
                    request = SendGetRequest(url, headerDict, contentType);
                    break;

                case HttpMethod.Put:
                    request = SendPutRequest(url, headerDict, requestResource, contentType);
                    break;
            }

            return new Tuple<string, HttpStatusCode>(request.ResponseBody, request.StatusCode);
        }

        public Tuple<string, HttpStatusCode> SendRequest(string method, string url, string jsonBody, Dictionary<string, string> headerDict = null, string contentType = "application/json;charset=\"utf-8\"")
        {
            Console.WriteLine("SendRequest: " + url);

            Request request = new Request();

            switch (method)
            {
                case HttpMethod.Post:
                    request = SendPostRequest(url, jsonBody, headerDict);
                    break;

                case HttpMethod.Get:
                    request = SendGetRequest(url, headerDict, contentType);
                    break;

                case HttpMethod.Put:
                    request = SendPutRequest(url, jsonBody, headerDict, contentType);
                    break;
            }

            return new Tuple<string, HttpStatusCode>(request.ResponseBody, request.StatusCode);
        }

        private Request SendPostRequest(string url, Dictionary<string, string> headerDict = null, string jsonFilePath = null, string contentType = null)
        {

            Console.WriteLine("SendPostRequest: " + url);

            myRequest = CreatePostRequest(url, headerDict, contentType);

            if (jsonFilePath != null)
            {
                myRequest.LoadRequestBodyJson(jsonFilePath);
            }

            myRequest.SendRequestJson();
            return myRequest;
        }

        private Request SendPostRequest(string url, string jsonBody = null, Dictionary<string, string> headerDict = null, string contentType = null)
        {

            Console.WriteLine("SendPostRequest: " + url);

            myRequest = CreatePostRequest(url, headerDict, contentType);

            if (jsonBody != null)
            {
                myRequest.AddBody(jsonBody);
            }

            myRequest.SendRequestJson();
            return myRequest;
        }

        private Request CreatePostRequest(string url, Dictionary<string, string> headerDict, string contentType = null)
        {
            Console.WriteLine("CreatePostRequest: " + url);

            myRequest = new Request()
                                  .CreateWebRequest(url, "")
                                  .Accept("application/json")
                                  .ContentType(contentType)
                                  .Method("POST");

            if (headerDict != null)
            {
                AddHeaders(myRequest, headerDict);
            }
            return myRequest;
        }

        private Request SendGetRequest(string url, Dictionary<string, string> headerDict = null, string contentType = null)
        {
            Console.WriteLine("SendGetRequest: " + url);


            myRequest = new Request()
                                .CreateWebRequest(url, "")
                                .ContentType(contentType);
            if (headerDict != null)
            {
                AddHeaders(myRequest, headerDict);
            }

            myRequest.SendRequestJson();

            return myRequest;
        }

        private Request SendPutRequest(string url, Dictionary<string, string> headerDict = null, string jsonFilePath = null, string contentType = null)
        {
            Console.WriteLine("SendPutRequest: " + url);

            myRequest = createPutRequest(url, headerDict, contentType);
            if (jsonFilePath != null)
            {
                myRequest.LoadRequestBodyJson(jsonFilePath);
            }

            myRequest.SendRequestJson();
            return myRequest;
        }

        private Request SendPutRequest(string url, string jsonBody = null, Dictionary<string, string> headerDict = null, string contentType = null)
        {
            Console.WriteLine("SendPutRequest: " + url);

            myRequest = createPutRequest(url, headerDict, contentType);
            if (jsonBody != null)
            {
                myRequest.AddBody(jsonBody);
            }

            myRequest.SendRequestJson();
            return myRequest;
        }

        private Request createPutRequest(string url, Dictionary<string, string> headerDict, string contentType)
        {
            Console.WriteLine("createPutRequest: " + url);

            myRequest = new Request()
                                .CreateWebRequest(url, "")
                                .Accept("application/json")
                                .ContentType(contentType)
                                .Method("PUT");
            if (headerDict.Count > 0)
            {
                AddHeaders(myRequest, headerDict);
            }
            return myRequest;
        }

        private void AddHeaders(Request myRequest, Dictionary<string, string> headerDict)
        {
            if (headerDict.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in headerDict)
                {
                    myRequest.AddHeader(item.Key, item.Value);
                }
            }
        }

        public string getResponseValue(HttpWebResponse response, String key)
        {
            string responseValue = null;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                var details = JObject.Parse(responseText);
                responseValue = details[key].ToString();
            }
            return responseValue;
        }

        public string getResponseBody(HttpWebResponse response)
        {
            string responseValue = null;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                responseValue = reader.ReadToEnd();
            }
            return responseValue;
        }

        public string GetMessageContent(string message)
        {
            var resultMessage = "";
            if (message.Contains(". Path"))
            {
                var messageArr = message.Split(". Path");
                var removedMessage = "Path" + messageArr[messageArr.Length - 1].ToString();
                var replacedMessage = message.Replace(removedMessage, "");
                resultMessage = Regex.Replace(replacedMessage, @"[^0-9a-zA-Z.]+", " ").Trim();
            }
            else
            {
                resultMessage = Regex.Replace(message, @"[^0-9a-zA-Z.,]+", " ").Trim();
            }
            return resultMessage;
        }

        public string CopyJsonFile(string originalFilePath, string tempFileName)
        {
            string tempFilePath = string.Empty;

            if (File.Exists(originalFilePath))
            {
                string path = Path.GetDirectoryName(originalFilePath);
                tempFilePath = Path.Combine(path, tempFileName);
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
                File.Copy(originalFilePath, tempFilePath);
            }
            return tempFilePath;
        }
        public Dictionary<string, string> GetHeader(string context, string authorization = null)
        {
            var headerDict = new Dictionary<string, string>();
            headerDict.Add("Context", context);
            headerDict.Add("Content-Type", "application/json");
            if (authorization != null)
            {
                headerDict.Add("Authorization", authorization);
            }

            return headerDict;
        }
    }
}
