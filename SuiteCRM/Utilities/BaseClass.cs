using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using ICSharpCode.SharpZipLib.Zip;
using NUnit.Framework.Interfaces;

namespace SuiteCRM.Utilities
{
    public class BaseClass
    {
        ExtentReports extent;
        [OneTimeSetUp]
        public void SetupReport() {

            String workingDirectory = Environment.CurrentDirectory;
            String projectDirectory = Directory.GetParent(workingDirectory).FullName;
            String reportPath = projectDirectory + "index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent.AttachReporter(htmlReporter);
        
        }


        public IWebDriver driver;
        [SetUp]

        public void startBrowser()
        {
            extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser("Chrome");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://suite8demo.suiteondemand.com/#/Login";
        }

        public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void exitApplication()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            //if (status == TestStatus.Passed) { 
            //}
            //else (status == fa) { 
            //}
            driver.Quit();
        }
    }

}