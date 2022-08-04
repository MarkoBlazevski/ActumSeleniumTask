using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Common;

namespace Selenium.PageObjects
{
    public class SignInPage : Base
    {
        private readonly IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Finding elements

        private IWebElement Email => driver.FindElement(By.Id("email_create"));
        private IWebElement HomeSignInButton => driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a"));
        private IWebElement LogoutBtn => driver.FindElement(By.ClassName("logout"));
        private IWebElement CreateAnAccountButton => driver.FindElement(By.XPath("//*[@id='SubmitCreate']"));
        private IWebElement TitleRadioButton => driver.FindElement(By.XPath("//*[@id='id_gender1']"));
        private IWebElement FirstName => driver.FindElement(By.XPath("//*[@id='customer_firstname']"));
        private IWebElement LastName => driver.FindElement(By.XPath("//*[@id='customer_lastname']"));
        private IWebElement Password => driver.FindElement(By.XPath("//*[@id='passwd']"));
        private IWebElement Date => driver.FindElement(By.XPath("//*[@id='days']/option[14]"));
        private IWebElement Month => driver.FindElement(By.XPath("//*[@id='months']/option[9]"));
        private IWebElement Year => driver.FindElement(By.XPath("//*[@id='years']/option[38]"));
        private IWebElement Address => driver.FindElement(By.XPath("//*[@id='address1']"));
        private IWebElement City => driver.FindElement(By.XPath("//*[@id='city']"));
        private IWebElement StateDropdown => driver.FindElement(By.XPath("//*[@id='id_state']/option[2]"));
        private IWebElement CountryDropdown => driver.FindElement(By.XPath("//*[@id='id_country']/option[2]"));
        private IWebElement Zip => driver.FindElement(By.XPath("//*[@id='postcode']"));
        private IWebElement MobilePhone => driver.FindElement(By.XPath("//*[@id='phone_mobile']"));
        private IWebElement RegisterButton => driver.FindElement(By.XPath("//*[@id='submitAccount']"));
        private IWebElement MyAccountHeader => driver.FindElement(By.XPath("//*[@id='columns']/div[1]/span[2]"));
        private IWebElement ForgotPassword => driver.FindElement(By.XPath("//*[@id='login_form']/div/p[1]/a"));
        private IWebElement ForgotPasswordPage => driver.FindElement(By.XPath("//*[@id='form_forgotpassword']/fieldset/p/button"));
        private IWebElement SignInButton => driver.FindElement(By.XPath("//*[@id='SubmitLogin']"));
        private IWebElement SignInEmail => driver.FindElement(By.XPath("//*[@id='email']"));
        private IWebElement SignInPass => driver.FindElement(By.XPath("//*[@id='passwd']"));
        private IWebElement SignInError => driver.FindElement(By.XPath("//*[@id='center_column']/div[1]/ol/li"));
        private IWebElement ExistingEmail => driver.FindElement(By.XPath("//*[@id='create_account_error']/ol/li"));

        // Actions

        public IWebElement AccountButton() => CreateAnAccountButton;
        public IWebElement HomeSignInBtn() => HomeSignInButton;

        public IWebElement Logout() => LogoutBtn;

        public void PersonalInfo()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TitleRadioButton.Click();
            FirstName.SendKeys(ExtractUserData().FirstName);
            LastName.SendKeys(ExtractUserData().LastName);
            Password.SendKeys(ExtractUserData().Password);
            Date.Click();
            Month.Click();
            Year.Click();
            Address.SendKeys(ExtractUserData().Address);
            City.SendKeys(ExtractUserData().City);
            CountryDropdown.Click();
            StateDropdown.Click();
            Zip.SendKeys(ExtractUserData().Zip);
            MobilePhone.SendKeys(ExtractUserData().MobilePhone);
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            IWebElement error = wait.Until(driver => ExistingEmail);
            return error;
        }

        public IWebElement MyAccountPageValidation() => MyAccountHeader;
    }
}
