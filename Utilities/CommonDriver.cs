using Login_Page.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Page.Utilities
{
    class CommonDriver
    {
        // initialize webdriver gobally
        public IWebDriver driver { set; get; }

        [OneTimeSetUp]
        public void StartUpTests()
        {
            // define driver
            driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

            // page object for Login page
            LoginPage1 loginObj = new LoginPage1();
            loginObj.LoginSteps(driver);
        }

        [OneTimeTearDown]
        public void FinishTestRun()
        {
            // close the driver
            driver.Close();

        }
    }
}
