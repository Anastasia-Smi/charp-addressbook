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
            var helper = new ContactHelper(app);

            helper.CreateContactIfNotExist(1);

            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.SelectContact(0);
            app.Contact.ClickDeleteButton();
            app.Contact.OpenContactSummaryPage();
            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(1);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }


    }
    
}


    
