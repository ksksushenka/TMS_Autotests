using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Page
{
    internal class SignUpPage : BasePage
    {
        By SignUpButtonLocator = By.LinkText("Sign up");
        By ZIPCodeInputLocator = By.Name("zip_code");
        By ContinueButtonLocator = By.XPath("//input[@value='Continue']");
        By FirstNameInputLocator = By.Name("first_name");
        By LastNameInputLocator = By.Name("last_name");
        By EmailInputLocator = By.Name("email");
        By PasswordInputLocator = By.Name("password1");
        By ConfirmPasswordInputLocator = By.Name("password2");
        By RegisterButtonLocator = By.XPath("//input[@value='Register']");
        By ConfirmMessageLocator = By.CssSelector("span.confirmation_message");

        public SignUpPage(WebDriver driver) : base(driver) { }

        void ClickSignUp()
        {
            ChromeDriver.FindElement(SignUpButtonLocator).Click();
        }

        void SetZIPCode(string zipCode)
        {
            ChromeDriver.FindElement(ZIPCodeInputLocator).SendKeys(zipCode);
        }

        void ClickContinue()
        {
            ChromeDriver.FindElement(ContinueButtonLocator).Click();
        }

        void SetFirstName(string firstName)
        {
            ChromeDriver.FindElement(FirstNameInputLocator).SendKeys(firstName);
        }

        void SetLastName(string lastName)
        {
            ChromeDriver.FindElement(LastNameInputLocator).SendKeys(lastName);
        }

        void SetEmail(string email)
        {
            ChromeDriver.FindElement(EmailInputLocator).SendKeys(email);
        }

        void SetPassword(string password)
        {
            ChromeDriver.FindElement(PasswordInputLocator).SendKeys(password);
        }

        void SetConfirmPassword(string confirmPassword)
        {
            ChromeDriver.FindElement(ConfirmPasswordInputLocator).SendKeys(confirmPassword);
        }

        void ClickRegister()
        {
            ChromeDriver.FindElement(RegisterButtonLocator).Click();
        }

        public string GetConfirmMessage()
        {
            return ChromeDriver.FindElement(ConfirmMessageLocator).Text;
        }

        public void SignUp(string zipCode, string firstName, string lastName, string email, string password, string confirmPassword)
        {
            ClickSignUp();
            SetZIPCode(zipCode);
            ClickContinue();
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password);
            SetConfirmPassword(confirmPassword);
            ClickRegister();
        }
    }
}
