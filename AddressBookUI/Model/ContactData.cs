using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace AddressBookUI
{ 
    [Table(Name = "addressbook") ]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
       
        public ContactData()
        { 
        
        }
        private string allPhones;
        private string allEmails;
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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
            if (phone == null || phone == "")
            {
                return "";
            }
            //return phone.Replace(" ", "").Replace("-", "").Replace(")", "").Replace("(", "") + "\r\n";
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        //public string AllEmails { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email+ "\r\n" + Email2+ "\r\n" + Email3+ "\r\n").Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        //private string CleanUp1(string email)
        //{
        //    if (email == null || email == "")
        //    {
        //        return "";
        //    }
        //    //return email.Replace(" ", "").Replace("-", "").Replace(")", "").Replace("(", "") + "\r\n";
        //    return Regex.Replace(email, "[ -()]", "") + "\r\n";
        //}
        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        public string AllData { get; set; }
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

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();

            }
        }
    }
}


