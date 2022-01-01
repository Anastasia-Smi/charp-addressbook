﻿using System;
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
        private List<ContactData> _contactCache = null;


        /// <summary>
        /// I an constructor and i need this param
        /// </summary>
        /// <param name="manager">this cool param</param>
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            _contactCache = null;
            return this;
        }

        public ContactHelper FillAddContactForm (ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
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

        /// <summary>
        /// This function returns contact list from the page
        /// </summary>
        /// <returns>returns contact list</returns>
        public List<ContactData> GetContactList()
        {

            if (_contactCache == null)
            {
                _contactCache = new List<ContactData>();

                manager.Navigator.OpenHomePage();

                //find a table
                var myTable = driver.FindElement(By.Id("maintable"));

                //get all rows
                List<IWebElement> rows = myTable.FindElements(By.TagName("tr")).ToList();

                //iterate thru each data row
                rows.ForEach(row =>
                {
                    //identify each cell and put into list
                    var cells = row.FindElements(By.TagName("td")).ToList();
                    var Id = driver.FindElement(By.TagName("input")).GetAttribute("value");

                    //go to next iteration
                    if (cells.Count == 0) return;

                    //create data hash for each row
                    _contactCache.Add(new ContactData(cells[2].Text)
                    {
                      
                        LastName = cells[1].Text,
                        Address = cells[3].Text,
                        Email = cells[4].Text,
                        HomePhone = cells[5].Text
                    }) ; 
                });
            }

            return _contactCache;
        }

        public int GetContactsCount()
        {
            return driver.FindElements(By.TagName("tr")).Count-1;
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
            _contactCache = null;
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
            _contactCache = null;
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
