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

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();

            return this;
        }
        public ContactHelper FillAddContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.firstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();
           // ICollection<IWebElement> elements =  driver.FindElements(By.CssSelector("input[type='checkbox' ][name='selected[]']"));

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[@id= 'maintable']/tbody/tr[*]/td[8]/a/img"));


            foreach (IWebElement element in elements)
            {
               contacts.Add(new ContactData(element.Text));
            }
            return contacts;
        }

        public ContactHelper GoToAddContactPage()
        {
            driver.FindElement(By.LinkText("add new"))
                .Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form//td["+ (index + 1) +"]/input")).Click();
            return this;
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

        public ContactHelper LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.OpenHomePage();
            SelectEditContact(p);
            FillAddContactForm(newData);
            SubmitEditedConatct();
            OpenContactSummaryPage();
            return this;
        }
        public ContactHelper SelectEditContact(int index)
        {
            //if (IsElementPresent(By.Name("update"))
            // && IsElementPresent(By.XPath("//div[@id='content']/h1[.='Edit / add address book entry']")))
            //{
            // return;
            // }
            //driver.FindElement(By.XPath("//*[@id= 'maintable']/tbody/tr[" + (index + 1) + "]/td[8]/a/img")).Click();
            driver.FindElement(By.XPath("//*[@id= 'maintable']/tbody/tr[*]/td[8]/a/img")).Click();
       
            return this;

        }

        public ContactHelper EditEmail(ContactData contact)
            {
                driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
                Type(By.Name("email"), contact.Email);
                return this;
            }
        

           public ContactHelper SubmitEditedConatct()
           {
            driver.FindElement(By.Name("update")).Click();
            return this;
           }

           public ContactHelper EditEmail3(ContactData contact)
           {
            driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
            Type(By.Name("email3"), contact.Email3);
            return this;
           }

           public ContactHelper EditEmail2(ContactData contact)
           {
            driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
            Type(By.Name("email2"), contact.Email2);
            return this;
           }

           public ContactHelper EditMobileTelephone(ContactData contact)
           {
            driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
           Type(By.Name("mobile"), contact.MobilePhone);
            return this;
            }

           public ContactHelper EditHomeTelephone(ContactData contact)
           {
            driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
            Type(By.Name("home"), contact.HomePhone);
           return this;
           }

           public ContactHelper EditAddress(ContactData contact)
           {
            driver.FindElement(By.XPath("//form[@action='edit.php']")).Click();
            Type(By.Name("address"), contact.Address);
            return this;
           }

            public ContactHelper EditLastName(ContactData contact)
            {
            driver.FindElement(By.Name("lastname")).Click();
            Type(By.Name("lastname"), contact.LastName);
            return this;
            }

            public ContactHelper EditFirstName(ContactData contact)
            {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), contact.FirstName);
            return this;
            }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.OpenHomePage();


            SelectContact(p);
            ClickDeleteButton();
            return this;
        }
        public ContactHelper CreateContactIfNotExist(int index)
        {
            manager.Navigator.OpenHomePage();

            if (!IsElementPresent(By.XPath("//*[@id= 'maintable']/tbody/tr[" + (index + 1) + "]/td[8]/a/img")))
            {
                FillAddContactForm(new ContactData("NewContactIfNotExist"));
            }

            return this;

        }
    }
}
