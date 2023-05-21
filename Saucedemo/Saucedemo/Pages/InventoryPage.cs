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
    public class InventoryPage : BasePage
    {
        private static string END_POINT = "inventory.html";

        private static readonly By AddToCartBackpackButtonBy = By.Id("add-to-cart-sauce-labs-backpack");
        private static readonly By ShoppingCartIconBy = By.ClassName("shopping_cart_link");

        public InventoryPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public InventoryPage(IWebDriver? driver) : base(driver, false)
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
                return Driver.FindElement(AddToCartBackpackButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void ClickAddToCartBackpackButton()
        {
            Driver.FindElement(AddToCartBackpackButtonBy).Click();
        }

        void ClickAddToCartButton()
        {
            Driver.FindElement(ShoppingCartIconBy).Click();
        }

        public CartPage AddToCard()
        {
            ClickAddToCartBackpackButton();
            ClickAddToCartButton();
            return new CartPage(Driver);
        }
    }
}
