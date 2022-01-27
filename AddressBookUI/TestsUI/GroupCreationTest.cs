using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using Exel = Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;



namespace AddressBookUI

{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    GroupHeader = GenerateRandomString(100),
                    GroupFooter = GenerateRandomString(100)
                });
            }
            return groups;
        }


        public static IEnumerable<GroupData> GroupDataFromCvsFile()
        {
            return (List<GroupData>)
              new XmlSerializer(typeof(List<GroupData>))
              .Deserialize(new StreamReader(@"groups.xml"));
        }



        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                 File.ReadAllText(@"groups.json")
                 );

        }

        public static IEnumerable<GroupData> GroupDataFromExelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Exel.Application app = new Exel.Application();

            Exel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(),
                @"groups.xlsx"));
            Exel.Worksheet sheet = wb.ActiveSheet;
            Exel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    GroupName = range.Cells[i, 1].Value,
                    GroupHeader = range.Cells[i, 2].Value,
                    GroupFooter = range.Cells[i, 3].Value,
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;

        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();

            string[] lines = File.ReadAllLines(@"groups.xml");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    GroupHeader = parts[1],
                    GroupFooter = parts[2]
                });
            }

            return groups;

        }





        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreation(GroupData groups)
        {
            app.Navigator.GoToGroupsPage();
            //GroupData group = new GroupData("Family");
            //group.GroupName = "Family";
            //group.GroupHeader = "HeaderFamiy";
            //group.GroupFooter = "FooterFamily";

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(groups);


            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(groups);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }


        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));



            start = DateTime.Now;
            //using (AddressbookDB db = new AddressbookDB()) { 
            //List<GroupData> fromDb = (from g in db.groups select g).ToList();
            //}
            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }
    }
}