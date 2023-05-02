using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Page
{
    internal class BookPage : BasePage
    {
        By AddToCardButtonLocator = By.XPath("//p[2]/a/img");

        public BookPage(WebDriver driver) : base(driver) { }

        public bool GetAddToCardButton()
        {
            return ChromeDriver.FindElement(AddToCardButtonLocator).Displayed;
        }

        public void ClickAddToCardButton()
        {
            ChromeDriver.FindElement(AddToCardButtonLocator).Click();
        }
    }
}
