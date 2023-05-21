using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Salesforce.Core.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.NUnitTest.Pages
{
    internal abstract class BasePage
    {
        protected WebDriver Driver { get; set; }

        public BasePage(WebDriver driver)
        {
            Driver = driver;
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
