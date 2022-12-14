using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Common;

namespace Selenium.PageObjects
{
    public class SignInPage : Base
    {
        private new readonly IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver Driver => driver;

        //Finding elements

        private IWebElement Email => Driver.FindElement(By.Id("email_create"));
        private IWebElement HomeSignInButton => Driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a"));
        private IWebElement LogoutBtn => Driver.FindElement(By.ClassName("logout"));
        private IWebElement CreateAnAccountButton => Driver.FindElement(By.XPath("//*[@id='SubmitCreate']"));
        private IWebElement TitleRadioButton => Driver.FindElement(By.XPath("//*[@id='id_gender1']"));
        private IWebElement FirstName => Driver.FindElement(By.XPath("//*[@id='customer_firstname']"));
        private IWebElement LastName => Driver.FindElement(By.XPath("//*[@id='customer_lastname']"));
        private IWebElement Password => Driver.FindElement(By.XPath("//*[@id='passwd']"));
        private IWebElement Date => Driver.FindElement(By.XPath("//*[@id='days']/option[14]"));
        private IWebElement Month => Driver.FindElement(By.XPath("//*[@id='months']/option[9]"));
        private IWebElement Year => Driver.FindElement(By.XPath("//*[@id='years']/option[38]"));
        private IWebElement Address => Driver.FindElement(By.XPath("//*[@id='address1']"));
        private IWebElement City => Driver.FindElement(By.XPath("//*[@id='city']"));
        private IWebElement StateDropdown => Driver.FindElement(By.XPath("//*[@id='id_state']/option[2]"));
        private IWebElement CountryDropdown => Driver.FindElement(By.XPath("//*[@id='id_country']/option[2]"));
        private IWebElement Zip => Driver.FindElement(By.XPath("//*[@id='postcode']"));
        private IWebElement MobilePhone => Driver.FindElement(By.XPath("//*[@id='phone_mobile']"));
        private IWebElement RegisterButton => Driver.FindElement(By.XPath("//*[@id='submitAccount']"));
        private IWebElement MyAccountHeader => Driver.FindElement(By.XPath("//*[@id='columns']/div[1]/span[2]"));
        private IWebElement ForgotPassword => Driver.FindElement(By.XPath("//*[@id='login_form']/div/p[1]/a"));
        private IWebElement ForgotPasswordPage => Driver.FindElement(By.XPath("//*[@id='form_forgotpassword']/fieldset/p/button"));
        private IWebElement SignInButton => Driver.FindElement(By.XPath("//*[@id='SubmitLogin']"));
        private IWebElement SignInEmail => Driver.FindElement(By.XPath("//*[@id='email']"));
        private IWebElement SignInPass => Driver.FindElement(By.XPath("//*[@id='passwd']"));
        private IWebElement SignInError => Driver.FindElement(By.XPath("//*[@id='center_column']/div[1]/ol/li"));
        private IWebElement ExistingEmail => Driver.FindElement(By.XPath("//*[@id='create_account_error']/ol/li"));


        // Actions

        public IWebElement AccountButton() => CreateAnAccountButton;
        public IWebElement HomeSignInBtn() => HomeSignInButton;

        public IWebElement Logout() => LogoutBtn;

        public void PersonalInfo()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TitleRadioButton.Click();
            FirstName.SendKeys(GetUserData().FirstName);
            LastName.SendKeys(GetUserData().LastName);
            Password.SendKeys(GetUserData().Password);
            Date.Click();
            Month.Click();
            Year.Click();
            Address.SendKeys(GetUserData().Address);
            City.SendKeys(GetUserData().City);
            CountryDropdown.Click();
            StateDropdown.Click();
            Zip.SendKeys(GetUserData().Zip);
            MobilePhone.SendKeys(GetUserData().MobilePhone);
        }

        public IWebElement RegisterBtn() => RegisterButton;

        public IWebElement CreateAccountBtn() => CreateAnAccountButton;

        public IWebElement NewEmail() => Email;

        public IWebElement EmailCredentials() => Email;

        public IWebElement SignInEmailCredentials() => SignInEmail;

        public IWebElement SignInPasswordCredentials() => SignInPass;

        public IWebElement SigninButton() => SignInButton;

        public IWebElement ForgotPasswordLink() => ForgotPassword;

        // Validation

        public IWebElement AuthenticationErrorValidation() => SignInError;

        public IWebElement EmailAddressErrorValidation() => SignInError;

        public IWebElement EmailFormatErrorValidation() => SignInError;

        public IWebElement RequiredPasswordErrorValidation() => SignInError;

        public IWebElement ForgotPassPageValidation() => ForgotPasswordPage;
        public IWebElement ExistingEmailErrorValidation()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement error = wait.Until(driver => ExistingEmail);
            return error;
        }

        public IWebElement MyAccountPageValidation() => MyAccountHeader;
    }
}
