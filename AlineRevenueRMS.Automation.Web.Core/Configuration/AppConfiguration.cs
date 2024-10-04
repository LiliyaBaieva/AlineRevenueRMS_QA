using AlineRevenueRMS.Automation.Web.Core.Configuration.Models;
using static AlineRevenueRMS.Automation.Web.Core.Configuration.ConfigurationManager;

namespace AlineRevenueRMS.Automation.Web.Core.Configuration
{
    public static class AppConfiguration
    {
        static AppConfiguration()
        {
            Config = GetConfiguration<AppConfig>();
        }

        private static readonly AppConfig Config;

        public static Uri BaseUrl => Config.BaseUrl;
        public static List<User> Users => Config.Users;
        public static TimeSpan GetTimeout() => TimeSpan.FromSeconds(Config.TimeoutSeconds);
        public static TimeSpan GetPollingInterval() => TimeSpan.FromMilliseconds(Config.PollingIntervalMilliseconds);
    }
}
