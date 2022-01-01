using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBookUI
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
       

        public GroupData(string groupName)
        {
            GroupName = groupName;
        }
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
            return "groupName=" + GroupName;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return GroupName.CompareTo(other.GroupName);
        
        }
        public string GroupName { get; set;  }
        
        public string GroupHeader { get; set; }
       
        public string GroupFooter { get; set; }

        public string Id { get; set; }

    }
    }



