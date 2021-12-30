using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookUI { 

[TestFixture]

public class ContactMificationTests : AuthBaseTest
{
    [Test]

    public void ContactModificationTest()

        {

            var helper = new ContactHelper(app);
            helper.CreateContactIfNotExist(1);
            
            ContactData newData = new ContactData("Test_Name");
            newData.firstName = "TestName";
            newData.lastName = null;
            newData.mobilePhone = null;
            newData.homePhone = null;
            newData.workPhone = null;
            newData.address = null;
            newData.email = null;
            newData.Email2 = null;
            newData.Email3 = null;
           
            List<ContactData> oldContacts = app.Contact.GetContactList();  
            
           
            app.Contact.Modify(0, newData);

            List<ContactData> newContacts = app.Contact.GetContactList();
            
            oldContacts[0].firstName = newData.firstName;
            
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
