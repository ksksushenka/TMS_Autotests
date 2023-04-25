using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Page
{
    internal class LoginPage : BasePage
    {
        By EmailInputLocator = By.Name("email");
        By PasswordInputLocator = By.Name("password");
        By LoginButtonLocator = By.XPath("//input[@value='Login']");
        By ConfirmMessageLocator = By.CssSelector("span.user");

        public LoginPage(WebDriver driver) : base(driver) { }

        void SetEmail(string email)
        {
            ChromeDriver.FindElement(EmailInputLocator).SendKeys(email);
        }

        void SetPassword(string password)
        {
            ChromeDriver.FindElement(PasswordInputLocator).SendKeys(password);
        }

        void ClickLoginButton()
        {
            ChromeDriver.FindElement(LoginButtonLocator).Click();
        }

        public bool GetConfirmMessage()
        {
            return ChromeDriver.FindElement(ConfirmMessageLocator).Displayed;
        }

        public void Login(string email = "", string password = "")
        {
            SetEmail(email);
            SetPassword(password);
            ClickLoginButton();
        }
    }
}
