using Allure.Commons;
using Core.Models;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BaseEntities;
using Tests.Pages;

namespace Tests.Tests
{
    public class OrderTest : BaseTest
    {
        [Test(Description = "Successful Order")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("standard_user")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue("TMS-23")]
        [AllureTms("?case=1&previewMode=modal&suite=1")]
        [AllureTag("Smoke")]
        [AllureLink("https://www.saucedemo.com/")]
        [Description("Сhecking a successful order through the shopping cart")]
        public void TryToOrder()
        {
            string message = "Thank you for your order!";

            User user = new UserBuilder()
                .SetUsername("standard_user")
                .SetPassword("secret_sauce")
                .SetFirstName("FirstName")
                .SetLastName("LastName")
                .SetZipCode("000000")
                .Build();

            LoginPage.Login(user)
                .AddToCard()
                .Checkout()
                .TryToGoToStepTwo(user)
                .TryToFinishOrder();

            Assert.That(CheckoutCompletePage.GetSuccessMessage, Is.EqualTo(message));
        }
    }
}
