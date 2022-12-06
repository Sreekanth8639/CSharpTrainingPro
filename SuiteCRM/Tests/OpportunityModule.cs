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
    public class OpTests : BaseClass
    {

        
        //TC-43
        [Test]
        [TestCase("Demo1")]
        public void createOpportunity( string oppName)
        {
           

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            DashboardPage dashboardPage1 = new DashboardPage(driver);

            Thread.Sleep(TimeSpan.FromSeconds(5));
                Actions action = new Actions(driver);
                action.MoveToElement(dashboardPage1.opprtunitiesDropdown).Build().Perform();
                dashboardPage1.createOpprtunityOption.Click();
                dashboardPage1.opportunityName.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage1.opportunityName.SendKeys(oppName);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage1.opportunityAmount.SendKeys("$50");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage1.opportunitySalesStage.SendKeys("Qualification");
                dashboardPage1.opportunitySalesStageDropdown.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage1.opportunityAccount.SendKeys("AB Drivers Limited");
                dashboardPage1.opportunityAccountDropdown.Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
                dashboardPage1.opportunityCloseDate.SendKeys("2022-12-30");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                dashboardPage1.createOpportunitySaveButton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
                String opporPageName = dashboardPage1.createdOpportunityPageName.Text;
                Console.WriteLine(opporPageName);
                Assert.AreEqual("Opportunity is not created as expected", oppName, opporPageName);           

        }

        //TC-49
        [Test]
       
        public void bulkActionDropdownOptions()
        {
            
            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            DashboardPage dashboardPage1 = new DashboardPage(driver);

            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage1.opprtunitiesDropdown).Build().Perform();
            dashboardPage1.viewOpportunityOption.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage1.viewOpportunityCheckbox.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage1.bulkActionButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            IList<IWebElement> bulkDropdown = dashboardPage1.bulkActionDropdownElements;
                string[] elements = { "Delete", "Export", "Merge", "Mass Update" };

                for (int j = 0; j < elements.Length; j++)
                {
                    Assert.AreEqual(elements[j], bulkDropdown[j].Text);
                }
            
        }


        
        //TC_42
        [Test]
        
        public void opportunitiesDropdownOptions()
        {
           

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            DashboardPage dashboardPage1 = new DashboardPage(driver);
           

            Thread.Sleep(TimeSpan.FromSeconds(5));
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage1.opprtunitiesDropdown).Build().Perform();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Assert.IsTrue(dashboardPage1.createOpprtunityOption.Displayed);
            Assert.IsTrue(dashboardPage1.viewOpportunityOption.Displayed);
            Assert.IsTrue(dashboardPage1.importOpportuntiesOption.Displayed);
        }

        //TC-46

        [Test]
        
        public void deleteOpportunities()
        {
           

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            DashboardPage dashboardPage1 = new DashboardPage(driver);

            Thread.Sleep(TimeSpan.FromSeconds(5));
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage1.opprtunitiesDropdown).Build().Perform();
            dashboardPage1.viewOpportunityOption.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage1.recordInViewOpportunties.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage1.actionsDropdownInExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            dashboardPage1.deleteInActionsDropdownInExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            dashboardPage1.proceedToDeleteExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            string alert = dashboardPage1.deletionAlertText.Text;
            Console.WriteLine(alert.Trim());
            Assert.AreEqual("Record deleted successfully\r\n×", alert.Trim());
        }

        //TC-44
        [Test]
        [TestCase( "2022-12-30")]
        public void editOpportunities( string data)
        {
            

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            DashboardPage dashboardPage1 = new DashboardPage(driver);

            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage1.opprtunitiesDropdown).Build().Perform();
            dashboardPage1.viewOpportunityOption.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage1.recordInViewOpportunties.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            string previousData = dashboardPage1.getTextXpathOfOpportuntiesCloseDate.Text;
            
            Console.WriteLine(previousData);
            dashboardPage1.editButtonInExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            dashboardPage1.opportunityCloseDate.Clear();
            dashboardPage1.opportunityCloseDate.SendKeys(data);
            dashboardPage1.saveButtonInExistingOpportunty.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string currentData = dashboardPage1.getTextXpathOfOpportuntiesCloseDate.Text;
            Console.WriteLine(currentData);
            Assert.AreNotEqual("User is not able to edit the details as expected", previousData, currentData);  

            
        }


        //TC-48
        [Test]
        [TestCase("AB Drivers Limited")]
        public void filterOpportunities( string data)
        {
          

            LoginClass login = new LoginClass(driver);
            login.validLogin("will", "will");
            DashboardPage dashboardPage1 = new DashboardPage(driver);

            Thread.Sleep(TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions action = new Actions(driver);
            action.MoveToElement(dashboardPage1.opprtunitiesDropdown).Build().Perform();
            dashboardPage1.viewOpportunityOption.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            dashboardPage1.filterButtonInViewOpportunties.Click();

            dashboardPage1.opportunityAccount.SendKeys("AB Drivers Limited");
            dashboardPage1.opportunityAccountDropdown.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            dashboardPage1.searchButtonToFilterOpportunties.Click();
            dashboardPage1.searchButtonToFilterOpportunties.Click();
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

           
        }

    }
}