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

            app.Contact.CreateContactIfNotExists(1);
         
            ContactData newData = new ContactData("Test", "TestName");
            //newData.FirstName = "TestName";
            //newData.lastName = null;
            //newData.mobilePhone = null;
            //newData.homePhone = null;
            //newData.workPhone = null;
            //newData.address = null;
            //newData.email = null;
            //newData.Email2 = null;
            //newData.Email3 = null;

           
            List<ContactData> originalRows = app.Contact.GetContactList();
            
            //select original row
            //ContactData originalRowToTest = originalRows[1];

            app.Contact.Modify(0, newData);
            
            // old quantity of rows= quantity of rows after mofification
            Assert.AreEqual(originalRows.Count, app.Contact.GetContactsCount());
            
            // collect new data from the table 
            List<ContactData> newRows = app.Contact.GetContactList();
            
            
            originalRows[0].FirstName = newData.FirstName;
            
            //sorting rows
            originalRows.Sort();
            newRows.Sort();

            Assert.AreEqual(originalRows, newRows);

            //// each id of old cells in newrows suppose to be equal of cell id in oldrows 
            
            //foreach (ContactData contact in newRows)
            //{
            //    if (contact== newData.Id)
            //    {
            //        Assert.AreEqual(newData.FirstName, contact.FirstName);
            //    }
            //}
        }
    }
}
