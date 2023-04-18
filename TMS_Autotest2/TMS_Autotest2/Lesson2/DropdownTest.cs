using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TMS_Autotest2.Lesson2
{
    internal class DropdownTest
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
            Chrome.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");

            IWebElement dropdown = Chrome.FindElement(By.Id("dropdown"));
            dropdown.Click();
            List<IWebElement> elements = Chrome.FindElements(By.TagName("option")).ToList();

            foreach(IWebElement element in elements)
            {
                var displayed = element.Displayed;
                Assert.IsTrue(displayed);
            }

            SelectElement selected = new SelectElement(Chrome.FindElement(By.Id("dropdown")));
            selected.SelectByText("Option 1");
            IWebElement element1 = Chrome.FindElement(By.XPath("//option[@value='1']"));
            var checkElement1 = element1.GetAttribute("selected");
            Assert.IsNotNull(checkElement1);

            selected.SelectByText("Option 2");
            IWebElement element2 = Chrome.FindElement(By.XPath("//option[@value='2']"));
            var checkElement2 = element2.GetAttribute("selected");
            Assert.IsNotNull(checkElement2);
        }

        [TearDown]
        public void TearDown()
        {
            Chrome.Quit();
        }
    }
}