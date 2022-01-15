using System;
using System.IO;
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


        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();

            string[] lines = File.ReadAllLines(@"groups.cvs");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                { 
                GroupHeader = parts[1],
                GroupFooter = parts[2]
                });
            }

            return groups;
        
        }



        [Test, TestCaseSource("GroupDataFromFile")]
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