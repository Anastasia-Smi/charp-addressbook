using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookUI.TestsUI
{

    [TestFixture]
    public class ContactInformationTests : AuthBaseTest
    {
        [Test]
        public void ContactInformationTest()
        {
            //method whict takes information from table and return information ContactData type
           ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            // method that takes information from editcontact form and return information Contactdata type
           ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);


            //
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            //Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
    }
}