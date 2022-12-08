using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SuiteCRM.PageObjects;
using SuiteCRM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V105.Runtime;
using System.Collections;

namespace SuiteCRM.Tests
{
    public class Quotes3 : BaseClass
    {
        [Test]
        public void saveButton35()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            Quotes quote = new Quotes(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes']")));

            IWebElement element = driver.FindElement(By.XPath("//a[@href='#/quotes']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")));

            quote.createQuote.Click();
            driver.SwitchTo().Frame(quote.quotesFrame);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@role='button']//preceding::div[@id='detailpanel_-1']//input[@id='name']")));
            quote.quoteTitle.SendKeys("Phillipse");
            WebDriverWait wait9 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            String title = quote.quoteTitle.GetAttribute("value");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='SAVE']")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            quote.quoteSave.Click();
            driver.SwitchTo().Frame(quote.frameAfterquotes);
            String titleQuote = quote.quoteTitleHeader.Text;

            Assert.AreEqual(title, titleQuote);

        }
        
        [Test]
        public void errorMessage40()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            Quotes quote = new Quotes(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes']")));

            IWebElement element = driver.FindElement(By.XPath("//a[@href='#/quotes']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")));

            quote.createQuote.Click();


            driver.SwitchTo().Frame(quote.quotesFrame);


            WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='SAVE']")));


            Boolean visible = quote.quoteSave.Displayed;
            Console.WriteLine(visible);

            quote.quoteSave.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Boolean errorMessage = quote.quoteErrorMessage.Displayed;
            Console.WriteLine(errorMessage);
            Assert.AreEqual(errorMessage, true);
        }
        
        [Test]
        public void opportunityWindow41()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            Quotes quote = new Quotes(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes']")));

            IWebElement element = driver.FindElement(By.XPath("//a[@href='#/quotes']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")));

            quote.createQuote.Click();
            driver.SwitchTo().Frame(quote.quotesFrame);


            WebDriverWait wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='name']")));


            quote.quoteTitle.SendKeys("Phillipse");

            IWebElement element2 = driver.FindElement(By.XPath("//button[@id='btn_opportunity']//*[name()='svg']"));
            Actions action2 = new Actions(driver);
            action.MoveToElement(element2).Perform();

            element2.Click();

            String firstWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(firstWindow);
            TestContext.Progress.WriteLine(quote.opportunityTable);
            Assert.True(quote.opportunityTable.Displayed);

            quote.accountNameSecondWindow.SendKeys("AB Drivers Limited - 1000 units");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//input[@id='search_form_submit']")).Click();
            quote.searchButtonSecondWindow.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            IWebElement oppportuniyName = quote.opportunityNameSecondWindow;
            oppportuniyName.Click();
            String firstWindow2 = driver.WindowHandles[0];
            driver.SwitchTo().Window(firstWindow2);

            driver.SwitchTo().Frame(quote.quotesFrame);

            String opportunityQuote = quote.opportunityName.GetAttribute("value");
            Assert.True(opportunityQuote.Contains("AB Drivers Limited - 1000 units"));

        }

       
        [Test]
        public void account36()
        {

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            Quotes quote = new Quotes(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes']")));

            IWebElement element = driver.FindElement(By.XPath("//a[@href='#/quotes']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")));

            quote.createQuote.Click();
            driver.SwitchTo().Frame(quote.quotesFrame);


            quote.quoteTitle.SendKeys("Phillipse");
            IWebElement account2 = quote.quoteAccountNameTextBox;
            account2.SendKeys("Robert");
            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='btn_billing_account']//*[name()='svg']")));


            IWebElement element2 = quote.quoteAccountCursor;
            element2.Click();

            Assert.AreEqual(2, driver.WindowHandles.Count);
            String secondWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(secondWindow);
            TestContext.Progress.WriteLine(quote.quoteAccountName);
            String variable = "Sea Region Inc";

            ArrayList a = new ArrayList();
            IList<IWebElement> accountnames = driver.FindElements(By.XPath("//table[4]/tbody"));
            foreach (IWebElement accountName in accountnames)
            {
                a.Add(accountName);
            }
            quote.accountNameSecondWindow.SendKeys("Sea Region Inc");
            quote.searchButtonSecondWindow.Click();

            if (a.Contains("Sea Region Inc"))
            {
                Assert.Equals("Sea Region Inc", variable);
            }


            quote.quoteAccountName.Click();

            String firstWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(firstWindow);
            TestContext.Progress.WriteLine(quote.quoteAccountNameTextBox);
            driver.SwitchTo().Frame(quote.quotesFrame);

            String name = quote.quoteAccountNameTextBox.GetAttribute("value");
            Assert.True(name.Contains("Sea Region Inc"));
        }
        
        [Test]
        public void searchAccount37()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            Quotes quote = new Quotes(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes']")));

            IWebElement element = driver.FindElement(By.XPath("//a[@href='#/quotes']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")));

            quote.createQuote.Click();
            driver.SwitchTo().Frame(quote.quotesFrame);


            quote.quoteTitle.SendKeys("Phillipse");
            IWebElement account2 = quote.quoteAccountNameTextBox;
            account2.SendKeys("Robert");
            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='btn_billing_account']//*[name()='svg']")));


            IWebElement element2 = quote.quoteAccountCursor;
            element2.Click();

            Assert.AreEqual(2, driver.WindowHandles.Count);
            String secondWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(secondWindow);
            TestContext.Progress.WriteLine(quote.quoteAccountName);
            String variable = "Sea Region Inc";

            ArrayList a = new ArrayList();
            IList<IWebElement> accountnames = driver.FindElements(By.XPath("//table[4]/tbody"));
            foreach (IWebElement accountName in accountnames)
            {
                a.Add(accountName);
            }
            quote.accountNameSecondWindow.SendKeys("Sea Region Inc");
            quote.searchButtonSecondWindow.Click();

            if (a.Contains("Sea Region Inc"))
            {
                Assert.Equals("Sea Region Inc", variable);
            }


            quote.quoteAccountName.Click();

            String firstWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(firstWindow);
            TestContext.Progress.WriteLine(quote.quoteAccountNameTextBox);
            driver.SwitchTo().Frame(quote.quotesFrame);

            String name = quote.quoteAccountNameTextBox.GetAttribute("value");
            Assert.True(name.Contains("Sea Region Inc"));

        }
        

        [Test]
        public void billingShippingAddress39()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            Quotes quote = new Quotes(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes']")));

            IWebElement element = driver.FindElement(By.XPath("//a[@href='#/quotes']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")));

            quote.createQuote.Click();
            driver.SwitchTo().Frame(quote.quotesFrame);


            quote.quoteTitle.SendKeys("hemsworth");
            IWebElement account2 = quote.quoteAccountNameTextBox;
            account2.SendKeys("Robert");
            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='btn_billing_account']//*[name()='svg']")));


            IWebElement element2 = quote.quoteAccountCursor;
            element2.Click();

            Assert.AreEqual(2, driver.WindowHandles.Count);
            String secondWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(secondWindow);
            TestContext.Progress.WriteLine(quote.quoteAccountName);
            String variable = "Sea Region Inc";

            ArrayList a = new ArrayList();
            IList<IWebElement> accountnames = driver.FindElements(By.XPath("//table[4]/tbody"));
            foreach (IWebElement accountName in accountnames)
            {
                a.Add(accountName);
            }
            quote.accountNameSecondWindow.SendKeys("Sea Region Inc");
            quote.searchButtonSecondWindow.Click();

            if (a.Contains("Sea Region Inc"))
            {
                Assert.Equals("Sea Region Inc", variable);
            }


            quote.quoteAccountName.Click();

            String firstWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(firstWindow);
            TestContext.Progress.WriteLine(quote.quoteAccountNameTextBox);
            driver.SwitchTo().Frame(quote.quotesFrame);

            String name = quote.quoteAccountNameTextBox.GetAttribute("value");
            Assert.True(name.Contains("Sea Region Inc"));

            String billingaddrs = quote.billingAddress.GetAttribute("value");
            String shippingaddrs = quote.shippingAddress.GetAttribute("value");
            Assert.AreEqual(billingaddrs, shippingaddrs);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            quote.shippingAddress.Clear();
            quote.shippingAddress.SendKeys("USA");


            WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='shipping_checkbox']")));

            Assert.IsTrue(quote.copyAddressCheckBox.Enabled);

        }
        
        [Test]
        public void crossButtonBesideAccount38()
        {
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");

            Quotes quote = new Quotes(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes']")));

            IWebElement element = driver.FindElement(By.XPath("//a[@href='#/quotes']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='#/quotes/edit?return_module=AOS_Quotes&return_action=DetailView']")));

            quote.createQuote.Click();
            driver.SwitchTo().Frame(quote.quotesFrame);


            quote.quoteTitle.SendKeys("Phillipse");
            IWebElement account2 = quote.quoteAccountNameTextBox;
            account2.SendKeys("Robert");
            WebDriverWait wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='btn_billing_account']//*[name()='svg']")));


            IWebElement element2 = quote.quoteAccountCursor;
            element2.Click();

            Assert.AreEqual(2, driver.WindowHandles.Count);
            String secondWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(secondWindow);
            TestContext.Progress.WriteLine(quote.quoteAccountName);
            String variable = "Sea Region Inc";

            ArrayList a = new ArrayList();
            IList<IWebElement> accountnames = driver.FindElements(By.XPath("//table[4]/tbody"));
            foreach (IWebElement accountName in accountnames)
            {
                a.Add(accountName);
            }
            quote.accountNameSecondWindow.SendKeys("Sea Region Inc");
            quote.searchButtonSecondWindow.Click();

            if (a.Contains("Sea Region Inc"))
            {
                Assert.Equals("Sea Region Inc", variable);
            }


            quote.quoteAccountName.Click();

            String firstWindow = driver.WindowHandles[0];
            driver.SwitchTo().Window(firstWindow);
            TestContext.Progress.WriteLine(quote.quoteAccountNameTextBox);
            driver.SwitchTo().Frame(quote.quotesFrame);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            account2.SendKeys("cruise");
            WebDriverWait wait7 = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='btn_clr_billing_contact']//*[name()='svg']//*[name()='g']//*[name()='polygon' and contains(@class,'st0')]")));

            IWebElement element3 = driver.FindElement(By.XPath("//button[@id='btn_clr_billing_account']//*[name()='svg']"));
            Assert.True(element3.Enabled);
            element3.Click();

            if (quote.quoteAccountNameTextBox == null)
            {
                Assert.True(true);
            }

        }

    }
}
