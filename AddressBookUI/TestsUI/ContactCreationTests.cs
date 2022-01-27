using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using Exel = Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;



namespace AddressBookUI
{
    [TestFixture]
    public class AddNewContactTest : AuthBaseTest
    {
        [TestFixture]
        public class ContactCreationTests : AuthBaseTest
        {
            public static IEnumerable<ContactData> RandomContactDataProvider()
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < 5; i++)
                {
                    contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                    {
                        Address = GenerateRandomString(10),
                        MobilePhone = GenerateRandomString(10),
                        Email = GenerateRandomString(10),
                    });
                }
                return contacts;
            }




            //public static IEnumerable<ContactData> ContactDataFromJsonFile()
            //{
            //    return JsonConvert.DeserializeObject<List<ContactData>>(
            //         File.ReadAllText(@"contacts.json")
            //         );

            //}


            public static IEnumerable<ContactData> ContactDataFromXmlFile()
            {
                List<ContactData> contacts = new List<ContactData>();

                string[] lines = File.ReadAllLines(@"contacts.xml");
                foreach (string l in lines)
                {
                    string[] parts = l.Split(',');
                    contacts.Add(new ContactData(parts[0], parts[1])
                    {
                        Address = parts[2],
                        MobilePhone = parts[3],
                        Email = parts[4],
                    });
                }
                return contacts;

            }





            [Test, TestCaseSource("ContactDataFromJsonFile")]
            public void AddNewContact()
            {
                List<ContactData> oldContacts = app.Contact.GetContactList();

                app.Contact.GoToAddContactPage();



                ContactData contact = new ContactData("FirstName", "LastName");
                //contact.FirstName = $"FN_{DateTime.Now:MMddyyyyhh}";
                //contact.LastName = $"LN_{DateTime.Now:MMddyyyyhh}";
                //contact.Address = $"Address{DateTime.Now:MMddyyyyhhmmss}";
                //contact.HomePhone = $"1{DateTime.Now:MMddhhmmss}";
                //contact.MobilePhone = $"2{DateTime.Now:MMddhhmmss}";
                //contact.Email = $"EEE_{DateTime.Now:MMddyyyyhhmmsstt}" + "@gmail.com";
                //contact.Email2 = $"CCC_{DateTime.Now:MMddyyyyhhmmsstt}" + "@gmail.com";
                //contact.Email3 = $"DDD_{DateTime.Now:MMddyyyyhhmmsstt}" + "@gmail.com";


                app.Contact.FillAddContactForm(contact);

                app.Contact.SubmitContactCreation();
                app.Contact.OpenContactSummaryPage();

                Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactsCount());

                List<ContactData> newContacts = app.Contact.GetContactList();

                oldContacts.Add(contact);
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts, newContacts);

            }

            [Test]
            public void TestDBConnectivity()
            {
                app.Contact.GetContactList();

                AddressbookDB db = new AddressbookDB();
                (from g in db.Groups select g).ToList();

            }
        }
    }
}
