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

            manager.Navigator.GoToGroupPage();

            return this;
        }

        //public  void Remove(GroupData toBeRemoved)
        //{
        //    throw new NotImplementedException();
        //}

        private List<GroupData> groupCache = null;


        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length; 
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].GroupName = "";
                    }
                    else 
                    { 
                    groupCache[i].GroupName = parts[i-shift].Trim();
                    }                }
            }
            return new List<GroupData>(groupCache);
    }


    public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();

            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModofication();
           
            manager.Navigator.GoToGroupPage();

            return this;
        }

        public  int GetGroupCount()
        {
           return  driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper SubmitGroupModofication()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            // cleaning cash
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            //cleaning cashe
            return this;
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

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
            DeleteGroup();
            return this;
        }


        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value= '"+id+"'])")).Click();
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
