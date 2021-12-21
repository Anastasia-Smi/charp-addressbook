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
    public class ContactHelper : HelperBase
    {
       //private IWebDriver driver;
        //private string baseURL;

        public ContactHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
               //this.driver = driver;
               //this.baseURL = baseURL;
            
        }

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit"));

            return this;
        }
        public ContactHelper FillAddContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.HomePhone);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.MobilePhone);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.WorkPhone);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);

            return this;
        }

        public ContactHelper GoToAddContactPage()
        {
            driver.FindElement(By.LinkText("add new"))
                .Click();
            return this;
        }

        public void  SelectContact()
        {
            driver.FindElement(By.Id("1")).Click();
            
        }
        public ContactHelper ClickDeleteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper OpenContactSummaryPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }

        public ContactHelper LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

    }
}
