using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Common;

namespace Selenium.PageObjects
{
    public class HomePage : Base
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SearchBox => driver.FindElement(By.XPath("//*[@id='search_query_top']"));
        private IWebElement SearchButton => driver.FindElement(By.XPath("//*[@id='searchbox']/button"));
        private IWebElement SearchResults => driver.FindElement(By.XPath("//*[@id='center_column']/h1/span[2]"));
        private IWebElement EnterASearchWarning => driver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement NoResultsFoundWarning => driver.FindElement(By.XPath("//*[@id='center_column']/p"));
        private IWebElement HintMenu => driver.FindElement(By.ClassName("ac_results"));

        public IWebElement GetSearchBox() => SearchBox;
        public IWebElement SearchBtn() => SearchButton;
        public IWebElement SearchResult() => SearchResults;
        public IWebElement EnterASearchWarningMessage() => EnterASearchWarning;
        public IWebElement NoResultsFoundWarningMessage() => NoResultsFoundWarning;
        public IWebElement HintDropdownMenuValidation()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement dropdown = wait.Until(driver => HintMenu);
            return dropdown;
        }
    }
}
