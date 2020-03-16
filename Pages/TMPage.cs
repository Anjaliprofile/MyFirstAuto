using Login_Page.Utilities;
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
    class TMPage
    {
        public void AddTM(IWebDriver driver)
        {
            // identify Create New button 
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();
            
            // Populate Create TM test data collection
            ExcelLibHelpers.PopulateInCollection(@"A:\TestCases\Login Page\Login Page\TestData\TestData.xls", "TMPage");
            //identify code button
            driver.FindElement(By.Id("Code")).SendKeys(ExcelLibHelpers.ReadData(2,"Code"));
            //identify description button
            driver.FindElement(By.Id("Description")).SendKeys(ExcelLibHelpers.ReadData(2,"Description"));
            //click on Save button
            driver.FindElement(By.Id("SaveButton")).Click();
            // wait
            // Thread.Sleep(1000);
            // wait for the TM page to be loaded and Go to last page button rendered
             Sync.WaitForVisiblitity(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 10);
            // go to the last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();
            // wait for the TM page to be loaded and Go to last page button rendered
            Sync.WaitForVisiblitity(driver, "XPath", ".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);
            // Implementation of Assertion
            Assert.That(driver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text, Is.EqualTo(ExcelLibHelpers.ReadData(2, "Code")));

            //// verify if T&M present record is presen or not
            //if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text == "Perfect")
            //{
            //    Console.WriteLine("TM created successfully, Test Passed");
            //}
            //else
            //{
            //    Console.WriteLine("Test Failed");
            //}
     
        }

        public void EditTM(IWebDriver driver)
        {
            // wait 
            //Thread.Sleep(1000);
            // wait for the TM page to be loaded and Edit button rendered
            Sync.WaitForVisiblitity(driver, "XPath", ".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 10);

            // click on edit button 
            driver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();
            // remove record from code button 
            driver.FindElement(By.XPath("//*[@id='Code']")).Clear();
            // Populate Edit TM test data collection
            ExcelLibHelpers.PopulateInCollection(@"A:\TestCases\Login Page\Login Page\TestData\TestData.xls", "TMPage");
            // Fill the value in code button
            driver.FindElement(By.XPath("//*[@id='Code']")).SendKeys(ExcelLibHelpers.ReadData(3, "Code"));
            // remove record from description box
            driver.FindElement(By.XPath("//*[@id='Description']")).Clear();
            // identify description button
            driver.FindElement(By.XPath("//*[@id='Description']")).SendKeys(ExcelLibHelpers.ReadData(3, "Description"));
            // click on save button
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
            // Wait
            //Thread.Sleep(2000);
            // wait for the TM page to be loaded and Edited Code textbox button rendered
            Sync.WaitForVisiblitity(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 10);
            // Implementation of Assertion
            Assert.That(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text, Is.EqualTo(ExcelLibHelpers.ReadData(3, "Code")));
            // verify if T&M editing is success
            //if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text == "Industry1")
            //{
            //    Console.WriteLine("T&M edited successfully, Test Passed");
            //}
            //else
            //{
            //    Console.WriteLine("Test Failed");
            //}
        }

        public void DeleteTM(IWebDriver driver)
        {
            //wait
            //Thread.Sleep(1000);
           // wait for the TM page to be loaded and Delete button rendered
            Sync.WaitForVisiblitity(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 10);
           //count record before deletion
            string countBeforeDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/span[2]")).Text.Remove(0, 9);
            Console.WriteLine(countBeforeDelete);
            string numberBefore = countBeforeDelete.Remove(countBeforeDelete.Length - 5);
            Console.WriteLine(numberBefore);
            // click on delete button
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]")).Click();
           // click OK on Pop buttom
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Console.WriteLine("Deleted Sucessfully");
            // Refresh page after delete
            driver.Navigate().Refresh();
            // wait for check deleted record
            Thread.Sleep(1000);
           
            //count record After deletion
            string countAfterDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/span[2]")).Text.Remove(0, 9);
            Console.WriteLine(countAfterDelete);
            string numberAfter = countAfterDelete.Remove(countAfterDelete.Length - 5);
            Console.WriteLine(numberAfter);
            // use assertion
            // Assert.That(numberBefore!=numberAfter);
            Assert.AreNotEqual(numberBefore, numberAfter);
            Console.WriteLine("deleted sucessfully");
            //if(numberBefore == numberAfter)
            //{
            //    Console.WriteLine("Record is not deleted");
            //}
            //else
            //{
            //    Console.WriteLine("Record is successfully deleted");
            //}
            // Wait
            //Thread.Sleep(1000);
            //// Check delete function is work or not
            //if(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text == "20101")
            //{
            //    Console.WriteLine("record is not found, Test Passed");
            //}
            // else
            //{
            //    Console.WriteLine("Test failed");
            //}
        }
    }
}
