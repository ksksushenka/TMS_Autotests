using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharelaneAutomation.Tests
{
    internal class SignUpTest : BaseTest
    {
        SignUpPage SignUpPage { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeDriver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            SignUpPage = new SignUpPage(ChromeDriver);
        }

        [Test]
        public void SignUp_ValidData()
        {
            string zipCode = "123456";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string email = "testemail@test.com";
            string password = "123qwe123";
            string confirmPassword = "123qwe123";
            string message = "Account is created!";

            SignUpPage.SignUp(zipCode, firstName, lastName, email, password, confirmPassword);

            Assert.That(SignUpPage.GetConfirmMessage, Is.EqualTo(message));
        }
    }
}
