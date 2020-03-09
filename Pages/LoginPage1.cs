using Login_Page.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Page.Pages
{
    class LoginPage1
    {
        public void LoginSteps(IWebDriver driver)  
        {
            // enter the url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");
            // Maximize the browser
            driver.Manage().Window.Maximize();
            // wait for the login page to be loaded and username textbox be rendered
            Sync.WaitForVisiblitity(driver,"Id", "Username", 10);
            // Populate Login page test data collection
            ExcelLibHelpers.PopulateInCollection(@"A:\TestCases\Login Page\Login Page\TestData\TestData.xls", "LoginPage");
            // identify username and username value
            driver.FindElement(By.Id("UserName")).SendKeys(ExcelLibHelpers.ReadData(2, "Username"));
            // identify password and password
            driver.FindElement(By.Id("Password")).SendKeys(ExcelLibHelpers.ReadData(2, "Password"));
            // identify login button and click
            driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();
            // wait for the login page to be loaded and username textbox be rendered
            Sync.WaitForVisiblitity(driver, "XPath", "//*[@id='logoutForm']/ul/li/a", 5);
            // Use Exception
            try
            {
                // Apply Assertion
                Assert.That(driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a")).Text, Is.EqualTo(ExcelLibHelpers.ReadData(2, "Username")));

            }
            catch(Exception ex)
            {
                Console.WriteLine("Home page not displayed", ex.Message);
            }
                        // verify if the home page is displayed as expected
            //if (driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a")).Text == "Hello hari!")
            //{
            //    Console.WriteLine("Test Passed");
            //}
            //else
            //{
            //    Console.WriteLine("Test Failed");
            //}

        }
    }
}
