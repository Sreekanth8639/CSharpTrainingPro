using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteCRM.PageObjects
{
    public class Quotes
    {
        IWebDriver driver;
        public Quotes(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='#/quotes']")]
        public IWebElement quotes;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")]
        public IWebElement createQuote;

        [FindsBy(How = How.XPath, Using = "//input[@id='name']")]
        public IWebElement quoteTitle;

        [FindsBy(How = How.XPath, Using = "//input[@id='SAVE']")]
        public IWebElement quoteSave;

        [FindsBy(How = How.XPath, Using = "//div[text()='Missing required field: Title']")]
        public IWebElement quoteErrorMessage;

        [FindsBy(How = How.XPath, Using = "//button[@id='btn_billing_account']//*[name()='svg']")]
        public IWebElement quoteAccountCursor;

        [FindsBy(How = How.XPath, Using = "//table[4]/tbody")]
        public IWebElement quoteAccountTable;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Sea Region Inc']")]
        public IWebElement quoteAccountName;

        [FindsBy(How = How.XPath, Using = "//input[@id='billing_account']")]
        public IWebElement quoteAccountNameTextBox;

        [FindsBy(How = How.XPath, Using = "//table[4]")]
        public IWebElement opportunityTable;

        



    }
}
