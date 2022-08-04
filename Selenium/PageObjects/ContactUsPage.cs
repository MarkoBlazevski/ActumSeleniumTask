using OpenQA.Selenium;
using Selenium.Common;

namespace Selenium.PageObjects
{
    public class ContactUsPage : Base
    {
        private readonly IWebDriver driver;

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Finding elements

        private IWebElement DropDownMenuCustomerService => driver.FindElement(By.XPath("//*[@id='id_contact']/option[2]"));
        private IWebElement DropDownMenuWebmaster => driver.FindElement(By.XPath("//*[@id='id_contact']/option[3]"));
        private IWebElement Email => driver.FindElement(By.Id("email"));
        private IWebElement OrderRef => driver.FindElement(By.Id("id_order"));
        private IWebElement Message => driver.FindElement(By.Id("message"));
        private IWebElement SendBtn => driver.FindElement(By.XPath("//*[@id='submitMessage']/span"));
        private IWebElement SuccessMessage => driver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement EmailErrorMessage => driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement SubjectErrorMessage => driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement MessageErrorMessage => driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
        private IWebElement HomePageBtn => driver.FindElement(By.XPath("//*[@id='columns']/div[1]/a"));
        private IWebElement ContactUsButton => driver.FindElement(By.Id("contact-link"));


        //Actions

        public IWebElement ContactUs() => ContactUsButton;
        public IWebElement DropDownCustomerService() => DropDownMenuCustomerService;

        public IWebElement DropdownWebmaster() => DropDownMenuWebmaster;

        public IWebElement SendButton() => SendBtn;

        public IWebElement HomePageButton() => HomePageBtn;

        public void Credentials()
        {
            Email.SendKeys(ExtractUserData().Email);
            OrderRef.SendKeys(ExtractUserData().OrderReference);
            Message.SendKeys(ExtractUserData().Message);
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
            return driver.Url;
        }
    }
}
