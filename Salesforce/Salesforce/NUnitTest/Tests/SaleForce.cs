using OpenQA.Selenium.DevTools.V110.Browser;
using Salesforce.Core.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.NUnitTest.Tests
{
    public class SaleForce
    {
        [Test]
        public void Test()
        {
            Browser.Instance.NavigateToUrl("https://d7q00000d1c9duar.lightning.force.com/lightning/page/home");
        }
    }
}
