using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace sell.webapi.Common.Config
{
    public class ConfigHelper : Singleton<ConfigHelper>
    {
        private IConfigurationRoot Config { get; set; }
        public ConfigHelper()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载      
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            //.AddJsonFile($"appsettings.{Kernel.Environment}.json", optional: true);
            Config = builder.Build();
        }

        public string GetConfig(string name)
        {
            try
            {
                return Config.GetSection(name).Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
