using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Groups.Remove(1);
            app.Navigator.GoToGroupPage();
            app.Auth.LogOut();
        }
    }
}
