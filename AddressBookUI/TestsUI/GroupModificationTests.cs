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


            app.Groups.Modify(1, newData);


        }
    }
}
