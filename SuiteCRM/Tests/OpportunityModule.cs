using MongoDB.Driver.Core.Authentication;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SuiteCRM.PageObjects;
using SuiteCRM.Utilities;
using System.Runtime.ConstrainedExecution;

namespace SuiteCRM.Tests
{
    public class Tests : BaseClass
    {

        
        //TC-43
        [Test]
        [TestCase("will", "will", "Demo1")]
        public void createOpportunity(string username, string password, string oppName)
        {
            LoginClass loginClassPageOjbects = new LoginClass(driver);
            DashboardPage dashboardPage = loginClassPageOjbects.validLogin(username, password);

                Thread.Sleep(TimeSpan.FromSeconds(5));
                Actions action = new Actions(driver);
                action.MoveToElement(dashboardPage.opprtunitiesDropdown).Build().Perform();
                dashboardPage.createOpprtunityOption.Click();
                dashboardPage.opportunityName.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage.opportunityName.SendKeys(oppName);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage.opportunityAmount.SendKeys("$50");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage.opportunitySalesStage.SendKeys("Qualification");
                dashboardPage.opportunitySalesStageDropdown.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage.opportunityAccount.SendKeys("AB Drivers Limited");
                dashboardPage.opportunityAccountDropdown.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage.opportunityCloseDate.SendKeys("2022-12-30");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                dashboardPage.createOpportunitySaveButton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
                String opporPageName = dashboardPage.createdOpportunityPageName.Text;
                Console.WriteLine(opporPageName);
                Assert.AreEqual("Opportunity is not created as expected", oppName, opporPageName);           

        }

        //TC-49
        [Test]
        [TestCase("will", "will")]
        public void bulkActionDropdownOptions(string username, string password)
        {
            LoginClass loginClassPageOjbects = new LoginClass(driver);
            DashboardPage dashboardPage = loginClassPageOjbects.validLogin(username, password);

            //dashboardPage.bulkActionDropdownOptions();
            
            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage.opprtunitiesDropdown).Build().Perform();
            dashboardPage.viewOpportunityOption.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage.viewOpportunityCheckbox.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage.bulkActionButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            IList<IWebElement> bulkDropdown = dashboardPage.bulkActionDropdownElements;
                string[] elements = { "Delete", "Export", "Merge", "Mass Update" };

                for (int j = 0; j < elements.Length; j++)
                {
                    Assert.AreEqual(elements[j], bulkDropdown[j].Text);
                }
            
        }


        
        //TC_42
        [Test]
        [TestCase("will", "will")]
        public void opportunitiesDropdownOptions(string username, string password)
        {
            LoginClass loginClassPageOjbects = new LoginClass(driver);
            DashboardPage dashboardPage = loginClassPageOjbects.validLogin(username, password);

            //dashboardPage.opportunitiesDropdownOptions();
            
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage.opprtunitiesDropdown).Build().Perform();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Assert.IsTrue(dashboardPage.createOpprtunityOption.Displayed);
            Assert.IsTrue(dashboardPage.viewOpportunityOption.Displayed);
            Assert.IsTrue(dashboardPage.importOpportuntiesOption.Displayed);
        }

        //TC-46
        [Test]
        [TestCase("will", "will")]
        public void deleteOpportunities(string username, string password)
        {
            LoginClass loginClassPageOjbects = new LoginClass(driver);
            DashboardPage dashboardPage = loginClassPageOjbects.validLogin(username, password);

            //dashboardPage.deleteOpportunities();
            
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage.opprtunitiesDropdown).Build().Perform();
            dashboardPage.viewOpportunityOption.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage.recordInViewOpportunties.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage.actionsDropdownInExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            dashboardPage.deleteInActionsDropdownInExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            dashboardPage.proceedToDeleteExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            string alert = dashboardPage.deletionAlertText.Text;
            Console.WriteLine(alert.Trim());
            Assert.AreEqual("Record deleted successfully\r\n×", alert.Trim());
        }

        //TC-44
        [Test]
        [TestCase("will", "will", "2022-12-30")]
        public void editOpportunities(string username, string password, string data)
        {
            LoginClass loginClassPageOjbects = new LoginClass(driver);
            DashboardPage dashboardPage = loginClassPageOjbects.validLogin(username, password);

            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage.opprtunitiesDropdown).Build().Perform();
            dashboardPage.viewOpportunityOption.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage.recordInViewOpportunties.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            string previousData = dashboardPage.getTextXpathOfOpportuntiesCloseDate.Text;
            
            Console.WriteLine(previousData);
            dashboardPage.editButtonInExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            dashboardPage.opportunityCloseDate.Clear();
            dashboardPage.opportunityCloseDate.SendKeys(data);
            dashboardPage.saveButtonInExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string currentData = dashboardPage.getTextXpathOfOpportuntiesCloseDate.Text;
            Console.WriteLine(currentData);
            Assert.AreNotEqual("User is not able to edit the details as expected", previousData, currentData);  

            
        }


        //TC-48
        [Test]
        [TestCase("will", "will", "AB Drivers Limited")]
        public void filterOpportunities(string username, string password, string data)
        {
            LoginClass loginClassPageOjbects = new LoginClass(driver);
            DashboardPage dashboardPage = loginClassPageOjbects.validLogin(username, password);

            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage.opprtunitiesDropdown).Build().Perform();
            dashboardPage.viewOpportunityOption.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            dashboardPage.filterButtonInViewOpportunties.Click();

            dashboardPage.opportunityAccount.SendKeys("AB Drivers Limited");
            dashboardPage.opportunityAccountDropdown.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage.searchButtonToFilterOpportunties.Click();
            dashboardPage.searchButtonToFilterOpportunties.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            IList<IWebElement> filteredRecords = driver.FindElements(By.XPath("//a[starts-with(@href, \"#/opportunities/record\")]"));
            for (int i = 0; i < filteredRecords.Count; i++)
            {
                Console.WriteLine(filteredRecords.Count);
                Console.WriteLine(filteredRecords[i].Text);
                string[] filterRecord = filteredRecords[i].Text.Split("-");
                Console.WriteLine(filterRecord[0].Trim());
                Assert.AreEqual(filterRecord[0].Trim(), data);
            }

            //recently view record(//scrm-label[@labelkey="LBL_LAST_VIEWED"]//following::a)[1]
        }

    }
}