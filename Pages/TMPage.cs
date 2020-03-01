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
            //identify code button
            driver.FindElement(By.Id("Code")).SendKeys("Perfect");
            //identify description button
            driver.FindElement(By.Id("Description")).SendKeys("123456");
            //click on Save button
            driver.FindElement(By.Id("SaveButton")).Click();
            // wait
            Thread.Sleep(1000);
            // go to the last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

            // verify if T&M present record is presen or not
            if (driver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text == "Perfect")
            {
                Console.WriteLine("TM created successfully, Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }
     
        }

        public void EditTM(IWebDriver driver)
        {
            // wait 
            Thread.Sleep(1000);
            // click on edit button 
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();
            // remove record from code button 
            driver.FindElement(By.XPath("//*[@id='Code']")).Clear();
            // Fill the value in code button
            driver.FindElement(By.XPath("//*[@id='Code']")).SendKeys("Industry");
            // remove record from description box
            driver.FindElement(By.XPath("//*[@id='Description']")).Clear();
            // identify description button
            driver.FindElement(By.XPath("//*[@id='Description']")).SendKeys("test pass");
            // click on save button
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();
            // Wait
            Thread.Sleep(1000);
            // verify if T&M editing is success
            if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text == "Industry")
            {
                Console.WriteLine("T&M edited successfully, Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }
        }

        public void DeleteTM(IWebDriver driver)
        {
            //wait
            Thread.Sleep(1000);
            // click on delete button
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]")).Click();
           // click OK on Pop buttom
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Console.WriteLine("Deleted Successfully");
            // Wait
            Thread.Sleep(1000);
            // Check delete function is work or not
            if(driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text == "20101")
            {
                Console.WriteLine("record is not found");
            }
             else
            {
                Console.WriteLine("Test failed");
            }
        }
    }
}
