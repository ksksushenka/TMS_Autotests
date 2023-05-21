using Core.Models;
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
        [Test]
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
