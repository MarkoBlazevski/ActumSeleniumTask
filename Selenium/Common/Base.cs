using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Selenium.Models;
using Selenium.Utilities;
using System.Configuration;
using System.Text.Json;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Common
{
    public class Base
    {
        public ExtentReports extentReports;
        public ExtentTest test;
        String browserName;

        //Report file
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extentReports = new ExtentReports();

            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("Host Name", "localhost");
            extentReports.AddSystemInfo("Envronment", "QA");
            extentReports.AddSystemInfo("Username", "Marko Blazevski");

        }

        //public IWebDriver? driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]

        public void StartBrowser()
        {
            // If there is no flag for browser type in terminal take it from appConfig file
            test = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);

            var browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);

            // Implicit Wait 
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = Settings.HomePageUrl;
        }

        public IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
            }
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            
            var stakTrace = TestContext.CurrentContext.Result.StackTrace;


            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if(status == TestStatus.Failed)
            {
                test.Fail("Test Failed", CaptureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, "Test failed with log trace" + stakTrace);
            }
            else if (status == TestStatus.Passed)
            {

            }
            extentReports.Flush();
            driver.Value.Quit();
        }


        public static UserData GetUserData()
        {
            string userDataJson = "UserData.json";
            string jsonString = File.ReadAllText(userDataJson);
            return JsonSerializer.Deserialize<UserData>(jsonString)!;
        }


        // Capturing screenshot
        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            var screenShot = takesScreenshot.GetScreenshot().AsBase64EncodedString; // .SaveAsFile if you want to save in file

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenshotName).Build();
        }

    }
}
