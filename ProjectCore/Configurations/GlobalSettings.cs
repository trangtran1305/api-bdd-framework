using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjectCore.Configurations
{
    public class GlobalSettings
    {
        public string BaseUrl { get; set; }
        public WaitTimeSettings WaitTimeSettings { get; set; }
        public Browser Browser { get; set; }
        public string LogFolderName { get; set; }
        public string ReportFolderName { get; set; }
        public APISetting APISetting { get; set; }

        public List<ConnectionString> ConnectionStrings { get; set; }
        public AzureKeyVault AzureKeyVault { get; set; }
    }

    public class ConnectionString
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ConnectionStrings
    {
        public string UIAtlantaDb { get; set; }
        public string UIDVLACacheDb { get; set; }
    }

    public class AzureKeyVault
    {
        public string Url { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationSecret { get; set; }
    }

    public class APISetting
    {
        public string APIBaseUrl { get; set; }
        public List<Context> ContextList { get; set; }
    }

    public class Context
    {
        public string ContextName { get; set; }
        public string Value { get; set; }
        public string BaseUrl { get; set; }
    }

    public class Browser
    {
        public List<DriverTypeName> DriverTypeList { get; set; }        
    }

    public class Argument
    {
        public string ArgumentName { get; set; }
    }

    public class UserProfilePreference
    {
        public string Name { get; set; }
        public bool Value { get; set; }
    }

    public class DriverTypeName
    {
        public string Name { get; set; }
        public string Value { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public List<UserProfilePreference> UserProfilePreferences { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public List<Argument> Arguments { get; set; }
    }

    public class WaitTimeSettings
    {
        public uint Regular { get; set; }
        public uint SemiLong { get; set; }
        public uint Long { get; set; }
    }

}