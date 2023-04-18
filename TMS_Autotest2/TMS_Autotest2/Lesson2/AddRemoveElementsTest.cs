using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TMS_Autotest2.Lesson2
{
    public class AddRemoveElementsTest
    {
        WebDriver Chrome { get; set; }
        int count;

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
            Chrome.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");

            IWebElement addButton = Chrome.FindElement(By.XPath("//button[text()='Add Element']"));
            addButton.Click();
            addButton.Click();

            var deleteButton = Chrome.FindElement(By.XPath("//button[text()='Delete']"));
            deleteButton.Click();

            var elements = Chrome.FindElements(By.XPath("//button[text()='Delete']"));

            foreach (var e in elements)
            {
                    count++;
            }

            Assert.That(count, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown()
        {
            Chrome.Quit();
        }
    }
}