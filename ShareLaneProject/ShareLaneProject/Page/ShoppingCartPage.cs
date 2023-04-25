using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Page
{
    internal class ShoppingCartPage : BasePage
    {
        By ShoppingCartLinkLocator = By.LinkText("Shopping Cart");
        By QuantityInputLocator = By.Name("q");
        By UpdateButtonLocator = By.XPath("//input[@value='Update']");
        By ProceedToCheckoutButtonLocator = By.XPath("//input[@value='Proceed to Checkout']");
        By PriceLocator = By.XPath("//tr[2]/td[4]");
        By DiscountPercentagesLocator = By.XPath("//td[5]/p/b");
        By DiscountValueLocator = By.XPath("//tr[2]/td[6]");
        By TotalLocator = By.XPath("//tr[2]/td[7]");

        public ShoppingCartPage(WebDriver driver) : base(driver) { }

        public void ClickShoppingCart()
        {
            ChromeDriver.FindElement(ShoppingCartLinkLocator).Click();
        }

        void SetQuantity(string quantity)
        {
            ChromeDriver.FindElement(QuantityInputLocator).Clear();
            ChromeDriver.FindElement(QuantityInputLocator).SendKeys(quantity);
        }

        void ClickUpdate()
        {
            ChromeDriver.FindElement(UpdateButtonLocator).Click();
        }

        public void ClickProceedToCheckOut()
        {
            ChromeDriver.FindElement(ProceedToCheckoutButtonLocator).Click();
        }

        public string GetPrice()
        {
            return ChromeDriver.FindElement(PriceLocator).Text;
        }

        public string GetDiscountPercentages()
        {
            return ChromeDriver.FindElement(DiscountPercentagesLocator).Text;
        }

        public string GetDiscountValue()
        {
            return ChromeDriver.FindElement(DiscountValueLocator).Text;
        }

        public string GetTotal()
        {
            return ChromeDriver.FindElement(TotalLocator).Text;
        }

        public void AddToCart(string quantity)
        {
            new MainPage(ChromeDriver).ClickNameOfBook();
            new BookPage(ChromeDriver).ClickAddToCardButton();
            ClickShoppingCart();
            SetQuantity(quantity);
            ClickUpdate();
        }
    }
}
