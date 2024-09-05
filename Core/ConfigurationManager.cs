using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Core
{
    public static class ConfigurationManager
    {
        private static IConfiguration _configuration;

        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                    _configuration = builder.Build();
                }

                return _configuration;
            }

        }
    }
}
