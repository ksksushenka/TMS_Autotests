using SharelaneAutomation.Page;

namespace SharelaneAutomation.Tests
{
    internal class LoginTest : BaseTest
    {
        LoginPage LoginPage { get; set; }
        Get—redentials Get—redentials { get; set; }

        [SetUp]
        public void Setup()
        {
            LoginPage = new LoginPage(ChromeDriver);
            Get—redentials = new Get—redentials(ChromeDriver);
        }

        [Test]
        public void Login_ValidData()
        {
            string email = Get—redentials.SetEmail();
            string password = "1111";

            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            LoginPage.Login(email, password);

            Assert.IsTrue(LoginPage.GetConfirmMessage());
        }
    }
}