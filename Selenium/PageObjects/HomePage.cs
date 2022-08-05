using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Common;

namespace Selenium.PageObjects
{
    public class HomePage : Base
    {
        private new readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver Driver => driver;


        private IWebElement SearchBox => Driver.FindElement(By.XPath("//*[@id='search_query_top']"));
        private IWebElement SearchButton => Driver.FindElement(By.XPath("//*[@id='searchbox']/button"));
        private IWebElement SearchResults => Driver.FindElement(By.XPath("//*[@id='center_column']/h1/span[2]"));
        private IWebElement EnterASearchWarning => Driver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement NoResultsFoundWarning => Driver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement HintMenu => Driver.FindElement(By.ClassName("ac_results"));


        public IWebElement GetSearchBox() => SearchBox;
        public IWebElement SearchBtn() => SearchButton;
        public IWebElement SearchResult() => SearchResults;
        public IWebElement EnterASearchWarningMessage() => EnterASearchWarning;
        public IWebElement NoResultsFoundWarningMessage() => NoResultsFoundWarning;
        public IWebElement HintDropdownMenuValidation()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement dropdown = wait.Until(driver => HintMenu);
            return dropdown;
        }
    }
}
