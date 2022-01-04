using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace AddressBookUI
{
    [TestFixture]
    public class AddNewContactTest : AuthBaseTest
    {
        [Test]
        public void AddNewContact()
        {
            List<ContactData> oldContacts = app.Contact.GetContactList();  
            
            app.Contact.GoToAddContactPage();
            
          

            ContactData contact = new ContactData("FirstName", "LastName");
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
            app.Contact.OpenContactSummaryPage();

            Assert.AreEqual(oldContacts.Count +1, app.Contact.GetContactsCount());

            List<ContactData> newContacts =  app.Contact.GetContactList();
            
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
         
        }
    }
}
