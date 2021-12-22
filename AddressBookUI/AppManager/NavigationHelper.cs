using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBookUI
{
    public class NavigationHelper : HelperBase


        
    {
        public  IWebDriver Driver;
        private string baseURL;
  

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.Driver = driver;
            this.baseURL = baseURL;
        }

        public NavigationHelper Wait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return this;
        }
        public NavigationHelper OpenHomePage()
            
        {
            driver.Navigate().GoToUrl(baseURL);
            return this;
        
        }

        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public NavigationHelper GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
    }
}
