﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Groups.Create(group);
            app.Auth.LogOut();
        }
        [Test ]
        public void GroupCreationEmptyFields()
        {
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("");
            group.GroupName = "";
            group.GroupHeader = "";
            group.GroupFooter = "";
            app.Groups.Create(group);
            app.Auth.LogOut();
        }
    }
}