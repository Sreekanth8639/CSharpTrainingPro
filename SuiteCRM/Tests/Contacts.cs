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

        //Tc_015
        [Test]
        public void Verifycontactdropdown()
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            Assert.IsTrue(contacts.verifycreatecontacts.Displayed);
            Assert.IsTrue(contacts.verifycreatecontactsfromvcard.Displayed);
            Assert.IsTrue(contacts.verifyviewcontact.Displayed);
            Assert.IsTrue(contacts.verifyimportcontact.Displayed);

        }

        //Tc_016
        [Test]
        public void Verifycontactspage()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            contacts.contacts.Click();
            Assert.IsTrue(contacts.verifycontactspage.Displayed);

        }

        //Tc_017
        [Test]
        public void Verifycreatecontactspage()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            contacts.createcontacts.Click();
            Assert.IsTrue(contacts.verifycreatecontactspage.Displayed);

        }

        //Tc_018
        [Test]
        public void Verifyviewcontactspage()

        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            contacts.verifyviewcontact.Click();
            Assert.IsTrue(contacts.verifyviewcontactspage.Displayed);

        }


        //Tc_019
        [Test]
        [TestCase("John","Jons")]
        public void createcontacts(string a, string b)
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            contacts.createcontacts.Click();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            IWebElement element1 = driver.FindElement(By.XPath("(//input)[3]"));
            action.MoveToElement(element1).Click().Perform();
            
            //first name
        
            action.MoveToElement(element1).SendKeys(a).Perform();

            //Last name
            contacts.lastname.SendKeys(b);
            

            contacts.save.Click();

        }

        //Tc_020
        [Test]
        [TestCase("John", "Jons")]
        
        public void editcontacts(string a, string b)
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            ContactsPageObjects contacts = new ContactsPageObjects(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//nav//li[2]")));
            IWebElement element = driver.FindElement(By.XPath("//nav//li[2]"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            contacts.createcontacts.Click();

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement element1 = driver.FindElement(By.XPath("(//input)[3]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element1).Click().Perform();

            //first name

            action.MoveToElement(element1).SendKeys(a).Perform();

            //Last name
            contacts.lastname.SendKeys(b);

            contacts.save.Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[text()[normalize-space()='Edit']]")));

            contacts.edit.Click();

            IWebElement element2 = driver.FindElement(By.XPath("(//input)[3]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element2).Click().Perform();

            //first name
            
            action.MoveToElement(element2).SendKeys("y").Perform();

            Thread.Sleep(100);

            contacts.save.Click();

        }

        //TC_021

        [Test]
        [TestCase("John", "Jons")]
        
        public void popup(string a, string b)
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

            action.MoveToElement(element1).SendKeys(a).Perform();

            //Last name
            contacts.lastname.SendKeys(b);

            Thread.Sleep(50);

            contacts.cancel.Click();

            Assert.IsTrue(contacts.popup.Displayed);
            Thread.Sleep(50);
            contacts.ok.Click();

            Assert.IsTrue(contacts.verifycontactspage.Displayed);

        }

        //Tc_022
        [Test]
        
        [TestCase("John", "Jons")]

        public void newcontacts(string a, string b)
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

            action.MoveToElement(element1).SendKeys(a).Perform();

            //Last name
            contacts.lastname.SendKeys(b);

            contacts.save.Click();

            Thread.Sleep(5000);

            contacts.newcontact.Click();

            Assert.IsTrue(contacts.createcontact.Displayed);

        }

        //Tc_022
        [Test]

        [TestCase("John", "Jons")] 
        public void actiondropdown(string a, string b)
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

            action.MoveToElement(element1).SendKeys(a).Perform();

            //Last name
            contacts.lastname.SendKeys(b);

            contacts.save.Click();

            Thread.Sleep(5000);

            contacts.action.Click();

            
            IList<IWebElement> Dropdown = driver.FindElements(By.XPath("//div[@class=\"dropdown-menu show\"]/a"));
            string[] elements = { "Delete", "Duplicate", "View Change Log", "Find Duplicates", "Print as PDF" };

            for (int i = 0; i < elements.Length; i++)
            {
                Assert.AreEqual(elements[i], Dropdown[i].Text);
            }

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
