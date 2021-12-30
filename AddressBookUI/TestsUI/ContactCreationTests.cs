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
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.FillAddContactForm(contact);
            
            app.Contact.SubmitContactCreation();

            //make sure that the new contact was created as well as the old one still exists

            //compare the quantity of contacts 
            List<ContactData> newContacts =  app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
         
        }
    }
}
