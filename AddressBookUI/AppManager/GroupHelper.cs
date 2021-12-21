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
    public class GroupHelper : HelperBase
    {
           

            public GroupHelper(ApplicationManager manager) :base(manager)
            {
            }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModofication();

            return this;
        }

        public GroupHelper SubmitGroupModofication()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.GroupName);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.GroupHeader);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.GroupFooter);
            return this;
        }
        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();

            
            SelectGroup(p);
            DeleteGroup();
            return this;
        }


        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }
    }
}
