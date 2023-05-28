using OpenQA.Selenium;
using Core;
using Core.Utilites.Configuration;
using OpenQA.Selenium.Chrome;
using Tests.Pages;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Framework.Interfaces;

namespace Tests.BaseEntities
{
    [AllureNUnit]
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected static IWebDriver? Driver;
        protected WaitService? WaitService;
        private AllureLifecycle _allure;
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

            _allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment(name: "Screenshot", type: "image/png", screenshotBytes);
            }

            Driver?.Quit();
        }
    }
}
