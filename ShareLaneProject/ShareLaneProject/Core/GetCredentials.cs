using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V110.WebAudio;
using SharelaneAutomation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Core
{
    internal class GetCredentials : BasePage
    {
        By EmailLocator = By.XPath("//td[2]/b");
        By CardNumberLocator = By.CssSelector("b");

        public GetCredentials(WebDriver driver) : base(driver) { }

        void GoToUrlForGetCredsForLogin()
        {
            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/register.py?page=2&zip_code=123123&first_name=dwqd&last_name=qwqdw&email=wqewq%40qwe.qwe&password1=123123qwe&password2=123123qwe");
        }

        void GoToUrlForGetCredsForCard()
        {
            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/get_credit_card.py?type=1");
        }

        string GetEmail()
        {
            return ChromeDriver.FindElement(EmailLocator).Text;
        }

        string GetCardNumber()
        {
            return ChromeDriver.FindElement(CardNumberLocator).Text;
        }

        public string SetEmail()
        {
            GoToUrlForGetCredsForLogin();
            return GetEmail();
        }

        public string SetCardNumber()
        {
            GoToUrlForGetCredsForCard();
            return GetCardNumber();
        }
    }
}
