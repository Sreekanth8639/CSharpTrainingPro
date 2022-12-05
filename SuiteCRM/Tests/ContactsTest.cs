using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SuiteCRM.PageObjects;
using SuiteCRM.Tests;
using SuiteCRM.Utilities;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace SuiteCRM.Tests {
    public class ContactsTest : BaseClass
    {

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
            ContactsPage ContactPageObj = new ContactsPage(driver);
            ContactPageObj.CreateContacts.Click();

            
            IWebElement element1 = ContactPageObj.FirstName;
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//input)[3]")));
            action.MoveToElement(element1).Click().Perform();
            action.MoveToElement(element1).SendKeys("John").Perform();
            ContactPageObj.LastName.SendKeys("Doe");
            ContactPageObj.SaveButton.Click();
            Thread.Sleep(3000);
            ContactPageObj.ActionButton.Click();
            ContactPageObj.DeleteButton.Click();
            Thread.Sleep(1000);
            ContactPageObj.ProceedButton.Click();
            Assert.IsTrue(ContactPageObj.DeletingAlert.Displayed);


        }
    }
}
