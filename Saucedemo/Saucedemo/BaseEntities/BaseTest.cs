using OpenQA.Selenium;
using Core;
using Core.Utilites.Configuration;
using OpenQA.Selenium.Chrome;
using Tests.Pages;

namespace Tests.BaseEntities
{
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected static IWebDriver? Driver;
        protected WaitService? WaitService;
        public LoginPage LoginPage { get; set; }
        public CheckoutCompletePage CheckoutCompletePage { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);

            LoginPage = new LoginPage(Driver);
            CheckoutCompletePage = new CheckoutCompletePage(Driver);
            LoginPage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }
    }
}
