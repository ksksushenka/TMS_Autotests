using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Page
{
    internal class SearchPage : BasePage
    {
        By SearchInputLocator = By.Name("keyword");
        By SearchButtonLocator = By.XPath("//input[@value='Search']");
        By ConfirmMessageLocator = By.CssSelector("span.confirmation_message");

        public SearchPage(WebDriver driver) : base(driver) { }

        void SetSearch(string search)
        {
            ChromeDriver.FindElement(SearchInputLocator).SendKeys(search);
        }

        void ClickSearch()
        {
            ChromeDriver.FindElement(SearchButtonLocator).Click();
        }

        public string GetConfirmMessage()
        {
            return ChromeDriver.FindElement(ConfirmMessageLocator).Text;
        }

        public BookPage Search(string search)
        {
            SetSearch(search);
            ClickSearch();

            return new BookPage(ChromeDriver);
        }
    }
}
