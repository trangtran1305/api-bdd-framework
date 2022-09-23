using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ProjectCore.Configurations
{
    public class ConfigsBuilder
    {
        private readonly IConfiguration Configuration;
        
        public ConfigsBuilder()
        {
            var envVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.User);

            Console.WriteLine("[Environment]: " + envVariable + ". Current Dir: " + Directory.GetCurrentDirectory());

            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddJsonFile(envVariable != null ? $"appsettings.{envVariable}.json" : $"appsettings.Development.json", optional: true);
                   

            this.Configuration = builder.Build();
        }
        public GlobalSettings GetGlobalSettings()
        {
            return Configuration.GetSection("GlobalSettings").Get<GlobalSettings>();
        }        
        
    }

}
