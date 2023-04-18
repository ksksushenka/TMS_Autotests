using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Autotest2.Lesson2
{
    internal class InputsTest
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
            Chrome.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");

            IWebElement input = Chrome.FindElement(By.TagName("input"));

            input.SendKeys("123456789");
            var text1 = input.GetAttribute("value");
            Assert.That(text1, Is.EqualTo("123456789"));

            input.Clear();
            input.Click();
            input.SendKeys("asdsad");
            var text2 = input.GetAttribute("value");
            Assert.IsEmpty(text2);

            input.Clear();
            input.SendKeys(Keys.ArrowUp);
            var text3 = input.GetAttribute("value");
            Assert.That(text3, Is.EqualTo("1"));

            input.Clear();
            input.SendKeys(Keys.ArrowDown);
            var text4 = input.GetAttribute("value");
            Assert.That(text4, Is.EqualTo("-1"));
        }

        [TearDown]
        public void TearDown()
        {
            Chrome.Quit();
        }
    }
}