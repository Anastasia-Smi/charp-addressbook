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
        public GroupHelper(ApplicationManager manager) : base(manager)
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

        public List<GroupData> GetGroupList()
        {
            //prepare an empty list, then fill it ant then return it
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            //for each element in every collection need to accomplesh the following actiont 
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
            //so, now we can read an elements and change them into groupData element....
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


            Type(By.Name("group_name"), group.GroupName);
            Type(By.Name("group_header"), group.GroupHeader);
            Type(By.Name("group_footer"), group.GroupFooter);
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
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }


        public GroupHelper CreateGroupIfNotExist(int index)
        {
            manager.Navigator.GoToGroupsPage();

            if (!IsElementPresent(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")))
            {
                Create(new GroupData("NewGroupIfNotExists"));
            }

            return this;

        }
    }
}
