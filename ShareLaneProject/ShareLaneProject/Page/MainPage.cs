using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Page
{
    internal class MainPage : BasePage
    {
        By NameOfBookLocator = By.XPath("//td/table/tbody/tr[3]/td/a");

        public MainPage(WebDriver driver) : base(driver) { }

        public string GetNameOfBook()
        {
            return ChromeDriver.FindElement(NameOfBookLocator).Text;
        }

        public void ClickNameOfBook()
        {
            ChromeDriver.FindElement(NameOfBookLocator).Click();
        }
    }
}
