using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteCRM.PageObjects
{
    public class ContactsPage
    {

        IWebDriver driver;
        public ContactsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//div//li[2]//div/div[1]//scrm-base-menu-item-link/a")]
        public IWebElement CreateContacts;

       [FindsBy(How = How.XPath, Using = "(//input)[3]")]
        public IWebElement FirstName;

        [FindsBy(How = How.XPath, Using = "(//input)[4]")]
        public IWebElement LastName;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Save ']")]
        public IWebElement SaveButton;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Actions ']")]
        public IWebElement ActionButton;     

        [FindsBy(How = How.XPath, Using = "//div[text()=' Delete ']")]
        public IWebElement DeleteButton;

        [FindsBy(How = How.XPath, Using = "//scrm-label[text()=' Proceed ']")]
        public IWebElement ProceedButton;

        [FindsBy(How =How.XPath, Using = "//div[@role='alert']")]
        public IWebElement DeletingAlert;

    }
}
