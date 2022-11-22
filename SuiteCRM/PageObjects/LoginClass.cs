using OpenQA.Selenium;
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

        
    }


}
