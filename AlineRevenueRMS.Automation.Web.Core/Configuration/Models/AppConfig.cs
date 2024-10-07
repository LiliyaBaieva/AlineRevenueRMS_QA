namespace AlineRevenueRMS.Automation.Web.Core.Configuration.Models
{
    public class AppConfig
    {
        public Uri BaseUrl { get; set; } = null!;
        public bool HeadlessMode { get; set; } = true;
        public int PollingIntervalMilliseconds { get; set; }
        public int TimeoutSeconds { get; set; }
        public List<User> Users { get; set; } = null!;
    }
}
