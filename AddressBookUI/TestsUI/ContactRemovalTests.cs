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
            app.Contact.CreateContactIfNotExist(1);

            List<ContactData> oldContacts = app.Contact.GetContactList();
            
            app.Contact.SelectContact(0);
            app.Contact.ClickDeleteButton();
            app.Contact.OpenContactSummaryPage();
            
            List<ContactData> newContacts = app.Contact.GetContactList();

           
         
            
            Assert.AreEqual(oldContacts.Count -1 , app.Contact.GetContactsCount());

            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

           ContactData toBeRemoved = oldContacts[0];
           
            oldContacts.RemoveAt(0);
           
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }


    }
    
}


    
