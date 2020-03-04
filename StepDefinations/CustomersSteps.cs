using Login_Page.Pages;
using Login_Page.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Login_Page.StepDefinations
{
    [Binding]
     class CustomersSteps : CommonDriver
    {
        [Given(@"I log In to TurnUp portal")]
        public void GivenILogInToTurnUpPortal()
        {
            // define driver
            driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

            // page object for Login page
            LoginPage1 loginObj = new LoginPage1();
            loginObj.LoginSteps(driver);
        }
        
        [Given(@"I navigate to Customer Page")]
        public void GivenINavigateToCustomerPage()
        {
            // page object for Home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCustomer(driver);
        }
        
        [Then(@"I should be able to create Customer record with valid information")]
        public void ThenIShouldBeAbleToCreateCustomerRecordWithValidInformation()
        {
            // create object for CustomerPage
            CustomersPage custObj = new CustomersPage();
            // create new customer test
            custObj.AddCustome(driver);
            // quit driver
            driver.Quit();
        }
        
        [Then(@"I should be able to edit Customer record with updated information")]
        public void ThenIShouldBeAbleToEditCustomerRecordWithUpdatedInformation()
        {
            // create object for CustomerPage
            CustomersPage custObj = new CustomersPage();
            // Edit customer test
            custObj.EditCustomer(driver);
            // quit driver
            driver.Quit();
        }
        [Then(@"I should be able to Delete Customer record")]
        public void ThenIShouldBeAbleToDeleteCustomerRecord()
        {
            // create object for CustomerPage
            CustomersPage custObj = new CustomersPage();
            //Delete customer test
            custObj.DeleteCustomer(driver);
            // quit driver
            driver.Quit();
        }


    }
}
