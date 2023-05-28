using Core.Models;
using OpenQA.Selenium;
using Tests.BaseEntities;

namespace Tests.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By UsernameInputBy = By.Id("user-name");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By LoginButtonBy = By.Id("login-button");
        private static readonly By ErrorElementBy = By.XPath("//*[@data-test='error']");

        public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("The Login page is opened.");
        }

        public LoginPage(IWebDriver? driver) : base(driver, false)
        {
            _logger.Info("The Login page is opened.");
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(LoginButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void SetUsernameInput(string username)
        {
            Driver.FindElement(UsernameInputBy).SendKeys(username);
        }

        void SetPswInput(string psw)
        {
            Driver.FindElement(PswInputBy).SendKeys(psw);
        }

        void ClickLoginButton()
        {
            Driver.FindElement(LoginButtonBy).Click();
        }

        public string GetErrorMessage()
        {
            return Driver.FindElement(ErrorElementBy).Text;
        }

        public void TryToLogin(User user)
        {
            SetUsernameInput(user.Username);
            SetPswInput(user.Password);
            ClickLoginButton();
        }

        public InventoryPage Login(User user)
        {
            TryToLogin(user);
            return new InventoryPage(Driver);
        }
    }
}
