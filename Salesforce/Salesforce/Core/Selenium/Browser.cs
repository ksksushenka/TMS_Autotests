using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Core.Selenium
{
    public class Browser
    {
        private static Browser instance = null;
        private IWebDriver driver;

        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }
                return instance;
            }
        }

        public IWebDriver Driver { get { return driver; } }

        private Browser()
        {

            var headless = Configuration.Browser.Headless;
            var t = TestContext.Parameters.Get("Browser");

            switch (TestContext.Parameters.Get("Browser").ToLower())
            {
                case "chrome":

                    if (bool.Parse(TestContext.Parameters.Get("Headless")!))
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");
                        driver = new ChromeDriver(options);
                    }
                    else
                    {
                        driver = new ChromeDriver();
                    }

                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void CloseTab()
        {
            driver.Close();
        }
    }
}
