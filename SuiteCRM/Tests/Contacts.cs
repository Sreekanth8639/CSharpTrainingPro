using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SuiteCRM.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuiteCRM.Utilities;

namespace SuiteCRM.Tests
{
    public class Contacts :BaseClass
    {

        [Test]
        //Tc_015
        public void Verifycontactdropdown()
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display = contacts.verifycreatecontacts.Displayed;
            Assert.AreEqual(display, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display1 = contacts.verifycreatecontactsfromvcard.Displayed;

            Assert.AreEqual(display1, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display2 = contacts.verifyviewcontact.Displayed;

            Assert.AreEqual(display2, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display3 = contacts.verifyimportcontact.Displayed;

            Assert.AreEqual(display3, true);

        }

        [Test]
        //Tc_016
        public void Verifycontactspage()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);
            contacts.contacts.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display = contacts.verifycontactspage.Displayed;

            Assert.AreEqual(display, true);

        }

        [Test]
        //Tc_017
        public void Verifycreatecontactspage()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            contacts.createcontacts.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display = contacts.verifycreatecontactspage.Displayed;

            Assert.AreEqual(display, true);
        }

        [Test]
        //Tc_018
        public void Verifyviewcontactspage()

        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            contacts.verifyviewcontact.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display = contacts.verifyviewcontactspage.Displayed;

            Assert.AreEqual(display, true);

        }

        [Test]
        //Tc_019
        public void createcontacts()
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            contacts.createcontacts.Click();

            IWebElement element1 = driver.FindElement(By.XPath("(//input)[3]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element1).Click().Perform();

            //first name

            action.MoveToElement(element1).SendKeys("John").Perform();

            //Last name
            driver.FindElement(By.XPath("(//input)[4]")).SendKeys("jons");

            contacts.save.Click();

        }

        [Test]
        //Tc_020
        public void editcontacts()
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            contacts.createcontacts.Click();

            IWebElement element1 = driver.FindElement(By.XPath("(//input)[3]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element1).Click().Perform();

            //first name

            action.MoveToElement(element1).SendKeys("John").Perform();

            //Last name
            driver.FindElement(By.XPath("(//input)[4]")).SendKeys("jons");

            contacts.save.Click();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()[normalize-space()='Edit']]")));
            Thread.Sleep(500);
            contacts.edit.Click();

            IWebElement element2 = driver.FindElement(By.XPath("(//input)[3]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element2).Click().Perform();

            //first name
            
            action.MoveToElement(element2).SendKeys("y").Perform();

            Thread.Sleep(100);

            contacts.save.Click();

        }


        [Test]
        //TC_021
        public void popup()
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            contacts.createcontacts.Click();

            IWebElement element1 = driver.FindElement(By.XPath("(//input)[3]"));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));

            action.MoveToElement(element1).Click().Perform();

            //first name

            action.MoveToElement(element1).SendKeys("John").Perform();

            //Last name
            driver.FindElement(By.XPath("(//input)[4]")).SendKeys("Doe");

            Thread.Sleep(50);

            contacts.cancel.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display = contacts.popup.Displayed;

            Assert.AreEqual(display, true);

            contacts.ok.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display1 = contacts.verifycontactspage.Displayed;

            Assert.AreEqual(display1, true);

        }

        [Test]
        //Tc_022
        public void newcontacts()
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            contacts.createcontacts.Click();

            IWebElement element1 = driver.FindElement(By.XPath("(//input)[3]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element1).Click().Perform();

            //first name

            action.MoveToElement(element1).SendKeys("John").Perform();

            //Last name
            driver.FindElement(By.XPath("(//input)[4]")).SendKeys("Doe");

            contacts.save.Click();

            Thread.Sleep(5000);

            contacts.newcontact.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display = contacts.createcontact.Displayed;

            Assert.AreEqual(display, true);

        }

        [Test]
        //Tc_022
        public void actiondropdown()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            contacts.createcontacts.Click();

            IWebElement element1 = driver.FindElement(By.XPath("(//input)[3]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element1).Click().Perform();

            //first name

            action.MoveToElement(element1).SendKeys("John").Perform();

            //Last name
            driver.FindElement(By.XPath("(//input)[4]")).SendKeys("Doe");

            contacts.save.Click();

            Thread.Sleep(5000);

            IWebElement element2 = driver.FindElement(By.XPath("//scrm-dropdown-button[@class=\"ng-star-inserted\"]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//scrm-dropdown-button[@class=\"ng-star-inserted\"]")));
            action.MoveToElement(element2).Click().Perform();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display1 = contacts.delete.Displayed;

            Assert.AreEqual(display1, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display2 = contacts.duplicate.Displayed;

            Assert.AreEqual(display2, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display3 = contacts.viewchangelog.Displayed;

            Assert.AreEqual(display3, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display4 = contacts.findDuplicates.Displayed;

            Assert.AreEqual(display4, true);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Boolean display5 = contacts.printasPDF.Displayed;

            Assert.AreEqual(display5, true);

            
        }

        [Test]
        public void verifyDeletingContact()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            ContactsPageObjects contacts = new ContactsPageObjects(driver);
            contacts.CreateContacts.Click();


            IWebElement element1 = contacts.FirstName;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element1).Click().Perform();
            action.MoveToElement(element1).SendKeys("John").Perform();
            contacts.LastName.SendKeys("Doe");
            contacts.SaveButton.Click();
            Thread.Sleep(3000);
            contacts.ActionButton.Click();
            contacts.DeleteButton.Click();
            Thread.Sleep(1000);
            contacts.ProceedButton.Click();
            Assert.IsTrue(contacts.DeletingAlert.Displayed);


        }


    }
}
