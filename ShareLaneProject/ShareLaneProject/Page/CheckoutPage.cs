using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Page
{
    internal class CheckoutPage : BasePage
    {
        By CardNumberInputLocator = By.Name("card_number");
        By MakePaymentButtonLocator = By.XPath("//input[@value='Make Payment']");
        By ConfirmMessageLocator = By.XPath("//font/b");
        By ConfirmMessage2Locator = By.CssSelector("span.error_message");

        public CheckoutPage(WebDriver driver) : base(driver) { }

        void SetCardNumber(string cardNumber)
        {
            ChromeDriver.FindElement(CardNumberInputLocator).SendKeys(cardNumber);
        }

        void ClickMakePayment()
        {
            ChromeDriver.FindElement(MakePaymentButtonLocator).Click();
        }

        public string GetConfirmMessage()
        {
            return ChromeDriver.FindElement(ConfirmMessageLocator).Text;
        }

        public string GetConfirmMessage2()
        {
            return ChromeDriver.FindElement(ConfirmMessage2Locator).Text;
        }

        public void MakeAPayment(string cardNumber)
        {
            new MainPage(ChromeDriver).ClickNameOfBook();
            new BookPage(ChromeDriver).ClickAddToCardButton();
            new ShoppingCartPage(ChromeDriver).ClickShoppingCart();
            new ShoppingCartPage(ChromeDriver).ClickProceedToCheckOut();
            SetCardNumber(cardNumber);
            ClickMakePayment();
        }
    }
}
