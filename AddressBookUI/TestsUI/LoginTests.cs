using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookUI.TestsUI
{  
    [TestFixture]
    public class LoginTests: BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //preparing
            app.Auth.LogOut();
            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            //preparing
            app.Auth.LogOut();
            //action
            AccountData account = new AccountData("admin", "WRONG");
            app.Auth.Login(account);
            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }


    }
}
