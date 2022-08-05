using OpenQA.Selenium;
using Selenium.Common;

namespace Selenium.PageObjects
{
    public class ContactUsPage : Base
    {
        private new readonly IWebDriver driver;

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver Driver => driver;

        //Finding elements

        private IWebElement DropDownMenuCustomerService => Driver.FindElement(By.XPath("//*[@id='id_contact']/option[2]"));
        private IWebElement DropDownMenuWebmaster => Driver.FindElement(By.XPath("//*[@id='id_contact']/option[3]"));
        private IWebElement Email => Driver.FindElement(By.Id("email"));
        private IWebElement OrderRef => Driver.FindElement(By.Id("id_order"));
        private IWebElement Message => Driver.FindElement(By.Id("message"));
        private IWebElement SendBtn => Driver.FindElement(By.XPath("//*[@id='submitMessage']/span"));
        private IWebElement SuccessMessage => Driver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement EmailErrorMessage => Driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement SubjectErrorMessage => Driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement MessageErrorMessage => Driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement HomePageBtn => Driver.FindElement(By.XPath("//*[@id='columns']/div[1]/a"));
        private IWebElement ContactUsButton => Driver.FindElement(By.Id("contact-link"));



        //Actions

        public IWebElement ContactUs() => ContactUsButton;
        public IWebElement DropDownCustomerService() => DropDownMenuCustomerService;

        public IWebElement DropdownWebmaster() => DropDownMenuWebmaster;

        public IWebElement SendButton() => SendBtn;

        public IWebElement HomePageButton() => HomePageBtn;

        public void Credentials()
        {
            Email.SendKeys(GetUserData().Email);
            OrderRef.SendKeys(GetUserData().OrderReference);
            Message.SendKeys(GetUserData().Message);
        }

        //Validations

        public IWebElement SuccessMessageValidation() => SuccessMessage;
        public IWebElement EmailAddress() => Email;
        public IWebElement orderReference() => OrderRef;
        public IWebElement message() => Message;

        public IWebElement IvalidEmailAddressValidation() => EmailErrorMessage;

        public IWebElement BlankMessageValidation() => MessageErrorMessage;

        public IWebElement InvalidSubjectValidation() => SubjectErrorMessage;

        public string HomePageValidation()
        {
            return Driver.Url;
        }
    }
}
