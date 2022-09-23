using ProjectCore.Configurations;
using System;

namespace ProjectCore.SQL
{
    public class SqlHelper
    {
        public TestConfigs _configs = new TestConfigs();

        public string GetConnectionString(string connectionName)
        {
            string connectionString = "";
            var connectStrings = _configs.GetGlobalSettings().ConnectionStrings;
            foreach (var connect in connectStrings)
            {
                if (connect.Name.Equals(connectionName))
                {
                    connectionString = connect.Value;
                }
            }

            connectionString = IsDevelopment() ? connectionString : GetKeyVault(connectionName);
            return connectionString;
        }

        public bool IsDevelopment()
        {
            var envVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.User);
            if (envVariable == null)
            {
                return true;
            }

            return "Development".Equals(envVariable);
        }

        public string GetKeyVault(string key)
        {
            string connectionValue = "";
            foreach (var connect in _configs.GetGlobalSettings().ConnectionStrings)
            {
                if (connect.Name.Equals(key))
                {
                    connectionValue = connect.Value;
                }
            }
            var clientId = _configs.GetGlobalSettings().AzureKeyVault.ApplicationId;
            var clientSecret = _configs.GetGlobalSettings().AzureKeyVault.ApplicationSecret;
            var baseUrl = _configs.GetGlobalSettings().AzureKeyVault.Url;

            var keyVaultCache = new KeyVaultCache(baseUrl + "secrets/", clientId, clientSecret);
            var cacheSecret = keyVaultCache.GetCachedSecret(connectionValue);

            return cacheSecret.Result;
        }
    }
}