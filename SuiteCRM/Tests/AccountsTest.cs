using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SuiteCRM.PageObjects;
using SuiteCRM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AventStack.ExtentReports.Gherkin.Model;

namespace SuiteCRM.Tests
{
    public class AccountsTest : BaseClass
    {
        //TC-06
        [Test]
        public void VerifyAccountoptionfromAccountsModuledropdownlist()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            //driver.FindElement(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")).Click();
            AccountsPageObjects.CreateAccounts.Click();

            AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.Createtitle.Displayed;
            Assert.AreEqual(display, true);

        }

        //TC-07
        [Test]
        public void VerifyViewAccountsfromtheAccountsModuledropdownlist()
        {
             LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
       
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/index?return_module=Accounts&return_action=DetailView']")));
            AccountsPageObjects.View.Click();

            AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.ViewAccountstitle.Displayed;
            Assert.AreEqual(display, true);


        }

        //TC-08

        [Test]
        [TestCase("Sunil")]
        public void VerifyCreateaccount(string Accountname)
        {
             LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")));
            AccountsPageObjects.CreateAccounts.Click();

            AccountsPageObjects.name.SendKeys(Accountname);
            AccountsPageObjects.Save.Click();

            AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.accountstitle.Displayed;
            Assert.AreEqual(display, true);


        }

        //TC-09

        [Test]
        public void VerifyCreateaccountWithoutdata()
        {

             LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")));
            AccountsPageObjects.CreateAccounts.Click();

            
            AccountsPageObjects.Save.Click();

            AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.Error.Displayed;
            Assert.AreEqual(display, true);


        }

        //TC-10

        [Test]
        [TestCase("Sunil","1")]
        public void Verifyeditthecreatedaccount(String Accountname,String Accountname1)
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")));
            AccountsPageObjects.CreateAccounts.Click();

            AccountsPageObjects.name.SendKeys(Accountname);
            AccountsPageObjects.Save.Click();
            Thread.Sleep(5000);
            AccountsPageObjects.Edit.Click();
            Thread.Sleep(50);
            AccountsPageObjects.name.SendKeys("Y");
            AccountsPageObjects.Save.Click();

            AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.accountstitle.Displayed;
            Assert.AreEqual(display, true);



        }
        //TC-11

        [Test]
        [TestCase("Sunil")]
        public void VerifyCancelwhilecreatingaccount(String Accountname)
        {
             LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")));
            AccountsPageObjects.CreateAccounts.Click();

            AccountsPageObjects.name.SendKeys(Accountname);

            AccountsPageObjects.Cancel.Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//scrm-label[normalize-space()='Ok']")));
            AccountsPageObjects.Popup.Click();

             AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.Createtitle.Displayed;
            Assert.AreEqual(display, true);
            


        }

        //TC-12
        [Test]
        [TestCase("Sunil")]
        public void VerifyNewbutton(String Accountname)
        {

              LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")));
            AccountsPageObjects.CreateAccounts.Click();

            AccountsPageObjects.name.SendKeys(Accountname);

            AccountsPageObjects.Save.Click();
            Thread.Sleep(3000);
            AccountsPageObjects.New.Click();

            AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.Createtitle.Displayed;
            Assert.AreEqual(display, true);
            


        }

        //TC-13

        [Test]
        [TestCase("Sunil")]
        public void VerifyActiondropdown(String Accountname)
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")));
            AccountsPageObjects.CreateAccounts.Click();

            AccountsPageObjects.name.SendKeys(Accountname);

            AccountsPageObjects.Save.Click();
            Thread.Sleep(3000);
            AccountsPageObjects.actiondrop.Click(); 
            

            AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.Delete.Displayed;
            Assert.AreEqual(display, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display1 = verify.Duplicate.Displayed;
            Assert.AreEqual(display, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display2 = verify.Viewchangelog.Displayed;
            Assert.AreEqual(display, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display3 = verify.Findduplicates.Displayed;
            Assert.AreEqual(display, true);

           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display4 = verify.Printpdf.Displayed;
            Assert.AreEqual(display, true);
  

        }

        //TC-14
        [Test]
        [TestCase("Sunil")]
        public void VerifyDeleteaccount(String Accountname)
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")));
            AccountsPageObjects.CreateAccounts.Click();

            AccountsPageObjects.name.SendKeys(Accountname);

            AccountsPageObjects.Save.Click();
            Thread.Sleep(3000);
            AccountsPageObjects.actiondrop.Click();
            AccountsPageObjects.Delete.Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn-main button-group-button modal-button btn btn-sm']")));
            AccountsPageObjects.Deleteprocede.Click();
            AccountsPage verify = new AccountsPage(driver);

            Boolean display = verify.Deletesucesfull.Displayed;
            Assert.AreEqual(display, true);


        }

        [Test]
        //TC-001
        public void verifyLabels()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-button")));
            Thread.Sleep(3000);
            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@src='./legacy/index.php?module=Home']")));

            Thread.Sleep(2000);
            String MyCalls = AccountsPageObjects.MyCalls.Text;
            Console.WriteLine(MyCalls);
            Assert.That(MyCalls, Is.EqualTo("My Calls"), "Both are Equal");

            Thread.Sleep(2000);
            String MyActivityStream = AccountsPageObjects.MyActivityStream.Text;
            Console.WriteLine(MyActivityStream);
            Assert.That(MyActivityStream, Is.EqualTo("My Activity Stream"), "Both are Equal");

            Thread.Sleep(2000);
            String MyMeetings = AccountsPageObjects.MyMeetings.Text;
            Console.WriteLine(MyMeetings);
            Assert.That(MyMeetings, Is.EqualTo("My Meetings"), "Both are Equal");

            Thread.Sleep(2000);
            String MyTopOpenOpportunities = AccountsPageObjects.MyTopOpenOpportunities.Text;
            Console.WriteLine(MyTopOpenOpportunities);
            Assert.That(MyTopOpenOpportunities, Is.EqualTo("My Top Open Opportunities"), "Both are Equal");

            Thread.Sleep(2000);
            String MyAccounts = AccountsPageObjects.MyAccounts.Text;
            Console.WriteLine(MyAccounts);
            Assert.That(MyAccounts, Is.EqualTo("My Accounts"), "Both are Equal");

            Thread.Sleep(2000);
            String MyLeads = AccountsPageObjects.MyLeads.Text;
            Console.WriteLine(MyLeads);
            Assert.That(MyLeads, Is.EqualTo("My Leads"), "Both are Equal");


        }
        [Test]
        //TC-003
        public void verifyInvalidLogin()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("abc", "cba");
            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-button")));
            Thread.Sleep(3000);
            String invalidLoginAlert = AccountsPageObjects.InvalidLoginAlert.Text;
            Assert.IsTrue(AccountsPageObjects.InvalidLoginAlert.Displayed);
        }

        [Test]
        //TC-004
        public void verifyEmptyLogin()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("", "");
            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-button")));
            Thread.Sleep(3000);
            Assert.IsTrue(AccountsPageObjects.VerifyEmptyLogin.Displayed);

        }

        [Test]
        //TC-005
        public void verifyAccountsDropdown()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts']")));
            IWebElement element = AccountsPageObjects.AccountsModule;
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            Assert.IsTrue(AccountsPageObjects.CreateAccount.Displayed);
            Assert.IsTrue(AccountsPageObjects.ViewAccounts.Displayed);
            Assert.IsTrue(AccountsPageObjects.ImportAccounts.Displayed);
        }


    }


}

