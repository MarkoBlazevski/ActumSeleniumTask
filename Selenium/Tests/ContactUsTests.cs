using NUnit.Framework;
using Selenium.Common;
using Selenium.Models;
using Selenium.PageObjects;
using Selenium.Utilities;

namespace Selenium.Tests
{
    [Parallelizable(ParallelScope.Children)]
    public class ContactUsTests : Base
    {

        [Test, Category("Smoke")]
        public void SendMessageToCustomerServiceTest()
        {
            ContactUsPage contactUs = new ContactUsPage(GetDriver());

            contactUs.ContactUs().Click();
            contactUs.DropDownCustomerService().Click();
            contactUs.Credentials();
            contactUs.SendButton().Click();

            Assert.That(contactUs.SuccessMessageValidation().Text, Is.EqualTo(ErrorMessages.MessageSuccessfulySentMessage));
        }

        [Test, Category("Regression")]
        public void SendMessageToWebmasterTest()
        {
            ContactUsPage contactUs = new ContactUsPage(GetDriver());

            contactUs.ContactUs().Click();
            contactUs.DropdownWebmaster().Click();
            contactUs.Credentials();
            contactUs.SendButton().Click();

            Assert.That(contactUs.SuccessMessageValidation().Text, Is.EqualTo(ErrorMessages.MessageSuccessfulySentMessage));
        }

        [Test, Category("Smoke")]
        public void InvalidEmailFormatTest()
        {
            ContactUsPage contactUs = new ContactUsPage(GetDriver());

            contactUs.ContactUs().Click();
            contactUs.DropDownCustomerService().Click();
            contactUs.EmailAddress().SendKeys(ExtractUserData().InvalidEmailFormat);
            contactUs.orderReference().SendKeys(ExtractUserData().OrderReference);
            contactUs.message().SendKeys(ExtractUserData().Message);
            contactUs.SendButton().Click();

            Assert.That(contactUs.IvalidEmailAddressValidation().Text, Is.EqualTo(ErrorMessages.InvalidEmail));
        }

        [Test, Category("Smoke")]
        public void NoOptionFromSubjectHeadingTest()
        {
            ContactUsPage contactUs = new ContactUsPage(GetDriver());

            contactUs.ContactUs().Click();
            contactUs.Credentials();
            contactUs.SendButton().Click();

            Assert.That(contactUs.InvalidSubjectValidation().Text, Is.EqualTo(ErrorMessages.SelectSubjectError));
        }

        [Test]
        public void SendWithoutAnyRequiredFieldTest()
        {
            ContactUsPage contactUs = new ContactUsPage(GetDriver());

            contactUs.ContactUs().Click();
            contactUs.SendButton().Click();

            Assert.That(contactUs.IvalidEmailAddressValidation().Text, Is.EqualTo(ErrorMessages.InvalidEmail));
        }


        [Test]
        public void SendEmptyMessageTest()
        {
            ContactUsPage contactUs = new ContactUsPage(GetDriver());

            contactUs.ContactUs().Click();
            contactUs.EmailAddress().SendKeys(ExtractUserData().AlreadyRegisteredEmail);
            contactUs.orderReference().SendKeys(ExtractUserData().OrderReference);
            contactUs.SendButton().Click();

            Assert.That(contactUs.BlankMessageValidation().Text, Is.EqualTo(ErrorMessages.BlankMessageError));
        }

        [Test]
        public void BackToHomeTest()
        {
            ContactUsPage contactUs = new ContactUsPage(GetDriver());

            contactUs.ContactUs().Click();
            contactUs.HomePageButton().Click();

            Assert.That(contactUs.HomePageValidation(), Is.EqualTo(Settings.HomePageUrl));
        }
    }
}
