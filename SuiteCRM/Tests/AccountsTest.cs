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

        //TC-06
        [Test]
        public void VerifyAccountoptionfromdropdownlist()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            AccountsPage AccountsPageObjects = new AccountsPage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Accounts']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            AccountsPageObjects.CreateAccounts.Click();
            Assert.IsTrue(AccountsPageObjects.Createtitle.Displayed);

        }


        //TC-07
        [Test]
        public void VerifyViewAccounts()
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
            Assert.IsTrue(AccountsPageObjects.ViewAccountstitle.Displayed);

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
            Assert.IsTrue(AccountsPageObjects.accountstitle.Displayed);

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
            Assert.IsTrue(AccountsPageObjects.Error.Displayed);

        }

        //TC-10
        [Test]
        [TestCase("Sunil","Y")]
        public void createAccount(String Accountname,String Accountname1)
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
            AccountsPageObjects.name.SendKeys(Accountname1);
            AccountsPageObjects.Save.Click();
            Assert.IsTrue(AccountsPageObjects.accountstitle.Displayed);

        }
        
        
        //TC-11
        [Test]
        [TestCase("Sunil")]
        public void cancelAccount(String Accountname)
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
            Assert.IsTrue(AccountsPageObjects.Createtitle.Displayed);

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
            Assert.IsTrue(AccountsPageObjects.Createtitle.Displayed);

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

            IList<IWebElement> Dropdown = driver.FindElements(By.XPath("//div[@class=\"dropdown-menu show\"]/a"));
            string[] elements = { "Delete", "Duplicate", "View Change Log", "Find Duplicates", "Print as PDF" };

            for (int i = 0; i < elements.Length; i++)
            {
               Assert.That(Dropdown[i].Text, Is.EqualTo(elements[i]));
            }

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
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn-main button-group-button modal-button btn btn-sm']")));
            Thread.Sleep(200);
            AccountsPageObjects.Deleteprocede.Click();          
            Assert.IsTrue(AccountsPageObjects.Deletesucesfull.Displayed);
          
        }
    }
}

