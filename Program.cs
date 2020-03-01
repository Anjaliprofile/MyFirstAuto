using Login_Page.Pages;
using Login_Page.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Login_Page
{
    class Program
    {
        static void Main(string[] args)
        {
            //// define driver
            //CommonDriver.driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");
            //// page object for Login page
            //LoginPage1 loginObj = new LoginPage1();
            //loginObj.LoginSteps(CommonDriver.driver);
            //// page object for Home page
            //HomePage homeObj = new HomePage();
            //homeObj.NavigateToTM(CommonDriver.driver);
            //// page object for TM page
            //TMPage tmObj = new TMPage();
            //// create new TM test case
            //tmObj.AddTM(CommonDriver.driver);
            //// Edti TM test acse
            // tmObj.EditTM(CommonDriver.driver);
            //// Delete TM test case
            //tmObj.DeleteTM(CommonDriver.driver);

            //// create object for CustomerPage
            //CustomersPage custObj = new CustomersPage();
            //// create new customer test
            //custObj.AddCustome();

            //// Edit customer test
            //custObj.EditCustomer();

            ////Delete customer test
            //custObj.DeleteCustomer();

        }
    }

    [TestFixture, Description("Time And Material Test Cases")]
    class TimeandMaterialTestSuit : CommonDriver
    {
        [SetUp]
        public void StartUpTests()
        {
            // define driver
            driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

            // page object for Login page
            LoginPage1 loginObj = new LoginPage1();
            loginObj.LoginSteps(driver);
        }

        [Test, Description("Check if user is able to Add TM with valid data")]
        public void AddNewTMTest()
        {
            // page object for Home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            // page object for TM page
            TMPage tmObj = new TMPage();

            // create new TM test case
            tmObj.AddTM(driver);
        }

        [Test, Description("Check if user is able to Edit TM with valid data")]
        public void EditTMTest()
        {
            // page object for home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            // page object for TM page
            TMPage tmObj = new TMPage();

            // Edit TM test case
            tmObj.EditTM(driver);
        }

        [Test, Description("Check if user is able to delete record")]
        public void DeleteTMTest()
        {
            // page object for Home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            // page object for TM page
            TMPage tmObj = new TMPage();

            // Delete TM test case
            tmObj.DeleteTM(driver);
        }

        [TearDown]
        public void FinishTestRun()
        {
            // close the driver
            driver.Close();

        }
    }

    [TestFixture, Description("Customer Test cases")]
    class CustomerTestSuit : CommonDriver
        {
        [SetUp]
        public void StartUpTests()
        {
            // define driver
            driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

            // page object for Login page
            LoginPage1 loginObj = new LoginPage1();
            loginObj.LoginSteps(driver);
     }

        [Test, Description("Check if user is able to Add Customer with valid data")]
        public void AddNewCustonerTest()
        {

            // page object for Home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCustomer(driver);
          // create object for CustomerPage
            CustomersPage custObj = new CustomersPage();
            // create new customer test
            custObj.AddCustome(driver);
       
        }

        [Test, Description("Check if user is able to Edit Customer with valid data")]
        public void EditCustonerTest()
        {
            // page object for Home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCustomer(driver);
            // create object for CustomerPage
            CustomersPage custObj = new CustomersPage();
         // Edit customer test
            custObj.EditCustomer(driver);
        
        }

        [Test, Description("Check if user is able to Delete customer record")]
        public void DeleteCustonerTest()
        {
            // page object for Home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToCustomer(driver);
            // create object for CustomerPage
            CustomersPage custObj = new CustomersPage();
           //Delete customer test
            custObj.DeleteCustomer(driver);
        }

        [TearDown]
        public void FinishTestRun()
        {
            //close the driver
            driver.Close();
        }
    }
}
