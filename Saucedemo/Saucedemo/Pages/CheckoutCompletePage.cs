﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BaseEntities;

namespace Tests.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private static string END_POINT = "checkout-complete.html";

        private static readonly By BackHomeButtonBy = By.Id("back-to-products");
        private static readonly By SuccessMessageBy = By.ClassName("complete-header");

        public CheckoutCompletePage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutCompletePage(IWebDriver? driver) : base(driver, false)
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
                return SuccessMessage().Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement SuccessMessage()
        {
            return Driver.FindElement(SuccessMessageBy);
        }

        public string GetSuccessMessage()
        {
            return Driver.FindElement(SuccessMessageBy).Text;
        }

        void ClickBackHome()
        {
            Driver.FindElement(BackHomeButtonBy).Click();
        }

        public InventoryPage ReturnToHomePage()
        {
            ClickBackHome();
            return new InventoryPage(Driver);
        }
    }
}
