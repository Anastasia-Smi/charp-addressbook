using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressBookUI
{
    [TestFixture]
    public class GroupRemovalTtests : AuthBaseTest
    {
        [Test]
        public void GroupRemovalTest()
        {

            app.Navigator.GoToGroupPage();
            app.Groups.CreateGroupIfNotExist(0);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);
            app.Navigator.GoToGroupPageAfterDeletition();

            Assert.AreEqual(oldGroups.Count -1, app.Groups.GetGroupCount());
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
           
            oldGroups.RemoveAt(0);

            
            oldGroups.Sort();
            newGroups.Sort();
           
           Assert.AreEqual(oldGroups, newGroups); 
            
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
