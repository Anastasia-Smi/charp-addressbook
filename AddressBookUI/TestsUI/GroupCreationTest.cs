using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace AddressBookUI

{
    [TestFixture]
    public class GroupCreationTests : AuthBaseTest
    {
        [Test]
        public void GroupCreation()
        {
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("Family");
            group.GroupName = "Family";
            group.GroupHeader = "HeaderFamiy";
            group.GroupFooter = "FooterFamily";
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
          
        }
        [Test ]
        public void GroupCreationEmptyFields()
        {
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("");
            group.GroupName = "";
            group.GroupHeader = "";
            group.GroupFooter = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}