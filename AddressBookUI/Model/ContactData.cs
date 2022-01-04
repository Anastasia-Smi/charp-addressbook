using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUI
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones 
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else 
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim(); 
                }

            }
            set
            {
                allPhones = value;
            } 
        }
        private string CleanUp(string phone)
        {
            if (WorkPhone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace(")", "").Replace("(", "") + "\r\n";
        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllEmails { get; set; }
        public string Id { get; set; }

        /// <summary>
        /// constyructor
        /// </summary>
        /// <param name="firstName"></param>
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
          
        }

        /// <summary>
        /// checks if contact reference is the same
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName;

        }

        /// <summary>
        /// Get contact hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "firstName=" + FirstName;
        }



        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return FirstName.CompareTo(other.FirstName);
        }

    }
}


