using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AddressBookUI;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);

            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(BaseTest.GenerateRandomString(10))
                {
                    GroupHeader = BaseTest.GenerateRandomString(100),
                    GroupFooter = BaseTest.GenerateRandomString(100),
                });
            }
            if (format == "csv")
            {
                writeGroupsToCvsFile(groups, writer);
            }
            else if (format == "xml")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
        }


        static void writeGroupsToCvsFile(List<GroupData> groups, StreamWriter writer)

        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2},",
                    group.GroupName, group.GroupHeader, group.GroupFooter));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
    }
}
