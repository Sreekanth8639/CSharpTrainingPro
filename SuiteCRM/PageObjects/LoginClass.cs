using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteCRM.PageObjects
{
    public class LoginClass
    {
        IWebDriver driver;
        public LoginClass(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//input[@aria-label=\"Username\"]")]
        public IWebElement username;

        [FindsBy(How = How.XPath, Using = "//input[@aria-label=\"Password\"]")]
        public IWebElement password;

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement login;

        public void validLogin(string v1, string v2)
        {
            username.SendKeys(v1);
            password.SendKeys(v2);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login-button")));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            login.Click();
        }

    }


}
