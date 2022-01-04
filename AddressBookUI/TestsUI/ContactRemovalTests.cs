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
            app.Contact.CreateContactIfNotExists(1);

            List<ContactData> oldContacts = app.Contact.GetContactList();
            


            //deletion 
            app.Contact.SelectContact(0);
            app.Contact.ClickDeleteButton();
            //navigation back 
            app.Contact.OpenContactSummaryPage();  
            
            
            Assert.AreEqual(oldContacts.Count -1 , app.Contact.GetContactsCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
                     
            //new variable which stores data of the first contact in aldlist

            ContactData toBeRemoved = oldContacts[0];  
            
            //edit an oldList  
            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}


    
