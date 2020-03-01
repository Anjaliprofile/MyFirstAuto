using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Page.Pages
{
    class HomePage
    {
        public void NavigateToTM(IWebDriver driver)
        {
            // click on administration
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            // click on time and material
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();


        }
        public void NavigateToCustomer(IWebDriver driver)
        {
            // click on administration
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
            // Click on Customer
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[1]/a")).Click();
        }
    }
}
