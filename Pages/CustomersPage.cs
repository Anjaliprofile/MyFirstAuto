﻿using Login_Page.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Login_Page.Pages
{
    class CustomersPage
    {
        public void AddCustome(IWebDriver driver)
        {
            
            // identify Create New button 
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();
            // Populate Add Customer test data collection
            ExcelLibHelpers.PopulateInCollection(@"A:\TestCases\Login Page\Login Page\TestData\TestData.xls", "CustomerPage");
            //identify Name button
            driver.FindElement(By.XPath("//*[@id='Name']")).SendKeys(ExcelLibHelpers.ReadData(2,"Name"));
            //identify Edit Contact button
            driver.FindElement(By.XPath("//*[@id='EditContactButton']")).Click();
            //wait
            //Thread.Sleep(1000);
            // wait for the Edit Contact page to be loaded and First name, LastName textbox rendered
            Sync.WaitForVisiblitity(driver, "XPath", "//*[@id='contactDetailWindow']/iframe", 10);
            // Handle second window
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='contactDetailWindow']/iframe")));
            // identify First Name of edit contact
            driver.FindElement(By.XPath("//*[@id='FirstName']")).SendKeys(ExcelLibHelpers.ReadData(2, "FirstName"));            
            // identify Last Name botton of Edit Contact
            driver.FindElement(By.XPath("//*[@id='LastName']")).SendKeys(ExcelLibHelpers.ReadData(2, "LastName"));
            // identify the Phone botton of Edit contact
            driver.FindElement(By.XPath("//*[@id='Phone']")).SendKeys(ExcelLibHelpers.ReadData(2, "Phone"));
            //click on Save Edit contact button
            driver.FindElement(By.XPath(".//*[@id='submitButton' ][@value='Save Contact']")).Click();
            driver.SwitchTo().DefaultContent();
            // click on Save as above

            driver.FindElement(By.XPath("//*[@id='IsSameContact']")).Click();
         
            // Click on save button
            driver.FindElement(By.XPath(".//*[@id='submitButton' ]")).Click();
            // click on administration
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            // Click on Customer
           driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[1]/a")).Click();
            // wait
            // Thread.Sleep(3000);
            // wait for the Customer page to be loaded and Go to Last Page button rendered
            Sync.WaitForVisiblitity(driver, "XPath", "//*[@id='clientsGrid']/div[4]/a[4]", 10);

            // go to the last page
            driver.FindElement(By.XPath("//*[@id='clientsGrid']/div[4]/a[4]")).Click();
            // wait
            //Thread.Sleep(1000);
            // wait for the Last record of Customer page to be loaded and new record to be display
            Sync.WaitForVisiblitity(driver, "XPath", "//*[@id='clientsGrid']/div[2]/table/tbody/tr[last()]/td[2]", 10);
            // Implementation of Assertion
            Assert.That(driver.FindElement(By.XPath("//*[@id='clientsGrid']/div[2]/table/tbody/tr[last()]/td[2]")).Text, Is.EqualTo(ExcelLibHelpers.ReadData(2, "Name")));

            //// verify if Customer record is present or not
            //if (driver.FindElement(By.XPath("//*[@id='clientsGrid']/div[2]/table/tbody/tr[last()]/td[2]")).Text == "Bharati")
            //{
            //    Console.WriteLine("Customer created successfully, Test Passed");
            //}
            //else
            //{
            //    Console.WriteLine("Test Failed");
            //}
        }
        
        public void EditCustomer(IWebDriver driver)
        {
            // wait
            Thread.Sleep(2000);
            // click on Edit button
            driver.FindElement(By.XPath("//*[@id='clientsGrid']/div[2]/table/tbody/tr[last()]/td[last()]/a[1]")).Click();
            // Handle second window
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='detailWindow']/iframe")));
            // Populate Edit Customer test data collection
            ExcelLibHelpers.PopulateInCollection(@"A:\TestCases\Login Page\Login Page\TestData\TestData.xls", "CustomerPage");
            // remove record from Name button 
            driver.FindElement(By.XPath("//*[@id='Name']")).Clear();
            // Fill the value in code button
            driver.FindElement(By.XPath("//*[@id='Name']")).SendKeys(ExcelLibHelpers.ReadData(3, "Name"));
            // Click on Edit Contact
            driver.FindElement(By.XPath("//*[@id='EditContactButton']")).Click();
            Thread.Sleep(1000);
            // Handle third window
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='contactDetailWindow']/iframe")));           
            // identify First Name button of Edit Contact
            driver.FindElement(By.XPath("//*[@id='FirstName']")).SendKeys(ExcelLibHelpers.ReadData(3, "FirstName"));
            // identify Last Name botton of Edit Contact
            driver.FindElement(By.XPath("//*[@id='LastName']")).SendKeys(ExcelLibHelpers.ReadData(3, "LastName"));
            // identify the Phone botton of Edit contact
            driver.FindElement(By.XPath("//*[@id='Phone']")).SendKeys(ExcelLibHelpers.ReadData(3, "Phone"));
            // CLICK on SaveContact button
            driver.FindElement(By.XPath("//*[@id='submitButton'][@value='Save Contact']")).Click();
            // back to second window
            driver.SwitchTo().DefaultContent();
            //wait
            Thread.Sleep(1000);
            // Handle second window
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='detailWindow']/iframe")));
            // click on save button
            driver.FindElement(By.XPath("//*[@id='submitButton'][@value='Save']")).Click();
            // wait
            Thread.Sleep(1000);
            // Implementation of Assertion
            Assert.That(driver.FindElement(By.XPath("//*[@id='clientsGrid']/div[2]/table/tbody/tr[last()]/td[2]")).Text, Is.EqualTo(ExcelLibHelpers.ReadData(3, "Name")));
            //// verify if Customer editing function work or not
            //if (driver.FindElement(By.XPath("//*[@id='clientsGrid']/div[2]/table/tbody/tr[last()]/td[2]")).Text == "Industry")
            //{
            //    Console.WriteLine("Customer edited successfully, Test Passed");
            //}
            //else
            //{
            //    Console.WriteLine("Test Failed");
            //}

        }

        public void DeleteCustomer(IWebDriver driver)
        {
            // wait
            Thread.Sleep(2000);
            // click on delete button
            driver.FindElement(By.XPath("//*[@id='clientsGrid']/div[2]/table/tbody/tr[last()]/td[4]/a[2]")).Click();
            // click OK on Pop buttom
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Console.WriteLine("Deleted successfully");

        }
    }
}
