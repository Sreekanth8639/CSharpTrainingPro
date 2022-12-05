using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteCRM.PageObjects
{
    public class LeadsPage
    {

        IWebDriver driver;
        public LeadsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "(//input)[4]")]
        public IWebElement LastName;

       [FindsBy(How = How.XPath, Using = "(//input)[3]")]
        public IWebElement FirstName;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space(text())='Create Lead']")]
        public IWebElement CreateLead;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space(text())='Create Lead From vCard']")]
        public IWebElement CreateLeadFromvCard;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space(text())='View Leads']")]
        public IWebElement ViewLeads;     

        [FindsBy(How = How.XPath, Using = "//a[normalize-space(text())='Import Leads']")]
        public IWebElement ImportLeads;

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Save']")]
        public IWebElement Save;

        [FindsBy(How =How.XPath, Using = "//div[@class='col-md-4']")]
        public IWebElement CreateLeadPage;

        [FindsBy(How = How.XPath, Using = "(//input)[3]")]
        public IWebElement FirstNameInput;

        [FindsBy(How = How.XPath, Using = "(//input)[4]")]  
        public IWebElement LastNameInput;

        [FindsBy(How = How.XPath, Using = "(//input)[6]")]
        public IWebElement JobTitle;

        [FindsBy(How = How.XPath, Using = "(//input)[7]")]
        public IWebElement Mobile;

        [FindsBy(How = How.XPath, Using = "(//input)[8]")]
        public IWebElement Department;

        [FindsBy(How = How.XPath, Using = "//a[text()='MORE INFORMATION']")]
        public IWebElement MoreInformationButton;

        [FindsBy(How = How.XPath, Using = "(//textarea)[1]")]
        public IWebElement StatusDescription;

        [FindsBy(How = How.XPath, Using = "(//input)[4]")]
        public IWebElement OpportunityAmount;

        [FindsBy(How = How.XPath, Using = "//span[text()='Missing required field: Last Name']")]
        public IWebElement MissingFieldError;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Cancel ']")]
        public IWebElement CancelButton;

        [FindsBy(How = How.XPath, Using = "//scrm-label[@class='ng-tns-c337-8']")]
         public IWebElement CancelWarning;

        [FindsBy(How = How.XPath, Using = "(//button[@type='button'])[8]")]
        public IWebElement OKButton;

        [FindsBy(How = How.XPath, Using = "(//button[@type='button'])[7]")]
        public IWebElement CancelButtonPopup;

        [FindsBy(How = How.XPath, Using = "(//button[@type='button'])[8]")]
        public IWebElement OKButtonPopup;
    }
}
