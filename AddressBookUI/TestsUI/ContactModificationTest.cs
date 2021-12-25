using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookUI { 

[TestFixture]

public class ContactMificationTests : AuthBaseTest
{
    [Test]

    public void ContactModificationTest()

    {
            ContactData newData = new ContactData("aaaa");
            newData.firstName = "aaaa";
            newData.lastName = "bbb";
            newData.mobilePhone = "123456";
            newData.homePhone = "4564789";
            newData.workPhone = "4587946";
            newData.address = "kkk";
            newData.email = "kjlpp@gamil.com";
            newData.Email2 = "oouygjs@gmail.com";
            newData.Email3 = "hjjoo@gmail.com";

            app.Contact.Modify(newData);
            app.Auth.LogOut();
    }


}

}
