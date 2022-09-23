using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProjectCore.ApiCore.Common
{
    static class Constants
    {
        private static Dictionary<string, string> defaultConfiguration = new Dictionary<string, string>();
        static Constants()
        {
            defaultConfiguration.Add("path.resource", @".\Resources\");
        }
        private static string ParseConfiguration(string key, string defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            return value;
        }

        public static string GetConfiguration(string key)
        {
            if (defaultConfiguration.ContainsKey(key))
            {
                return ParseConfiguration(key, defaultConfiguration[key]);
            }

            var message = string.Format("Unsupported or invalid configuration attribute named [{0}]. Please make sure you have it in default configuration", key);
            throw new Exception(message);
        }

    }
}
