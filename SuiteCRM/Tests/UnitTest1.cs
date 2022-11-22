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
        [TestCase("Will", "Will")]
        public void Test1(String username, String password)
        {
            LoginClass loginClassPageOjbects = new LoginClass(driver);
            loginClassPageOjbects.username.SendKeys(username);
            loginClassPageOjbects.password.SendKeys(password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-button")));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            loginClassPageOjbects.login.Click();
            


        }
    }
}