using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookUI
{

    [TestFixture]
        public class ContactRemovalTests : BaseTest
    {
            [Test]

            public void ContactRemovalTest()
        {
            app.Contact.GoToAddContactPage();
            ContactData contact = new ContactData("FirstName");
            contact.FirstName = $"FN_{DateTime.Now:MMddyyyyhh}";
            contact.LastName = $"LN_{DateTime.Now:MMddyyyyhh}";
            contact.Address = $"Address{DateTime.Now:MMddyyyyhhmmss}";
            contact.HomePhone = $"1{DateTime.Now:MMddhhmmss}";
            contact.MobilePhone = $"2{DateTime.Now:MMddhhmmss}";
            contact.Email = $"EEE_{DateTime.Now:MMddyyyyhhmmsstt}" + "@gmail.com";
            contact.Email2 = $"CCC_{DateTime.Now:MMddyyyyhhmmsstt}" + "@gmail.com";
            contact.Email3 = $"DDD_{DateTime.Now:MMddyyyyhhmmsstt}" + "@gmail.com";
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


    
