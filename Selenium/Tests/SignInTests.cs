using NUnit.Framework;
using Selenium.Common;
using Selenium.PageObjects;

namespace Selenium.Tests
{
    [Parallelizable(ParallelScope.Children)]
    public class SignInTests : Base
    {
        [Test,Category("Smoke")]
        public void CreateAnAccountTest()
        {
            SignInPage signIn = new SignInPage(GetDriver());

            signIn.HomeSignInBtn().Click();
            signIn.NewEmail().SendKeys(Utilities.Utils.GenerateRandomEmail());
            signIn.CreateAccountBtn().Click();
            signIn.PersonalInfo();
            signIn.RegisterBtn().Click();
            //signIn.Logout().Click();

            Assert.IsTrue(signIn.MyAccountPageValidation().Displayed);
        }

        [Test]
        public void CreateAnAccountWithEmailThatIsAlreadyRegisteredTestTest()
        {
            SignInPage signIn = new SignInPage(GetDriver());

            signIn.HomeSignInBtn().Click();
            signIn.EmailCredentials().SendKeys(ExtractUserData().AlreadyRegisteredEmail);
            signIn.CreateAccountBtn().Click();

            Assert.IsTrue(signIn.ExistingEmailErrorValidation().Displayed);
        }

        [Test, Category("Smoke")]
        public void ForgotYourPasswordTest()
        {
            SignInPage signIn = new SignInPage(GetDriver());

            signIn.HomeSignInBtn().Click();
            signIn.ForgotPasswordLink().Click();

            Assert.IsTrue(signIn.ForgotPassPageValidation().Displayed);
        }


        [Test]
        public void EmptyEmailAndPasswordForSignInTest()
        {
            SignInPage signIn = new SignInPage(GetDriver());

            signIn.HomeSignInBtn().Click();
            signIn.SigninButton().Click();

            Assert.IsTrue(signIn.EmailAddressErrorValidation().Displayed);
            Assert.That(signIn.EmailAddressErrorValidation().Text, Is.EqualTo(ErrorMessages.EmailRequiredError));
        }

        [Test]
        public void InvalidEmailFormatTest()
        {
            SignInPage signIn = new SignInPage(GetDriver());

            signIn.HomeSignInBtn().Click();
            signIn.SignInEmailCredentials().SendKeys(ExtractUserData().InvalidEmailFormat);
            signIn.SigninButton().Click();

            Assert.IsTrue(signIn.EmailAddressErrorValidation().Displayed);
            Assert.That(signIn.EmailAddressErrorValidation().Text, Is.EqualTo(ErrorMessages.InvalidEmail));
        }

        [Test, Category("Smoke")]
        public void InvalidSignInPasswordTest()
        {
            SignInPage signIn = new SignInPage(GetDriver());

            signIn.HomeSignInBtn().Click();
            signIn.SignInEmailCredentials().SendKeys(ExtractUserData().AlreadyRegisteredEmail);
            signIn.SignInPasswordCredentials().SendKeys(ExtractUserData().Password);
            signIn.SigninButton().Click();

            Assert.IsTrue(signIn.EmailAddressErrorValidation().Displayed);
            Assert.That(signIn.EmailAddressErrorValidation().Text, Is.EqualTo(ErrorMessages.AuthenticationError));
        }

        [Test]
        public void EmptyPasswordSignInTest()
        {
            SignInPage signIn = new SignInPage(GetDriver());

            signIn.HomeSignInBtn().Click();
            signIn.SignInEmailCredentials().SendKeys(ExtractUserData().AlreadyRegisteredEmail);
            signIn.SigninButton().Click();

            Assert.IsTrue(signIn.EmailAddressErrorValidation().Displayed);
            Assert.That(signIn.EmailAddressErrorValidation().Text, Is.EqualTo(ErrorMessages.PasswordRequired));
        }
    }
}
