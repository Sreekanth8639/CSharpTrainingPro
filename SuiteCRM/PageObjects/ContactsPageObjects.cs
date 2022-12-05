using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteCRM.PageObjects
{
    public class ContactsPageObjects
    {
        IWebDriver driver;
        public ContactsPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//nav//li[2]")]
        public IWebElement contacts;

        [FindsBy(How = How.XPath, Using = "//div/nav/div[1]/ul/li[2]/scrm-menu-item/scrm-base-menu-item/div/div[1]/scrm-menu-item-link/scrm-base-menu-item-link/a")]
        public IWebElement createcontacts;

        [FindsBy(How = How.XPath, Using = "//div/nav/div[1]/ul/li[2]/scrm-menu-item/scrm-base-menu-item/div/div[1]/scrm-menu-item-link/scrm-base-menu-item-link/a")]
        public IWebElement verifycreatecontacts;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/contacts/importvcard']")]
        public IWebElement verifycreatecontactsfromvcard;

        [FindsBy(How = How.XPath, Using = "//a[@href='#/contacts/index?return_module=Contacts&return_action=DetailView']")]
        public IWebElement verifyviewcontact;

        [FindsBy(How = How.XPath, Using = "//li[2]//scrm-menu-item[1]//scrm-base-menu-item[1]//div[1]//div[4]//scrm-menu-item-link[1]//scrm-base-menu-item-link[1]//a[1]")]
        public IWebElement verifyimportcontact;



        [FindsBy(How = How.XPath, Using = "//scrm-module-title[@class='list-view-title']")]
        public IWebElement verifycontactspage;


        [FindsBy(How = How.XPath, Using = "//span[@class='dynamic-label ng-star-inserted']")]
        public IWebElement verifycreatecontactspage;

        [FindsBy(How = How.XPath, Using = "//scrm-module-title[@class='list-view-title']")]
        public IWebElement verifyviewcontactspage;

        [FindsBy(How = How.XPath, Using = "//input)[3]")]
        public IWebElement firstname;

        [FindsBy(How = How.XPath, Using = "(//input)[4]")]
        public IWebElement lastname;

        [FindsBy(How = How.XPath, Using = "//button[text()=\" Save \"]")]
        public IWebElement save;

        [FindsBy(How = How.XPath, Using = "//button[text()[normalize-space()='Edit']]")]
        public IWebElement edit;

        [FindsBy(How = How.XPath, Using = "(//button[text()=\" New \"])[2]")]
        public IWebElement newcontact;


        [FindsBy(How = How.XPath, Using = "//span[text()=\"Create\"]")]
        public IWebElement createcontact;

        [FindsBy(How = How.XPath, Using = "//html//scrm-dropdown-button/div/button")]
        public IWebElement actiondropdown;

        [FindsBy(How = How.XPath, Using = "//div[text()=\" Delete \"]")]
        public IWebElement delete;

        [FindsBy(How = How.XPath, Using = "//div[@class='flex-grow-1'][normalize-space()='Duplicate']")]
        public IWebElement duplicate;

        [FindsBy(How = How.XPath, Using = "//div[text()=\" View Change Log \"]")]
        public IWebElement viewchangelog;

        [FindsBy(How = How.XPath, Using = "//div[text()=\" Find Duplicates \"]")]
        public IWebElement findDuplicates;

        [FindsBy(How = How.XPath, Using = "//div[text()=\" Print as PDF \"]")]
        public IWebElement printasPDF;

        [FindsBy(How = How.XPath, Using = "(//button)[4]")]
        public IWebElement cancel;

        [FindsBy(How = How.XPath, Using = "//scrm-label[text()=\" You are about to leave this record without saving any changes you may have made to the record. Are you sure you want to navigate away from this record? \"]")]
        public IWebElement popup;

        [FindsBy(How = How.XPath, Using = "//scrm-label[text()=\" Ok \"]")]
        public IWebElement ok;

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

        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
        public IWebElement DeletingAlert;


    }
}
