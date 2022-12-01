using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteCRM.PageObjects
{
    public class AccountsPage
    {

        IWebDriver driver;
        public AccountsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Accounts']")]
        public IWebElement acounts;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/accounts/edit?return_module=Accounts&return_action=DetailView']")]
        public IWebElement CreateAccounts;

        [FindsBy(How = How.XPath, Using = "//span[@class='dynamic-label ng-star-inserted']")]
        public IWebElement create;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/accounts/index?return_module=Accounts&return_action=DetailView']")]
        public IWebElement View;

        [FindsBy(How = How.XPath, Using ="//span[text()='Create']")]
        public IWebElement Createtitle;     

        [FindsBy(How = How.XPath, Using = "(//input)[2]")]
        public IWebElement name;

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Save']")]
        public IWebElement Save;

        [FindsBy(How =How.XPath, Using ="//scrm-module-title[@class='record-view-title']")]
        public IWebElement accountstitle;

        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
        public IWebElement Error;

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Edit']")]  
        public IWebElement Edit;

        [FindsBy(How = How.XPath, Using ="//*[@id=\"ngb-nav-24-panel\"]/div/scrm-field-layout/form/div[1]/div[1]/div[2]/div[1]/scrm-field/scrm-dynamic-field/scrm-varchar-detail")]
        public IWebElement Title;

        [FindsBy(How = How.XPath, Using ="//scrm-label[normalize-space()='Ok']")]
        public IWebElement Popup;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/div/scrm-create-record/div/scrm-record-header/div/div/div[2]/div/div[2]/scrm-action-group-menu/div/scrm-button-group/div/scrm-button[2]/button")]
        public IWebElement Cancel;

        [FindsBy(How = How.XPath, Using = "//button[@class='button-group-button settings-button'][normalize-space()='New']")]
        public IWebElement New;

        [FindsBy(How = How.XPath, Using = "//button[@class='dropdown-toggle button-group-button settings-button']")]
        public IWebElement actiondrop;

        [FindsBy(How = How.XPath, Using = "//body//app-root//scrm-record-header//a[1]")]
        public IWebElement Delete;

        [FindsBy(How = How.XPath, Using = "//div[@class='flex-grow-1'][normalize-space()='Duplicate']")]
        public IWebElement Duplicate;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'View Change Log')]")]
        public IWebElement Viewchangelog;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Find Duplicates')]")]
         public IWebElement Findduplicates;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Print as PDF')]")]
        public IWebElement Printpdf;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn-main button-group-button modal-button btn btn-sm']")]
        public IWebElement Deleteprocede;

        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
        public IWebElement Deletesucesfull;
    }
}
