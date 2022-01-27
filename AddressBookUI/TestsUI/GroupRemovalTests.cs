﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressBookUI
{
    [TestFixture]
    public class GroupRemovalTtests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            app.Navigator.GoToGroupPage();
            app.Groups.CreateGroupIfNotExist(0);


            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);
            app.Navigator.GoToGroupPageAfterDeletition();

            Assert.AreEqual(oldGroups.Count -1, app.Groups.GetGroupCount());
            
            List<GroupData> newGroups = GroupData.GetAll(); 
         
           
            oldGroups.RemoveAt(0);

           
           Assert.AreEqual(oldGroups, newGroups); 
            
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
