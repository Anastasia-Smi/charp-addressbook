using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace AddressBookUI
{
    [TestFixture]
    public class AddNewContactTest : BaseTest
    {
        [Test]
        public void AddNewContact()
        {
            app.Contact.GoToAddContactPage();
            ContactData contact = new ContactData("FirstName");
            contact.FirstName = "TestFirstName";
            contact.LastName = "TestLastName";
            contact.Address = "TestAddress";
            contact.HomePhone = "123456";
            contact.MobilePhone = "11111111";
            contact.Email = "test@gmail.com";
            contact.Email2 = "test2@gmail.com";
            contact.Email3 = "test3@gmail.com";
            app.Contact.FillAddContactForm(contact);
            app.Contact.SubmitContactCreation();
            app.Auth.LogOut();
        }
    }
}
