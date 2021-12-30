using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUI
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string firstName;
        public string lastName = "";
        public string address = "";
        public string homePhone = "";
        public string mobilePhone = "";
        public string workPhone = "";
        public string email = "";
        private string email2 = "";
        public string email3 = "";

        public ContactData(string firstName)
        {
            this.firstName = firstName;
        }

        public  bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return firstName == other.firstName;

        }

        public override  int GetHashCode()
        {
            return firstName.GetHashCode();
        }

        public override string ToString() 
        {
            return "firstName=" + firstName;
        }



        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return firstName.CompareTo(other.firstName);
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


