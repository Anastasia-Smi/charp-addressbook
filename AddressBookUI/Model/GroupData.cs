using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBookUI
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string groupName;
        private string groupHeader = "";
        private string groupFooter = "";

        public GroupData(string groupName)
        {
            this.groupName = groupName;
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
            return groupName == other.groupName;
        }

        public override int GetHashCode()
            
        {
            return groupName.GetHashCode();
        
        }

        public override string ToString()
        {
            return "groupName=" + groupName;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return groupName.CompareTo(other.groupName);
        
        }
        public string GroupName
        {
            get
            {
                return groupName;
            }

            set
            {
                groupName = value;
            }
        }
        public string GroupHeader
        {
            get
            {
                return groupHeader;
            }

            set
            {
                groupHeader = value;
            }
        }
              public string GroupFooter
              {
            get
              {
                return groupFooter;
              }

            set
              {
                groupFooter = value;
              }
        }
    }
}

