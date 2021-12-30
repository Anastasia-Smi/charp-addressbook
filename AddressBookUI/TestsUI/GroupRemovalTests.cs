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
            var helper = new GroupHelper(app);
            helper.CreateGroupIfNotExist(1);

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
