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
            contact.FirstName = "TestFirstName";
            contact.LastName = "TestLastName";
            contact.Address = $"Address{DateTime.Now:MMddyyyyhhmmss}";
            contact.HomePhone = "123456";
            contact.MobilePhone = "11111111";
            contact.Email = "test@gmail.com";
            contact.Email2 = "test2@gmail.com";
            contact.Email3 = "test3@gmail.com";
            app.Contact.FillAddContactForm(contact);
            app.Contact.SubmitContactCreation();
            app.Contact.OpenContactSummaryPage();
            app.Contact.SelectContact();
            app.Contact.ClickDeleteButton();
            app.Contact.OpenContactSummaryPage();
            app.Auth.LogOut();
            }
        }
    }


    
