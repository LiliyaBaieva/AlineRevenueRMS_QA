using AlineRevenueRMS.Automation.Web.Core.Conditions;
using AlineRevenueRMS.Automation.Web.Tests.Pages;
using AlineRevenueRMS.Automation.Web.Tests.Tests.Base;
using NUnit.Framework;

namespace AlineRevenueRMS.Automation.Web.Tests.Tests
{
    public class SampleTest : BaseLogin
    {
        public SampleTest() : base(1)
        {
        }

        [Test]
        public void TestObject_Action_ExpectedResult()
        {
            LoginPage.TenantCollectionValidateWarning.Should(Be.Visible);
        }
    }
}
