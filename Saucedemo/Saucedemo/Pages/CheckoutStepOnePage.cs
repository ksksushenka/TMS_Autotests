using Core.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BaseEntities;

namespace Tests.Pages
{
    public class CheckoutStepOnePage : BasePage
    {
        private static string END_POINT = "checkout-step-one.html";

        private static readonly By FirstNameInputBy = By.Id("first-name");
        private static readonly By LastNameInputBy = By.Id("last-name");
        private static readonly By ZipCodeInputBy = By.Id("postal-code");
        private static readonly By ContinueButtonBy = By.Id("continue");

        public CheckoutStepOnePage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutStepOnePage(IWebDriver? driver) : base(driver, false)
        {
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(ContinueButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void SetFirstName(string firstName)
        {
            Driver.FindElement(FirstNameInputBy).SendKeys(firstName);
        }

        void SetLastName(string lastName)
        {
            Driver.FindElement(LastNameInputBy).SendKeys(lastName);
        }

        void SetZipCode(string zipCode)
        {
            Driver.FindElement(ZipCodeInputBy).SendKeys(zipCode);
        }

        void ClickContinue()
        {
            Driver.FindElement(ContinueButtonBy).Click();
        }

        public CheckoutStepTwoPage TryToGoToStepTwo(User user)
        {
            SetFirstName(user.FirstName);
            SetLastName(user.LastName);
            SetZipCode(user.ZipCode);
            ClickContinue();
            return new CheckoutStepTwoPage(Driver);
        }
    }
}
