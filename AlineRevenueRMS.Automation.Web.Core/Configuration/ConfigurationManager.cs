using Microsoft.Extensions.Configuration;

namespace AlineRevenueRMS.Automation.Web.Core.Configuration
{
    public static class ConfigurationManager
    {
        public static T GetConfiguration<T>()
        {
            return GetConfiguration().Get<T>()!;
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }
    }
}
