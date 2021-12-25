using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            app.Contact.FillAddContactForm(contact);
            app.Contact.SubmitContactCreation();
            app.Auth.LogOut();
        }
    }
}
