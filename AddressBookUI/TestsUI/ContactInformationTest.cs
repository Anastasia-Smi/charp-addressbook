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
            //method whict takes information from the Table and return information ContactData type
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            // method that takes information from the EditContact form and return information Contactdata type
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);


            //
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
        [Test]
        public void ContactDetailPageVerification()
        {
            //method that takes information from the ContactDetails page  and return information ContactData type
            ContactData fromPage = app.Contact.GetContactInformationFromContactDetailsPage(0);
            
            // method that takes information from the EditContact and return information Contactdata type
            
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            //asserts
            Assert.AreEqual(fromPage, fromForm);
            //Assert.AreEqual(fromPage.Address, fromForm.Address);
            //Assert.AreEqual(fromPage.AllPhones, fromForm.AllPhones);
            //Assert.AreEqual(fromPage.AllEmails, fromForm.AllEmails);
        }

    }
}