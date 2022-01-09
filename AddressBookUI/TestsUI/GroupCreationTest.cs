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
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    GroupHeader = GenerateRandomString(100),
                    GroupFooter = GenerateRandomString(100)
                });
            }
                return groups;
        }

      

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreation(GroupData groups)
        {
            app.Navigator.GoToGroupsPage();
            //GroupData group = new GroupData("Family");
            //group.GroupName = "Family";
            //group.GroupHeader = "HeaderFamiy";
            //group.GroupFooter = "FooterFamily";
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(groups);

           
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(groups);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
          
        }
       
    }
}