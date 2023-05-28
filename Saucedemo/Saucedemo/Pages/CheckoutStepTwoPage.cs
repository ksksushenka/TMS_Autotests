using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BaseEntities;

namespace Tests.Pages
{
    public class CheckoutStepTwoPage : BasePage
    {
        private static string END_POINT = "checkout-step-two.html";

        private static readonly By FinishButtonBy = By.Id("finish");

        public CheckoutStepTwoPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("The Checkout Step Two page is opened.");
        }

        public CheckoutStepTwoPage(IWebDriver? driver) : base(driver, false)
        {
            _logger.Info("The Checkout Step Two page is opened.");
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(FinishButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void ClickFinish()
        {
            Driver.FindElement(FinishButtonBy).Click();
        }

        public CheckoutCompletePage TryToFinishOrder()
        {
            ClickFinish();
            return new CheckoutCompletePage(Driver);
        }
    }
}
