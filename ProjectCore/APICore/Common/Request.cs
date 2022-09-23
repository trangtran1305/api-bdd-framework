using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace ProjectCore.ApiCore.Common
{
   public class Request
    {
        private XmlDocument requestXml { get; set; }
        private String requestBody { get; set; }
        private HttpWebRequest webRequest { get; set; }
        public String ResponseBody { get; set; }
        public HttpWebResponse Response { get; set; }

        public HttpStatusCode StatusCode { set; get; }

        public Request()
        {
            requestXml = null;
            webRequest = null;
            requestBody = null;
            ResponseBody = "";
            Response = null;
        }

        public Request AddHeader(string headerName, string value)
        {
            webRequest.Headers.Add(headerName, value);
            return this;
        }

        public Request AddBody(string body)
        {
            requestBody = body;
            return this;
        }

        public Request ContentType(string value)
        {
            webRequest.ContentType = value;
            return this;
        }

        public Request Method(string methodType)
        {
            webRequest.Method = methodType;
            return this;
        }

        public Request Accept(string value)
        {
            webRequest.Accept = value;
            return this;
        }

        public Request CreateWebRequest(string url, string action)
        {
            webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            return this;
        }

        public Request CreateWebRequest(string url)
        {
            webRequest = (HttpWebRequest)WebRequest.Create(url);
            return this;
        }

        public Request LoadRequestBody(string path, params string[] numbers)
        {
            requestXml = new XmlDocument();
            requestXml.Load(path);
            var parsedPayLoad = String.Format(requestXml.OuterXml, numbers);
            requestXml.LoadXml(parsedPayLoad);
            return this;
        }

        public Request LoadRequestBodyJson(string path)
        {
            string readContents;
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd();
            }
            requestBody = readContents;

            return this;
        }

        public static void AddRequestBodyToRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        public Request SendRequestXml()
        {
            //HttpWebRequest webRequest = CreateWebRequest(url, action);
            if (requestXml != null)
            {
                AddRequestBodyToRequest(requestXml, webRequest);
            }
            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            //using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncResult))
            Response = (HttpWebResponse)webRequest.EndGetResponse(asyncResult);
            using (StreamReader rd = new StreamReader(Response.GetResponseStream()))
            {
                ResponseBody = rd.ReadToEnd();
            }

            return this;
            //return soapResult;
        }

        public Request SendRequestJson()
        {
            //HttpWebRequest webRequest = CreateWebRequest(url, action);
            if (requestBody != null)
            {
                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamWriter.Write(requestBody);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            try
            {
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

                asyncResult.AsyncWaitHandle.WaitOne();

                Response = (HttpWebResponse)webRequest.EndGetResponse(asyncResult);
                using (StreamReader rd = new StreamReader(Response.GetResponseStream()))
                {
                    this.ResponseBody = rd.ReadToEnd();
                }
                this.StatusCode = Response.StatusCode;
            }
            catch (WebException ex)
            {
                //this.Response = (HttpWebResponse)ex.Response;
                try
                {
                    using (WebResponse response = ex.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        using (Stream data = response.GetResponseStream())
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            this.ResponseBody = text;
                            this.StatusCode = httpResponse.StatusCode;
                        }
                        this.Response = httpResponse;
                    }
                }
                catch
                {
                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.User);

                    throw new Exception(
                        ex.Message
                        + "\nEnvironment: " + environment
                        + "\nUrl: " + webRequest.RequestUri
                        + "\nMethod :" + webRequest.Method
                        + "\nContentType: " + webRequest.ContentType
                        + "\nRequest body: " + requestBody
                        + "\nResponse body: " + ResponseBody
                        + "\nStatus Code: " + StatusCode
                        );
                }
            }
            return this;
        }

        public XmlNode ExtractXML(string xpath)
        {
            /*int markedIndex = 0;
            int currentIndex = 0;
            while (true)
            {
                currentIndex = XML.IndexOf("xmlns", markedIndex);
                if (currentIndex == -1)
                {
                    break;
                }
                else
                {
                    markedIndex = currentIndex + 5;
                }
                int start = XML.IndexOf(":", currentIndex) + 1;
                int end = XML.IndexOf("=", currentIndex);
                String x = XML.Substring(start, end - start);
                Console.WriteLine(x);
            }*/
            XmlDocument XmlDataDocument = new XmlDocument();
            XmlDataDocument.LoadXml(this.ResponseBody);
            //XmlNamespaceManager manager = new XmlNamespaceManager(XmlDataDocument.NameTable);
            //manager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            //manager.AddNamespace("ns1", "http://thomas-bayer.com/blz/");
            return XmlDataDocument.SelectSingleNode(xpath);
        }

        public string GetResponseAsString()
        {
            return ResponseBody;
        }

        public HttpWebResponse GetResponse()
        {
            return Response;
        }

        private HttpWebResponse CallRequest(IAsyncResult asyncResult)
        {
            return (HttpWebResponse)webRequest.EndGetResponse(asyncResult);
        }
    }
}
