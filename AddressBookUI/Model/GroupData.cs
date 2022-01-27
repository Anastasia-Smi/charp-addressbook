using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;



namespace AddressBookUI
{ 
    [Table(Name = "group_list")]
    //we can compare with another  objects type of groupdata 
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {

        }
        [Column(Name = "group_name")]
        public string GroupName { get; set; }
        
        [Column(Name = "group_header")]
        public string GroupHeader { get; set; }

        [Column(Name = "group_footer")]
        public string GroupFooter { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return  (from g in db.Groups.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();

            }
        }

            public GroupData(string groupName)
        {
            GroupName = groupName;
        }
        // function that realises comparison
        public bool Equals(GroupData other)
        {
            //if that object that we compare with is null
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            //verification by sence 
            return GroupName == other.GroupName;
        }

        public override int GetHashCode()
            
        {
            return GroupName.GetHashCode();
        }

        public override string ToString()
        {
            return "groupName=" + GroupName + "\ngroupHeader = " + GroupHeader + "\ngroupFooter = "+ GroupFooter;

        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return GroupName.CompareTo(other.GroupName);
        
        }

        public List<ContactData> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p=> p.GroupId == Id && p. ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c ).Distinct().ToList();

            }
        }
    }
    }



