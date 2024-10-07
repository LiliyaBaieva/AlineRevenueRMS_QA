using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace AlineRevenueRMS.Automation.Web.Core.Logger
{
    internal static class Logger
    {
        internal static void Initialize()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();
        }
    }
}
