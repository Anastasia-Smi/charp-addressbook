using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookUI
{
    public class AddingRemovingContactToGroupTests : AuthBaseTest
    {
        [Test]
        public void AddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();


            //actions
            app.Contact.AddContactToGroup(contact, group);



            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }


        [Test]
        public void RemovingContactFromGroup()
        {
            // add a contact to a group
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            app.Contact.AddContactToGroup(contact, group);

            //actions 
            app.Contact.RemoveFromGroup(contact, group);


            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }


    }
}
