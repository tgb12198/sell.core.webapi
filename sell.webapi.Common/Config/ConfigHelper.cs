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

        public T GetAppSettings<T>(string key) where T : class, new()
        {
            //var appconfig = new ServiceCollection()
            //.AddOptions()
            //.Configure<T>(Config.GetSection(key))
            //.BuildServiceProvider()
            //.GetService<IOptions<T>>()
            //.Value;
            //return appconfig;
            return null;
        }

        public string GetConfig(string name)
        {
            try
            {
                foreach (var item in Config.Providers)
                {
                    //var conn = item.
                }
                
                return Config.GetSection("connectionString").Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class MyServiceProvider
    {
        public static IServiceProvider ServiceProvider { get; set; }
    }
}
