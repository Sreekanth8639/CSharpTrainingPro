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


        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Sea Region Inc']")]
        public IWebElement quoteAccountName;

        [FindsBy(How = How.XPath, Using = "//input[@id='billing_account']")]
        public IWebElement quoteAccountNameTextBox;

        [FindsBy(How = How.XPath, Using = "//table[4]")]
        public IWebElement opportunityTable;

        [FindsBy(How = How.XPath, Using = "//iframe[@src='./legacy/index.php?return_module=AOS_Quotes&return_action=DetailView&module=AOS_Quotes&action=EditView']")]
        public IWebElement quotesFrame;

        [FindsBy(How = How.XPath, Using = "//h2[@class='module-title-text']")]
        public IWebElement quoteTitleHeader;

        [FindsBy(How = How.XPath, Using = "//iframe")]
        public IWebElement frameAfterquotes;

        [FindsBy(How = How.XPath, Using = "//input[@id='name_advanced']")]
        public IWebElement accountNameSecondWindow;

        [FindsBy(How = How.XPath, Using = "//input[@id='search_form_submit']")]
        public IWebElement searchButtonSecondWindow;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='AB Drivers Limited - 1000 units']")]
        public IWebElement opportunityNameSecondWindow;

        [FindsBy(How = How.XPath, Using = "//input[@id='opportunity']")]
        public IWebElement opportunityName;
        [FindsBy(How = How.XPath, Using = "//textarea[@id='billing_address_street']")]
        public IWebElement billingAddress;
        [FindsBy(How = How.XPath, Using = "//textarea[@id='shipping_address_street']")]
        public IWebElement shippingAddress;

        [FindsBy(How = How.XPath, Using = "//input[@id='shipping_checkbox']")]
        public IWebElement copyAddressCheckBox;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")]
        public IWebElement createQuote;

        [FindsBy(How = How.XPath, Using = "//input[@id='name']")]
        public IWebElement quoteTitle;


        [FindsBy(How = How.XPath, Using = "//button[@id='btn_billing_account']//*[name()='svg']")]
        public IWebElement quoteAccountCursor;

        [FindsBy(How = How.XPath, Using = "//input[@id='SAVE']")]
        public IWebElement quoteSave;

        [FindsBy(How = How.XPath, Using = "//div[text()='Missing required field: Title']")]
        public IWebElement quoteErrorMessage;

    }
}
