using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Selenium
{
    public class Selenium
    {
        [SetUp]

        public void StartBrowser()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //IWebDriver driver = new FirefoxDriver();

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            // Implicit Wait 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
        }
    }
}
