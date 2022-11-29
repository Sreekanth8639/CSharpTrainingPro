using MongoDB.Driver.Core.Authentication;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SuiteCRM.PageObjects;
using SuiteCRM.Utilities;
using WebDriverManager;

namespace SuiteCRM.Tests
{
    public class Tests : BaseClass
    {

        [Test]
        [TestCase("will", "will")]
        public void Test1(string username, string password )
        {
            LoginClass loginClassPageOjbects = new LoginClass(driver);
            loginClassPageOjbects.username.SendKeys(username);
            loginClassPageOjbects.password.SendKeys(password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-button")));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            loginClassPageOjbects.login.Click();
           

            //Creat account Check
          /*  AccountsClass accountsClassPageObjects = new AccountsClass(driver);
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            accountsClassPageObjects.counts.Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")));
            accountsClassPageObjects.CreateAccounts.Click();
            
            
            //View account
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Accounts']")));
            accountsClassPageObjects.counts.Click();
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/accounts/index?return_module=Accounts&return_action=DetailView']")));
            accountsClassPageObjects.View.Click();
            

            //Create account
            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='form-control form-control-sm ng-pristine ng-invalid is-invalid ng-touched']")));
            accountsClassPageObjects.name.SendKeys(Accountname);

            accountsClassPageObjects.Save.Click();*/



        }

    }
}