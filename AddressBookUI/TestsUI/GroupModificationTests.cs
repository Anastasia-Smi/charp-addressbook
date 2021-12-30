using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookUI
{
    [TestFixture]
    public class GroupModificationTests : AuthBaseTest
    {
        [Test]

 
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzzz");
        
            newData.GroupName = "ttt";
            newData.GroupHeader = null;
            newData.GroupFooter = null;
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            var helper = new GroupHelper(app);
           
            helper.CreateGroupIfNotExist(1);


            app.Groups.Modify(0, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].GroupName = newData.GroupName;
           
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
