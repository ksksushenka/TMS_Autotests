using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Autotest2.Lesson2
{
    internal class NotificationTest
    {
        WebDriver Chrome { get; set; }

        [SetUp]
        public void Setup()
        {
            Chrome = new ChromeDriver();
            Chrome.Manage().Window.Maximize();
            Chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void Test1()
        {
            Chrome.Navigate().GoToUrl("http://the-internet.herokuapp.com/notification_message_rendered");

            Chrome.FindElement(By.LinkText("Click here")).Click();

            var message = "Action successful\r\n×";

            IWebElement notification = Chrome.FindElement(By.Id("flash"));
            var text = notification.Text;
            Assert.That(text, Is.EqualTo(message));
        }

        [TearDown]
        public void TearDown()
        {
            Chrome.Quit();
        }
    }
}