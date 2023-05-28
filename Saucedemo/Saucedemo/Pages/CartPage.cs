using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BaseEntities;

namespace Tests.Pages
{
    public class CartPage : BasePage
    {
        private static string END_POINT = "cart.html";

        private static readonly By CheckoutButtonBy = By.Id("checkout");

        public CartPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("The Cart page is opened.");
        }

        public CartPage(IWebDriver? driver) : base(driver, false)
        {
            _logger.Info("The Cart page is opened.");
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(CheckoutButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void ClickCheckoutButton()
        {
            Driver.FindElement(CheckoutButtonBy).Click();
        }

        public CheckoutStepOnePage Checkout()
        {
            ClickCheckoutButton();
            return new CheckoutStepOnePage(Driver);
        }
    }
}
