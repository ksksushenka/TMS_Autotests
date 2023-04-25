using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Autotest2.Lesson2
{
    internal class CheckboxesTest
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
            Chrome.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");

            IWebElement checkbox = Chrome.FindElement(By.CssSelector("[type = checkbox]"));
            Assert.IsFalse(checkbox.Selected);

            checkbox.Click();
            Assert.IsTrue(checkbox.Selected);

            IWebElement checkbox2 = Chrome.FindElement(By.XPath("//input[2]"));
            Assert.IsTrue(checkbox2.Selected);

            checkbox2.Click();
            Assert.IsFalse(checkbox2.Selected);

        }

        [TearDown]
        public void TearDown()
        {
            Chrome.Quit();
        }
    }
}