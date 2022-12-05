using MongoDB.Driver.Core.Operations;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteCRM.PageObjects
{

    public class DashboardPage
    {
        IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@href=\"#/opportunities\"]")]
        public IWebElement opprtunitiesDropdown;

        [FindsBy(How = How.XPath, Using = "//scrm-base-menu-item-link[@class=\"ng-star-inserted\"]//child::a[text()[normalize-space()='Create Opportunity']]")]
        public IWebElement createOpprtunityOption;

        [FindsBy(How = How.XPath, Using = "//div[1]/div[1]/div[2]/div[1]/scrm-field/scrm-dynamic-field/scrm-varchar-edit/input")]
        public IWebElement opportunityName;

        [FindsBy(How = How.XPath, Using = "//scrm-field/scrm-dynamic-field/scrm-group-field/div/div[2]/span[2]/scrm-dynamic-field/scrm-varchar-edit/input")]
        public IWebElement opportunityAmount;

        [FindsBy(How = How.XPath, Using = "(//input[@placeholder=\"Select an item\"])[2]")]
        public IWebElement opportunitySalesStage;

        [FindsBy(How = How.XPath, Using = "/html/body/ng2-dropdown-menu[3]/div")]
        public IWebElement opportunitySalesStageDropdown;

        [FindsBy(How = How.XPath, Using = "(//input[@placeholder=\"Type to search...\"])[1]")]
        public IWebElement opportunityAccount;

        [FindsBy(How = How.XPath, Using = "/html/body/ng2-dropdown-menu[1]/div")]
        public IWebElement opportunityAccountDropdown;

        [FindsBy(How = How.XPath, Using = "//div[@class=\"field-datetime-edit input-group\"]/input")]
        public IWebElement opportunityCloseDate;

        [FindsBy(How = How.XPath, Using = "//button[text()[normalize-space()='Save']]")]
        public IWebElement createOpportunitySaveButton;

        [FindsBy(How = How.XPath, Using = "//div[@class=\"record-view-name d-flex\"]/scrm-dynamic-label/span")]
        public IWebElement createdOpportunityPageName;
        
        [FindsBy(How = How.XPath, Using = "//scrm-base-menu-item-link[@class=\"ng-star-inserted\"]//child::a[text()[normalize-space()='View Opportunities']]")]
        public IWebElement viewOpportunityOption;

        [FindsBy(How = How.XPath, Using = "(//span[@class=\"checkmark\"])[2]")]
        public IWebElement viewOpportunityCheckbox;

        [FindsBy(How = How.XPath, Using = "//div[@class=\"list-view-tableactions table-header\"]//button[text()=' Bulk Action ']")]
        public IWebElement bulkActionButton;

        [FindsBy(How = How.XPath, Using = "(//button[@class=\"dropdown-toggle bulk-action-button btn btn-sm\"])[2]//following-sibling::div/a/div/div")]
        public IList<IWebElement> bulkActionDropdownElements;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space(text())='Import Opportunities']")]
        public IWebElement importOpportuntiesOption;

        [FindsBy(How = How.XPath, Using = "(//a[starts-with(@href, \"#/opportunities/record\")])[5]")]
        public IWebElement recordInViewOpportunties;

        [FindsBy(How = How.XPath, Using = "//scrm-dropdown-button[@autoclose=\"outside\"]/div/button")]
        public IWebElement actionsDropdownInExistingOpportunty;

        [FindsBy(How = How.XPath, Using = "//div[text()=' Delete ']")]
        public IWebElement deleteInActionsDropdownInExistingOpportunty;

        [FindsBy(How = How.XPath, Using = "//button//scrm-label[text()=' Proceed ']")]
        public IWebElement proceedToDeleteExistingOpportunty;

        [FindsBy(How = How.XPath, Using = "//div[@class=\"d-flex justify-content-center flex-column align-items-center message-container ng-tns-c336-0 ng-star-inserted\"]")]
        public IWebElement deletionAlertText;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Edit ']")]
        public IWebElement editButtonInExistingOpportunty;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Save ']")]
        public IWebElement saveButtonInExistingOpportunty;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Filter ']")]
        public IWebElement filterButtonInViewOpportunties;

        [FindsBy(How = How.XPath, Using = "//scrm-label[text()=' Search ']")]
        public IWebElement searchButtonToFilterOpportunties;

        [FindsBy(How = How.XPath, Using = "//div/scrm-field-layout/form/div[2]/div[2]/div[2]/div[1]/scrm-field/scrm-dynamic-field/scrm-date-detail")]
        public IWebElement getTextXpathOfOpportuntiesCloseDate;





        
    }
}
