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
            app.Contact.GoToAddContactPage();
            ContactData contact = new ContactData("FirstName");
            app.Contact.FillAddContactForm(contact);
           
            app.Contact.SubmitContactCreation();
            app.Navigator.Wait();
 
            app.Contact.OpenContactSummaryPage();
            app.Contact.SelectContact();
            app.Contact.ClickDeleteButton();
            app.Contact.OpenContactSummaryPage();
            app.Auth.LogOut();
        }

    
    }
    
}


    
