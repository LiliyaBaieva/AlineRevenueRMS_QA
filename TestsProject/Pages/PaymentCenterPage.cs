﻿using AlineRevenueRMS_QA.Pages;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AlineRevenueRMS_QA.Pages
{
    public class PaymentCenterPage : BasePage
    {
        public PaymentCenterPage(){}

        private By ACHpaymentsLink = By.XPath("//h5[contains(text(),'ACH payments')]");

        [AllureStep("Go to ACH payment")]
        public PaymentMenegementPage GoToACHpayment()
        {
            Wrap.Click(ACHpaymentsLink);
            logger.Info("Navigate to ACH payment");
            return new PaymentMenegementPage();

        }
    }
}