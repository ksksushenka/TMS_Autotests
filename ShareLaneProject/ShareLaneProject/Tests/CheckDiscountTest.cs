using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Tests
{
    internal class CheckDiscountTest : BaseTest
    {
        ShoppingCartPage ShoppingCartPage { get; set; }
        LoginPage LoginPage { get; set; }
        GetСredentials GetСredentials { get; set; }

        [SetUp]
        public void Setup()
        {
            ShoppingCartPage = new ShoppingCartPage(ChromeDriver);
            LoginPage = new LoginPage(ChromeDriver);
            GetСredentials = new GetСredentials(ChromeDriver);

            string email = GetСredentials.SetEmail();
            string password = "1111";

            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            LoginPage.Login(email, password);
        }

        [TestCase("2", 2)]
        [TestCase("5", 3)]
        [TestCase("10", 4)]
        [TestCase("50", 5)]
        [TestCase("100", 6)]
        [TestCase("500", 7)]
        [TestCase("1000", 8)]
        public void CheckDiscount(string quantity, int discountPercentagesCurrent)
        {
            ShoppingCartPage.AddToCart(quantity);

            decimal price = Convert.ToDecimal(ShoppingCartPage.GetPrice());
            decimal discountPercentages = Convert.ToDecimal(ShoppingCartPage.GetDiscountPercentages());
            decimal discountValue = Convert.ToDecimal(ShoppingCartPage.GetDiscountValue());
            decimal total = Convert.ToDecimal(ShoppingCartPage.GetTotal());
            decimal quantityCurremnt = Convert.ToDecimal(quantity);

            decimal discountValueCurrent = quantityCurremnt * price / 100 * discountPercentagesCurrent;
            decimal totalCurrent = quantityCurremnt * price - discountValueCurrent;

            Assert.That(discountPercentages, Is.EqualTo(discountPercentagesCurrent));
            Assert.That(discountValue, Is.EqualTo(discountValueCurrent));
            Assert.That(total, Is.EqualTo(totalCurrent));
        }
    }
}
