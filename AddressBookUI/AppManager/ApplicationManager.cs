using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressBookUI
{
    public class ApplicationManager
    {
        
    
     
        protected IWebDriver driver;
        //private StringBuilder varificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
      

        public ApplicationManager()

        {
            //inicialise code
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
          
            navigationHelper = new NavigationHelper(this, baseURL);
            loginHelper = new LoginHelper(this); 
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
     
        }
        public IWebDriver Driver 
        {
            get 
            {
                return driver;
            }
        }
        public LoginHelper Auth
        {
            get 
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
           
        }
    }
}
