using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Tests
{
    internal class SearchTest : BaseTest
    {
        SearchPage SearchPage { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            SearchPage = new SearchPage(ChromeDriver);
        }

        [Test]
        public void Search_WithNameofBook()
        {
            var bookPage = SearchPage.Search(new MainPage(ChromeDriver).GetNameOfBook());

            Assert.IsTrue(bookPage.GetAddToCardButton());
        }

        [Test]
        public void Search_NoDataFound()
        {
            string search = "W.Somerset Maugham";
            string confirmMessage = "Nothing is found :(";

            SearchPage.Search(search);

            Assert.That(SearchPage.GetConfirmMessage, Is.EqualTo(confirmMessage));
        }
    }
}
