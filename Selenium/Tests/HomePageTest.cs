using NUnit.Framework;
using Selenium.Common;
using Selenium.PageObjects;

namespace Selenium.Tests
{
    [Parallelizable(ParallelScope.Children)]
    public class HomePageTest : Base
    {

        [Test, Category("Smoke")]
        public void TypeIntoSearchBoxAndPerformQueryTest()
        {
            HomePage homePage = new HomePage(GetDriver());

            homePage.GetSearchBox().SendKeys(GetUserData().Query);
            homePage.SearchBtn().Click();

            Assert.IsTrue(homePage.SearchResult().Displayed);
        }

        [Test]
        public void EmptySearchQueryTest()
        {
            HomePage homePage = new HomePage(GetDriver());

            homePage.SearchBtn().Click();

            Assert.IsTrue(homePage.EnterASearchWarningMessage().Displayed);
        }

        [Test]
        public void PartialSearchQueryTest()
        {
            HomePage homePage = new HomePage(GetDriver());

            homePage.GetSearchBox().SendKeys(GetUserData().PartialQuery);

            Assert.IsTrue(homePage.HintDropdownMenuValidation().Displayed);
        }

        [Test, Category("Smoke")]
        public void QueryWithNoSearchResultsTest()
        {
            HomePage homePage = new HomePage(GetDriver());

            homePage.GetSearchBox().SendKeys(GetUserData().NoResultsQuery);
            homePage.SearchBtn().Click();

            Assert.IsTrue(homePage.NoResultsFoundWarningMessage().Displayed);
        }

        [Test, Category("Regression")]
        public void CapsLockQueryTest()
        {
            HomePage homePage = new HomePage(GetDriver());

            homePage.GetSearchBox().SendKeys(GetUserData().CapsQuery);
            homePage.SearchBtn().Click();

            Assert.IsTrue(homePage.SearchResult().Displayed);
        }
    }
}
