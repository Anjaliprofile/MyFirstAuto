using Login_Page.Pages;
using Login_Page.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Login_Page.StepDefinations
{
    [Binding]
    class TimeAndMaterialSteps : CommonDriver
    {
        [Given(@"I have logged In TurnUp portal")]
        public void GivenIHaveLoggedInTurnUpPortal()
        {
            // define driver
            driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

            // page object for Login page
            LoginPage1 loginObj = new LoginPage1();
            loginObj.LoginSteps(driver);
        }
        
        [Given(@"I navigate to Time and Material Page")]
        public void GivenINavigateToTimeAndMaterialPage()
        {
            // page object for Home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);
        }
        
        [Then(@"I should be able to create time record with valid information")]
        public void ThenIShouldBeAbleToCreateTimeRecordWithValidInformation()
        {
            // page object for TM page
            TMPage tmObj = new TMPage();

            // create new TM test case
            tmObj.AddTM(driver);
            // quit driver
            driver.Quit();
        }
        [Then(@"I should be able to edit time record with updated information")]
        public void ThenIShouldBeAbleToEditTimeRecordWithUpdatedInformation()
        {
            // page object for TM page
            TMPage tmObj = new TMPage();

            // Edit TM test case
            tmObj.EditTM(driver);
            // quit driver
            driver.Quit();
        }
        [Then(@"I should be able to Delete time record")]
        public void ThenIShouldBeAbleToDeleteTimeRecord()
        {
            // page object for TM page
            TMPage tmObj = new TMPage();

            // Delete TM test case
            tmObj.DeleteTM(driver);
            // quit driver
            driver.Quit();
        }

    }
}
