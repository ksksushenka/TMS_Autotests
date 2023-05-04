using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Core;
using SharelaneAutomation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Tests
{
    internal class OrderBook : BaseTest
    {
        ShoppingCartPage ShoppingCartPage { get; set; }
        LoginPage LoginPage { get; set; }
        GetCredentials GetСredentials { get; set; }
        CheckoutPage CheckoutPage { get; set; }

        [SetUp]
        public void Setup()
        {
            ShoppingCartPage = new ShoppingCartPage(ChromeDriver);
            LoginPage = new LoginPage(ChromeDriver);
            GetСredentials = new GetCredentials(ChromeDriver);
            CheckoutPage = new CheckoutPage(ChromeDriver);

            string email = GetСredentials.SetEmail();
            string password = "1111";

            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            LoginPage.Login(email, password);
        }

        [Test]
        public void OrberBook_ValidData()
        {
            string cardNumber = GetСredentials.SetCardNumber();
            string message = "Thank you for your order!!!";

            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            CheckoutPage.MakeAPayment(cardNumber);

            Assert.That(CheckoutPage.GetConfirmMessage(), Is.EqualTo(message));
        }

        [Test]
        public void OrberBook_InvalidData()
        {
            string cardNumber = "1234567891234567";
            string message = "Oops, error. Invalid card number or not enough balance for purchase";

            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            CheckoutPage.MakeAPayment(cardNumber);

            Assert.That(CheckoutPage.GetConfirmMessage2(), Is.EqualTo(message));
        }
    }
}