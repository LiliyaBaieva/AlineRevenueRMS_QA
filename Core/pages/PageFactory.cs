using Core.pages;
using OpenQA.Selenium;

namespace AlineRevenueRMS_QA.Pages
{
    public class PageFactory
    {
        public PageFactory() { }

        public LoginPage GetLoginPage => new LoginPage();
        public EleganceAppPage GetEleganceAppPage => new EleganceAppPage();
        public EleganceRmsHomePage GetEleganceRmsHomePage => new EleganceRmsHomePage();
 

    }
}
