using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookUI
{

    [TestFixture]
        public class ContactRemovalTests : AuthBaseTest
    {
            [Test]

            public void ContactRemovalTest()
        {
            app.Contact.SelectContact(1);
            app.Contact.ClickDeleteButton();
            app.Contact.OpenContactSummaryPage();
            app.Auth.LogOut();
        }

    
    }
    
}


    
