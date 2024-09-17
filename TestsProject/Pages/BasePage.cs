using NLog;
using TestProject.Core;

namespace AlineRevenueRMS_QA.Pages
{
    public abstract class BasePage
    {
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();
        protected WebElementWrapper Wrap = new WebElementWrapper();
        protected PageFactory Pages = new PageFactory();

        public BasePage() {}
    }
}
