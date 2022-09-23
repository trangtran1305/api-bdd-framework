using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectCore.ApiCore.Helper
{
    public static class JsonHelper
    {
        public static void EditValue(JObject jsonInput, List<string> fieldNames, string value)
        {
            string path = GetPath(jsonInput, fieldNames);
            var jTokenValues = jsonInput.SelectTokens(path);
            var jTokenValue = jTokenValues.FirstOrDefault();

            if (value.Equals("missing"))
            {
                RemoveField(jsonInput, path);
            }
            else if (value.Equals("[]"))
            {
                var arr = (JArray)jTokenValue;
                arr.RemoveAll();
            }
            else if (jTokenValue is JArray && !value.Equals("null"))
            {
                List<JToken> lstValue = jTokenValue.ToList();
                int countArray = lstValue.Count();
                foreach (var item in lstValue)
                {
                    if (countArray != 1)
                    {
                        item.Remove();
                        countArray = countArray - 1;
                    }
                    else
                        break;
                }
                jTokenValue[0].Replace(value);
            }
            else
            {
                var convertedValue = ConvertFieldValue(value);
                IEnumerable<JToken> jsonObject = jsonInput.SelectTokens(path);
                foreach (var item in jsonObject)
                {
                    item.Replace(convertedValue);
                }
            }

        }
        public static Boolean EditValueValidation(JObject jsonInput, List<string> fieldNames, string value)
        {
            Boolean isPathExist = true;
            string path = GetPath(jsonInput, fieldNames);
            if (path == "")
            {
                isPathExist = false;
            } else
            {
                
                    var jTokenValues = jsonInput.SelectTokens(path);
                    var jTokenValue = jTokenValues.FirstOrDefault();
                    if (value.Equals("missing"))
                    {
                        RemoveField(jsonInput, path);
                    }
                    else if (value.Equals("[]"))
                    {
                        var arr = (JArray)jTokenValue;
                        arr.RemoveAll();
                    }
                    else if (jTokenValue is JArray && !value.Equals("null"))
                    {
                        List<JToken> lstValue = jTokenValue.ToList();
                        int countArray = lstValue.Count();
                        foreach (var item in lstValue)
                        {
                            if (countArray != 1)
                            {
                                item.Remove();
                                countArray = countArray - 1;
                            }
                            else
                                break;
                        }
                        jTokenValue[0].Replace(value);

                    }
                    else
                    {
                        string convertedValue = ConvertFieldValue(value);
                        IEnumerable<JToken> jsonObject = jsonInput.SelectTokens(path);

                        jsonObject.First().Replace(convertedValue);
                    }
                            
            }
            
            return isPathExist;

        }

        public static string GetPath(JObject requestBody, List<string> fieldNames)
        {
            string path = ""; 
            try
            {
                JToken body = requestBody.SelectToken("");
                foreach (string item in fieldNames)
                {
                    path += "." + item;
                    body = body.SelectToken(item);
                
                    if (body.Type == JTokenType.Array)
                    {
                        path += "[*]";
                        body = body.First;
                    }
                }
                if (path.Substring(path.Length - 3) == "[*]")
                {
                    path = path.Substring(0, path.Length - 3);
                }
                path = path.Substring(1);
            }
            catch (Exception ex)
            {
                path = "";
            }
            return path;
        }

        private static string ReplaceHolder(this string text, string find, string replace)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var pattern = $@"""<<{find}>>""";
            if (text.Contains(pattern))
                text = text.Replace(pattern, replace != null ? $@"""{replace}""" : "null");

            pattern = $@"<<{find}>>";
            if (text.Contains(pattern))
                text = text.Replace(pattern, replace ?? string.Empty);

            return text;
        }

        public static string ReplaceHolder(this string text, object o)
        {
            var props = o
                .GetType()
                .GetProperties();

            foreach (var prop in props)
            {
                var value = prop.GetValue(o, null);

                text = text.ReplaceHolder(prop.Name, value.ToString());
            }

            text = Regex.Replace(text, @"""<<[a-zA-Z0-9-]+>>""", "null");
            text = Regex.Replace(text, @"<<[a-zA-Z0-9-]+>>", string.Empty);

            return text;
        }
        private static void RemoveField(JObject jsonInput, string path)
        {

            IEnumerable<JToken> jsonObject = jsonInput.SelectTokens(path);
            foreach (var item in jsonObject)
            {
                item.Parent.Remove();
            }
            var s = jsonInput.ToString(Formatting.None);
            jsonInput = JObject.Parse(s);

        }
        private static string ConvertFieldValue(string value)
        {
            string convertedValue = "";
            switch (value)
            {
                case "null":
                    {
                        convertedValue = null;
                        break;
                    }
                case "\"\"":
                    {
                        convertedValue = "";
                        break;
                    }
                case "'-":
                    {
                        convertedValue = "";
                        break;
                    }
                case "[]":
                    {
                        convertedValue = @"[]";
                        break;
                    }


                default:
                    convertedValue = value;
                    break;
            }

            if (value.Contains("'-"))
            {
                convertedValue = value.Replace("'", "");
            }
            return convertedValue;
        }
    }
}

