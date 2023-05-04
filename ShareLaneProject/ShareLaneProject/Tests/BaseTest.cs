using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Tests
{
    internal class BaseTest
    {
        protected WebDriver ChromeDriver { get; set; }

        [SetUp]
        public void SetUp()
        {
            string browser = TestContext.Parameters.Get("Browser");

            switch(browser)
            {
                case "headless":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless");
                    break;
                default:
                    ChromeDriver = new ChromeDriver();
                    break;
            }

            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
