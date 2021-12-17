using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUI
{
    class ContactData
    {
        private string firstName;
        private string lastName = "";
        private string address = "";
        private string homePhone = "";
        private string mobilePhone = "";
        private string workPhone = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        public ContactData(string firstName)
        {
            this.firstName = firstName;
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
            public string MobilePhone
        {
            get
            {
                return mobilePhone;
            }

            set
            {
                mobilePhone = value;
            }
        }
            public string HomePhone
        {
            get
            {
                return homePhone;
            }

            set
            {
                homePhone = value;
            }
        }
            public string WorkPhone
        {
            get
            {
                return workPhone;
            }

            set
            {
                workPhone = value;
            }
        }
            public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
            public string Email2
        {
            get
            {
                return email2;
            }

            set
            {
                email2 = value;
            }
        }
            public string Email3
        {
            get
            {
                return email3;
            }

            set
            {
                email3 = value;
            }
        }
    }
}


