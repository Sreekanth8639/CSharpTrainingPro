using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SuiteCRM.PageObjects;
using SuiteCRM.Tests;
using SuiteCRM.Utilities;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace SuiteCRM.Tests {
    public class LeadsTest : BaseClass
    {
        [Test]
            public void verifyLeadsDropdown()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            LeadsPage LeadPageObj = new LeadsPage(driver);
            Assert.IsTrue(LeadPageObj.CreateLead.Displayed);
            Assert.IsTrue(LeadPageObj.CreateLeadFromvCard.Displayed);
            Assert.IsTrue(LeadPageObj.ViewLeads.Displayed);
            Assert.IsTrue(LeadPageObj.ImportLeads.Displayed);

        }

        [Test]
        public void navigateLeadsCreatePage()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            //header create leads
            Assert.IsTrue(LeadPageObj.CreateLeadPage.Displayed);
        }



        [Test]
        public void verifyFieldsPopulating()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            IWebElement InputField = LeadPageObj.FirstNameInput;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(InputField).Click().Perform();
            //first name input field
            action.MoveToElement(InputField).SendKeys("John").Perform();
            //last name input field
            LeadPageObj.LastName.SendKeys("Doe");
            //Job title
            LeadPageObj.JobTitle.SendKeys("Engineer");
            //Mobile
            LeadPageObj.Mobile.SendKeys("1234567890");
            //Department
            LeadPageObj.Department.SendKeys("Quality Assurance");
            Thread.Sleep(3000);
            //moreinformation click
            LeadPageObj.MoreInformationButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//textarea)[1]")));
            //status description
            LeadPageObj.StatusDescription.SendKeys("Lead has been created for the new employee.");
            //Opportunity Amount
            LeadPageObj.OpportunityAmount.SendKeys("$100");
        }


        String FirstName = "John", LastName = "Doe";
        [Test]
        public void verifySaveOptionByPopulatingRequiredFields()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            IWebElement InputField = LeadPageObj.FirstNameInput;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(InputField).Click().Perform();
            //first name input field
            action.MoveToElement(InputField).SendKeys(FirstName).Perform();
            //last name input field
            LeadPageObj.LastName.SendKeys(LastName);
            //save button
            LeadPageObj.Save.Click();
            //Leads Created Page
            Thread.Sleep(3000);
            Assert.IsTrue(LeadPageObj.CreateLeadPage.Displayed);

            String heading = LeadPageObj.CreateLeadPage.Text;
            String heading1 = Regex.Replace(heading,"\r\n"," ");
            Console.WriteLine(heading1);
            Assert.That(heading1, Is.EqualTo("LEADS" +" "+ FirstName + " " +LastName));
        }

        [Test]
        public void verifySaveOptionWithEmptyFields()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()=' Save ']")));
            //save button
            LeadPageObj.Save.Click();
            //Missing required fields
            Assert.IsTrue(LeadPageObj.MissingFieldError.Displayed);
        }

        [Test]
        public void verifyCancelOption()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            IWebElement InputField = LeadPageObj.FirstNameInput;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(InputField).Click().Perform();
            //first name input field
            action.MoveToElement(InputField).SendKeys(FirstName).Perform();
            //last name input field
            LeadPageObj.LastName.SendKeys(LastName);
            //save button
            LeadPageObj.CancelButton.Click();
            //Warning dialog box
            Thread.Sleep(2000);
            Assert.IsTrue(LeadPageObj.CancelWarning.Displayed);
            Assert.IsTrue(LeadPageObj.CancelButton.Displayed);
            Assert.IsTrue(LeadPageObj.OKButton.Displayed);
        }

        [Test]
        public void verifyCancelOptionOnPopup()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            IWebElement InputField = LeadPageObj.FirstNameInput;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(InputField).Click().Perform();
            //first name input field
            action.MoveToElement(InputField).SendKeys(FirstName).Perform();
            //last name input field
            LeadPageObj.LastName.SendKeys(LastName);
            LeadPageObj.CancelButton.Click();
            //Warning dialog box
            Thread.Sleep(5000);
            LeadPageObj.CancelButtonPopup.Click();
            Assert.IsTrue(LeadPageObj.CreateLeadPage.Displayed);

        }

        [Test]
        public void verifyOkOptionOnPopup()
        {
            LeadsPage LeadPage = new LeadsPage(driver);
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            IWebElement InputField = LeadPageObj.FirstNameInput;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(InputField).Click().Perform();
            //first name input field
            action.MoveToElement(InputField).SendKeys(FirstName).Perform();
            //last name input field
            LeadPage.LastName.SendKeys(LastName);
            //save button
            LeadPageObj.CancelButton.Click();
            //Warning dialog box
            Thread.Sleep(3000);
            LeadPageObj.OKButtonPopup.Click();
            //LeadsCreatePage
            Assert.IsTrue(LeadPageObj.CreateLeadPage.Displayed);

        }

        [Test]
        public void verifySearchsection()
        {
            LeadsPage LeadPage = new LeadsPage(driver);
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Search...']")));


            Boolean display = LeadPageObj.searchIcon.Displayed;
            Assert.AreEqual(display, true);


        }
        [Test]
        public void verifyOverviewMoreInformationOther()
        {
            LeadsPage LeadPage = new LeadsPage(driver);
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[4]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[4]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            LeadsPage LeadPageObj = new LeadsPage(driver);
            //create leads
            LeadPageObj.CreateLead.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Search...']")));

            Boolean display2 = LeadPageObj.overview.Displayed;
            Assert.AreEqual(display2, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Boolean display3 = LeadPageObj.moreInformation.Displayed;
            Assert.AreEqual(display3, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Boolean display4 = LeadPageObj.other.Displayed;
            Assert.AreEqual(display4, true);

        }

    }
}
